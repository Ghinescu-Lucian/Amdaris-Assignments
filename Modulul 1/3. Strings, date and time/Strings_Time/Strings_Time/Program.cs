using System;
using System.Globalization;
public class Program
{
    public static void Main(string[] args)
    {
        string s = string.Format(" Time : {0}",DateTime.Now);
        Console.WriteLine(s);

        String s1 = $" Time : {DateTime.Now}";
        Console.WriteLine(s1);

        string s2 = " A string ";
        s2=s2.Insert(s2.Length, string.Format(", {0}",s1));
        Console.WriteLine(s2);

        string s3 = "       Audi, BMW, Mercedes, VW, Opel";
        string s4;
        s4=s3.Trim();
        s4=s3.ToLower();
        string [] arr = new string[10];
        arr = s4.Split(',');
        for(int i =0;i<arr.Length;i++)
        {
            Console.WriteLine(arr[i]);
        }
        s4 = s4.Replace(", ", " ; ");
        Console.WriteLine(s4); ;
        Console.WriteLine(s4.Contains("Vw"));
        Console.WriteLine(string.Compare(s4, s3));

        TimeSpan t = new TimeSpan(1, 30, 0);
        DateTime d = DateTime.Now;
        DateTime d1;
        d1 = d.Add(t);
        Console.WriteLine($"Start:  {d.ToString("hh:mm:ss")} and finish:  {d1.ToString("hh:mm:ss")}");

        DateTime d2 = new DateTime(2022, 3, 14);
        Console.WriteLine(d2.ToString());
        Console.WriteLine();

        DateTimeOffset offset = DateTimeOffset.Now;
        DateTime utc = DateTime.UtcNow;
        Console.WriteLine(utc.ToString());
        Console.WriteLine(offset.ToString());
        Console.WriteLine();

        CultureInfo c = CultureInfo.CurrentCulture;
        CultureInfo c1 = new CultureInfo("ro-RO");
        Console.WriteLine(c);
        int amount = 1000;
        Console.WriteLine(amount.ToString("C",c));
        Console.WriteLine(amount.ToString("C",c1));

        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberGroupSeparator = " ";
        Console.WriteLine(123456789.ToString("N1",nfi));
    }
}
