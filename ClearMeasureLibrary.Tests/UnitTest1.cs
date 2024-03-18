using System.Text;

namespace ClearMeasureLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        int MaxUpperBound = 10000000;

        string[] StringBuilderToStringArray(StringBuilder SB)
        {
            return SB.ToString().Split(Environment.NewLine, 10000001);
        }
        [TestMethod]
        public void MaxInt()
        {
            StringBuilder builder = ClearMeasureLibrary.Program.WriteNumbers(MaxUpperBound, "Michael", "Birchmeier");

            String[] stringArray = StringBuilderToStringArray(builder);
            Assert.AreEqual(MaxUpperBound + 1, stringArray.Length, "The number of lines in the stringbuilder did not match expected");
            Assert.AreEqual(String.Empty, stringArray[MaxUpperBound], "There is unexpected data after the last newline");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An upperbound exceeding 1000000 was inappropriately allowed.")]
        public void ExceedsMaxRange()
        {
            StringBuilder builder = ClearMeasureLibrary.Program.WriteNumbers(MaxUpperBound + 1, "Michael", "Birchmeier");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An upperbound exceeding 10000000 was inappropriately allowed.")]
        public void LessThanZero()
        {
            StringBuilder builder = ClearMeasureLibrary.Program.WriteNumbers(-1, "Michael", "Birchmeier");
        }

        [TestMethod]
        public void CheckReplacements()
        {
            String[] stringArray = StringBuilderToStringArray(ClearMeasureLibrary.Program.WriteNumbers(100, "Michael", "Birchmeier"));
            Assert.AreEqual("Michael", stringArray[2]);
            Assert.AreEqual("Birchmeier", stringArray[4]);
            Assert.AreEqual("MichaelBirchmeier", stringArray[14]);
        }
    }
}