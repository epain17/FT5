using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    class ParkingLot
    {
        int maxNrCars;
        Queue<Car> carsOnTheLot = new Queue<Car>();
        ExitQueue nExit, sExit, wExit, eExit;
        EntryQueue nEntry, sEntry, wEntry, eEntry;
        Label l1, l2;

        public ParkingLot(int maxNrCars, ExitQueue nExit, ExitQueue sExit, ExitQueue wExit, ExitQueue eExit, 
            EntryQueue nEntry, EntryQueue sEntry, EntryQueue wEntry, EntryQueue eEntry, Label l1, Label l2)
        {
            this.maxNrCars = maxNrCars;
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

        
    }
}
