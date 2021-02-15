using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using CsharpDemo.Utils;
using ReLogLib;
using System;

namespace CsharpDemo.Events
{
    /**
     * PlayerConnect
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class PlayerConnect : IScript
    {
        // player connect handler
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer player, String reason)
        {
            player.SetDateTime(DateTime.Now);
            player.Model = (uint)PedModel.FreemodeMale01;
            player.Spawn(new Position(15, 15, 18));
            ReLog.ReLogService.AsyncInfo($":: {player.Name} 进入了服务器 {reason}");
            ChatHelper.SendPlayerMessageAll($"{player.Name} 进入了服务器 {reason}");
        }
    }
}
