using EntityFramework_CodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.DAO
{
    public interface IDAOManager
    {
        // ADDS AND IMPORTS
        public void ImportAll();

        //QUERIES
        public List<ProductLines> GetProductLines();
        public List<Products> GetProducts();
        public List<Offices> GetOffices();
        public List<Employees> GetEmployees();
        public List<Customers> GetCustomers();
        public List<Payments> GetPayments();
        public List<Orders> GetOrders();
        public List<OrderDetails> GetOrderDetails();
    }
}
