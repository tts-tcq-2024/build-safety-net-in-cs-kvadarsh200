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

        int sIndex = 1;
        char previousCode = GetSoundexCode(firstLetter);

        for (int i = 1; i < name.Length && sIndex < 4; i++)
        {
            char currentCode = GetSoundexCode(name[i]);
            AppendSoundexCode(currentCode, ref previousCode, soundex, ref sIndex);
        }

        FinalizeSoundex(soundex, sIndex);
        return soundex.ToString();
    }

    private static void AppendSoundexCode(char currentCode, ref char previousCode, StringBuilder soundex, ref int sIndex)
    {
        if (currentCode != '0' && currentCode != previousCode)
        {
            soundex.Append(currentCode);
            sIndex++;
            previousCode = currentCode;
        }
    }

    private static void FinalizeSoundex(StringBuilder soundex, int sIndex)
    {
        while (sIndex < 4)
        {
            soundex.Append('0');
            sIndex++;
        }
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
