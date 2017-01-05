using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    class ParkingLot
    {
        int maxNrCars;
        int currentNrCars;
        Queue<Car> carsOnTheLot = new Queue<Car>();
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        Label l1, l2;
        object mylock;
        bool run;
        Random random;

        public ParkingLot(bool run, int maxNrCars, EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry, Label l1, Label l2)
        {
            this.maxNrCars = maxNrCars;
            currentNrCars = 0;
            random = new Random();
           
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            this.l1 = l1;
            this.l2 = l2;


        }

        public void EnqueuweToLotFromEntry(Car car)
        {
            Monitor.Enter(mylock);
            while (carsOnTheLot.Count >= maxNrCars)
            {
                Monitor.Wait(mylock);
            }

            carsOnTheLot.Enqueue(car);

            Monitor.PulseAll(mylock);
            ++currentNrCars;
            l1.Invoke(new Action(delegate() { l1.Text = currentNrCars.ToString(); }));
            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

        }

        public void EnqueueNorth()
        {
            while(run == true)
            {
                Car temp;
                temp = nEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }
        }
        public void EnqueueSouth()
        {
            while (run == true)
            {
                Car temp;
                temp = sEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));

            }
        }
        public void EnqueueWest()
        {
            while (run == true)
            {
                Car temp;
                temp = wEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));

            }
        }
        public void EnqueueEast()
        {
            while (run == true)
            {
                Car temp;
                temp = eEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }
        }

        public Car DequeFromLot()
        {
            Monitor.Enter(mylock);

            while(carsOnTheLot.Count() == 0)
            {
                Monitor.Wait(mylock);
            }

            --currentNrCars;
            l1.Invoke(new Action(delegate () { l1.Text = currentNrCars.ToString(); }));

            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

            return carsOnTheLot.Dequeue();
        }


        public bool Empty()
        {
            if(carsOnTheLot.Count() == 0)
            {
                return true;
            }

            return false;
        }

    }
}
