using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasClicker.Worker
{
    public class Worker
    {
        public enum WorkerType
        {
            Parent = 1,
            Elf = 5,
            Robot = 15,
            Drone = 25
        }

        public Worker(WorkerType t)
        {
            type = t;
        }
        
        public WorkerType type;

        public void Tick()
        {
            ClickerSystem.WorkerClick(type);
        }
    }
}
