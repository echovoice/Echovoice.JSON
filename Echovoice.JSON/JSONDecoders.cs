using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echovoice.JSON
{
    public static class JSONDecoders
    {
        public static string[] DecodeJSONArray(string s)
        {
            List<string> strings = new List<string>();

            if (!string.IsNullOrWhiteSpace(s))
            {
                char[] c = s.ToCharArray();
                char control = '\0';
                char icontrol = '\0';
                int controls = 1;
                bool can_slice = true;
                int last_pos = 1;

                for (int i = 1; i < (c.Length - 1); i++)
                {
                    if (can_slice && c[i] == ',')
                    {
                        if (c[last_pos] == '\"')
                            strings.Add(DecodeJsString(s.Slice(last_pos, i)));

                        else
                            strings.Add(s.Slice(last_pos, i));

                        last_pos = i + 1;
                        continue;
                    }

                    else if (!can_slice && c[i] == control && c[i - 1] != '\\')
                    {
                        if (--controls <= 0)
                            can_slice = true;

                        continue;
                    }

                    else if (!can_slice && c[i] == icontrol && c[i - 1] != '\\')
                    {
                        controls++;
                        continue;
                    }

                    else if (can_slice && c[i - 1] != '\\' && (c[i] == '\"' || c[i] == '[' || c[i] == '{'))
                    {
                        can_slice = false;
                        switch (c[i])
                        {
                            case '\"':
                                controls = 1;
                                icontrol = '\"';
                                control = '\"';
                                break;

                            case '[':
                                controls = 1;
                                icontrol = '[';
                                control = ']';
                                break;

                            case '{':
                                controls = 1;
                                icontrol = '{';
                                control = '}';
                                break;
                        }
                        continue;
                    }
                }

                if (c[last_pos] == '\"')
                    strings.Add(DecodeJsString(s.Slice(last_pos, c.Length - 1)));

                else
                    strings.Add(s.Slice(last_pos, c.Length - 1));
            }
            return strings.ToArray();
        }

        public static string[] DecodeJsStringArray(string s)
        {
            List<string> strings = new List<string>();

            if (!string.IsNullOrWhiteSpace(s))
            {
                char[] c = s.ToCharArray();
                bool can_slice = true;
                int last_pos = 1;

                for (int i = 1; i < (c.Length - 1); i++)
                {
                    if (can_slice && c[i] == ',')
                    {
                        if (c[last_pos] == '\"')
                            strings.Add(s.Slice(last_pos + 1, i - 1));
                        else
                            strings.Add(s.Slice(last_pos, i));

                        last_pos = i + 1;
                        continue;
                    }

                    else if (!can_slice && c[i] == '\"' && c[i - 1] != '\\')
                    {
                        can_slice = true;
                        continue;
                    }

                    else if (can_slice && c[i - 1] != '\\' && c[i] == '\"')
                    {
                        can_slice = false;
                        continue;
                    }
                }

                if (c[last_pos] == '\"')
                    strings.Add(s.Slice(last_pos + 1, c.Length - 2));
                else
                    strings.Add(s.Slice(last_pos, c.Length - 1));

            }
            return strings.ToArray();
        }

        public static string DecodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            char[] c = s.ToCharArray();

            for (int i = 1; i < c.Length - 1; i++)
            {
                switch (c[i])
                {
                    case '\\':
                        if (c[i + 1] == 'u')
                        {
                            sb.Append(char.ConvertFromUtf32(Int32.Parse(s.Slice(i + 2, i + 6), System.Globalization.NumberStyles.HexNumber)));
                            i = i + 5;
                        }
                        break;

                    default:
                        sb.Append(c[i]);
                        break;
                }
            }

            return sb.ToString();
        }
    }

    public static class Extensions
    {
        /// Credit http://www.dotnetperls.com/string-slice
        /// <summary>
        /// Get the string slice between the two indexes.
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
                end = source.Length + end;

            int len = end - start;               // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }
    }
}