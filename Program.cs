using System;

namespace FootballChampionship.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём команды
            Team teamA = new Team("Спартак");
            Team teamB = new Team("Зенит");

            // Добавляем игроков
            teamA.AddPlayer(new Player("Иван Иванов", 28, 1.85, 80));
            teamB.AddPlayer(new Player("Алексей Петров", 30, 1.80, 75));

            // Создаём и проводим матч
            Match match = new Match(teamA, teamB, DateTime.Now);
            match.PlayMatch();
            match.PrintScore();

            // Оценка производительности команды (без switch!)
            var evaluator = new TeamPerformanceEvaluator();
            Console.WriteLine(evaluator.Evaluate(teamA));

            // Подробный отчёт о матче
            Console.WriteLine(match.GetReport());

            // Логирование результатов
            ResultLogger.Log(match, teamA, true);
            ResultLogger.Log(match, teamB, false);
        }
    }
}