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
        public MainWindow()
        {
            InitializeComponent();
            ImportTables();
        }

        public void ImportTables()
        {

        }
    }
}