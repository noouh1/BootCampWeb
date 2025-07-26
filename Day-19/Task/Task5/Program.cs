namespace Task5;

public class Program
{
    
    class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public static void Main(string[] args)
    {
        var source = new Source { Id = 1,Name = "noouh"};
        var destination = new Destination();

        AutoMapper.Map(source, destination);

        Console.WriteLine($"id : {destination.Id} Name: {destination.Name}");
    }
}