using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmiraPayNetRPA.POM
{

    public class TableData
    {
        public string BancoOrigen { get; set; }
        public string BancoBeneficiario { get; set; }
        public string Cantidad { get; set; }
        public string Divisa { get; set; }
        public string Estado { get; set; }
        public IWebElement DownloadButton { get; set; } // Propiedad para almacenar el botón de descarga

    }

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

        public List<TableData> GetTableDatas()
        {
            List<TableData> tableDatas = new List<TableData>();

            var rows = driver.FindElements(By.XPath("//*[@id=\"app\"]/div/main/article/div/table/tbody/tr"));
            

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));
                var downloadButton = row.FindElement(By.TagName("button"));

                tableDatas.Add(new TableData
                {
                    BancoOrigen = columns[0].Text,
                    BancoBeneficiario = columns[1].Text,
                    Cantidad = columns[2].Text,
                    Divisa = columns[3].Text,
                    Estado = columns[4].Text


                });
            }

            return tableDatas;
        }

    }
}
