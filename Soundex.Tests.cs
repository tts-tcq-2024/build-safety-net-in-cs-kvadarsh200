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
    public void HandlesMultipleCharacters()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("Aiden"));
        Assert.Equal("B230", Soundex.GenerateSoundex("Babcock"));
        Assert.Equal("C160", Soundex.GenerateSoundex("Christopher"));
    }

    [Fact]
    public void HandlesMixedCase()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("aiden"));
        Assert.Equal("B230", Soundex.GenerateSoundex("BaBcOcK"));
        Assert.Equal("C160", Soundex.GenerateSoundex("CHRISTOPHER"));
    }

    [Fact]
    public void HandlesRepeatingConsonants()
    {
        Assert.Equal("B120", Soundex.GenerateSoundex("Bobby"));
    }

    [Fact]
    public void HandlesVowelsAndIgnoredCharacters()
    {
        Assert.Equal("R260", Soundex.GenerateSoundex("Robert"));
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert"));
    }

    [Fact]
    public void PadsWithZeros()
    {
        Assert.Equal("H000", Soundex.GenerateSoundex("H"));
    }

    [Fact]
    public void TruncatesLongSoundex()
    {
        Assert.Equal("P120", Soundex.GenerateSoundex("Pfister"));
    }
}
