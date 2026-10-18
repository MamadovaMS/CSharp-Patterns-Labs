using System;

namespace FootballChampionship.Refactored
{
    public static class ResultLogger
    {
        public static void Log(Match match, Team team, bool isHomeTeam)
        {
            bool isWinner = (isHomeTeam && match.HomeGoals > match.AwayGoals) ||
                            (!isHomeTeam && match.AwayGoals > match.HomeGoals);
            string result = isWinner ? "победила" : "проиграла";
            int goalsFor = isHomeTeam ? match.HomeGoals : match.AwayGoals;
            int goalsAgainst = isHomeTeam ? match.AwayGoals : match.HomeGoals;

            Console.WriteLine($"Команда {team.Name} {result}!");
            Console.WriteLine($"Голы забитые командой {team.Name}: {goalsFor}. Голы пропущены: {goalsAgainst}");
        }
    }
}