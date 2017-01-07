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

        public void Sleep()
        {
            Thread.Sleep(random.Next(100, 200));
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

            Car temp;
            --currentCars;
            temp = carsInQueue.Dequeue();
            l1.Invoke(new Action(delegate () { l1.Text = currentCars.ToString(); }));

            return temp;
        }

        public bool Empty()
        {
            if (carsInQueue.Count() == 0)
            {
                return true;
            }

            return false;
        }

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
