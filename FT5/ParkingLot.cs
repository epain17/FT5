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

        /// <summary>
        /// Metoden tar in ett Car obejct från vald kö och lägger till den i parkeringens Queue sålänge den inte är full
        /// </summary>
        /// <param name="car"></param>
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

        /// <summary>
        /// 4 tasks jobbar på varsin ingång till parkeringen och lägger till från respektive 
        /// väntkö sålänge den inte är tom. Den sätts i delay om kön är tom.
        /// </summary>
        public async void EnqueueNorth()
        {
           
            while (nEntry.Empty() == false)
            {
                if (nEntry.Empty() == true) { break; }
                Car temp;
                temp = nEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                await Task.Delay(random.Next(200, 500));
            }

            Sleep(n);
        }
        public async void EnqueueSouth()
        {
            while (sEntry.Empty() == false)
            {
                if (sEntry.Empty() == true) { break; }
                Car temp;
                temp = sEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                await Task.Delay(random.Next(200, 500));
            }

            Sleep(s);

        }
        public async void EnqueueWest()
        {
            while (wEntry.Empty() == false)
            {
                if (wEntry.Empty() == true) { break; }
                Car temp;
                temp = wEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                await Task.Delay(random.Next(200, 500));
            }
            Sleep(w);

        }
        public async void EnqueueEast()
        {
            while (eEntry.Empty() == false)
            {
                if (eEntry.Empty() == true) { break; }
                Car temp;
                temp = eEntry.DequeueToLot();
                EnqueuweToLotFromEntry(temp);
                await Task.Delay(random.Next(200, 500));
            }
            Sleep(e);

        }

        /// <summary>
        /// metod som sätter tråd i delay
        /// </summary>
        /// <param name="queue"></param>
        public async void Sleep(int queue)
        {
           
            await Task.Delay(random.Next(50, 100));

            if (queue == 1) { EnqueueNorth(); }
            else if (queue == 2) { EnqueueSouth(); }
            else if (queue == 3) { EnqueueWest(); }
            else if (queue == 4) { EnqueueEast(); }
        }

        /// <summary>
        /// metod som tarbort car object från parkeringen.
        /// </summary>
        public void DequeFromLot()
        {
            Monitor.Enter(mylock);

            while (carsOnTheLot.Count() == 0)
            {
                Monitor.Wait(mylock);
            }
            carsOnTheLot.Dequeue();
            --currentNrCars;
            l1.Invoke(new Action(delegate () { l1.Text = currentNrCars.ToString(); }));

            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

            
        }

        /// <summary>
        /// bool som ser om parkeringen är tom
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            if (carsOnTheLot.Count() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// int som retunerar ett random värde till exit queues.
        /// </summary>
        public int Delay
        {
            get { return random.Next(2000, 5000); }
        }

    }
}
