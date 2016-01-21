namespace Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Models;

    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DataMapper dataMapper = new DataMapper();
            IEnumerable<Category> allCategories = dataMapper.GetAllCategories();
            List<Category> allCategoriesList = allCategories.ToList();
            IEnumerable<Product> allProducts = dataMapper.GetAllProducts();
            List<Product> allProductsList = allProducts.ToList();
            IEnumerable<Order> allOrders = dataMapper.GetAllOrders();
            List<Order> allOrdersList = allOrders.ToList();
            PrintMostExpensiveProducts(allProductsList);
            PrintNumberOfProductsInCategories(allProductsList, allCategoriesList);
            PrintTopProductsByOrderQuantity(allOrdersList, allProductsList);
            PrintMostProfitableCategory(allOrdersList, allProductsList, allCategoriesList);
        }

        private static void PrintMostProfitableCategory(List<Order> allOrders, 
            List<Product> allProducts, List<Category> allCategories)
        {
            var mostProfitableCategory = allOrders
                .GroupBy(order => order.ProductID)
                .Select(grouping => new
                {
                    categoryID = allProducts
                        .First(product => product.ID == grouping.Key)
                        .CategoryID,
                    price = allProducts
                        .First(product => product.ID == grouping.Key)
                        .UnitPrice,
                    quantity = grouping.Sum(order => order.Quantity)
                })
                .GroupBy(product => product.categoryID)
                .Select(grouping => new
                {
                    categoryName = allCategories
                        .First(category => category.ID == grouping.Key).Name,
                    totalQuantity = grouping
                        .Sum(groupingCategory => groupingCategory.quantity * groupingCategory.price)
                })
                .OrderByDescending(groupingCategory => groupingCategory.totalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.categoryName, mostProfitableCategory.totalQuantity);
        }

        private static void PrintTopProductsByOrderQuantity(List<Order> allOrders, List<Product> allProducts)
        {
            var topFiveProductsByOrderQuantity = allOrders
                .GroupBy(order => order.ProductID)
                .Select(grouping => new
                {
                    Product = allProducts
                        .First(product => product.ID == grouping.Key)
                        .Name,
                    Quantities = grouping
                        .Sum(order => order.Quantity)
                })
                .OrderByDescending(grouping => grouping.Quantities)
                .Take(5);
            foreach (var item in topFiveProductsByOrderQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));
        }

        private static void PrintNumberOfProductsInCategories(List<Product> allProducts, List<Category> allCategories)
        {
            var numberOfProductsInEachCategory = allProducts
                .GroupBy(product => product.CategoryID)
                .Select(grouping => new
                {
                    Category = allCategories
                        .First(category => category.ID == grouping.Key)
                        .Name,
                    Count = grouping.Count()
                })
                .ToList();
            foreach (var item in numberOfProductsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));
        }

        private static void PrintMostExpensiveProducts(List<Product> allProducts)
        {
            List<string> namesOfFiveMostExpensiveProducts = GetNamesOfFiveMostExpensiveProducts(allProducts);
            Console.WriteLine(string.Join(Environment.NewLine, namesOfFiveMostExpensiveProducts));
            Console.WriteLine(new string('-', 10));
        }

        private static List<string> GetNamesOfFiveMostExpensiveProducts(List<Product> allProducts)
        {
            List<string> namesOfFiveMostExpensiveProducts = allProducts
                .OrderByDescending(product => product.UnitPrice)
                .Take(5)
                .Select(product => product.Name).ToList();
            return namesOfFiveMostExpensiveProducts;
        }
    }
}
