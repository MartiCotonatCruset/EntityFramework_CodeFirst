using EntityFramework_CodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EntityFramework_CodeFirst.DAO
{
    public class DAOManagerImpl : IDAOManager
    {
        private const string PRODUCT_LINES_FILE = "PRODUCTLINES.CSV";
        private const string PRODUCTS_FILE = "PRODUCTS.CSV";
        private const string OFFICES_FILE = "OFFICES.CSV";
        private const string EMPLOYEES_FILE = "EMPLOYEES.CSV";
        private const string CUSTOMERS_FILE = "CUSTOMERS.CSV";
        private const string PAYMENTS_FILE = "PAYMENTS.CSV";
        private const string ORDERS_FILE = "ORDERS.CSV";
        private const string ORDER_DETAILS_FILE = "ORDERDETAILS.CSV"; 

        private ModelsClassicsDbContext context;
        public DAOManagerImpl()
        {
            this.context = new ModelsClassicsDbContext();
        }

        public bool AddCustomers(Customers oneCustomers)
        {
            throw new NotImplementedException();
        }

        public bool AddEmployees(Employees oneEmployees)
        {
            throw new NotImplementedException();
        }

        public bool AddOffices(Offices oneOffices)
        {
            throw new NotImplementedException();
        }

        public bool AddOrderDetails(OrderDetails oneOrderDetails)
        {
            throw new NotImplementedException();
        }

        public bool AddOrders(Orders oneOrders)
        {
            throw new NotImplementedException();
        }

        public bool AddPayments(Payments onePayment)
        {
            bool done = true;
            try
            {
                context.Payments.Add(onePayment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool AddProductLines(ProductLines oneProductLines)
        {
            throw new NotImplementedException();
        }

        public bool AddProducts(Products oneProducts)
        {
            throw new NotImplementedException();
        }

        public void ImportAll()
        {
            ImportProductLines();
            ImportProducts();
            ImportOffices();
            ImportEmployees();
            ImportCustomers();
            ImportPayments();
            ImportOrders();
            ImportOrderDetails();
        }

        public int ImportCustomers()
        {
            throw new NotImplementedException();
        }

        public int ImportEmployees()
        {
            throw new NotImplementedException();
        }

        public int ImportOffices()
        {
            throw new NotImplementedException();
        }

        public int ImportOrderDetails()
        {
            throw new NotImplementedException();
        }

        public int ImportOrders()
        {
            throw new NotImplementedException();
        }

        public int ImportPayments()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(PAYMENTS_FILE))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    string[] fields;
                    while (line != null)
                    {
                        fields = line.Split(',');
                        Payments p = new Payments()
                        {
                            CustomerNumber = Convert.ToInt32(fields[0]),
                            CheckNumber = fields[1], 
                            PaymentDate = DateTime.Parse(fields[2]), 
                            Amount = Convert.ToDouble(fields[3])
                        };
                        if (AddPayments(p)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return sum;
        }

        public int ImportProductLines()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(PRODUCT_LINES_FILE))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    string[] fields;
                    while (line != null)
                    {
                        fields = line.Split("\"");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sum;
        }

        public int ImportProducts()
        {
            throw new NotImplementedException();
        }
    }
}
