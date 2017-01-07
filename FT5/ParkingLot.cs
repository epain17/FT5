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
        PictureBox p1;
        object mylock;
        Random random;

        public ParkingLot(int maxNrCars, EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry,
            EntryQueue eEntry, Label l1, Label l2, PictureBox p1)
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
            this.p1 = p1;

            n = 1;
            s = 2;
            w = 3;
            e = 4;

            mylock = new object();

        }

        public void Sleep(int queue)
        {

            Thread.Sleep(random.Next(100, 500));

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
                p1.Invoke(new Action(delegate { p1.BackColor = System.Drawing.Color.Red; }));
                Monitor.Wait(mylock);
            }
            p1.Invoke(new Action(delegate { p1.BackColor = System.Drawing.Color.Green; }));

            Monitor.PulseAll(mylock);

            carsOnTheLot.Enqueue(car);

            Monitor.PulseAll(mylock);
            ++currentNrCars;
            l1.Invoke(new Action(delegate () { l1.Text = currentNrCars.ToString(); }));
            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

        }

        public void EnqueueNorth()
        {
           
            while (nEntry.Empty() == false)
            {
                if (nEntry.Empty() == true) { break; }
                Car temp;
                temp = nEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                Thread.Sleep(random.Next(200, 500));
            }

            Sleep(n);
        }
        public void EnqueueSouth()
        {
            while (sEntry.Empty() == false)
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
            while (wEntry.Empty() == false)
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
            while (eEntry.Empty() == false)
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
