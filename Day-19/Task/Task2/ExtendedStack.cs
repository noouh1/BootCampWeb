namespace Task2
{
    
    public static class ExtendStack
    {
        public static string GetNameMo(this Stack<string> stack,Predicate<string> name)
        {
            foreach (var person in stack)
            {
                if (name(person))
                    return person;
            }
            return null;
            
        }
            

                
    }
    
}