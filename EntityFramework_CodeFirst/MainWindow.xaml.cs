using EntityFramework_CodeFirst.DAO;
using EntityFramework_CodeFirst.MODEL;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFramework_CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProductLines> lines = new List<ProductLines>();
        List<Products> products = new List<Products>();
        List<Offices> offices = new List<Offices>();
        List<Employees> employees = new List<Employees>();
        List<Customers> customers = new List<Customers>();
        List<Payments> payments = new List<Payments>();
        List<Orders> orders = new List<Orders>();
        List<OrderDetails> orderDetails = new List<OrderDetails>();

        IDAOManager dao;

        public MainWindow()
        {
            InitializeComponent();
            this.dao = DAOFactory.createDAOManager();

            dao.ImportAll();
            GetAllTables();
        }

        private void GetAllTables()
        {
            lines = dao.GetProductLines();
            dgProdcutLines.ItemsSource = lines;
            products = dao.GetProducts();
            dgProdcuts.ItemsSource = products;
            offices = dao.GetOffices();
            dgOffices.ItemsSource = offices;
            employees = dao.GetEmployees();
            dgEmployees.ItemsSource = employees;
            customers = dao.GetCustomers();
            dgCustomer.ItemsSource = customers;
            payments = dao.GetPayments();
            dgPayments.ItemsSource = payments;
            orders = dao.GetOrders();
            dgOrders.ItemsSource = orders;
            orderDetails = dao.GetOrderDetails();
            dgOrderDetails.ItemsSource = orderDetails;
        }
    }
}