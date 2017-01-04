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
        ExitQueue nExit, sExit, wExit, eExit;
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        Label l1, l2;
        object mylock;


        public ParkingLot(int maxNrCars, ExitQueue nExit, ExitQueue sExit, ExitQueue wExit, ExitQueue eExit,
            EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry, Label l1, Label l2)
        {
            this.maxNrCars = maxNrCars;
            currentNrCars = 0;

            this.nExit = nExit;
            this.sExit = sExit;
            this.wExit = wExit;
            this.eExit = eExit;
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            this.l1 = l1;
            this.l2 = l2;


        }

        public void EnqueuweToLotFromEntry(int QueueSelect)
        {
            Monitor.Enter(mylock);
            while (carsOnTheLot.Count >= maxNrCars)
            {
                Monitor.Wait(mylock);
            }

            if (QueueSelect == 1)
            {
                carsOnTheLot.Enqueue(nEntry.DequeueToLot());
            }
            else if (QueueSelect == 2)
            {
                carsOnTheLot.Enqueue(sEntry.DequeueToLot());

            }
            else if (QueueSelect == 3)
            {
                carsOnTheLot.Enqueue(wEntry.DequeueToLot());

            }
            else if (QueueSelect == 4)
            {
                carsOnTheLot.Enqueue(eEntry.DequeueToLot());
            }

            Monitor.PulseAll(mylock);
            ++currentNrCars;
            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

        }

        public Car DequeFromLot()
        {
            Monitor.Enter(mylock);

            while(carsOnTheLot.Count() == 0)
            {
                Monitor.Wait(mylock);
            }

            Monitor.PulseAll(mylock);
            Monitor.Exit(mylock);

            return carsOnTheLot.Dequeue();
        }


    }
}
