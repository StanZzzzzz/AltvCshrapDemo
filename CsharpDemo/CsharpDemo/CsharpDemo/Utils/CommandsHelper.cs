using AltV.Net.Elements.Entities;
using CsharpDemo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsharpDemo.Utils
{
    /**
     * CommandHelper
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class CommandsHelper
    {
        private static IList<Command> commandList = new List<Command>();

        public static void AddCommand(String commandCode, String commandHelpText, String commandDesc, Boolean commandGreedyArg)
        {
            Command command = new Command(commandCode, commandHelpText, commandDesc, commandGreedyArg);
            commandList.Add(command);
        }

        public static Int32 GetCommandsCount()
        {
            return commandList.Count();
        }

        public static Boolean HasCommand(String commandCode)
        {
            Boolean flag = false;
            foreach (Command command in commandList)
            {
                if (String.Equals(command.CommandCode.Trim(), commandCode.Trim()))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static Command GetCommand(String commandCode)
        {
            Command targetCommand = null;
            foreach (Command command in commandList)
            {
                if (String.Equals(command.CommandCode.Trim(), commandCode.Trim()))
                {
                    targetCommand = command;
                    break;
                }
            }
            return targetCommand;
        }

        public static Boolean HasCommandArgs(String commandCode, String[] commandParams)
        {
            Boolean flag = false;
            foreach (Command command in commandList)
            {
                if (String.Equals(command.CommandCode.Trim(), commandCode.Trim()))
                {
                    List<String> paramsList = command.CommandHelpText.Split(" ").ToList();
                    paramsList.RemoveAt(0);
                    String[] getCommandParams = paramsList.ToArray();
                    if (command.CommandGreedyArg)
                    {
                        if (commandParams.Length >= getCommandParams.Length) flag = true;
                        break;
                    }
                    if (getCommandParams.Length == commandParams.Length) flag = true;
                    break;
                }
            }
            return flag;
        }

        public static String InvokeCommand(IPlayer player, String commandCode, String[] commandParams)
        {
            if (HasCommand(commandCode))
            {
                Command command = GetCommand(commandCode);
                if (HasCommandArgs(commandCode, commandParams))
                {
                    Type type = Type.GetType("CsharpDemo.Commands.PublicCommands");
                    Object obj = type.Assembly.CreateInstance("CsharpDemo.Commands.PublicCommands");
                    String commandName = commandCode.Substring(1, commandCode.Length - 1);
                    MethodInfo method = type.GetMethod(commandName);
                    if (method != null)
                    {
                        object[] invokeParams = { player, commandParams.ToArray() };
                        method.Invoke(obj, invokeParams);
                        return "";
                    }
                    return $"未找到指令：{commandCode}";
                }
                return $"指令帮助：{command.CommandHelpText}";
            }
            return $"未找到指令：{commandCode}";
        }
    }
}
