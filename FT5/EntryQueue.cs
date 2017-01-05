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
        bool empty, full;
        Queue<Car> carsInQueue = new Queue<Car>();
        Label l1;
        Random random;

        public EntryQueue(int maxInQueue, Label l1)
        {
            this.maxInQueue = maxInQueue;
            empty = true;
            full = false;
            currentCars = 0;
            this.l1 = l1;
            random = new Random();
        }

        public void Sleep()
        {
            Thread.Sleep(random.Next(1000, 2000));
            DequeueToLot();
        }

        public void EnqueToEntryQueue(Car car)
        {

            carsInQueue.Enqueue(car);
            ++currentCars;
            l1.Invoke(new Action(delegate () { l1.Text = currentCars.ToString(); }));


        }

        public Car DequeueToLot()
        {
            if (carsInQueue.Count() == 0)
            {
                Sleep();
            }
            --currentCars;
            return carsInQueue.Dequeue();
        }

        public bool Empty()
        {
            if (carsInQueue.Count() == 0)
            {
                return empty = true;
            }

            return empty = false;
        }

        public bool Full()
        {
            if (currentCars >= maxInQueue)
            {
                return full = true;
            }

            return full = false;
        }





    }
}
