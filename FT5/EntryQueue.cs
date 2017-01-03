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
        Queue<Car> carsInQueue = new Queue<Car>();

        public EntryQueue(int maxInQueue)
        {
            this.maxInQueue = maxInQueue;
        }

    }
}
