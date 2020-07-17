using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.linked
{
    [Command(Name = "linkedin.post", Tooltip = "This command allows user to post on linkedin profile")]
    class postCommand :Command
    {
        public postCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be posted ")]
            public TextStructure postvalue { get; set; }

            
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                //arguments.Search.Value = "bug-text-color";
                //arguments.By.Value = "class";
                //SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[7]/div[3]/div/div/div/div/div[1]/div/div[1]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[4]/div/div/div[2]/div/div[1]/div[1]/div[2]/div/div/div/div/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue.Value, arguments, arguments.Timeout.Value);
                
                arguments.Search.Value = "/html/body/div[4]/div/div/div[2]/div/div[2]/div[2]/button/span";
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
