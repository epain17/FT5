namespace FT5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParkingHousePicbox = new System.Windows.Forms.PictureBox();
            this.QueueStatus = new System.Windows.Forms.Label();
            this.PHstatus = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.NorthLabel = new System.Windows.Forms.Label();
            this.West = new System.Windows.Forms.Label();
            this.East = new System.Windows.Forms.Label();
            this.South = new System.Windows.Forms.Label();
            this.EastExit = new System.Windows.Forms.Label();
            this.ExitNorth = new System.Windows.Forms.Label();
            this.ExitWest = new System.Windows.Forms.Label();
            this.ExitSouth = new System.Windows.Forms.Label();
            this.CarsStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ParkingHousePicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // ParkingHousePicbox
            // 
            this.ParkingHousePicbox.Location = new System.Drawing.Point(122, 171);
            this.ParkingHousePicbox.Name = "ParkingHousePicbox";
            this.ParkingHousePicbox.Size = new System.Drawing.Size(421, 192);
            this.ParkingHousePicbox.TabIndex = 0;
            this.ParkingHousePicbox.TabStop = false;
            // 
            // QueueStatus
            // 
            this.QueueStatus.AutoSize = true;
            this.QueueStatus.Location = new System.Drawing.Point(130, 261);
            this.QueueStatus.Name = "QueueStatus";
            this.QueueStatus.Size = new System.Drawing.Size(75, 13);
            this.QueueStatus.TabIndex = 1;
            this.QueueStatus.Text = "Queue Status ";
            // 
            // PHstatus
            // 
            this.PHstatus.AutoSize = true;
            this.PHstatus.Location = new System.Drawing.Point(420, 261);
            this.PHstatus.Name = "PHstatus";
            this.PHstatus.Size = new System.Drawing.Size(110, 13);
            this.PHstatus.TabIndex = 2;
            this.PHstatus.Text = "Parking House Status";
            this.PHstatus.Click += new System.EventHandler(this.PHstatus_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(291, 261);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // NorthLabel
            // 
            this.NorthLabel.AutoSize = true;
            this.NorthLabel.Location = new System.Drawing.Point(291, 125);
            this.NorthLabel.Name = "NorthLabel";
            this.NorthLabel.Size = new System.Drawing.Size(79, 13);
            this.NorthLabel.TabIndex = 4;
            this.NorthLabel.Text = "Entrance North";
            // 
            // West
            // 
            this.West.AutoSize = true;
            this.West.Location = new System.Drawing.Point(13, 246);
            this.West.Name = "West";
            this.West.Size = new System.Drawing.Size(84, 13);
            this.West.TabIndex = 5;
            this.West.Text = "Enterance West";
            // 
            // East
            // 
            this.East.AutoSize = true;
            this.East.Location = new System.Drawing.Point(588, 246);
            this.East.Name = "East";
            this.East.Size = new System.Drawing.Size(80, 13);
            this.East.TabIndex = 6;
            this.East.Text = "Enterance East";
            // 
            // South
            // 
            this.South.AutoSize = true;
            this.South.Location = new System.Drawing.Point(291, 408);
            this.South.Name = "South";
            this.South.Size = new System.Drawing.Size(87, 13);
            this.South.TabIndex = 7;
            this.South.Text = "Enterance South";
            // 
            // EastExit
            // 
            this.EastExit.AutoSize = true;
            this.EastExit.Location = new System.Drawing.Point(591, 270);
            this.EastExit.Name = "EastExit";
            this.EastExit.Size = new System.Drawing.Size(48, 13);
            this.EastExit.TabIndex = 8;
            this.EastExit.Text = "East Exit";
            // 
            // ExitNorth
            // 
            this.ExitNorth.AutoSize = true;
            this.ExitNorth.Location = new System.Drawing.Point(291, 147);
            this.ExitNorth.Name = "ExitNorth";
            this.ExitNorth.Size = new System.Drawing.Size(53, 13);
            this.ExitNorth.TabIndex = 9;
            this.ExitNorth.Text = "North Exit";
            // 
            // ExitWest
            // 
            this.ExitWest.AutoSize = true;
            this.ExitWest.Location = new System.Drawing.Point(16, 263);
            this.ExitWest.Name = "ExitWest";
            this.ExitWest.Size = new System.Drawing.Size(52, 13);
            this.ExitWest.TabIndex = 10;
            this.ExitWest.Text = "Exit West";
            // 
            // ExitSouth
            // 
            this.ExitSouth.AutoSize = true;
            this.ExitSouth.Location = new System.Drawing.Point(294, 425);
            this.ExitSouth.Name = "ExitSouth";
            this.ExitSouth.Size = new System.Drawing.Size(55, 13);
            this.ExitSouth.TabIndex = 11;
            this.ExitSouth.Text = "Exit South";
            // 
            // CarsStatus
            // 
            this.CarsStatus.AutoSize = true;
            this.CarsStatus.Location = new System.Drawing.Point(507, 513);
            this.CarsStatus.Name = "CarsStatus";
            this.CarsStatus.Size = new System.Drawing.Size(80, 13);
            this.CarsStatus.TabIndex = 12;
            this.CarsStatus.Text = "How many cars";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 555);
            this.Controls.Add(this.CarsStatus);
            this.Controls.Add(this.ExitSouth);
            this.Controls.Add(this.ExitWest);
            this.Controls.Add(this.ExitNorth);
            this.Controls.Add(this.EastExit);
            this.Controls.Add(this.South);
            this.Controls.Add(this.East);
            this.Controls.Add(this.West);
            this.Controls.Add(this.NorthLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PHstatus);
            this.Controls.Add(this.QueueStatus);
            this.Controls.Add(this.ParkingHousePicbox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ParkingHousePicbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ParkingHousePicbox;
        private System.Windows.Forms.Label QueueStatus;
        private System.Windows.Forms.Label PHstatus;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label NorthLabel;
        private System.Windows.Forms.Label West;
        private System.Windows.Forms.Label East;
        private System.Windows.Forms.Label South;
        private System.Windows.Forms.Label EastExit;
        private System.Windows.Forms.Label ExitNorth;
        private System.Windows.Forms.Label ExitWest;
        private System.Windows.Forms.Label ExitSouth;
        private System.Windows.Forms.Label CarsStatus;
    }
}

