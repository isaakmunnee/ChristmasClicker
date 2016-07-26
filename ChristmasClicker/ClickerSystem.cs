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

        public static int totalTicks;
        public static int totalRelitiveClicks;

        public static int deltaTicks;

        public static int ticksBeforeClick;
        public static int ticklevel;

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
                tdlag = value - td;
                td = value;
            }
        }

        public static int playerDelivered;
        public static int totalPlayerClicks;

        public static int playerClickModifier;

        public static int workerClicks;
        public static int workerDeliveries;

        public static float timeInSeconds;

        public static long Smiles = 0;

        public static int Parent = 0;
        public static int Grandparent = 0;
        public static int SugarDaddy = 0;
        public static int CreditCard = 0;
        public static int Elf = 0;
        public static int Workshop = 0;
        public static int ReindeerTeam = 0;
        public static int SugarElven = 0;
        public static int SugarReindeer = 0;
        public static int Sugar = 0;
        public static int Splendid = 0;
        public static int Santa = 0;

        public static void Buy(int code)
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
            int local = 0;
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
            totalDelivered += playerClickModifier;
            playerDelivered += playerClickModifier;
        }

        /* New system Implemented
        public static void WorkerClick(Worker.Worker.WorkerType addition)
        {
            workerClicks += 1;
            totalDelivered += (int)addition;
            workerDeliveries += (int)addition;
        }
        */

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
            

            if (deltaTicks * 5 > ticksBeforeClick)
            {
                Smiles += (int)Math.Pow(tdlag, 3f / 4f);
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

        public static long priceOfSpeedUpgrade(int level)
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
    }
}
