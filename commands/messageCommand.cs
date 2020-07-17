using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.linked
{
    [Command(Name ="linkedin.message", Tooltip ="This command use to send message on LinkedIn")]
    class messageCommand : Command 
    {
        public messageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be posted ")]
            public TextStructure to { get; set; }

            [Argument(Required = true, Tooltip = "Enter the value to be posted ")]
            public TextStructure messageValue { get; set; }

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                //arguments.Search.Value = "bug-text-color";
                //arguments.By.Value = "class";
                //SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "search-global-typeahead__input";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.to.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);



                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "message-anywhere-button";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "msg-form__contenteditable";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.TypeText(arguments.messageValue.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "msg-form__send-button";
                arguments.By.Value = "class";

                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
