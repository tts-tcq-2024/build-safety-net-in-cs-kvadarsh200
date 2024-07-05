using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Fact]
    public void HandlesLowercaseInput()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("aiden"));
    }

    [Fact]
    public void HandlesUppercaseInput()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("AIDEN"));
    }

    [Fact]
    public void HandlesMixedCaseInput()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("AiDeN"));
    }

    [Fact]
    public void HandlesRepeatingConsonants()
    {
        Assert.Equal("B120", Soundex.GenerateSoundex("Bobby"));
    }

    [Fact]
    public void HandlesVowelsAndIgnoredCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert"));
    }

    [Fact]
    public void HandlesNamesWithMultipleSameConsonantGroups()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Sassoon"));
    }

    [Fact]
    public void HandlesLongNames()
    {
        Assert.Equal("P123", Soundex.GenerateSoundex("Pneumonoultramicroscopicsilicovolcanoconiosis"));
    }

    [Fact]
    public void PadsWithZeros()
    {
        Assert.Equal("H000", Soundex.GenerateSoundex("H"));
    }

    [Fact]
    public void HandlesCommonLastName1()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Robert"));
    }

    [Fact]
    public void HandlesCommonLastName2()
    {
        Assert.Equal("R150", Soundex.GenerateSoundex("Rupert"));
    }

    [Fact]
    public void HandlesNamesWithSilentLetters()
    {
        Assert.Equal("P236", Soundex.GenerateSoundex("Pneumonia"));
    }

    [Fact]
    public void HandlesNamesWithApostrophes()
    {
        Assert.Equal("O160", Soundex.GenerateSoundex("O'Connor"));
    }

    [Fact]
    public void HandlesHyphenatedNames()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Smith-Jones"));
    }

    [Fact]
    public void HandlesNamesWithSpaces()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Smith Jones"));
    }

    [Fact]
    public void HandlesNonAlphabeticCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert123"));
    }

    [Fact]
    public void HandlesSpecialCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert!@#"));
    }

    [Fact]
    public void HandlesConsonantsFollowedByHOrW()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Ashcraft"));
    }

    [Fact]
    public void HandlesNamesWithVowelsInBetweenConsonants()
    {
        Assert.Equal("M450", Soundex.GenerateSoundex("Martha"));
    }

    [Fact]
    public void HandlesNamesWithConsonantsPrecededByVowels()
    {
        Assert.Equal("M635", Soundex.GenerateSoundex("McGee"));
    }

    [Fact]
    public void HandlesNamesStartingWithConsonantsIgnored()
    {
        Assert.Equal("C620", Soundex.GenerateSoundex("Catherine"));
    }

    [Fact]
    public void HandlesMultipleSameConsonants()
    {
        Assert.Equal("H430", Soundex.GenerateSoundex("Hamm"));
    }

    [Fact]
    public void HandlesDifferentConsonantsInDifferentPositions()
    {
        Assert.Equal("G362", Soundex.GenerateSoundex("Gregory"));
    }

    [Fact]
    public void HandlesNamesEndingWithIgnoredLetters()
    {
        Assert.Equal("A536", Soundex.GenerateSoundex("Andrews"));
    }
}
