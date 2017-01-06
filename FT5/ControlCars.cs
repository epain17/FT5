using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FT5
{
    class ControlCars
    {
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        bool run;
        Random random;
        int carID, entryQ;

        public ControlCars(bool run, EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry)
        {
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            this.run = run;
            random = new Random();
            carID = 0;
            entryQ = 0;

        }

        public void Control()
        {
            //Console.WriteLine(run);
            while (run == true)
            {
                entryQ = random.Next(0, 5);
                AddCarsToLot(entryQ);
            }

            Sleep();
        }

        public void Sleep()
        {
            while (run != true)
            {
                Thread.Sleep(random.Next(50, 100));
            }
            Control();
        }

        public void AddCarsToLot(int Entry)
        {
            carID = random.Next(0, 3000);
            if (Entry == 1)
            {
                if (nEntry.Full() == false)
                {
                    Car car = new Car(carID);
                    nEntry.EnqueToEntryQueue(car);

                }

            }
            else if (Entry == 2)
            {
                if (sEntry.Full() == false)
                {
                    Car car = new Car(carID);
                    sEntry.EnqueToEntryQueue(car);

                }

            }
            else if (Entry == 3)
            {
                if (wEntry.Full() == false)
                {
                    Car car = new Car(carID);
                    wEntry.EnqueToEntryQueue(car);
                }
            }
            else if (Entry == 4)
            {
                if (eEntry.Full() == false)
                {
                    Car car = new Car(carID);
                    eEntry.EnqueToEntryQueue(car);
                }

            }

            Thread.Sleep(random.Next(50, 100));
            Control();
        }

        public bool Run
        {
            get { return run; }
            set { run = value; }
        }
    }
}
