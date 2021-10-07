using System;
namespace Task3
{

    public class Customer
    {
        private string surname;
        public string Surname
        {
            get => surname;
            set
            {
                
                if (value.Length > 0)
                    surname = value;
                else
                    throw new FormatException("Surname lenght <1");
            }
        }
        public int ApartmentsNumber { get; private set; }

        public ElectricityAccounting Electricity
        {
            get;
            private set;
        }
        
        public Customer(int number,string surname,ElectricityAccounting electricity)
        {
            Surname = surname;
            ApartmentsNumber = number;
            if (electricity != null)
                Electricity = electricity;
            else
                throw new NullReferenceException("");
            
        }
        public override string ToString()
        {
            return string.Format($"Flat:  {ApartmentsNumber,-6}  Surname: {surname,-10} {Electricity}");
        }
    }
}
