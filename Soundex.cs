using System;
using System.Text;
public class Soundex
{
    private static readonly int[] soundexMapping = new int[26] {
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
        soundex.Append(char.ToUpper(name[0]));
        int sIndex = 1;

        ProcessName(name, soundex, ref sIndex);
        FinalizeSoundex(soundex, sIndex);

        return soundex.ToString();
    }

    private static void ProcessName(string name, StringBuilder soundex, ref int sIndex)
    {
        for (int i = 1; i < name.Length && sIndex < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            AppendSoundexCode(code, soundex, ref sIndex);
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

    private static void AppendSoundexCode(char code, StringBuilder soundex, ref int sIndex)
    {
        if (code != '0' && (sIndex == 1 || code != soundex[sIndex - 1]))
        {
            soundex.Append(code);
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
