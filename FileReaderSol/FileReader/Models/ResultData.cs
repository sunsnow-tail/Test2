using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReader.Models
{
    /// <summary>
    /// keeps results and paging data
    /// </summary>
    public class ResultData
    {
        public List<FileData> FileData { get; set; }

        public Pager Pager { get; set; }
    }
}