string[] inputs = Console.ReadLine().Split(' ');
long a = long.Parse(inputs[0]);
long b = long.Parse(inputs[1]);
long c = long.Parse(inputs[2]);
long d = long.Parse(inputs[3]);

long start = Math.Max(a, c);
long end = Math.Min(b, d);

if (start <= end)
{
    Console.WriteLine($"{start} {end}");
}
else
{
    Console.WriteLine("-1");
}

