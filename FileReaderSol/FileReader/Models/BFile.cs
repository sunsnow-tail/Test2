using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// decribes B file data structure
    /// </summary>
    public class BFile : IFile
    {

        public Position AUTHOR { get; set; } =
            new Position
            {
                Start = 52,
                End = 72
            };

        public Position ISBN { get; set; } =
            new Position
            {
                Start = 31,
                End = 51
            };

        public Position Name { get; set; } =
            new Position
            {
                Start = 1,
                End = 30
            };       
    }
}