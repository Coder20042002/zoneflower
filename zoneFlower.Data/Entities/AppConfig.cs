using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data.Enums;

namespace zoneFlower.Data.Entities
{
    public class AppConfig
    {
        
        public string Key { get; set; }
        
        public string Value { get; set; }
    }
}
