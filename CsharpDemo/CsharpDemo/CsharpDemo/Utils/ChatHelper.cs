using AltV.Net;
using AltV.Net.Elements.Entities;
using CsharpDemo.Entity;
using CsharpDemo.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpDemo.Utils
{
    /**
     * ChatHelper
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class ChatHelper : IScript
    {
        [ClientEvent("ChatMessage")]
        public void ChatMessage(IPlayer player, String message)
        {
            if (message.Length <= 0) return;
            if (message.IndexOf('/') == -1 || message.IndexOf('/') > 0) PlayerChat.PlayerChatMessage(player, message);
            if (message.IndexOf('/') == 0)
            {
                String[] commandArgs = message.Split(" ");
                IList<String> commandParamsList = commandArgs.ToList();
                commandParamsList.RemoveAt(0);
                String[] commandParams = commandParamsList.ToArray();
                String commandErrorMessage = CommandsHelper.InvokeCommand(player, commandArgs[0], commandParams);
                Command command = CommandsHelper.GetCommand(commandArgs[0]);
                String commandDesc = command == null ? "无描述" : command.CommandDesc;
                PlayerChat.PlayerCommand(player, commandArgs[0], commandDesc, commandErrorMessage);
                return;
            }
        }

        public static void SendPlayerMessage(IPlayer player, String message)
        {
            player.Emit("chatmessage", player.Name, message);
        }
        
        public static void SendMessage(IPlayer player, String messageFrom, String message)
        {
            player.Emit("chatmessage", messageFrom, message);
        }

        public static void SendPlayerMessageRange(IPlayer player, String message, float range)
        {
            foreach (IPlayer targetPlayer in Alt.GetAllPlayers())
                if (targetPlayer.Position.Distance(player.Position) <= range)
                    targetPlayer.Emit("chatmessage", player.Name, message);
        } 
        
        public static void SendMessageRange(IPlayer player, String messageFrom, String message, float range)
        {
            foreach (IPlayer targetPlayer in Alt.GetAllPlayers())
                if (targetPlayer.Position.Distance(player.Position) <= range)
                    targetPlayer.Emit("chatmessage", messageFrom, message);
        }

        public static void SendPlayerMessageAll(String message)
        {
            foreach (IPlayer targetPlayer in Alt.GetAllPlayers())
                targetPlayer.Emit("chatmessage", "[全部]", message);
        }
    }
}
