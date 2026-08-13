namespace Dandraka.FuzzySubstringSearch
{
    /// <summary>
    /// Invalid Input Exception.
    /// </summary>
    public class InvalidInputException : ApplicationException
    {
        /// <summary>
        /// Invalid Input Exception.
        /// </summary>
        /// <param name="m">Input</param>
        public InvalidInputException(string m): base(m) { }
    }
}
