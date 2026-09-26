using System;
using System.Linq;
using Task_10_LINQ.Data;

namespace Task_10_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new ApplicationDbContext();

            // 1. List all customers' first and last names along with their email addresses.
            var q1 = dbContext.Customers
                .Select(c => new { c.FirstName, c.LastName, c.Email })
                .ToList();

            // 2. Retrieve all orders processed by a specific staff member (e.g., staff_id = 3).
            int staffId = 3;
            var q2 = dbContext.Orders
                .Where(o => o.StaffId == staffId)
                .ToList();

            // 3. Get all products that belong to a category named "Mountain Bikes".
            var q3 = dbContext.Products
                .Where(p => p.Category.CategoryName == "Mountain Bikes")
                .ToList();

            // 4. Count the total number of orders per store.
            var q4 = dbContext.Stores
                .Select(s => new
                {
                    s.StoreName,
                    TotalOrders = dbContext.Orders.Count(o => o.StoreId == s.StoreId)
                })
                .ToList();

            // 5. List all orders that have not been shipped yet (shipped_date is null).
            var q5 = dbContext.Orders
                .Where(o => o.ShippedDate == null)
                .ToList();

            // 6. Display each customer’s full name and the number of orders they have placed.
            var q6 = dbContext.Customers
                .Select(c => new
                {
                    FullName = c.FirstName + " " + c.LastName,
                    OrdersCount = dbContext.Orders.Count(o => o.CustomerId == c.CustomerId)
                })
                .ToList();

            // 7. List all products that have never been ordered (not found in order_items).
            var q7 = dbContext.Products
                .Where(p => !dbContext.OrderItems.Any(oi => oi.ProductId == p.ProductId))
                .ToList();

            // 8. Display products that have a quantity of less than 5 in any store stock.
            var q8 = dbContext.Products
                .Where(p => p.Stocks.Any(s => s.Quantity < 5))
                .ToList();

            // 9. Retrieve the first product from the products table.
            var q9 = dbContext.Products.FirstOrDefault();

            // 10. Retrieve all products from the products table with a certain model year (e.g., 2018).
            short year = 2018;
            var q10 = dbContext.Products
                .Where(p => p.ModelYear == year)
                .ToList();

            // 11. Display each product with the number of times it was ordered.
            var q11 = dbContext.Products
                .Select(p => new
                {
                    p.ProductName,
                    TimesOrdered = dbContext.OrderItems.Count(oi => oi.ProductId == p.ProductId)
                })
                .ToList();

            // 12. Count the number of products in a specific category (e.g., category_id = 1).
            int catId = 1;
            var q12 = dbContext.Products.Count(p => p.CategoryId == catId);

            // 13. Calculate the average list price of products.
            var q13 = dbContext.Products.Average(p => p.ListPrice);

            // 14. Retrieve a specific product from the products table by ID (e.g., product_id = 5).
            int prodId = 5;
            var q14 = dbContext.Products.FirstOrDefault(p => p.ProductId == prodId);

            // 15. List all products that were ordered with a quantity greater than 3 in any order.
            var q15 = dbContext.Products
                .Where(p => dbContext.OrderItems.Any(oi => oi.ProductId == p.ProductId && oi.Quantity > 3))
                .ToList();

            // 16. Display each staff member’s name and how many orders they processed.
            var q16 = dbContext.Staffs
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    OrdersProcessed = dbContext.Orders.Count(o => o.StaffId == s.StaffId)
                })
                .ToList();

            // 17. List active staff members only (active = 1) along with their phone numbers.
            var q17 = dbContext.Staffs
                .Where(s => s.Active == 1)
                .Select(s => new { FullName = s.FirstName + " " + s.LastName, s.Phone })
                .ToList();

            // 18. List all products with their brand name and category name.
            var q18 = dbContext.Products
                .Select(p => new
                {
                    p.ProductName,
                    BrandName = p.Brand.BrandName,
                    CategoryName = p.Category.CategoryName
                })
                .ToList();

            // 19. Retrieve orders that are completed (order_status = 4).
            var q19 = dbContext.Orders
                .Where(o => o.OrderStatus == 4)
                .ToList();

            // 20. List each product with the total quantity sold (sum of quantity from order_items).
            var q20 = dbContext.Products
                .Select(p => new
                {
                    p.ProductName,
                    TotalQuantitySold = dbContext.OrderItems
                        .Where(oi => oi.ProductId == p.ProductId)
                        .Sum(oi => (int?)oi.Quantity) ?? 0
                })
                .ToList();

            Console.WriteLine("All LINQ Queries Executed Successfully!");
        }
    }
}