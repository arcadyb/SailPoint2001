using System.Collections.Generic;

namespace SailPoint.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        long? CityId { get; set; }
    }
}