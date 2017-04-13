using FileReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileReader.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        {
            //clean error data
            Session["ErrorData"] = null;

            var result = new ResultData()
            {
                Pager = new Pager(0, 0),
                FileData = new List<FileData>()
            };

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // Read bytes from http input stream
                    BinaryReader bReader = new BinaryReader(file.InputStream);
                    byte[] binData = bReader.ReadBytes((int)file.InputStream.Length);

                    List<ErrorData> errors;

                    result.FileData.AddRange(FilesReader.ReadFile(binData, file.FileName, out errors));

                    var tempError = (ResultErrors)Session["ErrorData"] ?? 
                        new ResultErrors()
                        {
                            FileErrors = new List<ErrorData>()
                        };

                    tempError.FileErrors.AddRange(errors);

                    Session["ErrorData"] = tempError;
                }
            }

            var pager = new Pager(result.FileData.Count(), 1);
            result.Pager = pager;

            //temp data life time is too short for my purpose
            //TempData["Results"] = _result;
            Session["Results"] = result;

            ViewBag.Title = "Result";

            return View("Result", result);
        }

        [HttpGet]
        public ActionResult Result(int? page)
        {
            //i need a new variable, not a reference
            var savedResult = new ResultData()
            {
                Pager = new Pager(0, 0),
                FileData = new List<FileData>()
            };

            if (Session["Results"] != null)
            {
                savedResult.FileData.AddRange(((ResultData)Session["Results"]).FileData);
            }

            if (savedResult.FileData.Count() == 0)
            {
                ViewBag.Title = "No Result";
            }
            else
            {
                ViewBag.Title = "Result";

                var pager = new Pager(savedResult.FileData.Count(), page);
                savedResult.Pager = pager;
                savedResult.FileData = savedResult.FileData.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            }

            return View(savedResult);
        }

        [HttpGet]
        public ActionResult Errors(int? page)
        {
            //i need a new variable, not a reference
            var errors = new ResultErrors()
            {
                FileErrors = new List<ErrorData>()
            };

            //add session error data
            if (((ResultErrors)Session["ErrorData"]) != null)
            {
                errors.FileErrors.AddRange(((ResultErrors)Session["ErrorData"]).FileErrors);
            }

            if (errors == null || errors.FileErrors == null || errors.FileErrors.Count() == 0)
            {
                ViewBag.Title = "No Errors";
            }
            else
            {
                ViewBag.Title = errors.FileErrors.Count() + " Errors";

                var pager = new Pager(errors.FileErrors.Count(), page);
                errors.Pager = pager;
                errors.FileErrors = errors.FileErrors.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            }            

            return View(errors);
        }
    }
}