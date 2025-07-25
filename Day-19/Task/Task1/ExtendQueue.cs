namespace Task1
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
    
    public static class ExtendQueue
    {
        public static string GetName(this Queue<Person> queue, Func<Person, bool> found)
        {
            foreach (var person in queue)
            {
                if (found(person))
                    return person.Name;
            }
            
            return string.Empty;
        }
            

                
    }
    
}
            
