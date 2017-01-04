using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT5
{
    class EntryQueue
    {
        int maxInQueue;
        bool empty;
        Queue<Car> carsInQueue = new Queue<Car>();

        public EntryQueue(int maxInQueue)
        {
            this.maxInQueue = maxInQueue;
            empty = false;
        }



        public void EnqueToEntryQueue(Car car)
        {
            if (carsInQueue.Count != maxInQueue)
            {
                carsInQueue.Enqueue(car);

            }
           
        }

        public Car DequeueToLot()
        {
            return carsInQueue.Dequeue();
        }

        public bool Empty
        {
            get { return empty; }
            set { empty = value; }
        }



    }
}
