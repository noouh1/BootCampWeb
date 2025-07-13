using System.Numerics;    
string[] inputs = Console.ReadLine().Split(' ');
BigInteger a = BigInteger.Parse(inputs[0]);
BigInteger b = BigInteger.Parse(inputs[1]);
BigInteger c = BigInteger.Parse(inputs[2]);
BigInteger d = BigInteger.Parse(inputs[3]);

BigInteger result = a*b*c*d;

Console.WriteLine((result % 100).ToString("D2"));
