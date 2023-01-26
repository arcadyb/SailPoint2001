using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailPoint.Models
{
    public class AutoCompleteList
    {
        public List<City> ListItems { set; get; }
        public AutoCompleteList()
        {
            ListItems = new List<City>();
  
        }
    }
}
