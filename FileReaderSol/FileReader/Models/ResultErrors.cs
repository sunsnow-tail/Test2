using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// keeps errors and paging data
    /// </summary>
    public class ResultErrors
    {
        public List<ErrorData> FileErrors { get; set; }

        public Pager Pager { get; set; }
    }
}