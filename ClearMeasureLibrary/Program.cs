using System.Text;

namespace ClearMeasureLibrary
{
    public class Program
    {
        public static StringBuilder WriteNumbers(int upperBound, string threeReplacement, string fiveReplacement)
        {
            if (10000000 < upperBound)
            {
                throw new ArgumentOutOfRangeException("The Upper Bound must be under 1,000,000 to avoid running out of memory");
            }
            if (upperBound < 0)
            {
                throw new ArgumentOutOfRangeException("We cannot write negative lines");
            }

            StringBuilder toReturn = new StringBuilder();
            for (int i = 1; i <= upperBound; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    toReturn.AppendLine(threeReplacement + fiveReplacement);
                }
                else if (i % 5 == 0)
                {
                    toReturn.AppendLine(fiveReplacement);
                }
                else if (i % 3 == 0)
                {
                    toReturn.AppendLine(threeReplacement);
                }
                else
                {
                    toReturn.AppendLine(i.ToString());
                }
            }

            return toReturn;
        }
    }
}
