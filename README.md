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
	Console.WriteLine; // 78%

	int m2 = g.NGram(@"C:\Users\myuser\OneDrive\LookingGlass Project Team", "MYUSER");
	Console.WriteLine; // 100%
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

# Dandraka.FuzzySubstringSearch assembly

## Dandraka.FuzzySubstringSearch namespace

| public type | description |
| --- | --- |
| class [LookingGlass] | N-gram case-insensitive text search. |

# LookingGlass class

N-gram case-insensitive text search.

```csharp
public class LookingGlass
```

## Public Members

| name | description |
| --- | --- |
| [LookingGlass] | Creates a LookingGlass instance with sequential search. |
| [LookingGlass] | Creates a LookingGlass instance. |
| [NGram] | Performs an N-gram case-insensitive search. |

## See Also

* namespace [Dandraka.FuzzySubstringSearch]

# LookingGlass constructor 

Creates a LookingGlass instance with sequential search.

```csharp
public LookingGlass
```

## See Also

* class [LookingGlass]
* namespace [Dandraka.FuzzySubstringSearch]

---

# LookingGlass constructor 

Creates a LookingGlass instance.

```csharp
public LookingGlass
```

| parameter | description |
| --- | --- |
| isSequential | Defines if search is limited to sequencial mode. |

## See Also

* class [LookingGlass]
* namespace [Dandraka.FuzzySubstringSearch]

# LookingGlass.NGram method

Performs an N-gram case-insensitive search.

```csharp
public int NGram
```

| parameter | description |
| --- | --- |
| TargetString | The string in which search is being performed. |
| SearchString | The string sought within the target string. |
| NGramSize | The n-gram size, usually 2 or 3. Default is 3. |

## Return Value

A number between 0 and 100. 0 Means no part of the search string was found. 100 means that the search string was found verbatim.

## See Also

* class [LookingGlass]
* namespace [Dandraka.FuzzySubstringSearch]
