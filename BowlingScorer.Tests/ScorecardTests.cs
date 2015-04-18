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

            Assert.AreEqual("37", scorecard.CurrentScore);
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

        [TestMethod]
        public void PerfectGame_Scores300()
        {
            var frames = new List<Frame>
            {
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
                new Frame(10),
            };
            var finalFrame = new FinalFrame(new List<int> { 10, 10, 10 });
            var scorecard = new Scorecard() { Frames = frames };
            scorecard.FinalFrame = finalFrame;

            Assert.AreEqual("300", scorecard.CurrentScore);
        }

        [TestMethod]
        public void RandomGame_ScoresEachFrameCorrectly()
        {
            var scorecard = new Scorecard();

            scorecard.Frames.Add(new Frame(8, 1));
            Assert.AreEqual("9", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(4, 2));
            Assert.AreEqual("15", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(4, 6));
            Assert.AreEqual("15", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(10));
            Assert.AreEqual("35", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(2, 1));
            Assert.AreEqual("51", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(6, 2));
            Assert.AreEqual("59", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(5, 1));
            Assert.AreEqual("65", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(9, 0));
            Assert.AreEqual("74", scorecard.CurrentScore);
            scorecard.Frames.Add(new Frame(10));
            Assert.AreEqual("74", scorecard.CurrentScore);

            var finalFrame = new FinalFrame(new List<int> { 4, 6 });
            scorecard.FinalFrame = finalFrame;
            Assert.AreEqual("104", scorecard.CurrentScore);
            finalFrame.Rolls.Add(1);
            Assert.AreEqual("105", scorecard.CurrentScore);
        }
    }
}
