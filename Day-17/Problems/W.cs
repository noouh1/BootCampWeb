string[] inputs = Console.ReadLine().Split(' ');
int n = int.Parse(inputs[0]);
char c = char.Parse(inputs[1]);
int m = int.Parse(inputs[2]);
char d = char.Parse(inputs[3]);
long result = long.Parse(inputs[4]);

Console.WriteLine(
    c == '+'? (n + m == result ? "Yes" : n+m) :
    c == '-'? (n - m == result ? "Yes" : n-m) :
    c == '*'? (n * m == result ? "Yes" : n*m) :
    "invalid operation"
    
    );
