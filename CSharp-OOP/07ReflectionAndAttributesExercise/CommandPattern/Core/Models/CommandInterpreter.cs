using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }
        public string Read(string args)
        {
            string[] commandInfo = args.Split();
            string commandName = commandInfo[0];
            string[] commandArgs = commandInfo.Skip(1).ToArray();

            ICommand command = this.commandFactory.CreateCommand(commandName);

            return command.Execute(commandArgs);
        }
    }
}
