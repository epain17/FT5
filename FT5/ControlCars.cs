using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT5
{
    class ControlCars
    {
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        bool run;
        Random random;
        int carID, entryQ;

        public ControlCars(EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry)
        {
            this.nEntry = nEntry;
            this.sEntry = sEntry;
            this.wEntry = wEntry;
            this.eEntry = eEntry;
            run = false;
            random = new Random();
            carID = 0;
            entryQ = 0;
            
        }

        public void Control()
        {
            while(run == true)
            {
                entryQ = random.Next(0, 5);
                AddCarsToLot(entryQ);
            }
        }

        public void AddCarsToLot(int Entry)
        {
            carID = random.Next(0, 3000);
            if(Entry == 1)
            {
                Car car = new Car(carID);
                nEntry.EnqueToEntryQueue(car);
            }
            else if(Entry == 2)
            {
                Car car = new Car(carID);
                sEntry.EnqueToEntryQueue(car);
            }
            else if(Entry == 3)
            {
                Car car = new Car(carID);
                wEntry.EnqueToEntryQueue(car);
            }
            else if(Entry == 4)
            {
                Car car = new Car(carID);
                eEntry.EnqueToEntryQueue(car);
            }
        }
    }
}
