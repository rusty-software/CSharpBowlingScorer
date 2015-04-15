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

                return score.ToString();
            }
        }
    }
}
