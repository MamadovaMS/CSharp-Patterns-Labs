using System;

namespace FootballChampionship.Refactored
{
    public class Match
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public DateTime Date { get; }
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }

        public Match(Team home, Team away, DateTime date)
        {
            HomeTeam = home;
            AwayTeam = away;
            Date = date;
        }

        public void PlayMatch()
        {
            Random rnd = new Random();
            HomeGoals = rnd.Next(0, 8);
            AwayGoals = rnd.Next(0, 8);

            HomeTeam.UpdateResults(HomeGoals, AwayGoals);
            AwayTeam.UpdateResults(AwayGoals, HomeGoals);
        }

        public void PrintScore()
        {
            Console.WriteLine($"{HomeTeam.Name}: {HomeGoals} vs {AwayTeam.Name}: {AwayGoals}");
        }

        // Метод для получения отчёта (раньше был отдельный метод с кучей параметров)
        public string GetReport()
        {
            return $"Отчёт о матче {HomeTeam.Name} против {AwayTeam.Name} ({Date.ToShortDateString()}):\n" +
                   $" {HomeTeam.Name} забили {HomeGoals}, пропустили {AwayGoals}.\n" +
                   $" {AwayTeam.Name} забили {AwayGoals}, пропустили {HomeGoals}.";
        }
    }
}