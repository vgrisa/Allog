using aula1.Api.Entities;

namespace aula1.Api
{
    public class Data
    {
        public List<Customer> Customers { get; set; }
        private static Data? _instance;
        public static Data Instance
        {
            get
            {
                return _instance ??= new Data();
            }
        }
        public Data()
        {
            Customers = new List<Customer>{
                new Customer
                {
                    Id = 1,
                    FirstName = "v",
                    LastName = "grisa",
                    Cpf = "12744585955",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 1,
                            // CustomerId = 1,
                            Street = "Abobrinha",
                            City = "Abajur"
                        },
                        new Address
                        {
                            Id = 2,
                            // CustomerId = 1,
                            Street = "Barbecue",
                            City = "Borboleta"
                        }
                    }
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Vini",
                    LastName = "Grisa",
                    Cpf = "12345678999",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 3,
                            // CustomerId = 1,
                            Street = "Cobra",
                            City = "Cantor"
                        },
                        new Address
                        {
                            Id = 4,
                            // CustomerId = 1,
                            Street = "Dado",
                            City = "Diamba"
                        }
                    }
                }
            };
        }
    }
}