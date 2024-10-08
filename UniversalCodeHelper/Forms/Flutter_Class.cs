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
    public partial class Flutter_Class : Form
    {
        string result = "";
        string nl = "\r\n";
        string tab = "       ";
        string classname = "";

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
            txtEnter.Text = @"int age;" + nl + "double price;" + nl + "string name;" + nl + "bool isActive;";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            initiate();
        }

        void initiate()
        {
            classname = txtClassName.Text;
            filterTextBox();
            calibrateProperties();
            section1();
            section2();
            section3();
            section4();
            section5();
            txtSourceCode.Text = result;
        }

        void filterTextBox()
        {
            string prop = txtEnter.Text.Trim();
            string[] props = prop.Split(Environment.NewLine);
            string filtered = "";
            foreach (string item in props)
            {
                string clean1 = item.Replace("public", "");
                string clean2 = clean1.Replace("late", "");
                string clean3 = clean2.Replace("{ get; set; }", ";");
                string clean4 = clean3.Trim();
                if(clean4.Length>3)
                filtered += clean4 + "" + Environment.NewLine;
            }

            txtEnter.Text = filtered;
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
                string[] subs = clean2.Split(' ');

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
            result = "class " + classname + nl + "{" + nl;
        }

        // this creates properties
        void section2()
        {
            foreach (ClassProperty item in properties)
            {
                if (item.typeName == "string")
                {
                    result += tab + (radioLate.Checked ? "late " : "") + "String" + (radioNullSafety.Checked ? "? " : "") + " " + item.propName + ";" + nl;
                }
                else
                {
                    result += tab + (radioLate.Checked ? "late " : "") + item.typeName + (radioNullSafety.Checked ? "? " : "") + " " + item.propName + ";" + nl;
                }

            }
        }

        //create construction
        void section3()
        {
            if (radioLate.Checked)
            {
                result += nl + tab + classname + nl + tab + "();" + nl;
            }
            else
            {
                result += nl + tab + classname + nl + tab + "({" + nl;

                foreach (ClassProperty item in properties)
                {
                    result += tab + tab + (radioRequired.Checked ? "required " : "") + "this." + item.propName + "," + nl;
                }

                result += tab + "});";
            }



        }

        void section4()
        {
            result += nl + nl + tab + "Map<String, dynamic> toJson() => {" + nl;
            foreach (ClassProperty item in properties)
            {
                result += tab + tab + "\"" + item.propName.ToLower() + "\" : " + getTypebase_toJson(item) + "," + nl;
            }

            result += tab + "};";
        }

        void section5()
        {
            if (!radioRequired.Checked)
            {
                result += nl + nl + tab + "factory " + classname + ".fromJson(dynamic json) {" + nl;
                result += tab + tab + classname + " obj = " + classname + "();" + nl;
                foreach (ClassProperty item in properties)
                {
                    result += tab + tab + "obj." + item.propName + " = " + getTypeBase_fromJSon(item) + ";" + nl;
                }
                result += tab + tab + "return obj;" + nl;
                result += tab + "}";
                result += nl + "}";
            }
            else
            {
                result += nl + nl + tab + "factory " + classname + ".fromJson(dynamic json) => " + classname + "(" + nl;
                foreach (ClassProperty item in properties)
                {
                    result += tab + tab + item.propName + " : " + "json[\"" + item.propName + "\"]" + "," + nl;
                }
                result += tab + ");";
                result += nl + "}";
            }
        }


        string getTypebase_toJson(ClassProperty item)
        {
            string outted = "";
            string propertyName = item.propName;
            switch (item.typeName.ToLower())
            { 
                case "datetime":
                    outted = propertyName + ".toString()";
                    break;
                default:
                    outted = propertyName;
                    break;
            }

            return outted;
        }

        string getTypeBase_fromJSon(ClassProperty item)
        {
            // "json[\"" + item.propName.ToLower() + "\"]" + (item.typeName.ToLower().Contains("string") ? ".toString()" : "");
            string outted = "";
            string propertyName = item.propName.ToLower();
            switch (item.typeName.ToLower())
            {
                case "string":
                    outted = $"json['{propertyName}'].toString()";
                    break;
                case "datetime":
                    outted = $"DateTime.parse(json['{propertyName}'].toString())";
                    break;
                default:
                    outted = $"json['{propertyName}']";
                    break;
            }

            return outted;

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

