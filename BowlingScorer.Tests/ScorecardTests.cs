using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BowlingScorer;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class ScorecardTests
    {
        [TestMethod]
        public void CurrentScore_OnlyMisses_SumOfRolls()
        {
            var frames = new List<Frame> { new Frame(5, 4), new Frame(4, 5), new Frame(0, 9), new Frame(9, 0) };
            var scorecard = new Scorecard() { Frames = frames };

            Assert.AreEqual("36", scorecard.CurrentScore);
        }

        [TestMethod]
        public void CurrentScore_Strike_AddsSimpleSumOfTwoSubsequentFrames()
        {
            var frames = new List<Frame> { new Frame(10), new Frame(4, 5), new Frame(5, 4) };
            var scorecard = new Scorecard() { Frames = frames };

            Assert.AreEqual("46", scorecard.CurrentScore);
        }

        [TestMethod]
        public void CurrentScore_Spare_AddsSumOfFirstSubsequentRoll()
        {
            var frames = new List<Frame> { new Frame(4, 6), new Frame(8, 1), new Frame(5, 4) };
            var scorecard = new Scorecard() { Frames = frames };

            Assert.AreEqual("36", scorecard.CurrentScore);
        }

        [TestMethod]
        public void FullCard_ScoresCorrectly()
        {
            var frames = new List<Frame>
            {
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
                new Frame(4, 5),
            };
            var finalFrame = new FinalFrame(new List<int> { 4, 5 });
            var scorecard = new Scorecard() { Frames = frames };
            scorecard.FinalFrame = finalFrame;

            Assert.AreEqual("90", scorecard.CurrentScore);
        }

        [TestMethod]
        public void NinthFrameSpare_ScoresCorrectly()
        {
            var frames = new List<Frame>
            {
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 10),
            };
            var finalFrame = new FinalFrame(new List<int> { 4, 5 });
            var scorecard = new Scorecard() { Frames = frames };
            scorecard.FinalFrame = finalFrame;

            Assert.AreEqual("23", scorecard.CurrentScore);
        }

        [TestMethod]
        public void NinthFrameStrike_ScoresCorrectly()
        {
            var frames = new List<Frame>
            {
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(0, 0),
                new Frame(10),
            };
            var finalFrame = new FinalFrame(new List<int> { 4, 5 });
            var scorecard = new Scorecard() { Frames = frames };
            scorecard.FinalFrame = finalFrame;

            Assert.AreEqual("28", scorecard.CurrentScore);
        }
    }
}
