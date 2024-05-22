using OpenQA.Selenium;
using System.Net;
using System.Net.Http;
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

namespace AtmiraPayNetRPA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWebDriver _webDriver;

        public MainWindow()
        {
            InitializeComponent();
            // _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            //_webDriver.Url = "http://localhost:5058/#";
        }

        

        private void TestCreatePaymentLetter(object sender, RoutedEventArgs e)
        {
            //recoger datos
            



        }

        private void TestData(object sender, RoutedEventArgs e)
        {

            //TXT DEL LOGIN
            string emailLogin = txtEmailLogin.Text;
            string passwordLogin = txtPasswordLogin.Text;


            //TXT DEL PAGO
            string IBANBankOrigin = txtIBANOrigin.Text;
            string bankNameOrigin = txtBankNameOrigin.Text;
            string countryOrigin = txtCountryOrigin.Text;

            string IBANBankDestination = txtIBANDestination.Text;
            string bankNameDestination = txtBankNameDestination.Text;
            string countryDestination = txtCountryDestination.Text;

            

            string? IBANBankInter = txtIBANInter.Text;
            string bankNameInter = txtBankNameInter.Text;

            string CP = txtCp.Text;              
            string Street = txtStreet.Text;
            string NumberStreet = txtNumberStreet.Text;
            string PayAmount = txtPayAmount.Text;



            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:5058/");

            _webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(8);

            _webDriver.Manage().Window.Maximize();

            //LOGIN
            LoginPage loginPage = new LoginPage(_webDriver);
            loginPage.ClickLogin();
            loginPage.Login(emailLogin, passwordLogin);
            
            

            ListPaymentPage listPaymentPage = new ListPaymentPage(_webDriver);
            listPaymentPage.ClickHomebtn();

            CreatePaymentPage createPaymentPage = new CreatePaymentPage(_webDriver);
            createPaymentPage.ClickCreatePayment();

            


            createPaymentPage.CreatePayment(IBANBankOrigin, bankNameOrigin, countryOrigin, CP, Street, NumberStreet, PayAmount, IBANBankDestination, bankNameDestination, countryDestination, IBANBankInter, bankNameInter);

            ComboBoxItem selectedItem = comboBoxTypeOperation.SelectedItem as ComboBoxItem;

            string tipoOperacion =  selectedItem!.Content.ToString()!;

            

            if (tipoOperacion == "GENERAR")
            {
               createPaymentPage.ClickGenerar();
            }
            else
            {
                createPaymentPage.ClickBorrador();
            }


        }

    }
}