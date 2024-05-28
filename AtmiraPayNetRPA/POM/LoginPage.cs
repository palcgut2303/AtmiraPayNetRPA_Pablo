using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Windows;
using OpenQA.Selenium.Support.UI;

namespace AtmiraPayNetRPA.POM
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));

        }

        IWebElement loginLink => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"login\"]")));

        IWebElement emailLogin => _driver.FindElement(By.XPath("//*[@id=\"emailLogin\"]"));
        IWebElement passwordLogin => _driver.FindElement(By.XPath("//*[@id=\"passwordLogin\"]"));
        IWebElement loginButton => _driver.FindElement(By.XPath("//*[@id=\"btnLogin\"]"));

        public void ClickLogin()
        {
            loginLink.Click();
        }

        public void Login(string email, string password)
        {

            emailLogin.SendKeys(email);
            passwordLogin.SendKeys(password);
            loginButton.Click();



        }

        private void ShowError(string message, Exception ex)
        {
            // Mostrar el mensaje de error en un MessageBox
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }


    }
}
