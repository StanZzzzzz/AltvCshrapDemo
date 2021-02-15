using AltV.Net.Data;
using System;

namespace CsharpDemo.Utils
{
    /**
    * PositionHelper
    * @Author：RED
    * @Email：stan_zzzzzz@163.com
    */
    public class PositionHelper
    {
        public static Position PositionAround(Position position, float range)
        {
            Random random = new Random();
            position.X += (float)random.NextDouble() * (range * 2) - range;
            position.Y += (float)random.NextDouble() * (range * 2) - range;
            return position;
        }
    }
}
