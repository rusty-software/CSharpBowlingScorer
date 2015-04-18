using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScoreOneRoll()
        {
            var calc = new BowlingScorer();
            calc.AddRoll(1);
            Assert.AreEqual(1, calc.CurrentScore);
        }
        [TestMethod]
        public void ScoreOneFrame()
        {
            var calc = new BowlingScorer();
            calc.AddRoll(1);
            calc.AddRoll(8);
            Assert.AreEqual(9, calc.CurrentScore);
        }
    }

    public class BowlingScorer
    {
        private List<int> rolls = new List<int>();

        public void AddRoll(int pinCount)
        {
            rolls.Add(pinCount);
        }

        public int CurrentScore
        {
            get
            {
                return rolls.Sum();
            }
        }
    }
}
