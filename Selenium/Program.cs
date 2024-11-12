using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.DOM;
using OpenQA.Selenium.DevTools.V127.WebAuthn;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest

{
    class Program
    {
        static void VerifyPageTitleInputOutput()
        {
            //input data to input form
            Console.Write("Test case started ");
            Console.WriteLine();
            Console.Write("Input number: ");
            string numberinput = Console.ReadLine();
            Console.Write("Input text: ");
            string textinput = Console.ReadLine();
            Console.Write("Input password: ");
            string passwordinput = Console.ReadLine();
            Console.Write("Input date (in 'mm/dd/yyyy'): ");
            string dateinput = Console.ReadLine();

            Console.WriteLine();

            //create the reference for the browser  
            IWebDriver driver = new EdgeDriver();

            // navigate to URL  
            driver.Navigate().GoToUrl("https://practice.expandtesting.com/inputs");
            Thread.Sleep(2000);

            //maximize window
            driver.Manage().Window.Maximize();
            Console.WriteLine();

            //verify page title
            string actualpagetitle = driver.Title;
            string expectedpagetitle = "Hello world";
            if (actualpagetitle == expectedpagetitle)
            {
                Console.WriteLine("Actual Web Page title is matching with the Expected title");
            }
            else
            {
                Console.WriteLine("Actual Web Page title is NOT matching with the Expected title");
            }

            //input values to form in website
            IWebElement numberin = driver.FindElement(By.Name("input-number"));
            numberin.SendKeys(numberinput);

            IWebElement textin = driver.FindElement(By.Name("input-text"));
            textin.SendKeys(textinput);

            IWebElement passwordin = driver.FindElement(By.Name("input-password"));
            passwordin.SendKeys(passwordinput);

            IWebElement datein = driver.FindElement(By.Name("input-date"));
            datein.SendKeys(dateinput);

            //click Display button to show inputs
            IWebElement displaybtn = driver.FindElement(By.Id("btn-display-inputs"));
            displaybtn.Click();

            IWebElement numberout = driver.FindElement(By.Id("output-number"));
            IWebElement textout = driver.FindElement(By.Id("output-text"));
            IWebElement passwordout = driver.FindElement(By.Id("output-password"));
            IWebElement dateout = driver.FindElement(By.Id("output-date"));

            //store output values
            String numberoutvalue = numberout.Text;
            String textoutvalue = textout.Text;
            String passwordoutvalue = passwordout.Text;
            String dateoutvalue = dateout.Text;

            Console.WriteLine();
            Console.Write("\nDisplay number is:" + numberoutvalue);
            Console.Write("\nDisplay text is: " + textoutvalue);
            Console.Write("\nDisplay password is: " + passwordoutvalue);
            Console.Write("\nDisplay date is: " + dateoutvalue);

            //verify input and output values
            Console.WriteLine();
            if (numberin.GetAttribute("value") == numberoutvalue)
            {
                Console.Write("\nNumber value is correct. Passed.");
            }

            if (textin.GetAttribute("value") == textoutvalue)
            {
                Console.Write("\nText value is correct. Passed.");
            }

            if (passwordin.GetAttribute("value") == passwordoutvalue)
            {
                Console.Write("\nPassword value is correct. Passed.");
            }

            if (datein.GetAttribute("value") == dateoutvalue)
            {
                Console.Write("\nDate value is correct. Passed.");
            }

            Thread.Sleep(3000);

            Console.Write("\n\nTest case ended ");

            //close browser window
            driver.Close();

            //end method
        }


        static void Main(string[] args)
        {
            //call method 
            VerifyPageTitleInputOutput();
        }
    }
}
