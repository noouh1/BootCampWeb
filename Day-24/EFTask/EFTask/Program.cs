using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

            var cs = "Server=DESKTOP-PNLMVN8;Database=DapperTask;Trusted_Connection=True;TrustServerCertificate=True;";

            using var conn = new SqlConnection(cs);
            await conn.OpenAsync();
            Console.WriteLine("Successfully connected to task_dapper");

            Console.WriteLine("=== Categories CRUD ===");

            // Insert Category
            await conn.ExecuteAsync("sp_InsertCategory",
                new { CategoryName = "cat1" },
                commandType: CommandType.StoredProcedure);
            Console.WriteLine("Inserted Category: cat1");

            // Get Categories
            var categories = await conn.QueryAsync<Category>("sp_GetAllCategories", commandType: CommandType.StoredProcedure);
            foreach (var c in categories)
                Console.WriteLine($"Category => {c.CategoryId} - {c.CategoryName}");

            // Update Category
            await conn.ExecuteAsync("sp_UpdateCategory",
                new { CategoryId = 1, CategoryName = "Updated cat1" },
                commandType: CommandType.StoredProcedure);
            Console.WriteLine("Updated Category Id=1");

            // Delete Category
            //await conn.ExecuteAsync("sp_DeleteCategory",
            //new { CategoryId = 1 }, commandType: CommandType.StoredProcedure);

            Console.WriteLine("\n=== Products CRUD ===");

            // Insert Product
            await conn.ExecuteAsync("sp_InsertProduct",
                new { ProductName = "prod1", Price = 15000m, CategoryId = 1 },
                commandType: CommandType.StoredProcedure);
            Console.WriteLine("Inserted Product: prod1");

            // Get Products
            var products = await conn.QueryAsync<Product>("sp_GetAllProducts", commandType: CommandType.StoredProcedure);
            foreach (var p in products)
                Console.WriteLine($"Product => {p.ProductId} - {p.ProductName} - {p.Price}");

            // Update Product
            await conn.ExecuteAsync("sp_UpdateProduct",
                new { ProductId = 1, ProductName = "update prod1", Price = 20000m, CategoryId = 1 },
                commandType: CommandType.StoredProcedure);
            Console.WriteLine("Updated Product Id=1");

            // Delete Product
            // await conn.ExecuteAsync("sp_DeleteProduct", new { ProductId = 1 }, commandType: CommandType.StoredProcedure);

            Console.WriteLine("\n=== View ===");
            var prodWithCat = await conn.QueryFirstOrDefaultAsync<ProductWithCategory>(
                "SELECT * FROM vw_ProductWithCategory"
            );

            if (prodWithCat != null)
                Console.WriteLine($"[VIEW] {prodWithCat.ProductName} - {prodWithCat.CategoryName} - {prodWithCat.Price}");
            else
                Console.WriteLine("[VIEW] No product with category found.");

            Console.WriteLine("\n=== Function ===");
            var count = await conn.ExecuteScalarAsync<int>(
                "SELECT dbo.fn_GetProductsCountByCategory(@CatId)",
                new { CatId = 1 });
            Console.WriteLine($"Category 1 has {count} product(s)");

    // DTOs
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductWithCategory
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = "";
    }
