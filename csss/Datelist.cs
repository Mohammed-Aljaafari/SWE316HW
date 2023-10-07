using System;
namespace AttendanceVisualizer
public class Datelist
{
	private List<DATE> datalist = new List<DATE>;
	public Datelist(List<DATE>)
	{
		this.datalist = datelist;
	}
	public getdatalist()
	{
		return this.datalist;
	}
	public void Addtolist(string day, string TimeIn, string TimeOut)
	{
		datalist.add(new DATE(day, TimeIn, TimeOut));
	}
	public CalculateTotalTime()
	{
		int sum = 0;
		foreach (var item in datalist)
		{
			sum += item.TotalTime;
		}


		return sum;
	}

}
