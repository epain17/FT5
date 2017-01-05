﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT5
{
    public partial class Form1 : Form
    {
        bool run;
        ParkingLot pLot;
        ControlCars cCars;

        EntryQueue northEntry;
        EntryQueue southEntry;
        EntryQueue westEntry;
        EntryQueue eastEntry;

        ExitQueue northExit;
        ExitQueue southExit;
        ExitQueue westExit;
        ExitQueue eastExit;

        
        public Form1()
        {
            InitializeComponent();
            CreateParkingLot();
        }

        public void CreateParkingLot()
        {
            northEntry = new EntryQueue(50, NorthLabel);
            southEntry = new EntryQueue(50, South);
            westEntry = new EntryQueue(50, West);
            eastEntry = new EntryQueue(50, East);

            pLot = new ParkingLot(run, 2000, northEntry, southEntry, westEntry, eastEntry, PHstatus, QueueStatus);
            cCars = new ControlCars(run, northEntry, southEntry, westEntry, eastEntry);

            northExit = new ExitQueue(pLot, run, ExitNorth);
            southExit = new ExitQueue(pLot, run, ExitSouth);
            westExit = new ExitQueue(pLot, run, ExitWest);
            eastExit = new ExitQueue(pLot, run, EastExit);

        }

        public void CreateTasks()
        {
            var t1 = new Task(() => cCars.Control());
            var neTask = new Task(() => pLot.EnqueueNorth());
            var seTask = new Task(() => pLot.EnqueueSouth());
            var weTask = new Task(() => pLot.EnqueueWest());
            var eeTask = new Task(() => pLot.EnqueueEast());

            //var enTask = new Task(() => northExit.Control());
            //var esTask = new Task(() => southExit.Control());
            //var ewTask = new Task(() => westExit.Control());
            //var eETask = new Task(() => eastExit.Control());

            t1.Start();
            neTask.Start();
            seTask.Start();
            weTask.Start();
            eeTask.Start();
            //enTask.Start();
            //esTask.Start();
            //ewTask.Start();
            //eETask.Start();

        }

       

        private void PHstatus_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            run = true;
            if(run == true)
            {
                CreateTasks();
            }
        }
    }
}
