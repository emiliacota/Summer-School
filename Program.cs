// See https://aka.ms/new-console-template for more information
int a;
a = 12;
Console.WriteLine(a);
Console.WriteLine("New value for a");
a = int.Parse(Console.ReadLine());
Console.WriteLine("Another value for a");
string? input = Console.ReadLine();
if (int.TryParse(input, out int number))
    Console.Write(number);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for a");
Console.WriteLine(Int32.MinValue);
Console.WriteLine("Max value for a");
Console.WriteLine(Int32.MaxValue);

//byte
byte b;
b = 23;
Console.WriteLine(b);
Console.WriteLine("New value for b");
b = byte.Parse(Console.ReadLine());
Console.WriteLine("Another value for b");
string? input1 = Console.ReadLine();
if (byte.TryParse(input1, out byte number1))
    Console.Write(number1);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for b");
Console.WriteLine(Byte.MinValue);
Console.WriteLine("Max value for b");
Console.WriteLine(Byte.MaxValue);

//sbyte
sbyte c;
c = 2;
Console.WriteLine(c);
Console.WriteLine("New Value for c");
c = sbyte.Parse(Console.ReadLine());
Console.WriteLine("Another value for c");
string? input2 = Console.ReadLine();
if (sbyte.TryParse(input2, out sbyte number2))
    Console.Write(number2);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for c");
Console.WriteLine(SByte.MinValue);
Console.WriteLine("Max value for c");
Console.WriteLine(SByte.MaxValue);

//short
short d;
d= 2;
Console.WriteLine(d);
Console.WriteLine("New value for d");
d= short.Parse(Console.ReadLine());
Console.WriteLine("Another value for d");
string? input3 = Console.ReadLine();
if (short.TryParse(input3, out short number3))
    Console.Write(number3);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for d");
Console.WriteLine(Int16.MinValue);
Console.WriteLine("Max value for d");
Console.WriteLine(Int16.MaxValue);

//ushort
ushort e;
e = 45;
Console.WriteLine(e);
Console.WriteLine("New value for e");
e = ushort.Parse(Console.ReadLine());
Console.WriteLine("Another value for e");
string? input4 = Console.ReadLine();
if (ushort.TryParse(input4, out ushort number4))
    Console.Write(number4);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for e");
Console.WriteLine(UInt16.MinValue);
Console.WriteLine("Max value for e");
Console.WriteLine(UInt16.MaxValue);

//uint
uint f = 2;
Console.WriteLine(f);
Console.WriteLine("New value for f");
f = uint.Parse(Console.ReadLine());
Console.WriteLine("Another value for f");
string? input5 = Console.ReadLine();
if (uint.TryParse(input5, out uint number5))
    Console.Write(number5);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for f");
Console.WriteLine(UInt32.MinValue);
Console.WriteLine("Max value for f");
Console.WriteLine(UInt32.MaxValue);

//long 
long g = 23;
Console.WriteLine(g);
Console.WriteLine("New value for g");
g = long.Parse(Console.ReadLine());
Console.WriteLine("Another value for g");
string? input6 = Console.ReadLine();
if (long.TryParse(input6, out long number6))
    Console.Write(number6);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for g");
Console.WriteLine(Int64.MinValue);
Console.WriteLine("Max value for g");
Console.WriteLine(Int64.MaxValue);

//ulong
ulong h = 11;
Console.WriteLine(h);
Console.WriteLine("New value for h");
h = ulong.Parse(Console.ReadLine());
Console.WriteLine("Another value for h");
string? input7 = Console.ReadLine();
if (ulong.TryParse(input7, out ulong number7))
    Console.Write(number7);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for h");
Console.WriteLine(UInt64.MinValue);
Console.WriteLine("Max vale for h");
Console.WriteLine(UInt64.MinValue);

//float
float i = 1.6f;
Console.WriteLine(i);
Console.WriteLine("New value for i");
i = float.Parse(Console.ReadLine());
Console.WriteLine("Anothe value for i");
string? input8 = Console.ReadLine();
if (float.TryParse(input8, out float number8))
    Console.Write(number8);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for i");
Console.WriteLine(Single.MinValue);
Console.WriteLine("Max value for i");
Console.WriteLine(Single.MaxValue);

//double 
double j = 8.9;
Console.WriteLine(j);
Console.WriteLine("New value for j");
j = double.Parse(Console.ReadLine());
Console.WriteLine("Another value for j");
string? input9 = Console.ReadLine();
if (double.TryParse(input9, out double number9))
    Console.Write(number9);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for j");
Console.WriteLine(Double.MinValue);
Console.WriteLine("Max value for j");
Console.WriteLine(Double.MaxValue);

//decimal
decimal k = 1.2m;
Console.WriteLine(k);
Console.WriteLine("New value for k");
k = decimal.Parse(Console.ReadLine());
Console.WriteLine("Another value for k");
string? input10 = Console.ReadLine();
if (decimal.TryParse(input10, out decimal number10))
    Console.Write(number10);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for k");
Console.WriteLine(Decimal.MinValue);
Console.WriteLine("Max value for k");
Console.WriteLine(Decimal.MaxValue);

//bool
bool l = true;
Console.WriteLine(l);
Console.WriteLine("New value for l");
l = bool.Parse(Console.ReadLine());
Console.WriteLine("Another value value for l");
string? input11 = Console.ReadLine();
if (bool.TryParse(input11, out bool number11))
    Console.Write(number11);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for l");
Console.WriteLine(false);
Console.WriteLine("Max value for l");
Console.WriteLine(true);

//char
char m = 'm';
Console.WriteLine(m);
Console.WriteLine("New value for m");
m = char.Parse(Console.ReadLine());
Console.WriteLine("Another value for m");
string? input12 = Console.ReadLine();
if (char.TryParse(input12, out char number12))
    Console.Write(number12);
else
    Console.Write("Bad input");
Console.WriteLine("Min value for m");
Console.WriteLine(Char.MinValue);
Console.WriteLine("Max value for m");
Console.WriteLine(Char.MaxValue);





