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

        private int NextTwoApplicableScores(int curFrame)
        {
            var score = 0;
            if ((curFrame < 7) && ((curFrame + 2) <= Frames.Count))
            {
                score = Frames[curFrame + 1].RollSum + Frames[curFrame + 2].RollSum;
            } 
            else if (curFrame == 7 && FinalFrame != null)
            {
                score = Frames[curFrame + 1].RollSum + FinalFrame.Rolls[0];
            }
            else if (curFrame == 8 && FinalFrame != null)
            {
                score = FinalFrame.Rolls[0] + FinalFrame.Rolls[1];
            }
            return score;
        }

        private int ScoreStrikeIfPossible(int curFrame)
        {
            var strikeScore = 0;
            if (Frames.Count > 2)
            {
                strikeScore += 10 + NextTwoApplicableScores(curFrame);
            }
            return strikeScore;
        }

        private int NextApplicableScore(int curFrame)
        {
            var score = 0;
            if (curFrame < 8 && ((curFrame + 1) <= Frames.Count))
            {
                score = Frames[curFrame + 1].Roll1;
            }
            else if (curFrame == 8 && FinalFrame != null)
            {
                score = FinalFrame.Rolls[0];
            }
            return score;
        }

        private int ScoreSpareIfPossible(int curFrame)
        {
            var score = 0;
            if (Frames.Count > 1)
            {
                score = 10 + NextApplicableScore(curFrame);
            }
            return score;
        }

        private int ScoreFrame(int curFrame)
        {
            var score = 0;
            if (Frames[curFrame].Result == FrameResult.Strike)
            {
                score = ScoreStrikeIfPossible(curFrame);
            }
            else if (Frames[curFrame].Result == FrameResult.Spare)
            {
                score = ScoreSpareIfPossible(curFrame);
            }
            else
            {
                score = Frames[curFrame].RollSum;
            }
            return score;
        }

        private int ScoreFinalFrame()
        {
            var score = 0;
            if (FinalFrame != null)
            {
                score = FinalFrame.RollSum;
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
                    score += ScoreFrame(curFrame);
                }
                score += ScoreFinalFrame();
                return score.ToString();
            }
        }
    }
}
