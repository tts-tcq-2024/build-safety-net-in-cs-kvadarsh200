using System;
using System.Text;

public static class Soundex
{
    private static readonly int[] SoundexMapping = {
        0, 1, 2, 3, 0, 1, 2, 0, 0, 2,
        2, 4, 5, 5, 0, 1, 2, 6, 2, 3,
        0, 1, 0, 2, 0, 2
    };

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        if (c < 'A' || c > 'Z')
        {
            return '0';
        }
        return (char)(SoundexMapping[c - 'A'] + '0');
    }

    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.");
        }

        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        int sIndex = 1;
        for (int i = 1; i < name.Length && sIndex < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (code != '0' && code != soundex[sIndex - 1])
            {
                soundex.Append(code);
                sIndex++;
            }
        }

        while (sIndex < 4)
        {
            soundex.Append('0');
            sIndex++;
        }

        return soundex.ToString().Substring(0, 4);
    }
}
