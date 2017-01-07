using System;
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
        bool run = false;
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
            CreateTasks();
        }

        public void CreateParkingLot()
        {
            northEntry = new EntryQueue(50, NorthEntryUnits);
            southEntry = new EntryQueue(50, SouthEntryUnits);
            westEntry = new EntryQueue(50, WestEntryUnits);
            eastEntry = new EntryQueue(50, EastEntryUnits);

            pLot = new ParkingLot(100, northEntry, southEntry, westEntry, eastEntry, PHstatus, QueueStatus, ParkingHousePicbox);
            cCars = new ControlCars(run, northEntry, southEntry, westEntry, eastEntry);

            northExit = new ExitQueue(pLot, NorthExitUnits);
            southExit = new ExitQueue(pLot, SouthExitUnits);
            westExit = new ExitQueue(pLot, WestExitUnits);
            eastExit = new ExitQueue(pLot, EastExitUnits);

            ParkingHousePicbox.BackColor = Color.Green;

        }

        public void CreateTasks()
        {
            var t1 = Task.Factory.StartNew(() => cCars.Control());
            var neTask = Task.Factory.StartNew(() => pLot.EnqueueNorth());
            var seTask = Task.Factory.StartNew(() => pLot.EnqueueSouth());
            var weTask = Task.Factory.StartNew(() => pLot.EnqueueWest());
            var eeTask = Task.Factory.StartNew(() => pLot.EnqueueEast());

            var enTask = Task.Factory.StartNew(() => northExit.Control());
            var esTask = Task.Factory.StartNew(() => southExit.Control());
            var ewTask = Task.Factory.StartNew(() => westExit.Control());
            var eETask = Task.Factory.StartNew(() => eastExit.Control());
        }



        private void PHstatus_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            if (run == false)
            {
                run = true;
                cCars.Run = true;
                StartButton.Text = "Open";
            }
            else if (run == true)
            {
                run = false;
                cCars.Run = false;
                StartButton.Text = "Close";

            }
        }
    }
}
