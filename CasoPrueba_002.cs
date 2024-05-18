using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebaTecnica
{
    [TestClass]
    public class CasoPrueba_002
    {
        [TestMethod]
        public void TestMethod1()
        {
            string chromeDriver = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\driver\\");
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(chromeDriver, options);

            try
            {
                //Ingresando el sitio
                driver.Navigate().GoToUrl("https://demoqa.com/");
                Thread.Sleep(2000);
                IWebElement? Card = driver.FindElements(By.CssSelector(".card.mt-4.top-card"))?.ToList()[0];
                Card?.Click();
                Thread.Sleep(5000);

                //Radio Btn
                IWebElement radioButton = driver.FindElement(By.CssSelector("li#item-2.btn.btn-light"));
                radioButton.Click();

                driver.ExecuteScript("var input=document.querySelector('#yesRadio'); if(!input.checked){input.click()}");
                Thread.Sleep(2000);

                driver.ExecuteScript("alert('Test Ejecutado Exitosamente')");
                Thread.Sleep(2000);
                driver.Quit();
            }
            catch (Exception e)
            {
                driver.ExecuteAsyncScript("alert('ha ocurrido un error ejecutando el test " + e.Message + "')");
                throw;
            }
        }
    }
}
