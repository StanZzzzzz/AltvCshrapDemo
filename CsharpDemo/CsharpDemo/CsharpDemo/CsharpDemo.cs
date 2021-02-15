using AltV.Net;
using CsharpDemo.Utils;
using ReLogLib;

namespace CsharpDemo
{
    public class CsharpDemo : Resource
    {
        public override void OnStop() { }
        public override void OnStart()
        {
            ReLog.ReLogService.InitReLog();
            ReLog.ReLogService.Info("CSharp demo");
            ReLog.ReLogService.Info("@Author：RED");
            ReLog.ReLogService.Info("@Email：stan_zzzzzz@163.com");
            ReLog.ReLogService.Info("@From：Shenzhen, China");
            ReLog.ReLogService.Info("CSharp demo loading...");
            // init commands
            CommandsHelper.AddCommand("/test1", "/test1", "测试指令", false);
            CommandsHelper.AddCommand("/veh", "/veh [车辆名称] [车牌号] [颜色1] [颜色2]", "刷车", false);
            ReLog.ReLogService.Info($"Successful loading commands count: {CommandsHelper.GetCommandsCount()}");
            return;
        }
    }
}
