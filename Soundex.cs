using System;
using System.Text;

public class Soundex
{
    private static readonly int[] soundexMapping = {
        0, 1, 2, 3, 0, 1, 2, 0, 0, 2,
        2, 4, 5, 5, 0, 1, 2, 6, 2, 3,
        0, 1, 0, 2, 0, 2
    };

    public static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        if (c < 'A' || c > 'Z')
        {
            return '0';
        }
        return (char)(soundexMapping[c - 'A'] + '0');
    }

    private static void AppendSoundexCode(char code, StringBuilder soundex)
    {
        if (code != '0' && (soundex.Length == 0 || code != soundex[soundex.Length - 1]))
        {
            soundex.Append(code);
        }
    }

    private static void FinalizeSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
        soundex.Length = 4;
    }

    public static string GenerateSoundex(string name)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            AppendSoundexCode(code, soundex);
        }

        FinalizeSoundex(soundex);
        return soundex.ToString();
    }
}

