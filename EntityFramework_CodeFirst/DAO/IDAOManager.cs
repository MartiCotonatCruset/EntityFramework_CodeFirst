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
        bool AddProductLines(ProductLines oneProductLines);
        int ImportProductLines();  

        bool AddProducts(Products oneProducts);
        int ImportProducts();

        bool AddOffices(Offices oneOffices);
        int ImportOffices();

        bool AddEmployees(Employees oneEmployees);
        int ImportEmployees();

        bool AddCustomers(Customers oneCustomers);
        int ImportCustomers();

        bool AddPayments(Payments onePayments);
        int ImportPayments();

        bool AddOrders(Orders oneOrders);
        int ImportOrders();

        bool AddOrderDetails(OrderDetails oneOrderDetails);
        int ImportOrderDetails();

        public void ImportAll();


    }
}
