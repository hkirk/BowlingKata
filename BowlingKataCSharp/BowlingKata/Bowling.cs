using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Bowling
    {
        public const string SPARE = "/";
        public const string STRIKE = "X";
        public const int ROUNDS = 10;
        public const int MAX_POINTS = 10;

        public int CalculatePoints(IReadOnlyList<(string, string)> rounds)
        {
            return rounds
                .Select((pair, i) => CalculateRound(pair, i, rounds))
                .Take(ROUNDS)
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .Sum();
        }

        public int CalculateRound((string, string) pair, int i, IReadOnlyList<(string, string)> rounds)
        {
            if (pair.Item2 == SPARE)
            {
                var nextRoundIndex = i + 1;
                var nextRound = rounds[nextRoundIndex];
                return MAX_POINTS + SumOfNextNThrows(nextRound, nextRoundIndex, rounds, 1);
            }

            if (pair.Item1 == STRIKE)
            {
                var nextRoundIndex = i + 1;
                var nextRound = rounds[nextRoundIndex];
                return MAX_POINTS + SumOfNextNThrows(nextRound, nextRoundIndex, rounds, 2);
            }

            return SumPair(pair);
        }

        private int SumOfNextNThrows((string, string) round, int i, IReadOnlyList<(string, string)> rounds, int throws)
        {
            var values = new List<int>()
            {
                StrToInt(round.Item1, -1), StrToInt(round.Item2, -1)
            }.Where(value => value != -1).ToList();

            if (values.Count() >= throws)
            {
                return values.Take(throws).Sum();
            }
            var nextRoundIndex = i + 1;
            var nextRound = rounds[nextRoundIndex];
            return values.Sum() + SumOfNextNThrows(nextRound, nextRoundIndex, rounds, throws - values.Count());
        }

        public int SumPair((string, string) pair) => StrToInt(pair.Item1) + StrToInt(pair.Item2);

        private int StrToInt(string s, int value = 0)
        {
            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }

            return value;
        }
    }
}