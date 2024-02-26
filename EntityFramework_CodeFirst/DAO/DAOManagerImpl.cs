using EntityFramework_CodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool AddPayments(Payments onePayments)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
