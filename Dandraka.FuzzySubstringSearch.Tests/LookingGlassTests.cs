namespace Dandraka.FuzzySubstringSearch.Tests;

using Dandraka.FuzzySubstringSearch;
using FluentAssertions;

public class LookingGlassTests
{
    [Fact]
    public void T01_SingleWordVerbatimSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("The quick brown fox jumps over the lazy dog", "quick", 2);
        m.Should().Be(100, "the word exists in text");
    }

    [Fact]
    public void T02_DoubleWordVerbatimSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("The quick brown fox jumps over the lazy dog", "lazy dog", 2);
        m.Should().Be(100, "the words exist in text");
    }  

    [Fact]
    public void T03_SingleWordPartialSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "dolar", 2);
        m.Should().Be(50, "the 3-gram overlap is 50%");
    }        

    [Fact]
    public void T04_DoubleWordPartialSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("the projekt XYZ was finished last year", "project XYZ");
        m.Should().Be(67, "the 3-gram overlap is 66.67%");
    }    
}