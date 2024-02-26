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
            if (oneCustomers == null) throw new Exception("Parameter is null");
            
            bool done = false;

            if (this.context.Customers.Find(oneCustomers.CustomerNumber) == null)
            {
                this.context.Customers.Add(oneCustomers);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddEmployees(Employees oneEmployees)
        {
            if (oneEmployees == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.Employees.Find(oneEmployees.EmployeeNumber) == null)
            {
                this.context.Employees.Add(oneEmployees);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddOffices(Offices oneOffices)
        {
            if (oneOffices == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.Offices.Find(oneOffices.OfficeCode) == null)
            {
                this.context.Offices.Add(oneOffices);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddOrderDetails(OrderDetails oneOrderDetails)
        {
            if (oneOrderDetails == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.OrderDetails.Find(oneOrderDetails.OrderNumber, oneOrderDetails.ProductCode) == null)
            {
                this.context.OrderDetails.Add(oneOrderDetails);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddOrders(Orders oneOrders)
        {
            if (oneOrders == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.Orders.Find(oneOrders.OrderNumber) == null)
            {
                this.context.Orders.Add(oneOrders);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddPayments(Payments onePayment)
        {
            if (onePayment == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.Payments.Find(onePayment.CustomerNumber, onePayment.CheckNumber) == null)
            {
                this.context.Payments.Add(onePayment);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddProductLines(ProductLines oneProductLines)
        {
            if (oneProductLines == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.ProductLines.Find(oneProductLines.ProductLine) == null)
            {
                this.context.ProductLines.Add(oneProductLines);
                done = context.SaveChanges() > 0;
            }

            return done;
        }

        public bool AddProducts(Products oneProducts)
        {
            if (oneProducts == null) throw new Exception("Parameter is null");

            bool done = false;

            if (this.context.Products.Find(oneProducts.ProductCode) == null)
            {
                this.context.Products.Add(oneProducts);
                done = context.SaveChanges() > 0;
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