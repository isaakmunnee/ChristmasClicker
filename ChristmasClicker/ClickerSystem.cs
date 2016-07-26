using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasClicker
{
    public static class ClickerSystem
    {
        public static bool cheatMode;

        public static DateTime start = DateTime.Now;
        public static DateTime end = start.AddMinutes(10);

        public static long totalTicks;
        public static long totalRelitiveClicks;

        public static long deltaTicks;

        public static long ticksBeforeClick;
        public static long ticklevel;

        public static long td;
        public static long tdlag;
        public static long totalDelivered
        {
            get
            {
                return td;
            }
            set
            {
                if(value - td > 0)
                    tdlag = value - td;
                td = value;
            }
        }

        public static long playerDelivered;
        public static long totalPlayerClicks;

        public static long playerClickModifier = 1;

        public static long workerClicks;
        public static long workerDeliveries;

        public static long Smiles = 0;

        public static long Parent = 0;
        public static long Grandparent = 0;
        public static long SugarDaddy = 0;
        public static long CreditCard = 0;
        public static long Elf = 0;
        public static long Workshop = 0;
        public static long ReindeerTeam = 0;
        public static long SugarElven = 0;
        public static long SugarReindeer = 0;
        public static long Sugar = 0;
        public static long Splendid = 0;
        public static long Santa = 0;

        public static float cps;
        public static float deltaclique;
        public static float lagclique;

        public static void Buy(long code)
        {
            switch (code)
            {
                case 0:
                    if (Smiles < 10)
                        return;

                    if (Parent < 2)
                    {
                        Parent++;
                        Smiles -= 10;
                    }
                    break;
                case 1:
                    if (Smiles < 25)
                        return;

                    if (Grandparent < 4)
                    {
                        Grandparent++;
                        Smiles -= 25;
                    }
                    break;
                case 2:
                    if (Smiles < 100)
                        return;

                    if (SugarDaddy < 10)
                    {
                        SugarDaddy++;
                        Smiles -= 100;
                    }
                    break;
                case 3:
                    if (Smiles < 200)
                        return;

                    if (CreditCard < 5)
                    {
                        CreditCard++;
                        Smiles -= 200;
                    }
                    break;
                case 4:
                    if (Smiles < 5000)
                        return;

                    if (Elf < 50)
                    {
                        Elf++;
                        Smiles -= 5000;
                    }
                    break;
                case 5:
                    if (Smiles < 15000)
                        return;

                    if (Workshop < 10)
                    {
                        Workshop++;
                        Smiles -= 15000;
                    }
                    break;
                case 6:
                    if (Smiles < 25000)
                        return;

                    if (ReindeerTeam < 10)
                    {
                        ReindeerTeam++;
                        Smiles -= 25000;
                    }
                    break;
                case 7:
                    if (Smiles < 250000)
                        return;

                    if (SugarElven < 10)
                    {
                        SugarElven++;
                        Smiles -= 250000;
                    }
                    break;
                case 8:
                    if (Smiles < 1000000)
                        return;

                    if (SugarReindeer < 5)
                    {
                        SugarReindeer++;
                        Smiles -= 1000000;
                    }
                    break;
                case 9:
                    if (Smiles < 10000000)
                        return;

                    if (Sugar < 25)
                    {
                        Sugar++;
                        Smiles -= 10000000;
                    }
                    break;
                case 10:
                    if (Smiles < 50000000)
                        return;

                    if (Splendid < 25)
                    {
                        Splendid++;
                        Smiles -= 50000000;
                    }
                    break;
                case 11:
                    if (Smiles < 500000000)
                        return;

                    if (Santa < 2)
                    {
                        Santa++;
                        Smiles -= 500000000;
                    }
                    break;
            }
        }

        public static void ClickWorkers()
        {
            long local = 0;
            local += Parent * 5;
            local += Grandparent * 15;
            local += SugarDaddy * 50;
            local += CreditCard * 100;
            local += Elf * 500;
            local += Workshop * 1000;
            local += ReindeerTeam * 5000;
            local += SugarElven * 50000;
            local += SugarReindeer * 250000;
            local += Sugar * 1000000;
            local += Splendid * 5000000;
            local += Santa * 50000000;

            totalDelivered += local;
            workerDeliveries += local;

            local = 0;
            local += Parent;
            local += Grandparent;
            local += SugarDaddy;
            local += CreditCard;
            local += Elf;
            local += Workshop;
            local += ReindeerTeam;
            local += SugarElven;
            local += SugarReindeer;
            local += Sugar;
            local += Splendid;
            local += Santa;

            workerClicks += local;
        }

        public static void AddClickViaPlayer()
        {
            totalPlayerClicks++;
            td += playerClickModifier;
            tdlag += (long)Math.Ceiling(playerClickModifier / 2f);
            playerDelivered += playerClickModifier;
        }

        /* New system Implemented
        public static void WorkerClick(Worker.Worker.WorkerType addition)
        {
            workerClicks += 1;
            totalDelivered += (long)addition;
            workerDeliveries += (long)addition;
        }
        */

        public static void Initialise()
        {
            totalDelivered = 0;
            playerDelivered = 0;
            totalRelitiveClicks = 0;
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
            if (deltaTicks * 5 > ticksBeforeClick)
            {
                Smiles += (long)Math.Pow(tdlag, 3f / 4f);
                tdlag /= 2;
            }

            if (deltaTicks > ticksBeforeClick)
            {
                Click();
            }
            
            Program.myTimer.Enabled = true;
        }

        public static void Click()
        {
            deltaTicks = 0;
            totalRelitiveClicks++;
            ClickWorkers();
        }

        public static void BuySpeedUpgrade()
        {
            if (Smiles < priceOfSpeedUpgrade(ticklevel))
                return;

            Smiles -= priceOfSpeedUpgrade(ticklevel);
            ticksBeforeClick -= 5;
            ticklevel++;
        }

        public static long priceOfSpeedUpgrade(long level)
        {
            switch (level)
            {
                case 0:
                    return 10;
                case 1:
                    return 100;
                case 2:
                    return 1000;        //1k
                case 3:
                    return 5000;        //5k
                case 4:
                    return 10000;       //10k
                case 5:
                    return 50000;       //50k
                case 6:
                    return 100000;      //100k
                case 7:
                    return 500000;      //500k
                case 8:
                    return 1000000;     //1mil
                case 9:
                    return 5000000;     //5mil
                case 10:
                    return 10000000;    //10mil
                case 11:
                    return 50000000;    //50mil
                case 12:
                    return 100000000;   //100mil
                case 13:
                    return 500000000;   //500mil
                default:
                    return 1000000000;  //1billion


            }
        }

        public static void PresentsToSmiles(long code)
        {
            switch (code)
            {
                case 0:
                    if (ClickerSystem.totalDelivered < 100)
                        return;

                    ClickerSystem.totalDelivered -= 100;
                    ClickerSystem.Smiles += (long)1;
                    return;

                case 1:
                    if (ClickerSystem.totalDelivered < 100000)
                        return;

                    ClickerSystem.totalDelivered -= 100000;
                    ClickerSystem.Smiles += 1000;
                    return;

                case 2:
                    if (ClickerSystem.totalDelivered < 5000000)
                        return;

                    ClickerSystem.totalDelivered -= 50000000;
                    ClickerSystem.Smiles += 2500000;
                    return;

                case 3:
                    if (ClickerSystem.totalDelivered < 1000000000)
                        return;

                    ClickerSystem.totalDelivered -= 1000000000;
                    ClickerSystem.Smiles += 50000000;
                    return;

                case 4:
                    if (ClickerSystem.totalDelivered < 10000000000)
                        return;

                    ClickerSystem.totalDelivered -= 10000000000;
                    ClickerSystem.Smiles += 450000000;
                    return;

                default:
                    return;
            }
        }

        public class ClickLevel
        {
            public long upgrade;
            public long cost;

            public ClickLevel (long up, long c)
            {
                upgrade = up;
                cost = c;
            }
        }

        public static ClickLevel Qlickque(long code)
        {
            switch (code)
            {
                case 0:
                    return new ClickLevel(2, 20);
                case 1:
                    return new ClickLevel(5, 50);
                case 2:
                    return new ClickLevel(10, 100);
                case 3:
                    return new ClickLevel(25, 500);
                case 4:
                    return new ClickLevel(50, 1000);
                case 5:
                    return new ClickLevel(100, 5000);
                case 6:
                    return new ClickLevel(250, 10000);
                case 7:
                    return new ClickLevel(500, 50000);
                case 8:
                    return new ClickLevel(1000, 100000);
                case 9:
                    return new ClickLevel(5000, 500000);
                case 10:
                    return new ClickLevel(10000, 100000);
                case 11:
                    return new ClickLevel(100000, 5000000);
                case 12:
                    return new ClickLevel(250000, 7000000);
                case 13:
                    return new ClickLevel(500000, 10000000);
                case 14:
                    return new ClickLevel(1000000, 50000000);
                case 15:
                    return new ClickLevel(5000000, 150000000);
                case 16:
                    return new ClickLevel(10000000, 250000000);
                case 17:
                    return new ClickLevel(25000000, 500000000);
                case 18:
                    return new ClickLevel(50000000, 750000000);
                case 19:
                    return new ClickLevel(100000000, 1000000000);
                case 20:
                    return new ClickLevel(500000000, 10000000000);
                case 21:
                    return new ClickLevel(1000000000, 100000000000);
                case 22:
                    return new ClickLevel(5000000000, 1000000000000);
                case 23:
                    return new ClickLevel(10000000000, 10000000000000);
                default:
                    return null;
            }
        }
        public static void BuyClickingUpgrade(long code)
        {
            ClickLevel cl = Qlickque(code);

            if (Smiles < cl.cost)
                return;

            Smiles -= cl.cost;
            playerClickModifier += cl.upgrade;
        }
    }
}
