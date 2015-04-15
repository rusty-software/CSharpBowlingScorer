using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
    }

    public class Scorecard
    {
        public List<Frame> Frames { get; set; }

        private int ScoreStrikeIfNecessary(int curFrame)
        {
            var strikeScore = 0;
            if (curFrame >= 2 && Frames[curFrame - 2].Result == FrameResult.Strike)
            {
                strikeScore = 10 + Frames[curFrame - 1].RollSum + Frames[curFrame].RollSum;
            }
            return strikeScore;
        }

        private int ScoreSpareIfNecessary(int curFrame)
        {
            var strikeScore = 0;
            if (curFrame >= 1 && Frames[curFrame - 1].Result == FrameResult.Spare)
            {
                strikeScore = 10 + Frames[curFrame - 1].Roll1;
            }
            return strikeScore;
        }

        public string CurrentScore
        {
            get 
            {
                var score = 0;
                for (int curFrame = 0; curFrame < Frames.Count; curFrame ++)
                {
                    if (Frames[curFrame].Result == FrameResult.Miss)
                    {
                        score += ScoreStrikeIfNecessary(curFrame);
                        score += ScoreSpareIfNecessary(curFrame);
                        score += Frames[curFrame].RollSum;
                    }
                }

                return score.ToString();
            }
        }

    }
}
