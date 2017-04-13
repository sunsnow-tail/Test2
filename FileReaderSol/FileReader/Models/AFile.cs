using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// decribes A file data structure
    /// </summary>
    public class AFile : IFile
    {

        public Position AUTHOR { get; set; } =
            new Position
            {
                Start = 42,
                End = 62
            };        

        public Position ISBN { get; set; } =
            new Position
            {
                Start = 21,
                End = 41
            };

        public Position Name { get; set; } =
            new Position
            {
                Start = 1,
                End = 20
            };

        
    }
}