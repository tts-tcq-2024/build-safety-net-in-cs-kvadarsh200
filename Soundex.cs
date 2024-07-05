using System;
using System.Collections.Generic;
using System.Text;

public class Soundex
{
    private static readonly Dictionary<char, char> SoundexCodeMap = new Dictionary<char, char>
    {
        {'B', '1'}, {'F', '1'}, {'P', '1'}, {'V', '1'},
        {'C', '2'}, {'G', '2'}, {'J', '2'}, {'K', '2'}, {'Q', '2'}, {'S', '2'}, {'X', '2'}, {'Z', '2'},
        {'D', '3'}, {'T', '3'},
        {'L', '4'},
        {'M', '5'}, {'N', '5'},
        {'R', '6'}
    };

    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder(4);
        soundex.Append(char.ToUpper(name[0]));

        for (int i = 1, j = 0; i < name.Length && j < 3; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (code != '0' && (j == 0 || code != soundex[j]))
            {
                soundex.Append(code);
                j++;
            }
        }

        return soundex.ToString().PadRight(4, '0');
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return SoundexCodeMap.GetValueOrDefault(c, '0');
    }
}
