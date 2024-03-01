using CsvHelper;
using EntityFramework_CodeFirst.MODEL;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.IO;

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
                    oneCustomers.Employee = this.context.Employees.Find(oneCustomers.SalesRepEmployeeNumber);
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
                    oneEmployees.Offices = this.context.Offices.Find(oneEmployees.OfficeCode);
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
                    oneOrderDetails.Orders = this.context.Orders.Find(oneOrderDetails.OrderNumber);
                    oneOrderDetails.Products = this.context.Products.Find(oneOrderDetails.ProductCode);
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
                    oneOrders.Customers = this.context.Customers.Find(oneOrders.CustomerNumber);
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
                    onePayment.Customers = this.context.Customers.Find(onePayment.CustomerNumber);
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
                    oneProducts.ProductLines = context.ProductLines.Find(oneProducts.ProductLine);
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
                {
                    string line;
                    line = sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        string officeCode = values[0].Trim('"');
                        string city = values[1].Trim('"');
                        string phone = values[2].Trim('"');
                        string addressLine1 = values[3].Trim('"');
                        string addressLine2 = values[4].Trim('"') == "NULL" ? null : values[4].Trim('"');
                        string state = values[5].Trim('"') == "NULL" ? null : values[5].Trim('"');
                        string country = values[6].Trim('"');
                        string postalCode = values[7].Trim('"');
                        string territory = values[8].Trim('"');

                        Offices o = new Offices
                        {
                            OfficeCode = officeCode,
                            City = city,
                            Phone = phone,
                            AddressLine1 = addressLine1,
                            AddressLine2 = addressLine2,
                            State = state,
                            Country = country,
                            PostalCode = postalCode,
                            Territory = territory
                        };

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
                using (TextFieldParser parser = new TextFieldParser(PRODUCT_LINES_FILE))
                {
                    parser.SetDelimiters(",");
                    //QUOTES 
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 4)
                        {
                            string productLine = fields[0].Trim('"');
                            string textDescription = fields[1].Trim('"') == "NULL" ? null : fields[1].Trim('"');
                            string htmlDescription = fields[2].Trim('"') == "NULL" ? null : fields[2].Trim('"');
                            string image = fields[3].Trim('"') == "NULL" ? null : fields[3].Trim('"');

                            ProductLines pl = new ProductLines
                            {
                                ProductLine = productLine,
                                TextDescription = textDescription,
                                HtmlDescription = htmlDescription,
                                Image = image
                            };

                            if (AddProductLines(pl)) sum++;
                        }
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
                using (TextFieldParser parser = new TextFieldParser(PRODUCTS_FILE))
                {
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 9)
                        {
                            string productCode = fields[0].Trim('"');
                            string productName = fields[1].Trim('"');
                            string productLine = fields[2].Trim('"');
                            string productScale = fields[3].Trim('"');
                            string productVendor = fields[4].Trim('"');
                            string productDescription = fields[5].Trim('"');
                            short quantityInStock = Convert.ToInt16(fields[6].Trim('"'));
                            double buyPrice = Convert.ToDouble(fields[7].Trim('"'));
                            double msrp = Convert.ToDouble(fields[8].Trim('"'));

                            Products product = new Products
                            {
                                ProductCode = productCode,
                                ProductName = productName,
                                ProductLine = productLine,
                                ProductScale = productScale,
                                ProductVendor = productVendor,
                                ProductDescription = productDescription,
                                QuantityInStock = quantityInStock,
                                BuyPrice = buyPrice,
                                MSRP = msrp
                            };

                            if (AddProducts(product)) sum++;
                        }
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