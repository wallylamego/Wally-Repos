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
    public class JoinArrayController : Controller
    {
        [Route("api/joinArray")]
        [HttpGet]
        [HttpPost]
        public ActionResult JoinArray()
        {
            var dbType = Environment.GetEnvironmentVariable("DBTYPE");
            var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION");

            using (var db = new Database(dbType, dbConnection))
            {
                var response = new Editor(db, "users", "users.id")
                    .Debug(true)
                    .Model<JoinModelUsers>("users")
                    .Model<JoinModelSites>("sites")
                    .Field(new Field("users.site")
                        .Options(new Options()
                            .Table("sites")
                            .Value("id")
                            .Label("name")
                        )
                    )
                    .LeftJoin("sites", "sites.id", "=", "users.site")
                    .MJoin(new MJoin("permission")
                        .Link("users.id", "user_permission.user_id")
                        .Link("permission.id", "user_permission.permission_id")
                        .Model<JoinAccessModel>()
                        .Order("permission.name")
                        .Validator("permission[].id", Validation.MjoinMaxCount(4, "No more than four selections please"))
                        .Field(new Field("id")
                            .Options(new Options()
                                .Table("permission")
                                .Value("id")
                                .Label("name")
                            )
                        )
                    )
                    .Process(Request)
                    .Data();

                return Json(response);
            }
        }
    }
}
