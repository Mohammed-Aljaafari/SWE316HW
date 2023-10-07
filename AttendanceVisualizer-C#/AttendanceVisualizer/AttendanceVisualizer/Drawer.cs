using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace AttendanceVisualizer
{
    internal class Drawer

        
    {
        public Drawer()
        {

        }
   
        public void Draw(Employelist list, Graphics g, string item)
        {
            Pen GrayPen = new Pen(Color.Gray);
            
            g.Clear(Color.White);
            int Barx = 1;
            int Bary = 15;
            Drawdays(Barx, Bary, GrayPen, g);
            Barx = 75;
            DrawHours(Barx, g);

            foreach (employe s in list.GetEmployelists())
            {
                int barx = 35;
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

                            g.FillRectangle(Brushes.Green, barx * (int)TimeSpan.Parse(s.GetDatelist().Getitem(i).GetTimeIN()).TotalHours, bary, barWidth, 5);
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
        public static void Drawdays(int Barx, int Bary, Pen GrayPen, Graphics g)
        {
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
        }
        public static void DrawHours(int Barx, Graphics g)
        {
            for (int i = 1; i <= 24; i++)
            {
                int Bary = 1;
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
        }

    }
}
