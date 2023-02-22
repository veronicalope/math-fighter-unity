using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MathFighter.Math.Questions
{
    /// <summary>
    /// Player must workout which quadrant the specified coordinate is in
    /// </summary>
    public class DMQ_WhichQuadrant : DynamicMathQuestion
    {
        private const int MIN_VAR1 = -100;
        private const int MAX_VAR1 = 100;
        private const int MIN_VAR2 = -100;
        private const int MAX_VAR2 = 100;


        public override bool CanRandomizeAnswerOrder()
        {
            return false;
        }

        public override string[] GetContent()
        {
            string[] content = new string[7];

            // create the vars
            int var1 = GetNonZeroRandomNumber(MIN_VAR1, MAX_VAR1 + 1, 50);
            int var2 = GetNonZeroRandomNumber(MIN_VAR2, MAX_VAR2 + 1, 50);

            // create the question
            content[0] = "W<i>hich quadrant is the point</i> (" + var1 + "," + var2 + ") <i>in</i> ?";

            // record the position of the right answer in the list of possible answers
            int answerPos = 0;

            if (var1 < 0 && var2 > 0)
            {
                answerPos = 0;
            }
            else if (var1 > 0 && var2 > 0)
            {
                answerPos = 1;
            }
            else if (var1 < 0 && var2 < 0)
            {
                answerPos = 2;
            }
            else //if (var1 > 0 && var2 < 0)
            {
                answerPos = 3;
            }

            // fill in the answer list
            content[1] = "T<i>op Left</i>";
            content[2] = "T<i>op Right</i>";
            content[3] = "B<i>ottom Left</i>";
            content[4] = "B<i>ottom Right</i>";

            // provide a hint text
            content[5] = "This is the hint for Quadrants";

            // specify the answer position explicitly
            content[6] = answerPos.ToString();

            return content;
        }
    }
}
