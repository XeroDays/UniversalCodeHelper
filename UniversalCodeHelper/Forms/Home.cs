﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalCodeHelper.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFlutterClassGenerate_Click(object sender, EventArgs e)
        {
            Flutter_Class frm = new Flutter_Class();
            this.Hide(); 
            frm.Disposed += Frm_Deactivate;
            frm.ShowDialog(); 

        }

        private void Frm_Deactivate(object sender, EventArgs e)
        {
            this.Show();
        }



        #region Drager
        int movX, movY;
        bool isMoving;

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            // Assign this method to mouse_Down event of Form or Panel,whatever you want
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            // Assign this method to Mouse_Move event of that Form or Panel
            if (isMoving)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            // Assign this method to Mouse_Up event of Form or Panel.
            isMoving = false;
        }
        #endregion

        private void btnLocalization_Click(object sender, EventArgs e)
        {
            Translator translator = new Translator();
            this.Hide();
            translator.Disposed += Frm_Deactivate;
            translator.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoloTxtXmlConverter translator = new YoloTxtXmlConverter();
            this.Hide();
            translator.Disposed += Frm_Deactivate;
            translator.Show();
        }
    }
}
