﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MathFighter.Math.Questions
{
    /// <summary>
    /// Players workout how much the money adds up to: Dollars, Quarters, Dimes, Nickels, Pennies
    /// </summary>
    public class DMQ_Money : DynamicMathQuestion
    {
        private const int MAX_DOLLARS = 9;
        private const int MAX_QUARTERS = 4;
        private const int MAX_DIMES = 5;
        private const int MAX_NICKELS = 6;
        private const int MAX_PENNIES = 9;

        private enum EnumMoney { Dollar = 0, Quarter, Dime, Nickel, Penny };


        public override string[] GetContent()
        {
            string[] content = new string[6];

            // create the vars and answer
            int[] moneyAmounts = new int[5];
            moneyAmounts[(int)EnumMoney.Dollar] = _rnd.Next(1, MAX_DOLLARS + 1);
            moneyAmounts[(int)EnumMoney.Quarter] = _rnd.Next(1, MAX_QUARTERS + 1);
            moneyAmounts[(int)EnumMoney.Dime] = _rnd.Next(1, MAX_DIMES + 1);
            moneyAmounts[(int)EnumMoney.Nickel] = _rnd.Next(1, MAX_NICKELS + 1);
            moneyAmounts[(int)EnumMoney.Penny] = _rnd.Next(1, MAX_PENNIES + 1);

            // zero up to 2 of the monetary values - so we end up with 3-5 types left in the question
            int howManyToZero = _rnd.Next(0, 3);

            for (int i = 0; i < howManyToZero; i++)
            {
                int indx = _rnd.Next(0, 5);

                while (moneyAmounts[indx] == 0)
                {
                    indx = _rnd.Next(0, 5);
                }

                moneyAmounts[indx] = 0;
            }
            
            // create the question
            content[0] = "";
            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                if (moneyAmounts[i] > 0)
                {
                    content[0] += GetMoneyString(moneyAmounts[i], (EnumMoney)i);

                    if (count < 3 - howManyToZero)
                    {
                        content[0] += ", ";
                    }
                    else if (count == 3 - howManyToZero)
                    {
                        content[0] += " <i>and</i> ";
                    }

                    count++;
                }
            }

            // fill in the correct answer
            int answerInCents = 0;

            for (int i = 0; i < 5; i++)
            {
                answerInCents += GetMoneyValueInCents(moneyAmounts[i], (EnumMoney)i);
            }

            content[1] = "@<i>height</i>{0.7}#" + GetDollarCentStringFromCents(answerInCents);

            // create the decoy answers (perturb the correct answer by some amount in the range -100 to
            // +100, but not including zero obviously) - And also must not go negative.

            // create the pertubations - should not perturb by zero and should all be different
            Dictionary<string, int> alreadyUsed = new Dictionary<string, int>();
            alreadyUsed.Add(content[1], 1);

            for (int i = 2; i < 5; i++)
            {
                int pertubation;
                string rep;

                do
                {
                    pertubation = _rnd.Next(-100, 101);
                    rep = "@<i>height</i>{0.7}#" + GetDollarCentStringFromCents(answerInCents + pertubation);
                } while (answerInCents + pertubation < 0 || alreadyUsed.ContainsKey(rep));

                content[i] = rep;
                alreadyUsed.Add(rep, i);
            }

            // provide a hint text
            content[5] = "1 <i>Dollar is</i> 100 <i>Cents.  A Quarter is</i> 25 <>iCents.  A Dime is</i> 10 <i>Cents.  And a Nickel is</i> 5 <i>Cents</i>";

            return content;
        }

        private string GetMoneyString(int value, EnumMoney type)
        {
            switch (type)
            {
                case EnumMoney.Dollar:
                    if (value == 1)
                    {
                        return "1 <i>Dollar</i>";
                    }
                    else
                    {
                        return value.ToString() + " <i>Dollars</i>";
                    }
                //break;

                case EnumMoney.Quarter:
                    if (value == 1)
                    {
                        return "1 <i>Quarter</i>";
                    }
                    else
                    {
                        return value.ToString() + " <i>Quarters</i>";
                    }
                //break;

                case EnumMoney.Dime:
                    if (value == 1)
                    {
                        return "1 Dime";
                    }
                    else
                    {
                        return value.ToString() + " <i>Dimes</i>";
                    }
                //break;

                case EnumMoney.Nickel:
                    if (value == 1)
                    {
                        return "1 Nickel";
                    }
                    else
                    {
                        return value.ToString() + " <i>Nickels</i>";
                    }
                //break;

                case EnumMoney.Penny:
                    if (value == 1)
                    {
                        return "1 Penny";
                    }
                    else
                    {
                        return value.ToString() + " <i>Pennies</i>";
                    }
                //break;

                default:
                    Debug.Log("unrecognized money type: " + type);
                    return "";
            }
        }

        private int GetMoneyValueInCents(int value, EnumMoney type)
        {
            switch (type)
            {
                case EnumMoney.Dollar:
                    return value * 100;
                    //break;

                case EnumMoney.Quarter:
                    return value * 25;
                //break;

                case EnumMoney.Dime:
                    return value * 10;
                //break;

                case EnumMoney.Nickel:
                    return value * 5;
                //break;

                case EnumMoney.Penny:
                    return value;
                //break;

                default:
                    Debug.Log("unrecognized money type: " + type);
                    return 0;
            }
        }

        private string GetDollarCentStringFromCents(int value)
        {
            int cents = value % 100;
            int dollars = (value - cents) / 100;
            string ret = "$" + dollars + ".";

            if (cents < 10)
            {
                ret += "0" + cents;
            }
            else
            {
                ret += cents;
            }

            return ret;
        }
    }
}
