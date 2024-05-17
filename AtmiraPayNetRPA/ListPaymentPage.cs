using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmiraPayNetRPA
{
    public class ListPaymentPage
    {
        private readonly IWebDriver driver;

        public ListPaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement btnHomeListPayment => driver.FindElement(By.Id("viewPayment"));

        public void ClickHomebtn()
        {
            btnHomeListPayment.Click();
        }





    }
}
