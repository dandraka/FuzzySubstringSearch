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

    [Fact]
    public void T07_NonSequentialSearch()
    {
        var gS = new LookingGlass(true);
        var gNS = new LookingGlass(false);

        int mS = gS.NGram("ball center", "cell", 2);
        mS.Should().Be(33, "the 2-gram sequential overlap is 33.33%");

        int mNS = gNS.NGram("ball center", "cell", 2);
        mNS.Should().Be(67, "the 2-gram non-sequential overlap is 66.66%");
    }

    [Fact]
    public void T08_InvalidNValue()
    {
        var g = new LookingGlass();

        try
        {
            int m = g.NGram("the projekt XYZ was finished last year", "XYZ", 4);
            Assert.Fail("Operation should throw InvalidNValueException");
        }
        catch (InvalidNValueException) 
        { 
            // pass
        }
        catch(Exception)
        {
            Assert.Fail("Operation should throw InvalidNValueException");
        }
    }

    [Fact]
    public void T09_InvalidInput()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

        var g = new LookingGlass();

        try
        {
            int m = g.NGram(null, "XYZ", 2);
            Assert.Fail("Operation should throw InvalidInputException");
        }
        catch (InvalidInputException)
        {
            // pass
        }
        catch (Exception)
        {
            Assert.Fail("Operation should throw InvalidInputException");
        }

        try
        {
            int m = g.NGram("", "XYZ", 2);
            Assert.Fail("Operation should throw InvalidInputException");
        }
        catch (InvalidInputException)
        {
            // pass
        }
        catch (Exception)
        {
            Assert.Fail("Operation should throw InvalidInputException");
        }

        try
        {
            int m = g.NGram("XYZ", null, 2);
            Assert.Fail("Operation should throw InvalidInputException");
        }
        catch (InvalidInputException)
        {
            // pass
        }
        catch (Exception)
        {
            Assert.Fail("Operation should throw InvalidInputException");
        }

        try
        {
            int m = g.NGram("XYZ", "", 2);
            Assert.Fail("Operation should throw InvalidInputException");
        }
        catch (InvalidInputException)
        {
            // pass
        }
        catch (Exception)
        {
            Assert.Fail("Operation should throw InvalidInputException");
        }

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}