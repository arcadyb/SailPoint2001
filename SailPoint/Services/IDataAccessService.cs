using SailPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailPoint.Services
{
    public interface IDataAccessService
    {
        Task<AutoCompleteList> GetCities(string searchStr);
        Task<AutoCompleteList> GetFromCache(string searchKey);
    }
}
