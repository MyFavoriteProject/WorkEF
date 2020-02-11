using LowLevelQuery.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LowLevelQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Идентификатор: {customer.UserLogin} \tИмя: {customer.FirstName}");
            }

            Console.ReadLine();
        }

        private static List<CustomerProxy> GetCustomers()
        {
            using (IDbConnection connection = new SqlConnection(Settings.Default.DbConect))
            {
                IDbCommand command = new SqlCommand("SELECT * FROM BlogUser");
                command.Connection = connection;

                connection.Open();

                IDataReader reader = command.ExecuteReader();

                List<CustomerProxy> customers = new List<CustomerProxy>();

                while (reader.Read())
                {
                    CustomerProxy customer = new CustomerProxy();

                    customer.UserLogin = reader.GetString(0);
                    customer.Password = reader.GetString(1);
                    customer.FirstName = reader.GetString(2);
                    customer.SecondtName = reader.GetString(3);
                    customer.Email = reader.GetString(4);
                    customer.UserId = reader.GetInt32(5);
                    customer.RegistrationDate = reader.GetDateTime(6);

                    customers.Add(customer);
                }
                return customers;
            }
        }
    }
}

