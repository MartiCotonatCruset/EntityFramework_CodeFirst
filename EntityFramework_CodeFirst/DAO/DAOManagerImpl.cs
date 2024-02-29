using CsvHelper;
using CsvHelper.Configuration;
using EntityFramework_CodeFirst.MODEL;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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

        #region ADDS
        private bool AddCustomers(Customers oneCustomers)
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

        private bool AddEmployees(Employees oneEmployees)
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

        private bool AddOffices(Offices oneOffices)
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

        private bool AddOrderDetails(OrderDetails oneOrderDetails)
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

        private bool AddOrders(Orders oneOrders)
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

        private bool AddPayments(Payments onePayment)
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

        private bool AddProductLines(ProductLines oneProductLines)
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

        private bool AddProducts(Products oneProducts)
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
        #endregion

        #region IMPORTS
        public void ImportAll()
        {
            ImportProductLines();
            ImportProducts();
            ImportOffices();
            //ImportEmployees();
            //ImportCustomers();
            //ImportPayments();
            //ImportOrders();
            //ImportOrderDetails();
        }

        private int ImportCustomers()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(CUSTOMERS_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var customers = cr.GetRecords<Customers>();

                    foreach (Customers c in customers)
                    {
                        if (AddCustomers(c)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportEmployees()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(EMPLOYEES_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var employees = cr.GetRecords<Employees>();

                    foreach (Employees e in employees)
                    {
                        if (AddEmployees(e)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportOffices()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(OFFICES_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var offices = cr.GetRecords<Offices>();

                    foreach (Offices o in offices)
                    {
                        if (AddOffices(o)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportOrderDetails()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(ORDER_DETAILS_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var orderDetails = cr.GetRecords<OrderDetails>();

                    foreach (OrderDetails od in orderDetails)
                    {
                        if (AddOrderDetails(od)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportOrders()
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
                        if (AddOrders(o)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportPayments()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(PAYMENTS_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var payments = cr.GetRecords<Payments>();

                    foreach (Payments p in payments)
                    {
                        if (AddPayments(p)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportProductLines()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(PRODUCT_LINES_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var productLines = cr.GetRecords<ProductLines>();

                    foreach (ProductLines pl in productLines)
                    {
                        if (AddProductLines(pl)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }

        private int ImportProducts()
        {
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(PRODUCTS_FILE))
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var products = cr.GetRecords<Products>();

                    foreach (Products p in products)
                    {
                        if (AddProducts(p)) sum++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return sum;
        }
        #endregion

        #region QUERIES
        public List<ProductLines> GetProductLines()
        {
            return context.ProductLines.ToList();
        }

        public List<Products> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<Offices> GetOffices()
        {
            return context.Offices.ToList();
        }

        public List<Employees> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public List<Customers> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public List<Payments> GetPayments()
        {
            return context.Payments.ToList();
        }

        public List<Orders> GetOrders()
        {
            return context.Orders.ToList();
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return context.OrderDetails.ToList();
        }
        #endregion
    }
}