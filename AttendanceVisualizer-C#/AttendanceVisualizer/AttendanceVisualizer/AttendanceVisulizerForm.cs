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
         
       private Employelist empolyeeslist = new Employelist( );
        private Reader reader = new Reader();
        private Drawer drawer = new Drawer();
        Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;
        public AttendanceVisulizerForm()
        {
           
            InitializeComponent();
            empolyeeslist = reader.Read(xWorkBook,1,empolyeeslist);
            SheetContents_ListBox.Items.Clear();
            foreach ( employe s in empolyeeslist.GetEmployelists())
            {
                
                SheetContents_ListBox.Items.Add( s.GetID().ToString());
            }
            

        }
        
        
        private void DrawButton_Click(object sender, EventArgs e)
        {
            
            Graphics g = TimeLineDrawingPanel.CreateGraphics();
                string item = SheetContents_ListBox.SelectedItem.ToString();
            drawer.Draw(empolyeeslist, g,  item);
            
        }

        

         
    }
}
