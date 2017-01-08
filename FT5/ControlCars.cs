using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    class ControlCars
    {
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        bool run;
        Random random;
        int carID, entryQ, delay;
        object mylock;

        public ControlCars(bool run, EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry)
        {
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            this.run = run;
            mylock = new object();
            random = new Random();
            carID = 0;
            entryQ = 0;

        }

        /// <summary>
        /// Lägger en bil i en utav ingångarna. 
        /// </summary>
        public async void Control()
        {
            while (run == true)
            {
                entryQ = random.Next(0, 5);
                AddCarsToLot(entryQ);
                await Task.Delay(300);

            }

            Delay();
        }

        /// <summary>
        /// sätter tråd på delay om run boolen är false
        /// </summary>
        public async void Delay()
        {
            while (run != true)
            {
                await Task.Delay(DelayRandom);
            }
            Control();
        }

        /// <summary>
        /// Lägger till bilar random väntkö till parkeringen
        /// </summary>
        /// <param name="Entry"></param>
        public void AddCarsToLot(int Entry)
        {
            carID = carID + 2;
            Car car = new Car(carID);
            if (Entry == 1 && nEntry.Full() == false)
            {

                nEntry.EnqueToEntryQueue(car);

            }
            else if (Entry == 2 && sEntry.Full() == false)
            {

                sEntry.EnqueToEntryQueue(car);

            }
            else if (Entry == 3 && wEntry.Full() == false)
            {

                wEntry.EnqueToEntryQueue(car);

            }
            else if (Entry == 4 && eEntry.Full() == false)
            {
                eEntry.EnqueToEntryQueue(car);

            }

            Thread.Sleep(random.Next(50, 100));
            Control();
        }

        /// <summary>
        /// retunerar en random int
        /// </summary>
        /// <returns></returns>
        public int DelayRandom
        {        
            get { return delay = random.Next(200, 500); }
            
        }

        /// <summary>
        /// property för boolen run
        /// </summary>
        public bool Run
        {
            get { return run; }
            set { run = value; }
        }

    }
}
