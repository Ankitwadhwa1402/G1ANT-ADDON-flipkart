using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Flipkart
{

    [Command(Name = "flipkart.buynow", Tooltip = "This command is used to buy a product in a Flipkart .")]
    public class FlipkartBuyNowCommand : Command
    {
        public FlipkartBuyNowCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter Amazon Product URL")]
            public TextStructure Url { get; set; }

           /* [Argument(Required = true, Tooltip = "Enter your name")]
            public TextStructure Name { get; set; } 

            [Argument(Required = true, Tooltip = "Enter pincode")]
            public TextStructure Pin { get; set; }

            [Argument(Required = true, Tooltip = "Enter Address")]
            public TextStructure Address { get; set; }

            [Argument(Required = true, Tooltip = "City")]
            public TextStructure City { get; set; }

            [Argument(Required = true, Tooltip = "State")]
            public TextStructure State { get; set; } */


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, arguments.Url?.Value, arguments.NoWait.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[3]/div[2]/div[1]/div[1]/div[2]/div/ul/li[1]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                /* arguments.Search.Value = "enterAddressFullName";
                 arguments.By.Value = "id";
                 SeleniumManager.CurrentWrapper.TypeText(arguments.Name.Value, arguments, arguments.Timeout.Value);

                 arguments.Search.Value = "enterAddressPostalCode";
                 arguments.By.Value = "id";
                 SeleniumManager.CurrentWrapper.TypeText(arguments.Pin.Value, arguments, arguments.Timeout.Value);

                 arguments.Search.Value = "enterAddressAddressLine1";
                 arguments.By.Value = "id";
                 SeleniumManager.CurrentWrapper.TypeText(arguments.Address.Value, arguments, arguments.Timeout.Value);

                 arguments.Search.Value = "enterAddressCity";
                 arguments.By.Value = "id";
                 SeleniumManager.CurrentWrapper.TypeText(arguments.City.Value, arguments, arguments.Timeout.Value);

                 arguments.Search.Value = "enterAddressStateOrRegion";
                 arguments.By.Value = "id";
                 SeleniumManager.CurrentWrapper.TypeText(arguments.State.Value, arguments, arguments.Timeout.Value); */

                arguments.Search.Value = "/html/body/div[1]/div/div[2]/div/div/div[1]/div/div[3]/div/form/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[2]/div/div[1]/div[3]/div/div/div/div[2]/div[2]/span[2]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                



            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}