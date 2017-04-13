using FileReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileReader
{
    public static class FilesReader
    {
        /// <summary>
        /// read data from bytes
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="fileName">file name for error message</param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<FileData> ReadFile(byte[] fileData, string fileName, out List<ErrorData> errors)
        {
            errors = new List<ErrorData>();

            var lines = System.Text.Encoding.UTF8.GetString(fileData).Split(new string[] { "\r\n" }, StringSplitOptions.None);

            var fileType = lines.FirstOrDefault();

            if (fileType == null) throw new Exception("File " + fileName + " has wrong format. File type is not specified");

            IFile file;

            switch (fileType)
            {
                case "A":
                    file = new AFile();
                    break;
                case "B":
                    file = new BFile();
                    break;
                default: throw new Exception("File " + fileName + " has wrong file type in the first line.");
            }

            var data = new List<FileData>();

            foreach (var line in lines.Skip(1))
            {
                if (line.Contains("\t") || string.IsNullOrWhiteSpace(line))
                {
                    //log error
                    errors.Add(new ErrorData
                    {
                        FileName = fileName,
                        RowData = line,
                        Error = line.Contains("\t") ? "Tab is inserted in the data" : "Empty string instead of data"
                    });

                    continue;
                }

                //-1 as model count characters from 1 but substring from 0
                data.Add(new FileData
                {
                    Name = line.SubstringCutEnd(file.Name.Start - 1, file.Name.Length),
                    AUTHOR = line.SubstringCutEnd(file.AUTHOR.Start - 1, file.AUTHOR.Length),
                    ISBN = line.SubstringCutEnd(file.ISBN.Start - 1, file.ISBN.Length)
                });
            }

            return data;
        }
    }
}