namespace Dandraka.FuzzySubstringSearch;

/// <summary>
/// N-gram case-insensitive text search.
/// </summary>
public class LookingGlass
{
    private bool isSequential;

    /// <summary>
    /// Creates a LookingGlass instance with sequential search.
    /// </summary>
    public LookingGlass()
    {
        this.isSequential = true;
    }

    /// <summary>
    /// Creates a LookingGlass instance.
    /// </summary>
    /// <param name="isSequential">Defines if search is limited to sequencial mode.</param>
    public LookingGlass(bool isSequential)
    {
        this.isSequential = isSequential;
    }

    /// <summary>
    /// Performs an N-gram case-insensitive search.
    /// </summary>
    /// <param name="TargetString">The string in which search is being performed.</param>
    /// <param name="SearchString">The string sought within the target string.</param>
    /// <param name="NGramSize">The n-gram size, usually 2 or 3. Default is 3.</param>
    /// <returns>A number between 0 and 100. 0 Means no part of the search string was found. 100 means that the search string was found verbatim.</returns>
    public int NGram(string TargetString, string SearchString, int NGramSize = 3)
    {
        // sanity checks
        if (string.IsNullOrEmpty(TargetString) || string.IsNullOrEmpty(SearchString))
        {
            throw new InvalidInputException("Neither SearchString nor TargetString can be empty.");
        }

        if (NGramSize < 1 || NGramSize > SearchString.Length || NGramSize > TargetString.Length)
        {
            throw new InvalidNValueException(NGramSize);
        }

        string t = TargetString.ToLowerInvariant();
        string s = SearchString.ToLowerInvariant();
        
        int tNgramsCount = t.Length - (NGramSize-1);
        int sNgramsCount = s.Length - (NGramSize-1);
        
        var tGrams = new List<string>();
        var sGrams = new List<string>();

        // Generate n-grams
        for(int i = 0; i<tNgramsCount; i++)
        {
            tGrams.Add(t.Substring(i, NGramSize));
            //Console.WriteLine(tGrams[tGrams.Count-1]);
        }
        for(int i = 0; i<sNgramsCount; i++)
        {
            sGrams.Add(s.Substring(i, NGramSize));
            //Console.WriteLine(sGrams[sGrams.Count-1]);
        }        

        // search into target
        int r = 0; // result count
        int lastSearchPos = 0; // use for sequential search
        for(int i=0; i<tNgramsCount; i++)
        {
            string tGram = t.Substring(i, NGramSize);
            
            for(int n=lastSearchPos; n<sNgramsCount; n++)
            {
                string sGram = s.Substring(n, NGramSize);
                if (tGram.Equals(sGram))
                {
                    if (this.isSequential)
                    {
                        lastSearchPos = n;
                    }
                    r++;
                    //Console.WriteLine("Found " + tGram + " = " + r.ToString());
                    break;
                }
            }
        
            if (r >= sNgramsCount)
            {
                // word found, stop looking further
                break;
            }
        }

        //Console.WriteLine("r = " + r.ToString());
        //Console.WriteLine("tNgramsCount = " + tNgramsCount.ToString());

        decimal result = Math.Round(decimal.Divide(r, sNgramsCount) * 100);
        
        return Convert.ToInt32(result);
    }
}
