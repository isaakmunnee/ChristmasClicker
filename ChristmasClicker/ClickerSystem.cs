using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasClicker
{
    public static class ClickerSystem
    {
        public static int totalTicks;
        public static int totalRelitiveClicks;

        public static int deltaTicks;

        public static int ticksBeforeClick;

        public static int totalDelivered;

        public static int playerDelivered;
        public static int totalPlayerClicks;

        public static int playerClickModifier;

        public static int workerClicks;
        public static int workerDeliveries;

        public static float timeInSeconds;

        public static void AddClickViaPlayer()
        {
            totalPlayerClicks++;
            totalDelivered += playerClickModifier;
            playerDelivered += playerClickModifier;
        }

        public static void WorkerClick(Worker.Worker.WorkerType addition)
        {
            workerClicks += 1;
            totalDelivered += (int)addition;
            workerDeliveries += (int)addition;
        }

        public static void Initialise()
        {
            totalDelivered = 0;
            playerDelivered = 0;
            totalRelitiveClicks = 0;
            playerClickModifier = 1;
            workerClicks = 0;
            workerDeliveries = 0;
            ticksBeforeClick = 100;
            totalPlayerClicks = 0;
            deltaTicks = 0;
        }

        public static void Tick(Object myObject, EventArgs myEventArgs)
        {
            totalTicks++;
            deltaTicks++;

            timeInSeconds += 0.01f;

            if(deltaTicks > ticksBeforeClick)
            {
                Click();
            }

            Program.myTimer.Enabled = true;
        }

        public static void Click()
        {
            deltaTicks = 0;
            totalRelitiveClicks++;
        }
    }
}
