using System.Collections.Generic;
using System.Linq;

namespace FootballChampionship.Refactored
{
    public class Team
    {
        private List<Player> _players = new List<Player>();
        public string Name { get; }
        public int MatchesPlayed { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Draws { get; private set; }
        public int GoalsScored { get; private set; }
        public int GoalsConceded { get; private set; }

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player) => _players.Add(player);
        public void RemovePlayer(string name)
        {
            var found = _players.FirstOrDefault(p => p.Name == name);
            if (found != null) _players.Remove(found);
        }

        public void UpdateResults(int goalsFor, int goalsAgainst)
        {
            GoalsScored += goalsFor;
            GoalsConceded += goalsAgainst;
            if (goalsFor > goalsAgainst) Wins++;
            else if (goalsFor < goalsAgainst) Losses++;
            else Draws++;
            MatchesPlayed++;
        }

        // Новый метод: вычисляет процент побед (раньше это делала внешняя функция)
        public double GetWinPercentage()
        {
            int total = Wins + Losses;
            return total == 0 ? 0 : (double)Wins / total * 100;
        }

        public override string ToString() =>
            $"Команда: {Name}\nИгры сыграно: {MatchesPlayed}\nПобеды: {Wins}\nПроигрыши: {Losses}\nНичьи: {Draws}";
    }
}