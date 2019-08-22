using System;

namespace Marathonbet.Models
{
    public class Match
    {
        public long Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Url { get; set; }
        public string Time { get; set; }
        public Coefficient coefficient { get; set; }

        public void Show()
        {
            Console.WriteLine("Id: {0}", Id);
            Console.WriteLine("Url: {0}", Url);
            Console.WriteLine("Team 1: {0}", Team1.Name);
            Console.WriteLine("Team 2: {0}", Team2.Name);
            Console.WriteLine("Score: {0}:{1}", Team1Score, Team2Score);
            Console.WriteLine("Time: {0}", Time);
            //Console.WriteLine("Team1WinCoef :{0}", coefficient.Win1);
            //Console.WriteLine("DrawCoef :{0}", coefficient.Draw);
            //Console.WriteLine("Team2WinCoef :{0}", coefficient.Win2);
            Console.WriteLine();
        }

        public void ShowCoefs()
        {
            Console.WriteLine("Team1WinCoef :{0}", coefficient.Win1);
            Console.WriteLine("DrawCoef :{0}", coefficient.Draw);
            Console.WriteLine("Team2WinCoef :{0}", coefficient.Win2);
            Console.WriteLine();
        }
    }
}
