using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebaTecnica
{
    [TestClass]
    public class CasoPrueba_001
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

                IWebElement? Card = driver.FindElements(By.CssSelector(".card.mt-4.top-card"))?.ToList()[0];
                Card?.Click();
                Thread.Sleep(3000);

                //Btn Textbox
                IWebElement TextBox = driver.FindElement(By.CssSelector("li#item-0.btn.btn-light"));
                TextBox.Click();

                IWebElement userName = driver.FindElement(By.Id("userName"));
                userName.SendKeys("Juan Perez");

                IWebElement userEmail = driver.FindElement(By.Id("userEmail"));
                userEmail.SendKeys("juanp@gmail.com");

                //Input TexArea
                IWebElement currentAddress = driver.FindElement(By.Id("currentAddress"));
                currentAddress.SendKeys("San José, Costa rica");

                IWebElement permanentAddress = driver.FindElement(By.Id("permanentAddress"));
                permanentAddress.SendKeys("San José");

                //Btn Submit
                IWebElement submit = driver.FindElement(By.Id("submit"));
                submit.Click();
                Thread.Sleep(5000);
                driver.ExecuteAsyncScript("alert('Test Ejecutado Exitosamente')");
                Thread.Sleep(5000);
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