using System.Formats.Asn1;
using System.Globalization;
using System.Xml.Linq;

string firstName;
string middleName;
string familyName;
uint contractHoursPerWeek;
bool currentlyEmployed;
double wagePerYear;
uint weeksWorked;
uint age = 0;

//reading data for each employee
void readDates()
{
    Console.WriteLine("First name is:");
    firstName = Console.ReadLine();
    Console.WriteLine("Middle name is:");
    middleName = Console.ReadLine();
    Console.WriteLine("Family name is:");
    familyName = Console.ReadLine();
    Console.WriteLine("Number of hours per week in the contract:");
    contractHoursPerWeek = uint.Parse(Console.ReadLine());
    Console.WriteLine("Is he currently employed?");
    currentlyEmployed = bool.Parse(Console.ReadLine());
    Console.WriteLine("What is his wage per year?");
    wagePerYear = double.Parse(Console.ReadLine());
    Console.WriteLine("What is the number of weeks worked?");
    weeksWorked = uint.Parse(Console.ReadLine());
    if(currentlyEmployed == true)
    {
        Console.WriteLine("Age for the employee:");
        age = uint.Parse(Console.ReadLine());
    }
}

//forming the full name
string createFullName(string first, string? middle, string family)
{
    if(middle == null)
    {
        return first + " " + family;
    }
    else return first + " " +  middle + " " + family;
}

//finding out how much he earns per hour
double paymentPerHour(double wage, uint hours)
{
    return (wage / 52) / hours;
}

//finding out how much money he earned
double totalAmoutEarned(double wage, uint weeks)
{
    return (wage * weeks) / 52;
}

//what percentage of his life he worked
string percentageOfWork(uint weeks, uint ageEmployee)
{
    return (((double)weeks / 52) / (double)ageEmployee).ToString("P");
}

Console.WriteLine("Insert data for the first employee!");
readDates();


//Console.WriteLine("The full name of the employee is:");
string name = createFullName(firstName, middleName, familyName);
//Console.WriteLine(name);

//Console.WriteLine("The payment per hour is:");
double paymentHour = paymentPerHour(wagePerYear, contractHoursPerWeek);
//Console.WriteLine(paymentHour);

//Console.WriteLine("The total amount of money earned is:");
double paymentEarned = totalAmoutEarned(wagePerYear, weeksWorked);
//Console.WriteLine(paymentEarned);

//Console.WriteLine("The percentage of work out of age is:");
string percentageOfAge;
if (age != null)
{
    percentageOfAge = percentageOfWork(weeksWorked, age);
    //Console.WriteLine(percentageOfAge);
}

void AfisEmployee()
{
    Console.WriteLine(" ");
    Console.WriteLine("Full dates for employee: ");
    Console.WriteLine("First name is : " + firstName);
    Console.WriteLine("Middle name is: " + middleName);
    Console.WriteLine("Family name is : " + familyName);
    Console.WriteLine("Full name is : " + name);
    Console.WriteLine("Age: " + age);
    Console.WriteLine("Number of contract hours per week is: " + contractHoursPerWeek);
    Console.WriteLine("Currently employed: " + currentlyEmployed);
    Console.WriteLine("Wage per year: " + wagePerYear);
    Console.WriteLine("Number of weeks worked: " + weeksWorked);
    Console.WriteLine("Payment per hour is: " + paymentHour.ToString("N2"));
    Console.WriteLine("Money earned: " + paymentEarned.ToString("N2"));
    percentageOfAge = percentageOfWork(weeksWorked, age);
    Console.WriteLine("Percentage of work out of age: " + percentageOfAge);
}

//CultureInfo culture = new CultureInfo("es-ES", false);
//Console.WriteLine($"The price is {1234.012.ToString("N2", culture)}");//pastram doar 2 zecimale, C - vine de la valuta si e pt dolari
AfisEmployee();


Console.WriteLine("\nInsert data for the former employee!");
readDates();
AfisEmployee();