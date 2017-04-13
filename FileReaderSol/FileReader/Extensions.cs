using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader
{
    public static class Extensions
    {
        /// <summary>
        /// check the length to escape out of range exception
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringCutEnd(this string value, int start, int length)
        {
            if (value.Substring(start).Length < length) length = value.Substring(start).Length;

            return value.Substring(start, length);
        }
    }
}