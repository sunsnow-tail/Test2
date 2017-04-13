using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// keeps positions for data in files
    /// </summary>
    public class Position
    {
        public int Start { get; set; }

        public int End { get; set; }

        /// <summary>
        /// End - Start
        /// </summary>
        public int Length
        {
            get
            {
                return End - Start;
            }
        }
    }
}