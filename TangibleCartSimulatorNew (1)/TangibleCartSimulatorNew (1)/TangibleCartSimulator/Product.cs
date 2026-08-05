using System.Drawing; 
namespace TangibleCartSimulator
{
    public class Product
    {
        public string Name;
        public float Price;
        public Image Icon;
        public Product(string name, float price, Image icon) { Name = name; Price = price; Icon = icon; }
    }
}