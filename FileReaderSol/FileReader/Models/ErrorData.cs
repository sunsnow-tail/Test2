using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// a model for errors
    /// </summary>
    public class ErrorData
    {
        public string FileName { get; set; }

        public string Error { get; set; }

        public string RowData { get; set; }
    }
}