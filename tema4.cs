using Microsoft.VisualBasic;

double result = 0;
double a, b;
char op;
double modulo(double a, double b)
{
    return a % b;
}

void reinit(double result)//used when we want to delete the result
{
    result = 0;
}

double divide(double a, double b)
{
    return a / b;
}

double exponention(double a, int b)
{
    double p = 1.0;
    while (b != 0)
    {
        p *= a;
        b--;
    }
    return p;
}

double multiplication(double a, double b)
{
    return a * b;
}

double sum(double a, double b)
{
    return a + b;
}

double difference(double a, double b)
{
    return a - b;
}

int squareRoot(int a)
{
    int i;
    for(i = 1; i * i <= a; i++)
    {
        if (i * i == a) return i;
    }
    return i;
}

void functionPrincipal()
{
    Console.WriteLine("Do you want to make an operation?");
    bool operation = bool.Parse(Console.ReadLine());
    if(operation == false)
    {
        Console.WriteLine(result);
    }
    while (operation)
    {
        if (result == 0)
        {
            Console.WriteLine("First number: ");
            a = double.Parse(Console.ReadLine());
        }
        else a = result;
            Console.WriteLine("The operation is: ");
        op = char.Parse(Console.ReadLine());
        Console.WriteLine("The second number: ");
        b = double.Parse(Console.ReadLine());

        if (op == '%') result = modulo(a, b);
        else if (op == 'c') reinit(result);
        else if (op == '/') result = divide(a, b);
        else if (op == '*') result = multiplication(a, b);
        else if (op == '^') result = exponention(a, (int)b);
        else if (op == '+') result = sum(a, b);
        else if (op == '-') result = difference(a, b);
        else if (op == 'r') result = squareRoot((int)a);
        Console.WriteLine("The result of the operation is: " + result);
        Console.WriteLine("Do you want to make another operation?");
        operation = bool.Parse(Console.ReadLine());
    }
}

functionPrincipal();