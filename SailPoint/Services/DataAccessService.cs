using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SailPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailPoint.Services
{
    
    public class DataAccessService : IDataAccessService
    {
        private readonly ILogger<DataAccessService> _logger;
        private IMemoryCache _cache;

        public DataAccessService(
            ILogger<DataAccessService> logger ,
            IMemoryCache memoryCache
        )
        {
            _logger = logger;
            _cache = memoryCache;

        }
        public async Task<AutoCompleteList> GetCities(string searchStr)
        {
            var acList = new AutoCompleteList();
            
            try
            {
                var tryFromCache = await GetFromCache(searchStr);
                if (!string.IsNullOrEmpty(searchStr) && tryFromCache != null)
                {
                    return tryFromCache;
                }
                using (var db = new SPDBContext())
                {
                    if (string.IsNullOrEmpty(searchStr))
                    {

                        acList.ListItems = await db.Cities.OrderBy(x => x.Name).Take(100).ToListAsync();

                    }
                    else
                    {
                        //this is work around for EF bug
                        //https://stackoverflow.com/questions/60412799/ef-core-3-1-throws-an-exception-for-contains
                        var all = await db.Cities.OrderBy(x => x.Name).ToListAsync();
                        acList.ListItems = all.Where(x => x.Name.Contains(searchStr ?? "", StringComparison.CurrentCultureIgnoreCase)).OrderBy(x => x.Name).Take(20).ToList();
                        //acList.ListItems = await db.Cities.Where(x => x.Name.Contains(searchStr ?? "", StringComparison.CurrentCultureIgnoreCase)).OrderBy(x => x.Name).Take(100).ToListAsync();
                        SaveToCache(searchStr, acList);
                    }
                    
                    return acList;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<AutoCompleteList> GetFromCache(string searchKey)
        {
            
            
            AutoCompleteList listCities = new AutoCompleteList();
            if (!string.IsNullOrEmpty(searchKey))
            {
                // Look for cache key.
                if (!_cache.TryGetValue(searchKey, out listCities))
                {
                    return null;
                }
            }
            return listCities;
        }
        private void SaveToCache(string sKey, AutoCompleteList listRes)
        {
            DateTime cacheEntry = DateTime.Now;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(1));
            // Save data in cache.
            _cache.Set(sKey, listRes, cacheEntryOptions);
        }
    }
}
