using CsvHelper;
using CsvHelper.Configuration;
using EntityFramework_CodeFirst.MODEL;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            bool done = false;
            try
            {
                if (oneCustomers == null) throw new Exception("Parameter is null");

                if (this.context.Customers.Find(oneCustomers.CustomerNumber) == null)
                {
                    this.context.Customers.Add(oneCustomers);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddEmployees(Employees oneEmployees)
        {
            bool done = false;

            try
            {
                if (oneEmployees == null) throw new Exception("Parameter is null");

                if (this.context.Employees.Find(oneEmployees.EmployeeNumber) == null)
                {
                    this.context.Employees.Add(oneEmployees);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddOffices(Offices oneOffices)
        {
            bool done = false;

            try
            {
                if (oneOffices == null) throw new Exception("Parameter is null");


                if (this.context.Offices.Find(oneOffices.OfficeCode) == null)
                {
                    this.context.Offices.Add(oneOffices);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddOrderDetails(OrderDetails oneOrderDetails)
        {
            bool done = false;

            try
            {
                if (oneOrderDetails == null) throw new Exception("Parameter is null");


                if (this.context.OrderDetails.Find(oneOrderDetails.OrderNumber, oneOrderDetails.ProductCode) == null)
                {
                    this.context.OrderDetails.Add(oneOrderDetails);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddOrders(Orders oneOrders)
        {
            bool done = false;

            try
            {
                if (oneOrders == null) throw new Exception("Parameter is null");

                if (this.context.Orders.Find(oneOrders.OrderNumber) == null)
                {
                    this.context.Orders.Add(oneOrders);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddPayments(Payments onePayment)
        {
            bool done = false;

            try
            {
                if (onePayment == null) throw new Exception("Parameter is null");

                if (this.context.Payments.Find(onePayment.CustomerNumber, onePayment.CheckNumber) == null)
                {
                    this.context.Payments.Add(onePayment);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddProductLines(ProductLines oneProductLines)
        {
            bool done = false;

            try
            {
                if (oneProductLines == null) throw new Exception("Parameter is null");

                if (this.context.ProductLines.Find(oneProductLines.ProductLine) == null)
                {
                    this.context.ProductLines.Add(oneProductLines);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }

            return done;
        }

        public bool AddProducts(Products oneProducts)
        {
            bool done = false;

            try
            {
                if (oneProducts == null) throw new Exception("Parameter is null");

                if (this.context.Products.Find(oneProducts.ProductCode) == null)
                {
                    this.context.Products.Add(oneProducts);
                    done = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return done;
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
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(EMPLOYEES_FILE))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    string[] fields;
                    while (line != null)
                    {
                        fields = line.Split(',');
                        string reportsTo = fields[6];
                        if (fields[6] == "NULL") reportsTo = null;
                        Employees e = new Employees()
                        {
                            EmployeeNumber = Convert.ToInt32(fields[0]),
                            LastName = fields[1],
                            FirstName = fields[2],
                            Extension = fields[3],
                            Email = fields[4],
                            OfficeCode = fields[5],
                            ReportsTo = Convert.ToInt32(reportsTo),
                            JobTitle = fields[7],
                        };
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        public int ImportOffices()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(OFFICES_FILE))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    string[] fields;
                    while (line != null)
                    {
                        fields = line.Split(',');
                        string addressLine2 = fields[4];
                        if (fields[4] == "NULL") addressLine2 = null;
                        string state = fields[5];
                        if (fields[5] == "NULL") state = null;
                        Offices e = new Offices()
                        {
                            OfficeCode = fields[0],
                            City = fields[1],
                            Phone = fields[2],
                            AddressLine1 = fields[3],
                            AddressLine2 = addressLine2,
                            State = state,
                            Country = fields[6],
                            PostalCode = fields[7],
                            Territory = fields[8]
                        };
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        public int ImportOrderDetails()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(ORDER_DETAILS_FILE))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    string[] fields;
                    while (line != null)
                    {
                        fields = line.Split(',');
                        OrderDetails e = new OrderDetails()
                        {
                            OrderNumber = Convert.ToInt32(fields[0]),
                            ProductCode = fields[1],
                            QuantityOrdered = Convert.ToInt32(fields[2]),
                            PriceEach = Convert.ToDouble(fields[3]),
                            OrderLineNumber = short.Parse(fields[4])
                        };
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sum;
        }

        public int ImportOrders()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(ORDERS_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var orders = cr.GetRecords<Orders>();

                    foreach (Orders o in orders)
                    {
                        AddOrders(o);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
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
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        public int ImportProductLines()
        {
            throw new NotImplementedException();
        }

        public int ImportProducts()
        {
            throw new NotImplementedException();
        }
    }
}