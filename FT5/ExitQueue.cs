using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT5
{
    class ExitQueue
    {
        Queue<Car> carExitQueue = new Queue<Car>();
        ParkingLot pLot;
        int max;
        bool run;

        public ExitQueue(int max, ParkingLot pLot, bool run)
        {
            this.max = max;
            this.pLot = pLot;
            run = false;
        }

        public void Control()
        {
            while(run == true)
            {
                Car temp;
                temp = pLot.DequeFromLot();
                CarToExit(temp);
            }
        }

        public void CarToExit(Car car)
        {
            carExitQueue.Enqueue(car);
        }
    }
}
