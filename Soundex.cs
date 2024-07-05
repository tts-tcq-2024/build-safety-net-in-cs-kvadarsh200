using System;
using System.Text;

public class Soundex
{
    private static readonly int[] soundexMapping = new int[26]
    {
        0, 1, 2, 3, 0, 1, 2, 0, 0, 2,
        2, 4, 5, 5, 0, 1, 2, 6, 2, 3,
        0, 1, 0, 2, 0, 2
    };

    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder();
        char firstLetter = char.ToUpper(name[0]);
        soundex.Append(firstLetter);

        string encodedName = EncodeName(name.Substring(1));
        string filteredName = FilterEncodedName(encodedName, firstLetter);

        return FinalizeSoundex(filteredName, firstLetter);
    }

    private static string EncodeName(string name)
    {
        StringBuilder encoded = new StringBuilder();

        foreach (char c in name)
        {
            encoded.Append(GetSoundexCode(c));
        }

        return encoded.ToString();
    }

    private static string FilterEncodedName(string encodedName, char firstLetter)
    {
        StringBuilder filtered = new StringBuilder();
        char previousCode = GetSoundexCode(firstLetter);

        foreach (char code in encodedName)
        {
            if (code != '0' && code != previousCode)
            {
                filtered.Append(code);
                previousCode = code;
            }

            if (filtered.Length == 3)
            {
                break;
            }
        }

        return filtered.ToString();
    }

    private static string FinalizeSoundex(string filteredName, char firstLetter)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(firstLetter);
        soundex.Append(filteredName);

        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }

        return soundex.ToString();
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        if (c < 'A' || c > 'Z')
        {
            return '0';
        }
        return (char)('0' + soundexMapping[c - 'A']);
    }
}
