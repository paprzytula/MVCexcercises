using System.Collections.Generic;

namespace SimpleProjectMVC31.Models
{
    public class DataBase
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
{
new Product
{
Id=1,
Name= "Nice dress",
Price= 2.25m
},
new Product
{
Id=2,
Name="Laptop Tohiba",
Price=1759.00m
},
new Product
{
Id=3,
Name="To wszystko",
},
new Product
{
Id=4,
Name="Multi dimmensional water",
Price= 5999.00m },
new Product
{
Id=5,
Name="Rape pills forte ultra max",
Price= 7.99m },
new Product
{
Id=6,
Name="Toilet paper in Australia",
Price= (decimal)1700.00 },
new Product
{
Id=7,
Name="Master degree on WSB",
Price= 3000.00m },
new Product
{
Id=8,
Name="Bread with chokolade",
Price= 5.95m },
new Product
{
Id=9,
Name="1 night at covid chamber",
Price= 6.99m },
new Product
{
Id=10,
Name="Some real thoughts",
Price= 999999.99m },
};
            return products;
        }
        public static Product GetProduct(string slug)
        {
            List<Product> products = DataBase.GetProducts();
            foreach (var product in products)
            {
                if (product.Slug == slug)
                {
                    return product;
                }
            }
                return null;
        }
    }
}