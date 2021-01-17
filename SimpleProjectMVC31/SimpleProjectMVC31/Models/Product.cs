using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Models
{
    public class Product
    {public CultureInfo currency = new CultureInfo("en-US", false);
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slug => Name.Replace(' ', '-');
    }
}
