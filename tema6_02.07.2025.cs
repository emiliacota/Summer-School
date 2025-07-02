namespace tema5
{
    internal class Program
    {
        public struct Employee
        {
            public string firstName;
            public string? middleName;
            public string familyName;
            public uint contractHoursPerWeek;
            public bool currentlyEmployed;
            public double wagePerYear;
            public string fullName;//variabila pentru tot numele
            public double weeksWorkedByNow;
            public double totalEarned;
            public double paymentHour;
            public double percentageWorked;
            public uint wageIncreasePerYear;
            public double wageIncreasePerYearPercent;
            public int age;
            public DateTime dateOfHire;
            public DateTime? dateOfBirth;
            public DateTime? dateOfLeave;
            public status statusEmployee;//variabila care salveaza statusul actual al angajatului din enumeratie
            public enum status { fullTime, partTime, Intern, Student };

            public Employee()
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
                if (currentlyEmployed == true)
                {
                    Console.WriteLine("What is the date of birth?");
                    dateOfBirth = DateTime.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("What is the date of leave?");
                    dateOfLeave = DateTime.Parse(Console.ReadLine());
                }
                Console.WriteLine("What is the status of the employee?");
                Enum.TryParse(Console.ReadLine(), out statusEmployee);
                Console.WriteLine("What is the date of hire?");
                dateOfHire = DateTime.Parse(Console.ReadLine());
            }

            public string createFullName()
            {
                if (middleName == null)
                {
                    return firstName + " " + familyName;
                }
                else return firstName + " " + middleName + " " + familyName;
            }
            public double paymentPerHour()
            {
                return (wagePerYear / 52) / contractHoursPerWeek;
            }
            //functie prin care se calculeaza numarul de saptamani lucrate de la data angajarii pana in prezent
            public int weeksWorked()
            {
                TimeSpan duration = DateTime.Now - dateOfHire;
                return duration.Days / 7;
            }
            public double totalAmountEarned()
            {
                weeksWorkedByNow = weeksWorked();
                return wagePerYear * weeksWorkedByNow / 52;
            }
            public int ageEmployee()
            {
                int days = (DateTime.Now - dateOfBirth.Value).Days;
                return days / 365;
            }
            public double percentageOfWork()
            {
                age = ageEmployee();
                weeksWorkedByNow = weeksWorked();
                return (weeksWorkedByNow / 52) / age;
            }
            public void printData()
            {
                Console.WriteLine();
                Console.WriteLine("Employee Data:");
                Console.WriteLine("->firstName: " + firstName);
                Console.WriteLine("->middleName: " + middleName);
                Console.WriteLine("->familyName: " + familyName);
                Console.WriteLine("->contractHoursPerWeek: " + contractHoursPerWeek);
                Console.WriteLine("->currentlyEmployed: " + currentlyEmployed);
                if (currentlyEmployed == true)
                {
                    Console.WriteLine("->dateOfBirth: " + dateOfBirth);
                }
                else Console.WriteLine("->dateOfLeave: " + dateOfLeave);
                Console.WriteLine("->wagePerYear: " + wagePerYear);
                Console.WriteLine("->statusEmployee: " + statusEmployee);
                Console.WriteLine("->dateOfHire: " + dateOfHire);
            }

            public void showInformation()
            {
                Console.WriteLine("Full name of the employee is: ");
                fullName = createFullName();
                Console.WriteLine(fullName);

                Console.WriteLine("Payment per hour is: ");
                paymentHour = paymentPerHour();
                Console.WriteLine(paymentHour.ToString("N2"));
                //Console.WriteLine("Weeks worked by now: " + emp.weeksWorked());
                Console.WriteLine("Total amount earned by the employee is: " + totalAmountEarned().ToString("N2"));
                totalEarned = totalAmountEarned();

                //Console.WriteLine("Age of the employee: " + emp.ageEmployee());

                Console.WriteLine("Percentage of work out of age is:");
                percentageWorked = percentageOfWork();
                Console.WriteLine(percentageWorked.ToString("P"));
            }
            public uint increaseWageSum()
            {
                wagePerYear = wagePerYear + wageIncreasePerYear;
                return (uint)wagePerYear;
            }

            public double increaseWagePercent()
            {
                double increase = wagePerYear * wageIncreasePerYearPercent;
                return wagePerYear + increase;
            }
        }

        static void Main(string[] args)
        {
            bool reading = true;
            Employee[] employees = new Employee[50];
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine("Do you want to introduce an employee?[true/false]");
                reading = bool.Parse(Console.ReadLine());
                if (reading == false) break;
                employees[i] = new Employee();
                Console.WriteLine("How do you want to increase the wage?[Percentage/Uint]");
                Console.WriteLine("Insert the increase type: ");
                if (Console.ReadLine() == "Uint")
                {
                    Console.WriteLine("Insert the increase: ");
                    employees[i].wageIncreasePerYear = uint.Parse(Console.ReadLine());
                    Console.WriteLine("The increased wage per year is: ");
                    Console.WriteLine(employees[i].increaseWageSum().ToString("N2"));
                }
                else
                {
                    Console.WriteLine("Insert the increase: ");
                    employees[i].wageIncreasePerYearPercent = double.Parse(Console.ReadLine());
                    Console.WriteLine("The increased wage per year is: ");
                    Console.WriteLine(employees[i].increaseWagePercent().ToString("N2"));
                }
                employees[i].printData();
                employees[i].showInformation();
            }
        }
    }
}
