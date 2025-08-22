using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(@"Server=DESKTOP-PNLMVN8;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options;

        using var context = new ApplicationDbContext(options);

        // Insert data
        var category = InsertCategory(context, "Electronics");
        InsertProduct(context, "Smartphone", 699.99m, category.CategoryId);

        // Retrieve and display data
        DisplayCategoriesWithProducts(context);
        DisplayProductsWithCategories(context);

        // Update data
        UpdateProductPrice(context, "Smartphone", 749.99m);
    }

    static Category InsertCategory(ApplicationDbContext context, string categoryName)
    {
        var category = new Category { CategoryName = categoryName };
        context.Categories.Add(category);
        context.SaveChanges();
        return category;
    }

    static void InsertProduct(ApplicationDbContext context, string productName, decimal price, int categoryId)
    {
        var product = new Product
        {
            ProductName = productName,
            Price = price,
            CategoryId = categoryId
        };
        context.Products.Add(product);
        context.SaveChanges();
    }

    static void DisplayCategoriesWithProducts(ApplicationDbContext context)
    {
        var categories = context.Categories.Include(c => c.Products).ToList();
        Console.WriteLine("Categories:");
        foreach (var category in categories)
        {
            Console.WriteLine($"CategoryId: {category.CategoryId}, CategoryName: {category.CategoryName}");
            foreach (var product in category.Products)
            {
                Console.WriteLine($"  ProductId: {product.ProductId}, ProductName: {product.ProductName}, Price: {product.Price}");
            }
        }
    }

    static void DisplayProductsWithCategories(ApplicationDbContext context)
    {
        var products = context.Products.Include(p => p.Category).ToList();
        Console.WriteLine("\nProducts:");
        foreach (var product in products)
        {
            Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, Price: {product.Price}, CategoryName: {product.Category?.CategoryName}");
        }
    }

    static void UpdateProductPrice(ApplicationDbContext context, string productName, decimal newPrice)
    {
        var product = context.Products.FirstOrDefault(p => p.ProductName == productName);
        if (product != null)
        {
            product.Price = newPrice;
            context.SaveChanges();
            Console.WriteLine($"Updated ProductId: {product.ProductId}, New Price: {product.Price}");
        }
        else
        {
            Console.WriteLine($"Product with name '{productName}' not found.");
        }
    }
}