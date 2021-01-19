using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Models
{
    public class Product
    {
        public CultureInfo currency = new CultureInfo("en-US", false);
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter the product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the product price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Please select the category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal DiscountPercent => .20M;
        public decimal DiscountAmount => Price * DiscountPercent;
        public decimal DiscountPrice => Price - DiscountAmount;
        [Required(ErrorMessage ="Please enter the product code")]
        public string Code { get; set; }
        public string Slug => Name == null ? "" : Name.Replace(' ', '-');
    }
}
