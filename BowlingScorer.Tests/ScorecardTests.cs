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
        public void CurrentScore_Strike_AddsSimpleSumOfTwoSubsequentRoll()
        {
            var frames = new List<Frame> { new Frame(10), new Frame(4, 5), new Frame(5, 4) };
            var scorecard = new Scorecard() { Frames = frames };

            Assert.AreEqual("46", scorecard.CurrentScore);
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

        private bool StrikeScoreNeeded(Frame frame)
        {
            return frame.Roll1 == 10;
        }

        public string CurrentScore
        {
            get 
            {
                var score = 0;
                for (int curFrame = 0; curFrame < Frames.Count; curFrame ++)
                {
                    if (Frames[curFrame].Result != FrameResult.Strike)
                    {
                        score += ScoreStrikeIfNecessary(curFrame);
                        score += Frames[curFrame].RollSum;
                    }
                    else
                    {
                    }
                }

                return score.ToString();
            }
        }

    }
}
