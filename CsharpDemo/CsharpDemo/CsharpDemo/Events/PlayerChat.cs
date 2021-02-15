using AltV.Net.Elements.Entities;
using CsharpDemo.Utils;
using ReLogLib;
using System;

namespace CsharpDemo.Events
{
    /**
     * PlayerChat
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class PlayerChat
    {
        public static void PlayerChatMessage(IPlayer player, String message)
        {
            ChatHelper.SendPlayerMessageRange(player, message, 25);
            ReLog.ReLogService.AsyncInfo($":: [聊天信息]：{player.Name} 说 {message}");
        }

        public static void PlayerCommand(IPlayer player, String command, String commandDesc, String errorMessage)
        {
            if (errorMessage.Length > 0)
            {
                ChatHelper.SendMessage(player, "[指令信息]", $"使用指令{command}失败 错误信息：{errorMessage}");
                ReLog.ReLogService.AsyncInfo($":: [指令信息]：{player.Name} 使用错误指令 {command} 错误信息：{errorMessage}");
                return;
            }
            ChatHelper.SendMessage(player, "[指令信息]", $"成功使用指令：{command} , 描述：{commandDesc}");
            ReLog.ReLogService.AsyncInfo($":: [指令信息]：{player.Name} 使用指令 {command}");
        }
    }
}
