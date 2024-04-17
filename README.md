# FuzzySubstringSearch
Implements n-gram matching in a string, returning a match percentage in the range of 0-100.
Search is always case-insensitive.

## Example:

```
using Dandraka.FuzzySubstringSearch;

public void FuzzySubstringSearchExample
{
	var g = new LookingGlass(true); // true = sequential mode on

	int m1 = g.NGram("I'm wearing hedphones now", "headphones", 2);
	Console.WriteLine(m1.ToString()); // 78

	int m2 = g.NGram(@"C:\Users\myuser\OneDrive\LookingGlass Project Team", "MYUSER");
	Console.WriteLine(m2.ToString()); // 100
}
```

## What does 'Sequential Mode' mean?

Sequential mode, in this context, means that as soon as a part of search string is found, subsequect searches look only for the rest of the search string.

For example, when sequential is true, this is what happens when searching for 'cell' in target 'ball center' with 2-grams:

The word 'cell' has 3 x 2-grams: ce, el, ll.

| Target 2-gram | Is match |
| --- | --- |
| ba | No |
| al | No |
| ll  | Yes: matches ll, the 3rd 2-gram. |
| l[space] | No |
| [space]c | No |
| ce | No: it could match ce but this is the 1st 2-gram, we've already found the 3rd and sequential is on. |
| en | No |
| nt | No |
| te | No |
| er | No |

So the result is 1 match / 3 total = 33%.

When sequential is false this restriction does not apply:

| Target 2-gram | Is match |
| --- | --- |
| ba | No |
| al | No |
| ll  | Yes: matches ll, the 3rd 2-gram. |
| l[space] | No |
| [space]c | No |
| ce | Yes: matches ce, the 1st 2-gram. |
| en | No |
| nt | No |
| te | No |
| er | No |

So the result is 2 matches / 3 total = 67%.

## Downloading

Please download the Nuget package [here](https://www.nuget.org/packages/Dandraka.FuzzySubstringSearch).

## Development documentation

Please refer to the generated docs [here](https://github.com/dandraka/FuzzySubstringSearch/blob/main/docs/Dandraka.FuzzySubstringSearch.md).