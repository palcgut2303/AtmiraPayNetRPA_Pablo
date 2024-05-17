using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AtmiraPayNetRPA
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement loginLink => driver.FindElement(By.Id("login"));
        IWebElement emailLogin => driver.FindElement(By.Id("emailLogin"));
        IWebElement passwordLogin => driver.FindElement(By.Id("passwordLogin"));
        IWebElement loginButton => driver.FindElement(By.Id("btnLogin"));

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


    }
}
