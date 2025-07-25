namespace Task5;

public class AutoMapper
{
    public static void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        foreach (var sourceProperty in sourceType.GetProperties())
        {
            var destinationProperty = destinationType.GetProperty(sourceProperty.Name);
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(source);
                destinationProperty.SetValue(destination, value);
            }
        }
    }
}