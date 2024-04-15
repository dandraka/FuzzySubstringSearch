namespace Dandraka.FuzzySubstringSearch.Tests;

using Dandraka.FuzzySubstringSearch;
using FluentAssertions;

public class LookingGlassTests
{
    [Fact]
    public void T01_ExamplePhrase()
    {
        var g = new LookingGlass();

        int m = g.NGram("I'm wearing hedphones now", "headphones", 2);
        m.Should().Be(78, "the 2-gram overlap is 77.77%");
    }

    [Fact]
    public void T02_ExamplePath()
    {
        var g = new LookingGlass();

        int m = g.NGram(@"C:\Users\myuser\OneDrive\LookingGlass Project Team\04. Implementation Phase (Tier 3)\04. Deliverables WIP\Tactical Interfaces\Opportunity OP1048000 for LookingGlass.csv", "OP1048000");
        m.Should().Be(100, "the word exists in text");
        m = g.NGram(@"C:\Users\myuser\OneDrive\LookingGlass Project Team\04. Implementation Phase (Tier 3)\04. Deliverables WIP\Tactical Interfaces\Opportunity OP1048000 for LookingGlass.csv", "LookingGlass");
        m.Should().Be(100, "the word exists in text");        
    }    

    [Fact]
    public void T03_SingleWordVerbatimSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("The quick brown fox jumps over the lazy dog", "quick", 2);
        m.Should().Be(100, "the word exists in text");
    }

    [Fact]
    public void T04_DoubleWordVerbatimSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("The quick brown fox jumps over the lazy dog", "lazy dog", 2);
        m.Should().Be(100, "the words exist in text");
    }  

    [Fact]
    public void T05_SingleWordPartialSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "dolar", 2);
        m.Should().Be(50, "the 3-gram overlap is 50%");
    }        

    [Fact]
    public void T06_DoubleWordPartialSearch()
    {
        var g = new LookingGlass();

        int m = g.NGram("the projekt XYZ was finished last year", "project XYZ");
        m.Should().Be(67, "the 3-gram overlap is 66.67%");
    }        
}