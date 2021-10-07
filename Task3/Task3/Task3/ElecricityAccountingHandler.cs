using System;
using System.IO;
using System.Linq;
using System.Text;
namespace Task3
{
    public class ElecricityAccountingHandler
    {
        private int numberOfApartments;
        public int NumberOfApartments
        {
            get => numberOfApartments;
            set
            {
                if (value >= 0)
                    numberOfApartments = value;
                else
                    throw new FormatException("Number of apartments < 0");
            }
        }
        private Customer[] data;
        public ElecricityAccountingHandler()
        {
            numberOfApartments = 0;
            data = null;
        }
        public void ReadElectricityAccountingPerQuarter(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string metadata = reader.ReadLine();
                string[] sMetadata;
                if (metadata.Length > 1)
                    sMetadata = metadata.Split();
                else
                    throw new FormatException();
                if (!int.TryParse(sMetadata[0], out numberOfApartments))
                    throw new FormatException();
                int quarte = 0;
                    
                if (!int.TryParse(sMetadata[1], out quarte))
                    throw new FormatException();
                if (quarte > 4 || quarte < 1)
                    throw new FormatException();
                data = new Customer[numberOfApartments];
                string customer;
                for (int i = 0; i < numberOfApartments; i++)
                {
                    customer = reader.ReadLine();
                    string[] sCustomer = customer.Split();
                    int ApartmentNumber;
                    if (!int.TryParse(sCustomer[0], out ApartmentNumber))
                        throw new FormatException();
                    string surname = sCustomer[1];
                 
                    double[] array = new double[sCustomer.Length - 2];
                    for (int k=0, j = 2; j < sCustomer.Length;k++, j++)
                    {
                        if (!double.TryParse(sCustomer[j], out array[k]))
                            throw new FormatException();
                    }
                    try
                    {
                        data[i] = new Customer(ApartmentNumber, surname, new ElectricityAccountingPerQuarter((Quarter)quarte
                            , array[0], array[1], array[2], array[3], array[4], array[5]));
                    }
                    catch (NullReferenceException ex)
                    {
                        throw ;
                    }
                    catch (FormatException ex)
                    {
                        throw ;
                    }
                    catch (Exception ex)
                    {
                        throw ;
                    }
                    
                }
                if(reader!=null)
                    reader.Close();
            }
            
           

        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (var item in data)
            {
                temp.Append(item+"\n");
            }
            return temp.ToString(); 
        }
        public string ToString(int index)
        {
            if (index >= data.Length || index < 0)
                throw new IndexOutOfRangeException();
            return data[index].ToString();
             
        }
        public string FindLargestDebt(double price)
        {
            Customer temp = data[1];
            double debt, tempDebt = 0;
            debt = data[0].Electricity.CountConsumedElectricity() * price;
            for (int i = 1; i < data.Length; i++)
            {
                tempDebt = data[i].Electricity.CountConsumedElectricity() * price;
                if (tempDebt > debt)
                {
                    temp = data[i];
                    debt = tempDebt;
                }
            }
            return string.Format($"Customer with largest debt: Surname {temp.Surname} Debt {debt}");

        }
        public string FindApartmentsWithNoConsumption()
        {
            Customer[] customers = data.Where(x => x.Electricity.CountConsumedElectricity() ==0).ToArray();
            StringBuilder temp =new StringBuilder( "Apartments numbers without Consumption ");
            foreach (Customer item in customers)
            {
                temp.Append ("№"+item.ApartmentsNumber+" ");
            }
            return temp.ToString();
        }
    }
}
