using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tema6
{
    internal class Signal
    {
        public string name { get; set; }
        public double[] data { get; set; }
        public double[] time { get; set; }
        public int count = 0;

        public Signal(string Name, double[] Data, double[] Time)
        {
            name = Name;
            data = Data;
            time = Time;
            count++;
        }

        public void CleanNoise()
        {
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] < 0)
                {
                    data[i] = 0.00;
                }
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Signal Name: {name}");
            Console.Write("Data:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write($"({time[i]:F2},{data[i]:F2})");
            }
            Console.WriteLine();
        }
        public double[] GetData(double startTime, double endTime)
        {
            double[] dataValues = new double[data.Length];
            int k = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (time[i] >= startTime && time[i] <= endTime)
                { 
                    dataValues[k] = data[i]; 
                    k++; 
                }
            }
            return dataValues;
        }
        //merge two signals ordering the times
        public static Signal Merge(Signal signal1, Signal signal2)
        {   
            int n1 = signal1.time.Length, n2 = signal2.time.Length;
            int n = n1 + n2;

            double[] mergedTime = new double[n];
            double[] mergedDate = new double[n];

            int i = 0, j = 0, k = 0;
            while (i < n1 && j < n2)
            {
                if (signal1.time[i] < signal2.time[j])
                {
                    mergedTime[k] = signal1.time[i];
                    mergedDate[k] = signal1.data[i];
                    i++;
                    k++;
                }
                else if (signal1.time[i] > signal2.time[j])
                {
                    mergedTime[k] = signal2.time[j];
                    mergedDate[k] = signal2.data[j];
                    j++;
                    k++;
                }
                else if (signal1.time[i] == signal2.time[j])
                {
                    mergedTime[k] = signal1.time[i];
                    mergedDate[k] = signal1.data[i];
                    k++;
                    i++;
                    mergedTime[k] = signal2.time[j];
                    mergedDate[k] = signal2.data[j];
                    k++;
                    j++;
                }
            }
            while (i < n1)
            {
                mergedTime[k] = signal1.time[i];
                mergedDate[k] = signal1.data[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                mergedTime[k] = signal2.time[j];
                mergedDate[k] = signal2.data[j];
                j++;
                k++;
            }
            return new Signal("Merged Signal", mergedDate, mergedTime);
        }

        public int getRecordsNumber()
        {
            return count;
        }
    }
    internal class Machine 
    {
        public int currentSignalIndex = 0, MAX_SIGNALS = 10;
        public Signal[] signals;
        public string name;
        public Machine(string Name)
        {
            name = Name;
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
                Console.WriteLine("Maximum number of signals reached.");
            }
        }
        public void ChangeSignal(int index, Signal signal)
        {
            signals[index] = signal;
        }
        public Signal GetMaxSignal(double time)
        {
            int maxValueIndex = 0;
            double maxValue = double.MinValue;
            for (int i = 0; i < currentSignalIndex; i++)
            {
                double[] v = signals[i].GetData(time - 1, time + 1);
                for (int j = 0; j < signals[i].data.Length; j++)
                {
                    if (v[j] > maxValue)
                    {
                        maxValue = v[j];
                        maxValueIndex = i;
                    }
                }
            }
            return signals[maxValueIndex];
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Machine Name: {name}");
            Console.WriteLine($"Signals: ");
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
        }
    }
}
