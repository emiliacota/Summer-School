using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class TestMachines<T> where T : ITest
    {
        List<T> tests = new List<T>();
        public void AddTest(T test)
        {
            tests.Add(test);
        }
        public void RunTests()
        {
            foreach (T i in tests)
            {
                i.RunTest();
            }
        }
        public void PrintResults()
        {
            foreach (T i in tests)
            {
                i.GetTestResults();
            }
        }
    }
    internal interface ITest
    {
        void RunTest();
        void GetTestResults();
    }
    internal class TestMachineSignalOscillations : Machine, ITest
    {
        public static int threshold;
        public string Name;
        public bool state;
        public TestMachineSignalOscillations(string _name) : base(_name)
        {
            Name = _name;
        }
        public void RunTest()
        {
            for (int i = 0; i < currentSignalIndex; i++)
            {
                for (int j = 0; j < signals[i].Data.Length - 1; j++)
                {
                    if (signals[i].Data[j + 1] - signals[i].Data[j] > threshold)
                    { state = true; return; }
                    if (signals[i].Data[j] - signals[i].Data[j + 1] > threshold)
                    { state = true; return; }
                }
            }
            state = false;
        }

        public void GetTestResults()
        {
            if (state)
            {
                Console.WriteLine($"The Machine named {name} contains Signals that have consecutive oscillations larger than {threshold}.");
            }
            else
            {
                Console.WriteLine($"The Machine named {name} doesn't contain Signals that have consecutive oscillations larger than {threshold}.");
            }
        }
    }
    internal class TestMachineSignalNoise : Machine, ITest
    {
        public string Name;
        public bool state;
        public TestMachineSignalNoise(string _name) : base(_name)
        {
            Name = _name;
        }
        public void RunTest()
        {
            for (int i = 0; i < currentSignalIndex; i++)
            {
                double v = signals[i].getVariance();
                for (int j = 0; j < signals[i].Data.Length; j++)
                {
                    if (signals[i].Data[j] > v)
                    { state = true; return; }
                }
            }
            state = false;
        }
        public void GetTestResults()
        {
            if (state)
            {
                Console.WriteLine($"The Machine {name} contains Signals that have values larger than the variance of the data of that Signal.");
            }
            else
            {
                Console.WriteLine($"The Machine {name} doesn't contain Signals that have values larger than the variance of the data of that Signal.");
            }
        }
    }
    internal class Signal
    {
        private string _name;
        private double[] _data, _time;
        public static int count = 0;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public double[] Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public Signal(string name, double[] data, double[] time)
        {
            Name = name;
            Data = data;
            Time = time;
            count++;
        }

        public void CleanNoise()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] < 0)
                    Data[i] = 0.00;
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Signal name: {Name}");
            Console.Write("Data:");
            for (int i = 0; i < Data.Length; i++)
            {
                Console.Write($"({Time[i]:F2},{Data[i]:F2}) ");
            }
            Console.WriteLine();
        }
        public double[] GetData(double startTime, double endTime)
        {
            double[] dataValues = new double[Data.Length];
            int k = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                if (Time[i] >= startTime && Time[i] <= endTime)
                { dataValues[k] = Data[i]; k++; }
            }
            return dataValues;
        }

        public static Signal Merge(Signal signal1, Signal signal2)
        {
            int i = 0, j = 0, k = 0;
            double[] mergedDate = new double[signal1.Data.Length + signal2.Data.Length], mergedTime = new double[signal1.Time.Length + signal2.Time.Length];
            while (i < signal1.Data.Length && j < signal2.Data.Length)
            {
                if (signal1.Time[i] < signal2.Time[j])
                {
                    mergedDate[k] = signal1.Data[i];
                    mergedTime[k] = signal1.Time[i];
                    i++;
                }
                else
                {
                    mergedDate[k] = signal2.Data[j];
                    mergedTime[k] = signal2.Time[j];
                    j++;
                }
                k++;
            }
            while (i < signal1.Data.Length)
            {
                mergedDate[k] = signal1.Data[i];
                mergedTime[k] = signal1.Time[i];
                i++; k++;
            }
            while (j < signal2.Data.Length)
            {
                mergedDate[k] = signal2.Data[j];
                mergedTime[k] = signal2.Time[j];
                k++; j++;
            }
            return new Signal("Merged Signal", mergedDate, mergedTime);
        }
        public int getRecordsNumber()
        {
            return count;
        }

        public double getVariance()
        {
            double avg1 = 0, avg2 = 0;
            for (int i = 0; i < Data.Length; i++)
                avg1 += Data[i];
            avg1 /= Data.Length;
            for (int i = 0; i < Data.Length; i++)
            {
                avg2 += (avg1 - Data[i]) * (avg1 - Data[i]);
            }
            return avg2 / Data.Length;
        }
    }

    internal class Machine
    {
        public int currentSignalIndex = 0, MAX_SIGNALS = 10;
        public Signal[] signals;
        public string name;

        public Machine(string _name)
        {
            name = _name;
            signals = new Signal[MAX_SIGNALS];
        }
        public void AddSignal(Signal signal)
        {
            if (currentSignalIndex < MAX_SIGNALS)
            {
                signals[currentSignalIndex] = signal;
                currentSignalIndex++;
            }
            else
            {
                Console.WriteLine("Maximum number of signals reached");
            }
        }
        public void ChangeSignal(int index, Signal signal)
        {
            signals[index] = signal;
        }

        public Signal GetMaxSignal(double time)
        {
            int maxValueIndex = 0;
            double maxValue = -99;
            for (int i = 0; i < currentSignalIndex; i++)
            {
                double[] aux = signals[i].GetData(time - 1, time + 1);
                for (int j = 0; j < aux.Length; j++)
                {
                    if (aux[j] > maxValue)
                    {
                        maxValue = aux[j];
                        maxValueIndex = i;
                    }
                }
            }
            return signals[maxValueIndex];
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Machine Name: {name}");
            Console.WriteLine("Signals: ");
            for (int i = 0; i < currentSignalIndex; i++)
            {
                signals[i].PrintInfo();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Machine machine = new Machine("My machine");
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                double[] data = new double[7];
                double[] time = new double[7];
                for (int j = 0; j < 7; j++)
                {
                    data[j] = random.NextDouble() * 20 - 10;
                    time[j] = random.NextDouble() + j;
                }
                Signal signal = new Signal("Signal" + i, data, time);
                machine.AddSignal(signal);
            }
            Console.WriteLine("Raw signals: ");
            machine.PrintInfo();

            Console.WriteLine();

            Signal signal1 = machine.signals[0];
            Signal signal2 = machine.signals[1];
            Signal mergedSignal = Signal.Merge(signal1, signal2);
            mergedSignal.PrintInfo();

            Console.WriteLine();

            Console.WriteLine("Clean signals: ");
            foreach (Signal signal in machine.signals)
            {
                if (signal != null)
                    signal.CleanNoise();
            }
            machine.PrintInfo();
            Console.WriteLine();
            Console.WriteLine("The signal with the highest value in time [4,6]: ");
            Signal maxSignal = machine.GetMaxSignal(5);
            maxSignal.PrintInfo();

            // Create a test for the machine signal

            TestMachineSignalOscillations testOscillations = new TestMachineSignalOscillations("Oscillations Test");
            TestMachineSignalOscillations.threshold = 1;
            testOscillations.AddSignal(machine.signals[0]);
            testOscillations.AddSignal(machine.signals[1]);
            testOscillations.AddSignal(machine.signals[2]);
            testOscillations.AddSignal(machine.signals[3]);
            testOscillations.AddSignal(machine.signals[4]);

            TestMachineSignalNoise testNoise = new TestMachineSignalNoise("Noise Test");
            testNoise.AddSignal(machine.signals[0]);
            testNoise.AddSignal(machine.signals[1]);
            testNoise.AddSignal(machine.signals[2]);
            testNoise.AddSignal(machine.signals[3]);
            testNoise.AddSignal(machine.signals[4]);

            TestMachines<ITest> testMachines = new TestMachines<ITest>();
            testMachines.AddTest(testOscillations);
            testMachines.AddTest(testNoise);
            testMachines.RunTests();
            testMachines.PrintResults();
        }
    }
}