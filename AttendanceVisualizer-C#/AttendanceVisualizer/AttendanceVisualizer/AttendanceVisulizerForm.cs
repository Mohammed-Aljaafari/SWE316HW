using OfficeOpenXml.FormulaParsing.ExpressionGraph.FunctionCompilers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using  Excel = Microsoft.Office.Interop.Excel;
namespace AttendanceVisualizer
{
    public partial class AttendanceVisulizerForm : Form  
    {
         
        Employelist list = new Employelist( );
        Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;
        public AttendanceVisulizerForm()
        {
            Reader reader = new Reader( );
            InitializeComponent();
            list = reader.Read(xWorkBook,1,list);
            SheetContents_ListBox.Items.Clear();
            foreach ( employe s in list.GetEmployelists())
            {
                
                SheetContents_ListBox.Items.Add( s.GetID().ToString());
            }
            

        }
        //override


        private void ReadSheet_Button_Click(object sender, EventArgs e)
        {
            {
               
                
            }

        }
        //override
        
        private void DrawButton_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            Graphics g = TimeLineDrawingPanel.CreateGraphics();
                string item = SheetContents_ListBox.SelectedItem.ToString();
            drawer.Draw(list, g,  item);
            
        }

        

         
    }
}
