using System;
namespace AttendanceVisualizer

public class DATE
{
	private string day;

	private string TimeIN;

	private string TimeOut;
	public DATE(string day, string TimeIn, string TimeOut)
	{
		this.day = day;
		this.TimeIN = TimeIn;
		this.TimeOut = TimeOut;
	}
	public string Getday() { return day; }
	public string GetTimeIN() { return TimeIN; }
	public string GetTimeOut() { return TimeOut; }
	public int Calculatetime()
	{
		if (TimeIN.equal("-") || TimeOut.equal("-")) { return 0; }
		else
		{
			return int.Parse(TimeIN) - int.Parse(TimeOut);
		}
	}
}
