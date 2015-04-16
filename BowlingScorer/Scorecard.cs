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

        public Scorecard()
        {
            Frames = new List<Frame>();
        }

        private int CalcStrikeScore(int curFrame)
        {
            var score = 0;
            if ((curFrame < 7) && ((curFrame + 2) < Frames.Count))
            {
                score = 10 + Frames[curFrame + 1].RollSum + Frames[curFrame + 2].RollSum;
            } 
            else if (curFrame == 7 && FinalFrame != null && FinalFrame.Rolls != null && FinalFrame.Rolls.Count >= 1)
            {
                score = 10 + Frames[curFrame + 1].RollSum + FinalFrame.Rolls[0];
            }
            else if (curFrame == 8 && FinalFrame != null && FinalFrame.Rolls != null && FinalFrame.Rolls.Count >= 2)
            {
                score = 10 + FinalFrame.Rolls[0] + FinalFrame.Rolls[1];
            }
            return score;
        }

        private int CalcSpareScore(int curFrame)
        {
            var score = 0;
            if (curFrame < 8 && (curFrame + 1) < Frames.Count)
            {
                score = 10 + Frames[curFrame + 1].Roll1;
            }
            else if (curFrame == 8 && FinalFrame != null && FinalFrame.Rolls != null && FinalFrame.Rolls.Count >= 1)
            {
                score = 10 + FinalFrame.Rolls[0];
            }
            return score;
        }

        private int ScoreFrame(int curFrame)
        {
            var score = 0;
            if (Frames[curFrame].Result == FrameResult.Strike)
            {
                score = CalcStrikeScore(curFrame);
            }
            else if (Frames[curFrame].Result == FrameResult.Spare)
            {
                score = CalcSpareScore(curFrame);
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
                var score = ScoreFinalFrame();
                for (int curFrame = Frames.Count - 1; curFrame >= 0; curFrame--)
                {
                    score += ScoreFrame(curFrame);
                }
                return score.ToString();
            }
        }
    }
}
