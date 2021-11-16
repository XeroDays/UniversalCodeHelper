using System;
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
    public partial class Flutter_Class : Form
    {
        string result = "";


        List<ClassProperty> properties = new List<ClassProperty>();
        public Flutter_Class()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
        private void btnExample_Click(object sender, EventArgs e)
        {
            txtEnter.Text = @"int age;
                            double price;
                            string name;
                            bool isActive;
                            ";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            initiate();
        }

        void initiate()
        {
            calibrateProperties();
            section1();
            section2();
            txtSourceCode.Text = result;
        }

        void calibrateProperties()
        {
            string prop = txtEnter.Text.Trim();

            string[] props = prop.Split(';');
            foreach (string item in props)
            {
                if (item.Split(' ').Length == 2)
                {
                    string[] sub = item.Split(' ');
                    ClassProperty obj = new ClassProperty();
                    obj.typeName = sub[0].Trim();
                    obj.propName = sub[1].Trim();
                    properties.Add(obj);
                }
            }
        }

        //this creates header
        void section1()
        {
            result = "class " + txtClassName.Text + " {\n";
        }

        // this creates properties
        void section2()
        {
            foreach (ClassProperty item in properties)
            {
                result += item.typeName + " " + item.propName + ";\n";
            }
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
    }


    class ClassProperty
    {
        public string typeName { get; set; }
        public string propName { get; set; }
    }
}

