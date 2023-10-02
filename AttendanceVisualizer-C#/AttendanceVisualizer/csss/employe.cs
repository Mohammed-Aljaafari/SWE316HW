using System;
namespace AttendanceVisualizer
public class employe
{
	private int ID;
	private Datelist Datelist = new Datelist;
	public employe(int ID)
	{
		this.ID = ID;
	}
	public int GetTotalTime()
	{
		return Datelist.CalculateTotalTime();
	}
	public int GetID()
	{
		return ID;
	}
	public Datelist GetDatelist()
	{
		return Datelist;
	}
}
