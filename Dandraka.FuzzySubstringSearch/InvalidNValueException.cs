using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandraka.FuzzySubstringSearch
{
    /// <summary>
    /// Invalid N-Value Exception.
    /// </summary>
    public class InvalidNValueException: ApplicationException
    {
        /// <summary>
        /// Invalid N-Value Exception.
        /// </summary>
        /// <param name="n">N-Value</param>
        public InvalidNValueException(int n): base($"Invalid N value ({n}).") { }
    }
}
