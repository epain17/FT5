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
        ParkingLot pLot;
        Random random;
        Label l1;
        int nrCars, delay;
       

        public ExitQueue(ParkingLot pLot, Label l1)
        {
            nrCars = 0;
            this.pLot = pLot;
            random = new Random();
            this.l1 = l1;
           
        }

        /// <summary>
        /// Sålänge kön inte är tom så tas car objekt ut från parkeringen. annars sätts tråden i delay
        /// </summary>
        public async void Control()
        {
            while(pLot.Empty() == false)
            {
                delay = pLot.Delay;
                await Task.Delay(delay);
                
                pLot.DequeFromLot();
                ++nrCars;
                l1.Invoke(new Action(delegate () { l1.Text = nrCars.ToString(); }));
            }

            Delay();
        }

        /// <summary>
        /// sätter task i delay
        /// </summary>
        public async void Delay()
        {
            while (pLot.Empty() != false)
            {
                await Task.Delay(random.Next(1000, 1500));
            }
            Control();
        }


 

     
    }
}
