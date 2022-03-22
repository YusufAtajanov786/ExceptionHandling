using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int positivOrNegative = 1, index = 0, number = 0;

            if(stringValue is null)
            {
                throw new ArgumentNullException();
            }

            stringValue = stringValue.TrimStart().TrimEnd();

            if (stringValue == "")
            {
                throw new FormatException();
            }

            if (stringValue[index] <'0' || stringValue[index] > '9')
            {
                if (stringValue[index] == '-')
                {
                    positivOrNegative = -1;
                }else if(stringValue[index] != '+')
                {
                    throw new FormatException();
                }
                index++;
            }

            for(int i = index; i<stringValue.Length; i++)
            {
               
                if (stringValue[i] >= '0' && stringValue[i] <= '9')
                {
                    int digit = (stringValue[i] - '0');
                    if ( (int.MaxValue- (number * 10) ) < digit && positivOrNegative==1)
                    {
                        throw new OverflowException();
                    }
                    else if ((int.MinValue + (number * 10)) > -digit && positivOrNegative == -1)
                    {
                        throw new OverflowException();
                    }
                    number = number *  10 + digit;
                }else
                {
                    throw new FormatException();
                }
            }

            return positivOrNegative * number;
        }
    }
}