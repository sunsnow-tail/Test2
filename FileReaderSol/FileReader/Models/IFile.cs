using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// the idea was to create IoC container but I decided to load files from UI => I do not think that there is a need for IoC
    /// </summary>
    public interface IFile
    {
        Position Name { get; set; }

        Position ISBN { get; set; }

        Position AUTHOR { get; set; }
    }
}