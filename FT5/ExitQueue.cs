using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    class ExitQueue
    {
        Queue<Car> carExitQueue = new Queue<Car>();
        ParkingLot pLot;
        int nrCars;
        bool run;
        Random random;
        Label l1;

        public ExitQueue(ParkingLot pLot, bool run, Label l1)
        {
            nrCars = 0;
            this.pLot = pLot;
            this.run = run;
            random = new Random();
            this.l1 = l1;
        }

        public void Sleep()
        {
            while (pLot.Empty() != false)
            {
                Thread.Sleep(random.Next(1000, 1500));
            }
            Control();
        }

        public void Control()
        {
            while(pLot.Empty() == false)
            {
                Car temp;
                temp = pLot.DequeFromLot();
                CarToExit(temp);
                Thread.Sleep(random.Next(3000, 5000));
                ++nrCars;
                l1.Invoke(new Action(delegate () { l1.Text = nrCars.ToString(); }));
            }

            Sleep();
        }

        public void CarToExit(Car car)
        {
            carExitQueue.Enqueue(car);
        }
    }
}
