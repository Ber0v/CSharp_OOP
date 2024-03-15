using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commands = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = commands[0];
            string[] commandArgs = commands.Skip(1).ToArray();

            Type[] types = Assembly.GetEntryAssembly().GetTypes();
            Type commandType = types.FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;
            string result = command.Execute(commandArgs);
            return result;


        }

    }
}