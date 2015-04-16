using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BowlingScorer;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class FinalFrameTests
    {
        [TestMethod]
        public void TwoRollsSumLT10_ScoresNoExtraRolls()
        {
            var rolls = new List<int> { 4, 5, 10 };
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

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException), "Final frame must have at least two rolls!")]
        public void FinalFrame_RequiresAtLeast2Rolls()
        {
            var finalFrame = new FinalFrame(new List<int> { 1 });
        }
    }

}
