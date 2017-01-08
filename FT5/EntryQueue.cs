using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    class EntryQueue
    {
        int maxInQueue, currentCars;
        Queue<Car> carsInQueue = new Queue<Car>();
        Label l1;
        Random random;

        public EntryQueue(int maxInQueue, Label l1)
        {
            this.maxInQueue = maxInQueue;          
            currentCars = 0;
            this.l1 = l1;
            random = new Random();
        }

        /// <summary>
        /// Sätter task i delay
        /// </summary>
        public async void Delay()
        {
            await Task.Delay(random.Next(100, 200));
            DequeueToLot();
        }

        /// <summary>
        /// Lägger till ett car objekt till vänt listan
        /// </summary>
        /// <param name="car"></param>
        public void EnqueToEntryQueue(Car car)
        {
           
            carsInQueue.Enqueue(car);
            ++currentCars;
            l1.Invoke(new Action(delegate () { l1.Text = currentCars.ToString(); }));


        }

        /// <summary>
        /// Tar ut car objekt från kön till parkeringen.
        /// </summary>
        /// <returns></returns>
        public Car DequeueToLot()
        {
            if (carsInQueue.Count() == 0)
            {
                Delay();
            }

            Car temp;
            --currentCars;
            temp = carsInQueue.Dequeue();
            l1.Invoke(new Action(delegate () { l1.Text = currentCars.ToString(); }));

            return temp;
        }

        /// <summary>
        /// Bool som ser om kön är tom
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            if (carsInQueue.Count() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// bool som set om kön är full
        /// </summary>
        /// <returns></returns>
        public bool Full()
        {
            if (currentCars >= maxInQueue)
            {
                return true;
            }

            return false;
        }





    }
}
