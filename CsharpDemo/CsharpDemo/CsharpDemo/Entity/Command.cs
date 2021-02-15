using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpDemo.Entity
{
    /**
     * Command
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class Command
    {
        public virtual String CommandCode { get; set; }
        public virtual String CommandHelpText { get; set; }
        public virtual String CommandDesc { get; set; }
        public virtual Boolean CommandGreedyArg { get; set; }
        public Command(String commandCode, String commandHelpText, String commandDesc, Boolean CommandGreedyArg)
        {
            this.CommandCode = commandCode;
            this.CommandHelpText = commandHelpText;
            this.CommandDesc = commandDesc;
            this.CommandGreedyArg = CommandGreedyArg;
        }
    }
}
