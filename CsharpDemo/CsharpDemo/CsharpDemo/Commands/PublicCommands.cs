using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using CsharpDemo.Utils;
using ReLogLib;
using System;

namespace CsharpDemo.Commands
{
    /**
     * PublicCommands
     * @Author：RED
     * @Email：stan_zzzzzz@163.com
     */
    public class PublicCommands : IScript
    {
        // command test1
        public void test1(IPlayer player, object[] args)
        {
            player.Model = (uint)PedModel.Acult01AMM;
            IVehicle veh = Alt.CreateVehicle(VehicleModel.T20, PositionHelper.PositionAround(player.Position, 2), player.Rotation);
            veh.EngineOn = true;
            ReLog.ReLogService.AsyncInfo($"{player.Name}使用命令：test1");
        }

        //command veh
        public void veh(IPlayer player, object[] args)
        {
            String vehName = args[0].ToString();
            String vehHash = Enum.GetName(typeof(VehicleModel), Alt.Hash(vehName));
            String vehNumplate = args[1].ToString();
            Byte vehColor1 = Convert.ToByte(args[2]);
            Byte vehColor2 = Convert.ToByte(args[3]);
            if (vehHash == null || vehHash.Length <= 0)
            {
                ChatHelper.SendMessage(player, "[车管]", $"未找到车辆名称为：{vehName}的车辆");
                ReLog.ReLogService.AsyncInfo($"未找到玩家创建的车辆：{vehName}");
                return;
            }
            IVehicle veh = Alt.CreateVehicle(vehHash, PositionHelper.PositionAround(player.Position, 2), player.Rotation);
            veh.NumberplateText = vehNumplate;
            veh.PrimaryColor = vehColor1;
            veh.SecondaryColor = vehColor2;
            ReLog.ReLogService.AsyncInfo($"{player.Name}创建了一张{vehName}");
            ChatHelper.SendMessage(player, "[车管]", $"成功创建车辆：{vehName}");
            ReLog.ReLogService.AsyncInfo($"{player.Name}使用命令：veh");
        }
    }
}
