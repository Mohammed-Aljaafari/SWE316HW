using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.ExpressionGraph.FunctionCompilers;

using Excel = Microsoft.Office.Interop.Excel;
namespace AttendanceVisualizer
{
    internal class Reader
    {
        public Reader() { }

        public Employelist Read(Excel.Workbook xWorkBook, int sheet, Employelist list)
        {
           
            Excel.Range usedRng;
            Excel.Worksheet xWorksheet = xWorkBook.Worksheets.Item[sheet];
            usedRng = xWorksheet.UsedRange;
            int numberOfRows = usedRng.Rows.Count;
            int row = 2;

            
            Excel.Range rng;
            int i = 0;


            while (row <= numberOfRows)
            {
                rng = xWorksheet.Cells[row, 1];
                Datelist datelist = new Datelist();
                if (row == 2)
                {
                    
                    employe s = new employe((int)rng.Value);
                    s.SetDatelist(datelist);
                    list.AddTolist(s);
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list.GetEmploye(i).GetDatelist().Addtolist(date);

                    row += 1;
                    i += 1;
                }
                else if (!list.GetEmploye(i - 1).GetID().Equals(new employe((int)rng.Value).GetID()))
                {


                    employe s = new employe((int)rng.Value);
                    s.SetDatelist(datelist);
                    list.AddTolist(s);
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list.GetEmploye(i).GetDatelist().Addtolist(date);
                    
                    row += 1;
                    i += 1;
                }
                else
                {
                    DATE date = new DATE((xWorksheet.Cells[row, 2].Value).ToString(), xWorksheet.Cells[row, 3].Text.ToString(), xWorksheet.Cells[row, 4].Text.ToString());
                    list.GetEmploye(i - 1).GetDatelist().Addtolist(date);
                    row += 1;
                }
            }
            return list;
        }
    }
}
