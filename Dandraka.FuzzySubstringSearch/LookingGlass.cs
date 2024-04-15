using System.Diagnostics;

namespace Dandraka.FuzzySubstringSearch;

public class LookingGlass
{
    private bool isSequential;
    public LookingGlass()
    {
        this.isSequential = true;
    }

    public LookingGlass(bool isSequential)
    {
        this.isSequential = isSequential;
    }

    public int NGram(string TargetString, string SearchString, int NGramSize = 3)
    {
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
        }

        //Console.WriteLine("r = " + r.ToString());
        //Console.WriteLine("tNgramsCount = " + tNgramsCount.ToString());

        decimal result = Math.Round(decimal.Divide(r, sNgramsCount) * 100);
        
        return Convert.ToInt32(result);
    }
}
