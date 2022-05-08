using System;
using System.Collections.Generic;
using System.Text;
using Logic;


namespace Logic.Managers
{
    public class ProductManager
    {
        private List<Product> _products;
        public ProductManager()
        {
            _products = new List<Product>();
            _products.Add(new Product() { Name = "Pelota", Code = 1, Stock = 15, Type = "BASKET", Price = 50 });
            _products.Add(new Product() { Name = "Pelota", Code = 2, Stock = 15, Type = "FUTBOL", Price = 60});
            _products.Add(new Product() { Name = "Deportivo", Code = 3, Stock = 15, Type = "BASKET", Price = 320 });
            _products.Add(new Product() { Name = "Deportivo", Code = 4, Stock = 15, Type = "FUTBOL", Price = 420 });
        }
        public List<Product> GetProducts()
        {
           
            return _products;
        }

        public Product CreateProduct(string name, int stock, string type, double price)
        {
            int lastCode = _products[_products.Count - 1].Code + 1;
            price = 0;
            Product createdProduct = new Product() { Name = name, Stock = stock, Type = type, Price = price, Code = lastCode };
            _products.Add(createdProduct);
            return createdProduct;
        }

        public Product UpdateProduct(string name,int stock,string type,double price, int code)
        {
            _products[code-1].Name = name;
            _products[code-1].Stock = stock;
            _products[code-1].Type = type;
            _products[code-1].Price = price;
            return _products[code-1];
        }

        public Product DeleteProduct(int code)
        {
            Product deletedProduct = _products[code - 1];
            _products.Remove(_products[code - 1]);
            return deletedProduct;
        }
    }
}
