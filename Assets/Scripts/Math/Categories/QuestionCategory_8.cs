﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathFighter.Math.Questions;

namespace MathFighter.Math.Categories
{
    /// <summary>
    /// The implementation for question category 8.
    /// </summary>
    public class QuestionCategory_8 : QuestionCategory
    {
        private const string CATNAME = "Grade 8";

        public QuestionCategory_8()
            : base(CATNAME)
        {
            // do nothing - just here to pass on the category name
        }

        public QuestionCategory_8(int levelNum)
            : base(CATNAME, levelNum)
        {
            // do nothing - just here to pass on the category name
        }

        protected override int GetUniqueLevelCount()
        {
            return 3;
        }

        protected override void CreateAndAddLevel_1()
        {
            AddLevel(new Level("Absolute Values Multiplication", new DMQ_AbsoluteValuesMultiplication()));
        }

        protected override void CreateAndAddLevel_2()
        {
            AddLevel(new Level("Absolute Values", new DMQ_AbsoluteValue()));
        }

        protected override void CreateAndAddLevel_3()
        {
            AddLevel(new Level("Absolute Values Addition", new DMQ_AbsoluteValuesAddition()));
        }
    }
}
