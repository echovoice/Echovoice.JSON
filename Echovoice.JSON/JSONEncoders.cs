﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echovoice.JSON
{
    public static class JSONEncoders
    {
        public static string EncodeJsStringArray(string[] s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (s != null && s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (i > 0)
                        sb.Append(',');

                    sb.Append(EncodeJsString(s[i]));
                }
            }
            sb.Append(']');

            return sb.ToString();
        }

        /// <summary>
        /// Same as EncodeJsStringArray except it will not encode elements, useful when elements have already been encoded
        /// </summary>
        /// <param name="s">Array of strings already encoded</param>
        /// <returns>String in JSON format</returns>
        
        public static string EncodeJsObjectArray(string[] s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (s != null && s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (i > 0)
                        sb.Append(',');

                    sb.Append(s[i]);
                }
            }
            sb.Append(']');

            return sb.ToString();
        }

        /// <summary>
        /// Converts a List of Objects to a JSON encoded Array, objects MUST support toString(), no validation is done
        /// </summary>
        /// <param name="s">List of objects to be encoded into a JSON array</param>
        /// <returns>String in JSON Array format</returns>

        public static string EncodeJsObjectList<T>(List<T> s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (s != null && s.Count > 0)
            {
                for (int i = 0; i < s.Count; i++)
                {
                    if (i > 0)
                        sb.Append(',');

                    sb.Append(s[i].ToString());
                }
            }
            sb.Append(']');

            return sb.ToString();
        }

        /// <summary>
        /// Converts an Array of Objects to a JSON encoded Array, objects MUST support toString(), no validation is done
        /// </summary>
        /// <param name="s">Array of objects to be encoded into a JSON array</param>
        /// <returns>String in JSON Array format</returns>

        public static string EncodeJsObjectArray(object[] s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (s != null && s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (i > 0)
                        sb.Append(',');

                    sb.Append(s[i].ToString());
                }
            }
            sb.Append(']');

            return sb.ToString();
        }


        /// Credit http://www.west-wind.com/weblog/posts/2007/Jul/14/Embedding-JavaScript-Strings-from-an-ASPNET-Page
        /// 
        /// Edited to add reverse solidus
        /// 
        /// <summary>
        /// Encodes a string to be represented as a string literal. The format
        /// is essentially a JSON string.
        /// 
        /// The string returned includes outer quotes 
        /// Example Output: "Hello \"Mike\"!\r\nYou're the best coder in the world"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;

                    case '<':
                        sb.Append("\\u003C");
                        break;

                    case '>':
                        sb.Append("\\u003E");
                        break;

                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }
    }
}