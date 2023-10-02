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
    public partial class AttendanceVisulizerForm : Form , Reader , Drawer
    {
        List<employe> list = new List<employe>();
        public AttendanceVisulizerForm()
        {
            InitializeComponent();
        }
        //override
        public void read()
        {
            
            Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;

                Excel.Worksheet xWorksheet = xWorkBook.Worksheets.Item[1];
                Excel.Range usedRng;
                usedRng = xWorksheet.UsedRange;
                int numberOfRows = usedRng.Rows.Count;
                int row = 2;

                SheetContents_ListBox.Items.Clear();
                SheetContents_ListBox.Items.Add("Number of Rows = " + numberOfRows.ToString());
                Excel.Range rng;
                int i = 0;


                while ( row <= numberOfRows  )
                {
                    rng = xWorksheet.Cells[row, 1];
                Datelist datelist = new Datelist();
                if (row == 2)
                {
                    SheetContents_ListBox.Items.Add(rng.Value);
                    employe s = new employe((int)rng.Value);
                    s.SetDatelist(datelist);
                    list.Add(s);
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list[i].GetDatelist().Addtolist(date);

                    row += 1;
                    i+=1;
                }
                else if (!list[i-1].GetID().Equals(new employe((int)rng.Value).GetID()))
                {


                    employe s = new employe((int)rng.Value);
                    s.SetDatelist(datelist);
                    list.Add(s);
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list[i].GetDatelist().Addtolist(date);
                    SheetContents_ListBox.Items.Add(list[i].GetID().ToString());
                    row += 1;
                    i += 1;
                }
                else {
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list[i-1].GetDatelist().Addtolist(date);
                    row += 1; }

                    //SheetContents_ListBox.Items.Add(row.ToString() + ": " );
                    
                    //list.Add(new employe(rng.Value));
                   // row += 1;
                

                }


            


        }
        

        private void ReadSheet_Button_Click(object sender, EventArgs e)
        {
            {
                read();
                
            }

        }
        //override
        public void Draw()
        {
            Pen GrayPen = new Pen(Color.Gray);
            Graphics g = TimeLineDrawingPanel.CreateGraphics();

            string item = SheetContents_ListBox.SelectedItem.ToString();
            g.Clear(Color.White);
            int Barx = 1;
            int Bary = 15;
            for (int i = 1; i <= 30; i++)
            {

                Font font = new Font("Arial", 9);
                string day = "day" + i;
                g.DrawString(day, font, Brushes.Black, Barx, Bary);
                if (i % 5 == 0)
                {
                    Point p1 = new Point(Barx, Bary + 17);
                    Point p2 = new Point(Barx + 2000, Bary + 17);
                    g.DrawLine(GrayPen, p1, p2);
                }
                Bary += 15;
            }
            Barx = 35;

            for (int i = 1; i <= 24; i++)
            {
                Bary = 1;
                String day;
                Font font = new Font("Arial", 8);
                if (i < 12) { day = i + " AM "; }
                else if (i == 12) { day = i + " PM "; }
                else if (i == 24)
                {
                    day = i - 12 + " AM ";
                }
                else
                {
                    day = i - 12 + " PM ";
                }

                g.DrawString(day, font, Brushes.Black, Barx, Bary);
                Barx += 30;
            }
            foreach (employe s in list)
            {
                int barx = 33;
                int bary = 20;
                TimeSpan c = new TimeSpan(8, 30, 0);
                int pixelPerHour = 30;
                if (s.GetID().ToString() == item)
                {
                    for (int i = 0; i < s.GetDatelist().GetSize(); i++)
                    {
                        int barWidth = (int)s.GetDatelist().Getitem(i).Calculatetime().TotalHours * pixelPerHour;

                        Font font = new Font("Arial", 9);
                        if (s.GetDatelist().Getitem(i).Calculatetime() >= c)
                        {
                            g.FillRectangle(Brushes.Green, 50, bary, 10, 10);

                            g.FillRectangle(Brushes.Green, barx * (int)TimeSpan.Parse(s.GetDatelist().Getitem(i).GetTimeIN()).TotalHours, bary, barWidth + 20, 5);
                            g.DrawString(s.GetDatelist().Getitem(i).Calculatetime().ToString(), font, Brushes.Black, barx * (int)TimeSpan.Parse(s.GetDatelist().Getitem(i).GetTimeIN()).TotalHours + barWidth + 20, bary);

                            bary += 15;
                        }
                        else if (s.GetDatelist().Getitem(i).Calculatetime() < c && s.GetDatelist().Getitem(i).Calculatetime() > new TimeSpan())
                        {
                            g.FillRectangle(Brushes.Orange, 50, bary, 10, 10);
                            g.FillRectangle(Brushes.Orange, barx * (int)TimeSpan.Parse(s.GetDatelist().Getitem(i).GetTimeIN()).TotalHours, bary, barWidth + 20, 5);
                            g.DrawString(s.GetDatelist().Getitem(i).Calculatetime().ToString(), font, Brushes.Black, barx * (int)TimeSpan.Parse(s.GetDatelist().Getitem(i).GetTimeIN()).TotalHours + barWidth + 20, bary);

                            bary += 15;
                        }
                        else if (s.GetDatelist().Getitem(i).Calculatetime().Equals(new TimeSpan(-1, 0, 0)))
                        {
                            g.FillRectangle(Brushes.Red, 50, bary, 10, 10);
                            g.DrawString("Absent", font, Brushes.Black, barx + 30, bary);

                            bary += 15;
                        }
                        else if (s.GetDatelist().Getitem(i).Calculatetime().Equals(TimeSpan.Zero))
                        {
                            g.FillRectangle(Brushes.Blue, 50, bary, 10, 10);
                            g.DrawString("Data error", font, Brushes.Black, barx + 30, bary);

                            bary += 15;
                        }


                    }
                }
            }
        }
        private void DrawButton_Click(object sender, EventArgs e)
        {
            Draw();

            
            
        }

        void Reader.Read()
        {
            throw new NotImplementedException();
        }

         void Drawer.Draw()
        {
            throw new NotImplementedException();
        }
    }
}
