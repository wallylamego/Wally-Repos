﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using DataTables;
using EditorNetCoreDemo.Models;

namespace EditorNetCoreDemo.Controllers
{
    /// <summary>
    /// This is controller is used by the majority of Editor examples as it
    /// provides a nice rounded set of information for the client-side Editor
    /// Javascript library to show its capabilities.
    ///
    /// In the code here, note that the `StaffModel` is used as the model for
    /// the Editor, which automatically defines the database fields to be read.
    /// Additional instructions can be given for each field by creating a `Field`
    /// instance for it - many of the fields have validation methods applied here
    /// and the date field has a formatter to make it readable to users looking
    /// at the table!
    /// </summary>
    public class UploadController : Controller
    {
        [HttpGet, HttpPost, Route("api/upload")]
        public ActionResult Staff()
        {
            var dbType = Environment.GetEnvironmentVariable("DBTYPE");
            var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION");

            using (var db = new Database(dbType, dbConnection))
            {
                var response = new Editor(db, "users")
                    .Model<UploadModel>()
                            .TryCatch(false)
                    .Field(new Field("image")
                        .SetFormatter(Format.IfEmpty(null))
                        .Upload(new Upload(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "__ID____EXTN__"))
                            .Db("files", "id", new Dictionary<string, object>
                            {
                                {"web_path", Path.DirectorySeparatorChar+Path.Combine("uploads", "__ID____EXTN__")},
                                {"system_path", Upload.DbType.SystemPath},
                                {"filename", Upload.DbType.FileName},
                                {"filesize", Upload.DbType.FileSize}
                            })
                            .DbClean(data =>
                            {
                                foreach (var row in data)
                                {
                                    // Do something;
                                }
                                return true;
                            })
                            .Validator(Validation.FileSize(500000, "Max file size is 500K."))
                            .Validator(Validation.FileExtensions( new [] {"jpg", "png", "gif"}, "Please upload an image."))
                        )
                    )
                    .Process(Request)
                    .Data();

                return Json(response);
            }
        }
    }
}
