using System;

namespace UpdateDate
{
    class Program
    {
        static void Main(string[] args)
        {
            GitHelper.UpdateDates();
            Console.WriteLine("Done!");
        }
    }
}
