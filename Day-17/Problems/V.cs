string[] inputs = Console.ReadLine().Split(' ');
int n = int.Parse(inputs[0]);
char c = char.Parse(inputs[1]);
int m = int.Parse(inputs[2]);

Console.WriteLine(
    c == '>' ? (n > m ? "Right" : "Wrong") :
    c == '<' ? (n < m ? "Right" : "Wrong") :
    c == '=' ? (n == m ? "Right" : "Wrong") :
    "Wrong"
);