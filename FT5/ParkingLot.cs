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
        int n, s, w, e;
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
            this.run = run;
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            this.l1 = l1;
            this.l2 = l2;
            n = 1;
            s = 2;
            w = 3;
            e = 4;

            mylock = new object();


        }

        public void Sleep(int queue)
        {

            Console.WriteLine("thread sleeping");
            Thread.Sleep(random.Next(1000, 1500));

            if (queue == 1) { EnqueueNorth(); }
            else if (queue == 2) { EnqueueSouth(); }
            else if (queue == 3) { EnqueueWest(); }
            else if (queue == 4) { EnqueueEast(); }
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
            l1.Invoke(new Action(delegate () { l1.Text = currentNrCars.ToString(); }));
            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

        }

        public void EnqueueNorth()
        {
            while (run == true)
            {
                if (nEntry.Empty() == true) { break; }
                Car temp;
                temp = nEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Console.WriteLine("added from entry");
                Thread.Sleep(random.Next(200, 500));
            }
            Sleep(n);
        }
        public void EnqueueSouth()
        {
            while (run == true)
            {
                if (sEntry.Empty() == true) { break; }

                Car temp;
                temp = sEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }

            Sleep(s);

        }
        public void EnqueueWest()
        {
            while (run == true)
            {
                if (wEntry.Empty() == true) { break; }
                Car temp;
                temp = wEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }
            Sleep(w);

        }
        public void EnqueueEast()
        {
            while (run == true)
            {
                if (eEntry.Empty() == true) { break; }
                Car temp;
                temp = eEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }
            Sleep(e);

        }

        public Car DequeFromLot()
        {
            Monitor.Enter(mylock);

            while (carsOnTheLot.Count() == 0)
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
            if (carsOnTheLot.Count() == 0)
            {
                return true;
            }

            return false;
        }

    }
}
