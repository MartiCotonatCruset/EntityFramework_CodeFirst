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

        // QUERIES
        // GETS
        public List<ProductLines> GetProductLines();
        public List<Products> GetProducts();
        public List<Offices> GetOffices();
        public List<Employees> GetEmployees();
        public List<Customers> GetCustomers();
        public List<Payments> GetPayments();
        public List<Orders> GetOrders();
        public List<OrderDetails> GetOrderDetails();

        // FILTRES
        public List<ProductLines> OrderProductLines(string filtre);
        public List<Products> OrderProducts(string filtre);
        public List<Offices> OrderOffices(string filtre);
        public List<Employees> OrderEmployees(string filtre);
        public List<Customers> OrderCustomers(string filtre);
        public List<Payments> OrderPayments(string filtre);
        public List<Orders> OrderOrders(string filtre);
        public List<OrderDetails> OrderOrderDetails(string filtre);

        // INSERT / CREATE
        public bool InsertProductLine(ProductLines productLine);
        public bool InsertProduct(Products product);
        public bool InsertOffice(Offices office);
        public bool InsertEmployee(Employees employee);
        public bool InsertCustomer(Customers customer);
        public bool InsertPayment(Payments payment);
        public bool InsertOrder(Orders order);
        public bool InsertOrderDetail(OrderDetails orderDetail);

        // DELETE
        public bool DeleteProductLine();
        public bool DeleteProduct();
        public bool DeleteOffice();
        public bool DeleteEmployee();
        public bool DeleteCustomer();
        public bool DeletePayment();
        public bool DeleteOrder();
        public bool DeleteOrderDetail();
    }
}
