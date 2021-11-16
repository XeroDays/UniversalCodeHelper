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
        string nl = "\r\n";
        string tab = "       ";


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
            txtEnter.Text = @"int age;"+nl+"double price;"+nl+"string name;"+nl+"bool isActive;";
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
            section3();
            section4();
            section5();
            txtSourceCode.Text = result;  
        }

        void calibrateProperties()
        {
            properties.Clear();
            string prop = txtEnter.Text.Trim();
            string[] props = prop.Split(Environment.NewLine);

            foreach (string item in props)
            {
                string clean1 = item.Replace(';', ' ');
                string clean2 = clean1.Trim();
                string[] subs= clean2.Split(' ');

                List<string> parts = new List<string>();

                foreach (string subitem in subs)
                {
                    if (subitem.Trim() != string.Empty)
                        parts.Add(subitem);
                }

                if (parts.Count == 2)
                {
                    
                    ClassProperty obj = new ClassProperty();
                    obj.typeName = parts.First();
                    obj.propName = parts.Last();
                    properties.Add(obj);
                }
            }  
        }

        //this creates header
        void section1()
        {
            result = "class " + txtClassName.Text + nl+"{"+ nl;
        }

        // this creates properties
        void section2()
        {
            foreach (ClassProperty item in properties)
            {
                if(item.typeName=="string")
                {
                    result += tab + "String" + " " + item.propName + ";" + nl;
                }
                else
                {
                    result += tab + item.typeName + " " + item.propName + ";" + nl;
                }
               
            }
        }

        //create construction
        void section3()
        {
           
            result += nl+ tab+ txtClassName.Text+ nl+tab+"({"+nl;

            foreach (ClassProperty item in properties)
            {
                result += tab+tab + "this." + item.propName+"," + nl;
            }

            result += tab + "});";
 
        }
         
        
        void section4()
        {
            result += nl + nl + tab + "Map<String, dynamic> toJson() => {" + nl;
            foreach (ClassProperty item in properties)
            {
                result += tab + tab + "\"" + item.propName + "\" : " + item.propName+","+nl;
            }

            result += tab + "};";
        }

        void section5()
        {
            result += nl + nl + tab + "factory "+txtClassName.Text+".fromJson(dynamic json) => "+txtClassName.Text+"(" + nl;
            foreach (ClassProperty item in properties)
            {
                result += tab + tab +   item.propName + " : " + "json[\""+item.propName+"\"]" + "," + nl;
            }
            result += tab + ");";
            result += nl + "}";
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

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSourceCode.Text);
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

