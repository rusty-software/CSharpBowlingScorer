using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class FinalFrameTests
    {
        [TestMethod]
        public void TwoRollsSumLT10_ScoresNoExtraRolls()
        {
            var rolls = new List<int> { 4, 5 };
            var finalFrame = new FinalFrame(rolls);

            Assert.AreEqual(9, finalFrame.RollSum);
        }

        [TestMethod]
        public void TwoRollsSumTo10_ScoresOneExtraRoll()
        {
            var rolls = new List<int> { 4, 6, 7 };
            var finalFrame = new FinalFrame(rolls);

            Assert.AreEqual(17, finalFrame.RollSum);
        }

        [TestMethod]
        public void FirstRollOf10_ScoresTwoExtraRolls()
        {
            var rolls = new List<int> { 10, 10, 1 };
            var finalFrame = new FinalFrame(rolls);

            Assert.AreEqual(21, finalFrame.RollSum);
        }
    }

    public class FinalFrame
    {
        private List<int> rolls;

        public int RollSum
        {
            get
            {
                return rolls.Sum();
            }
        }
        public FinalFrame(List<int> rolls)
        {
            this.rolls = rolls;
        }
    }
}
