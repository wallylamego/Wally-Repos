﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using DataTables;
using EditorNetCoreDemo.Models;

namespace EditorNetCoreDemo.Controllers
{
    /// <summary>
    /// This example shows a very simple join using the `LeftJoin` method.
    /// Of particular note in this example is that the `JoinModel` defines two
    /// nested classes that obtain the data required from the two tables, where
    /// the nested class name defines the database table and the properties of
    /// the nested classes define the columns in each table.
    ///
    /// Note also the use of the `Options()` method for the `users.site` method
    /// which is used to retrieve the information for the `Site` drop down list
    /// on the client-side, which is automatically populated when the data is
    /// loaded.
    /// </summary>
    public class SoftDeleteController : Controller
    {
        [Route("api/softDelete")]
        [HttpGet]
        [HttpPost]
        public ActionResult Join()
        {
            var dbType = Environment.GetEnvironmentVariable("DBTYPE");
            var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION");

            using (var db = new Database(dbType, dbConnection))
            {
                var editor = new Editor(db, "users")
                    .Model<JoinModelUsers>("users")
                    .Model<JoinModelSites>("sites")
                    .Field(new Field("users.removed_date")
                        .SetFormatter(Format.IfEmpty(null))
                    )
                    .Field(new Field("users.site")
                        .Options(new Options()
                            .Table("sites")
                            .Value("id")
                            .Label("name")
                        )
                        .Validator(Validation.DbValues(new ValidationOpts { Empty = false }))
                    )
                    .LeftJoin("sites", "sites.id", "=", "users.site")
                    .Where("removed_date", null);

                // Disallow delete just in case anyone uses the API to do it
                editor.PreRemove += (sender, args) => args.Cancel = true;

                var response = editor
                    .Process(Request)
                    .Data();

                return Json(response);
            }
        }
    }
}
