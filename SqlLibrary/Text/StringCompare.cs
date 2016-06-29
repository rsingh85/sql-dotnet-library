using System;
using Microsoft.SqlServer.Server;

namespace SqlLibrary.Text
{
    public class StringCompare
    {
        /// <summary>
        /// Uses the Levenshtein string distance algorithm to compute the similarity between two strings.
        /// 1 = strings are equal, 0 = strings have no similarity
        /// </summary>
        /// <param name="inputOne">Input to compare with inputTwo.</param>
        /// <param name="inputTwo">Input to compare with inputOne.</param>
        /// <returns>A value been 0 and 1 (inclusive) with 1 being that the strings are fully similar (equal).</returns>
        [SqlProcedure]
        public static double GetTextSimilarity(string inputOne, string inputTwo)
        {
            if (inputOne == null)
                throw new ArgumentNullException(nameof(inputOne));

            if (inputTwo == null)
                throw new ArgumentNullException(nameof(inputTwo));

            if (inputOne == string.Empty && inputTwo == string.Empty)
                return 1;

            int distance = LevenshteinDistance.GetLevenshteinDistance(inputOne, inputTwo);

            return 1.0 - distance / (double)Math.Max(inputOne.Length, inputTwo.Length);
        }
    }
}
