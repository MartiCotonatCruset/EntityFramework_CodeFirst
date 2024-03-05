using EntityFramework_CodeFirst.MODEL;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xaml.Behaviors.Core;
using System.Diagnostics.Metrics;
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
            ImportEmployees();
            ImportCustomers();
            ImportPayments();
            ImportOrders();
            ImportOrderDetails();
        }

        private int ImportCustomers()
        {
            int sum = 0;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(CUSTOMERS_FILE))
                {
                    parser.SetDelimiters(",");
                    //QUOTES 
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 13)
                        {
                            string customerNumber = fields[0].Trim('"');
                            string customerName = fields[1].Trim('"');
                            string contactLastName = fields[2].Trim('"');
                            string contactFirstName = fields[3].Trim('"');
                            string phone = fields[4].Trim('"');
                            string addressLine1 = fields[5].Trim('"');
                            string addressLine2 = fields[6].Trim('"') == "NULL" ? null : fields[6].Trim('"');
                            string city = fields[7].Trim('"');
                            string state = fields[8].Trim('"') == "NULL" ? null : fields[8].Trim('"');
                            string postalCode = fields[9].Trim('"') == "NULL" ? null : fields[9].Trim('"');
                            string country = fields[10].Trim('"');
                            string salesRepEmployeeNumber = fields[11].Trim('"') == "NULL" ? null : fields[11].Trim('"');
                            string creditLimit = fields[12].Trim('"') == "NULL" ? null : fields[12].Trim('"');


                            int? toIntSalesRepEmployeeNumber = null;
                            decimal? toDecimalCreditLimit = null;

                            if (salesRepEmployeeNumber != null) toIntSalesRepEmployeeNumber = Convert.ToInt32(salesRepEmployeeNumber);
                            if (creditLimit != null) toDecimalCreditLimit = Convert.ToDecimal(creditLimit);

                            Customers c = new Customers
                            {
                                CustomerNumber = Convert.ToInt32(customerNumber),
                                CustomerName = customerName,
                                ContactLastName = contactLastName,
                                ContactFirstName = contactFirstName,
                                Phone = phone,
                                AddressLine1 = addressLine1,
                                AddressLine2 = addressLine2,
                                City = city,
                                State = state,
                                PostalCode = postalCode,
                                Country = country,
                                SalesRepEmployeeNumber = toIntSalesRepEmployeeNumber,
                                CreditLimit = toDecimalCreditLimit
                            };

                            if (AddCustomers(c)) sum++;
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

        private int ImportEmployees()
        {
            int sum = 0;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(EMPLOYEES_FILE))
                {
                    parser.SetDelimiters(",");
                    //QUOTES 
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 8)
                        {
                            string employeeNumber = fields[0].Trim('"');
                            string lastName = fields[1].Trim('"');
                            string firstName = fields[2].Trim('"');
                            string extension = fields[3].Trim('"');
                            string email = fields[4].Trim('"');
                            string officeCode = fields[5].Trim('"');
                            string reportsTo = fields[6].Trim('"') == "NULL" ? null : fields[6].Trim('"');
                            string jobTitle = fields[7].Trim('"');

                            int? numReportsTo = null;

                            if (reportsTo != null) numReportsTo = Convert.ToInt32(reportsTo);

                            Employees e = new Employees
                            {
                                EmployeeNumber = Convert.ToInt32(employeeNumber),
                                LastName = lastName,
                                FirstName = firstName,
                                Extension = extension,
                                Email = email,
                                OfficeCode = officeCode,
                                ReportsTo = numReportsTo,
                                JobTitle = jobTitle

                            };

                            if (AddEmployees(e)) sum++;
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
                using (TextFieldParser parser = new TextFieldParser(ORDER_DETAILS_FILE))
                {
                    parser.SetDelimiters(",");
                    //QUOTES 
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 5)
                        {
                            string orderNumber = fields[0].Trim('"');
                            string productCode = fields[1].Trim('"');
                            string quantityOrdered = fields[2].Trim('"');
                            string priceEach = fields[3].Trim('"');
                            string orderLineNumber = fields[4].Trim('"');

                            OrderDetails o = new OrderDetails()
                            {
                                OrderNumber = Convert.ToInt32(orderNumber),
                                ProductCode = productCode,
                                QuantityOrdered = Convert.ToInt32(quantityOrdered),
                                PriceEach = Convert.ToDouble(priceEach),
                                OrderLineNumber = Convert.ToInt16(orderLineNumber)
                            };

                            if (AddOrderDetails(o)) sum++;
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

        private int ImportOrders()
        {
            int sum = 0;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(ORDERS_FILE))
                {
                    parser.SetDelimiters(",");
                    //QUOTES 
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Read current line fields, handle commas within quotes
                        string[] fields = parser.ReadFields();

                        if (fields != null && fields.Length == 7)
                        {
                            string orderNumber = fields[0].Trim('"');
                            string orderDate = fields[1].Trim('"');
                            string requiredDate = fields[2].Trim('"');
                            string shippedDate = fields[3].Trim('"') == "NULL" ? null : fields[3].Trim('"');
                            string status = fields[4].Trim('"');
                            string comments = fields[5].Trim('"') == "NULL" ? null : fields[5].Trim('"');
                            string customerNumber = fields[6].Trim('"');

                            DateTime? toDateShippedDate = null;

                            if (shippedDate != null) toDateShippedDate = Convert.ToDateTime(toDateShippedDate);

                            Orders o = new Orders()
                            {
                                OrderNumber = Convert.ToInt32(orderNumber),
                                OrderDate = Convert.ToDateTime(orderDate),
                                RequiredDate = Convert.ToDateTime(requiredDate),
                                ShippedDate = toDateShippedDate,
                                Status = status,
                                Comments = comments,
                                CustomerNumber = Convert.ToInt32(customerNumber)
                            };

                            if (AddOrders(o)) sum++;
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

        private int ImportPayments()
        {
            int sum = 0;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(PAYMENTS_FILE))
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
                            string customerNumber = fields[0].Trim('"');
                            string checkNumber = fields[1].Trim('"');
                            string paymentDate = fields[2].Trim('"');
                            string amount = fields[3].Trim('"');

                            Payments p = new Payments()
                            {
                                CustomerNumber = Convert.ToInt32(customerNumber),
                                CheckNumber = checkNumber,
                                PaymentDate = Convert.ToDateTime(paymentDate),
                                Amount = Convert.ToDouble(amount)
                            };

                            if (AddPayments(p)) sum++;
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
        #region GETS
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
        #region FILTRES
        public List<ProductLines> OrderProductLines(string filtre)
        {
            return context.ProductLines.Where(p =>
                p.ProductLine.ToLower().Contains(filtre) ||
                p.TextDescription.ToLower().Contains(filtre) ||
                p.HtmlDescription.ToLower().Contains(filtre) ||
                p.Image.ToLower().Contains(filtre)
            )
            .OrderBy(p => p.ProductLine)
            .ToList();
        }

        public List<Products> OrderProducts(string filtre)
        {
            return context.Products.Where(p =>
                p.ProductCode.Contains(filtre) ||
                p.ProductName.Contains(filtre) ||
                p.ProductLine.Contains(filtre) ||
                p.ProductScale.Contains(filtre) ||
                p.ProductVendor.Contains(filtre) ||
                p.ProductDescription.Contains(filtre) ||
                p.QuantityInStock.ToString().Contains(filtre) ||
                p.BuyPrice.ToString().Contains(filtre) ||
                p.MSRP.ToString().Contains(filtre)
            )
            .OrderBy(p => p.ProductLine)
            .ToList();
        }

        public List<Offices> OrderOffices(string filtre)
        {
            return context.Offices.Where(p =>
                p.OfficeCode.Contains(filtre) ||
                p.City.Contains(filtre) ||
                p.Phone.Contains(filtre) ||
                p.AddressLine1.Contains(filtre) ||
                p.AddressLine2.Contains(filtre) ||
                p.State.Contains(filtre) ||
                p.Country.Contains(filtre) ||
                p.PostalCode.Contains(filtre) ||
                p.Territory.Contains(filtre)
            )
            .OrderBy(p => p.OfficeCode)
            .ToList();
        }

        public List<Employees> OrderEmployees(string filtre)
        {
            return context.Employees.Where(p =>
                p.EmployeeNumber.ToString().Contains(filtre) ||
                p.LastName.Contains(filtre) ||
                p.FirstName.Contains(filtre) ||
                p.Extension.Contains(filtre) ||
                p.OfficeCode.Contains(filtre) ||
                p.ReportsTo.ToString().Contains(filtre) ||
                p.JobTitle.Contains(filtre)
            )
            .OrderBy(p => p.EmployeeNumber)
            .ToList();
        }

        public List<Customers> OrderCustomers(string filtre)
        {
            return context.Customers.Where(p =>
                p.CustomerNumber.ToString().Contains(filtre) ||
                p.CustomerName.Contains(filtre) ||
                p.ContactLastName.Contains(filtre) ||
                p.ContactFirstName.Contains(filtre) ||
                p.Phone.Contains(filtre) ||
                p.AddressLine1.Contains(filtre) ||
                p.AddressLine2.Contains(filtre) ||
                p.City.Contains(filtre) ||
                p.State.Contains(filtre) ||
                p.PostalCode.Contains(filtre) ||
                p.Country.Contains(filtre) ||
                p.SalesRepEmployeeNumber.ToString().Contains(filtre) ||
                p.CreditLimit.ToString().Contains(filtre)
            )
            .OrderBy(p => p.CustomerNumber)
            .ToList();
        }

        public List<Payments> OrderPayments(string filtre)
        {
            return context.Payments.Where(p =>
                p.CustomerNumber.ToString().Contains(filtre) ||
                p.CheckNumber.Contains(filtre) ||
                p.PaymentDate.ToString().Contains(filtre) ||
                p.Amount.ToString().Contains(filtre)
            )
            .OrderBy(p => p.CustomerNumber)
            .ToList();
        }

        public List<Orders> OrderOrders(string filtre)
        {
            return context.Orders.Where(p =>
                p.OrderNumber.ToString().Contains(filtre) ||
                p.OrderDate.ToString().Contains(filtre) ||
                p.RequiredDate.ToString().Contains(filtre) ||
                p.ShippedDate.ToString().Contains(filtre) ||
                p.Status.Contains(filtre) ||
                p.Comments.Contains(filtre) ||
                p.CustomerNumber.ToString().Contains(filtre)
            )
            .OrderBy(p => p.OrderNumber)
            .ToList();
        }

        public List<OrderDetails> OrderOrderDetails(string filtre)
        {
            return context.OrderDetails.Where(p =>
                p.OrderNumber.ToString().Contains(filtre) ||
                p.ProductCode.Contains(filtre) ||
                p.QuantityOrdered.ToString().Contains(filtre) ||
                p.PriceEach.ToString().Contains(filtre) ||
                p.OrderLineNumber.ToString().Contains(filtre)
            )
            .OrderBy(p => p.OrderNumber)
            .ToList();
        }
        #endregion
        #region CRUD
        #region INSERTS
        public bool InsertProductLine(ProductLines productLine)
        {
            bool done = true;
            try
            {
                context.ProductLines.Add(productLine);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertProduct(Products product)
        {
            bool done = true;
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertOffice(Offices office)
        {
            bool done = true;
            try
            {
                context.Offices.Add(office);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertEmployee(Employees employee)
        {
            bool done = true;
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertCustomer(Customers customer)
        {
            bool done = true;
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertPayment(Payments payment)
        {
            bool done = true;
            try
            {
                context.Payments.Add(payment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertOrder(Orders order)
        {
            bool done = true;
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }

        public bool InsertOrderDetail(OrderDetails orderDetail)
        {
            bool done = true;
            try
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                done = false;
            }
            return done;
        }
        #endregion
        #region DELETE
        public bool DeleteProductLine()
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public bool DeleteOffice()
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public bool DeletePayment()
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderDetail()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #endregion
    }
}