using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class Scorecard
    {
        public List<Frame> Frames { get; set; }
        public FinalFrame FinalFrame { get; set; }

        private int ScoreStrikeIfNecessary(int curFrame)
        {
            var strikeScore = 0;
            if (curFrame >= 2 && (Frames[curFrame - 2].Result == FrameResult.Strike))
            {
                strikeScore = 10 + Frames[curFrame - 1].RollSum + Frames[curFrame].RollSum;
            }
            return strikeScore;
        }

        private int ScoreSpareIfNecessary(int curFrame)
        {
            var strikeScore = 0;
            if (curFrame >= 1 && (Frames[curFrame - 1].Result == FrameResult.Spare))
            {
                strikeScore = 10 + Frames[curFrame].Roll1;
            }
            return strikeScore;
        }

        private int NinthFrameSpareScore()
        {
            var score = 0;
            if (Frames.Count >= 8 && Frames[8].Result == FrameResult.Spare && FinalFrame != null)
            {
                score = 10 + FinalFrame.Rolls.First();
            }
            return score;
        }

        private int NinthFrameStrikeScore()
        {
            var score = 0;
            if (Frames.Count >= 8 && Frames[8].Result == FrameResult.Strike && FinalFrame != null)
            {
                score = 10 + (FinalFrame.Rolls.First() + FinalFrame.Rolls.Skip(1).First());
            }
            return score;
        }

        public string CurrentScore
        {
            get
            {
                var score = 0;
                for (int curFrame = 0; curFrame < Frames.Count; curFrame++)
                {
                    if (Frames[curFrame].Result == FrameResult.Miss)
                    {
                        score += ScoreStrikeIfNecessary(curFrame);
                        score += ScoreSpareIfNecessary(curFrame);
                        score += Frames[curFrame].RollSum;
                    }
                }
                score += NinthFrameSpareScore();
                score += NinthFrameStrikeScore();
                score += (FinalFrame != null) ? FinalFrame.RollSum : 0;
                return score.ToString();
            }
        }
    }
}
