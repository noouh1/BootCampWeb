string[] inputs = Console.ReadLine().Split(' ');
long a = long.Parse(inputs[0]);
long b = long.Parse(inputs[1]);
long c = long.Parse(inputs[2]);
long d = long.Parse(inputs[3]);

double left = b * Math.Log(a);
double right = d * Math.Log(c);

if (left > right)
    Console.WriteLine("YES");
else
    Console.WriteLine("NO");
