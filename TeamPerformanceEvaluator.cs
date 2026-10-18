using System;
using System.Collections.Generic;

namespace FootballChampionship.Refactored
{
    // Стратегия для оценки
    public interface IPerformanceStrategy
    {
        string GetPerformanceMessage(double winPercentage);
    }

    public class HighPerformanceStrategy : IPerformanceStrategy
    {
        public string GetPerformanceMessage(double winPercentage) => "Высокая производительность команды.";
    }

    public class MediumPerformanceStrategy : IPerformanceStrategy
    {
        public string GetPerformanceMessage(double winPercentage) => "Средняя производительность команды.";
    }

    public class LowPerformanceStrategy : IPerformanceStrategy
    {
        public string GetPerformanceMessage(double winPercentage) => "Низкая производительность команды.";
    }

    public class TeamPerformanceEvaluator
    {
        private readonly Dictionary<Func<double, bool>, IPerformanceStrategy> _strategies;

        public TeamPerformanceEvaluator()
        {
            _strategies = new Dictionary<Func<double, bool>, IPerformanceStrategy>
            {
                [p => p >= 70] = new HighPerformanceStrategy(),
                [p => p >= 50 && p <= 69] = new MediumPerformanceStrategy(),
                [p => p < 50] = new LowPerformanceStrategy()
            };
        }

        public string Evaluate(Team team)
        {
            if (team.MatchesPlayed == 0)
                return "Нет матчей";

            double winPercentage = team.GetWinPercentage();
            foreach (var strategy in _strategies)
            {
                if (strategy.Key(winPercentage))
                    return strategy.Value.GetPerformanceMessage(winPercentage);
            }
            return "Неизвестно";
        }
    }
}