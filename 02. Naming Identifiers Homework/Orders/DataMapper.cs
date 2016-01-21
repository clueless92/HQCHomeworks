namespace Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using Models;

    public class DataMapper
    {
        private const string CategoriesFileName = "../../Data/categories.txt";
        private const string ProductsFileName = "../../Data/products.txt";
        private const string OrdersFileName = "../../Data/orders.txt";

        private readonly string categoriesFileName;
        private readonly string productsFileName;
        private readonly string ordersFileName;

        public DataMapper(string categoriesFileName = CategoriesFileName,
            string productsFileName = ProductsFileName,
            string ordersFileName = OrdersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<string> readCategoryLines = ReadFileLines(this.categoriesFileName, true);
            List<Category> categories = readCategoryLines
                .Select(category => category.Split(','))
                .Select(category => new Category
                {
                    ID = int.Parse(category[0]),
                    Name = category[1],
                    Description = category[2]
                })
                .ToList();
            return categories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<string> readProductLines = ReadFileLines(this.productsFileName, true);
            List<Product> products = readProductLines
                .Select(product => product.Split(','))
                .Select(product => new Product
                {
                    ID = int.Parse(product[0]),
                    Name = product[1],
                    CategoryID = int.Parse(product[2]),
                    UnitPrice = decimal.Parse(product[3]),
                    UnitsInStock = int.Parse(product[4]),
                })
                .ToList();
            return products;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<string> readOrderLines = ReadFileLines(this.ordersFileName, true);
            List<Order> orders = readOrderLines
                .Select(order => order.Split(','))
                .Select(order => new Order
                {
                    ID = int.Parse(order[0]),
                    ProductID = int.Parse(order[1]),
                    Quantity = int.Parse(order[2]),
                    Discount = decimal.Parse(order[3]),
                })
                .ToList();
            return orders;
        }

        private List<string> ReadFileLines(string fileName, bool hasHeader)
        {
            List<string> allLines = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    allLines.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }
            return allLines;
        }
    }
}
