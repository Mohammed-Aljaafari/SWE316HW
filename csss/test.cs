using System;
namespace AttendanceVisualizer

public class test
{
	public test()
	{
		static public void Main(string[] args)
		{
			HashSet<employe> s = new HashSet<employe>();
			s.add(new employe(1));
			s.add(new employe(2));
			s.add(new employe(3));
			s.ElementAt(0).GetDatelist().Addtolist(new DATE("wen", "8", "15"));
			Console.WriteLine(s.GetTotalTime);
		}
	}
}
