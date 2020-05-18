using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BowlingKata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldCorrectlySumUpRounds()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
                ("4", "-"),
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(39);
        }
        
        [Fact]
        public void ShouldCorrectlySumUpRoundsWithPointInAllShots()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "3"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "3"),
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(77);
        }

        [Fact]
        public void ShouldHandleSpareCorrectly()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "3"),
                ("4", "4"),
                ("4", Bowling.SPARE),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "3"),
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(83);
        }
        
        [Fact]
        public void ShouldCalculateSpareInTenthRound()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "3"),
                ("4", "4"),
                ("3", Bowling.SPARE),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", Bowling.SPARE),
                ("4", string.Empty)
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(90);
        }
        
        [Fact]
        public void ShouldHandleStrikeCorrectly()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "3"),
                ("4", "4"),
                (Bowling.STRIKE, string.Empty),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "3"),
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(87);
        }
        
        [Fact]
        public void ShouldHandleStrikeInLastRoundCorrectly()
        {
            var rounds = new List<(string, string)>()
            {
                ("3", "3"),
                ("4", "4"),
                (Bowling.STRIKE, string.Empty),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                ("4", "4"),
                (Bowling.STRIKE, string.Empty),
                ("3", "4")
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(97);
        }

        [Fact]
        public void ShouldHandleAllStrikes()
        {
            var rounds = new List<(string, string)>()
            {
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                (Bowling.STRIKE, string.Empty),
                ("10", "10")
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(300);
        }
        
        [Fact]
        public void AllSparesWithAnExtraFive()
        {
            var rounds = new List<(string, string)>()
            {
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", Bowling.SPARE),
                ("5", string.Empty)
            };
            var bowling = new Bowling();

            var points = bowling.CalculatePoints(rounds);

            points.Should().Be(150);
        }
    }
}