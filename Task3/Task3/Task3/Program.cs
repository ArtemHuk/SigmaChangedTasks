using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ElecricityAccountingHandler item = new ElecricityAccountingHandler();
                item.ReadElectricityAccountingPerQuarter(@"/Users/artemhuk/Desktop/Sigma/Task3/Task3/data.txt");
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.FindLargestDebt(10));
                Console.WriteLine(item.FindApartmentsWithNoConsumption());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
