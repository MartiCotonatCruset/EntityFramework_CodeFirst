using EntityFramework_CodeFirst.DAO;
using EntityFramework_CodeFirst.MODEL;
using System.Reflection;
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
        private enum crudOptions { PRODUCTLINE, PRODUCT, OFFICES, EMPLOYEE, CUSTOMER, PAYMENT, ORDER, ORDERDETAIL};

        List<ProductLines> lines = new List<ProductLines>();
        List<Products> products = new List<Products>();
        List<Offices> offices = new List<Offices>();
        List<Employees> employees = new List<Employees>();
        List<Customers> customers = new List<Customers>();
        List<Payments> payments = new List<Payments>();
        List<Orders> orders = new List<Orders>();
        List<OrderDetails> orderDetails = new List<OrderDetails>();

        Debouncer debouncer;
        IDAOManager dao;

        public MainWindow()
        {
            InitializeComponent();
            this.dao = DAOFactory.createDAOManager();
            // dao.ImportAll();
            GetAllTables();
            debouncer = new Debouncer(Filtra, 500);
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

        #region FILTRES
        private void Filtra()
        {
            string filtre;
            Dispatcher.Invoke(() =>
            {
                if (tbFiltreProductLines.IsFocused)
                {
                    filtre = tbFiltreProductLines.Text.ToLower();
                    lines = dao.OrderProductLines(filtre);
                    dgProdcutLines.ItemsSource = lines;
                }
                else if (tbFiltreProducts.IsFocused)
                {
                    filtre = tbFiltreProducts.Text.ToLower();
                    products = dao.OrderProducts(filtre);
                    dgProdcuts.ItemsSource = products;
                }
                else if (tbFiltreOffices.IsFocused)
                {
                    filtre = tbFiltreOffices.Text.ToLower();
                    offices = dao.OrderOffices(filtre);
                    dgOffices.ItemsSource = offices;
                }
                else if (tbFiltreEmployees.IsFocused)
                {
                    filtre = tbFiltreEmployees.Text.ToLower();
                    employees = dao.OrderEmployees(filtre);
                    dgEmployees.ItemsSource = employees;
                }
                else if (tbFiltreCustomer.IsFocused)
                {
                    filtre = tbFiltreCustomer.Text.ToLower();
                    customers = dao.OrderCustomers(filtre);
                    dgCustomer.ItemsSource = customers;
                }
                else if (tbFiltrePayments.IsFocused)
                {
                    filtre = tbFiltrePayments.Text.ToLower();
                    payments = dao.OrderPayments(filtre);
                    dgPayments.ItemsSource = payments;
                }
                else if (tbFiltreOrders.IsFocused)
                {
                    filtre = tbFiltreOrders.Text.ToLower();
                    orders = dao.OrderOrders(filtre);
                    dgOrders.ItemsSource = orders;
                }
                else if (tbFiltreOrderDetails.IsFocused)
                {
                    filtre = tbFiltreOrderDetails.Text.ToLower();
                    orderDetails = dao.OrderOrderDetails(filtre);
                    dgOrderDetails.ItemsSource = orderDetails;
                }
            });
        }

        private void tbFiltre_TextChanged(object sender, TextChangedEventArgs e)
        {
            debouncer.Call();
        }
        #endregion
        #region CRUD
        private void btnCRUDProductLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDOffice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCRUDOderDetail_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}