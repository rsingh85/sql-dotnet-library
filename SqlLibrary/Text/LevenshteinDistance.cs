using System;
using Microsoft.SqlServer.Server;

namespace SqlLibrary.Text
{
    public class LevenshteinDistance
    {
        /// <summary>
        /// Computes the Levenshtein distance between two string inputs. 
        /// Implementation from http://www.dotnetperls.com/levenshtein.
        /// </summary>
        /// <param name="inputOne">String to compare against inputTwo.</param>
        /// <param name="inputTwo">String to compare against inputOne.</param>
        /// <returns>The Levenshtein distance between stringOne and stringTwo</returns>
        [SqlProcedure]
        public int Compute(string inputOne, string inputTwo)
        {
            if (inputOne == null)
                throw new ArgumentNullException(nameof(inputOne));

            if (inputTwo == null)
                throw new ArgumentNullException(nameof(inputTwo));

            int[,] d = new int[inputOne.Length + 1, inputTwo.Length + 1];

            if (inputOne.Length == 0)
                return inputTwo.Length;

            if (inputTwo.Length == 0)
                return inputOne.Length;

            for (int i = 0; i <= inputOne.Length; d[i, 0] = i++) { }
            for (int j = 0; j <= inputTwo.Length; d[0, j] = j++) { }

            for (int i = 1; i <= inputOne.Length; i++)
            {
                for (int j = 1; j <= inputTwo.Length; j++)
                {
                    int cost = (inputTwo[j - 1] == inputOne[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[inputOne.Length, inputTwo.Length];
        }
    }
}
