using G1ANT.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Flipkart
{
    [Command(Name = "flipkart.close", Tooltip = "This command is use to closes a web browser in which flipkart is opened.")]
    public class FlipkartCloseCommand : Command
    {
        public class Arguments : CommandArguments
        {
        }
        public FlipkartCloseCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.QuitCurrentWrapper();

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}