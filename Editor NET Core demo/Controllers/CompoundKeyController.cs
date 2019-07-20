﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using DataTables;
using EditorNetCoreDemo.Models;

namespace EditorNetCoreDemo.Controllers
{
    public class CompoundKeyController : Controller
    {
        [Route("api/compoundKey")]
        [HttpGet]
        [HttpPost]
        public ActionResult CompoundKey()
        {
            var dbType = Environment.GetEnvironmentVariable("DBTYPE");
            var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION");

            using (var db = new Database(dbType, dbConnection))
            {
                var response = new Editor(db, "users_visits", new[] {"user_id", "visit_date"})
                    .TryCatch(false)
                    .Model<CompoundKeyModel>()
                    .Field(new Field("users_visits.user_id")
                        .Options( new Options()
                            .Table("users")
                            .Value("id")
                            .Label(new[] {"first_name", "last_name"})
                        )
                    )
                    .Field(new Field("users_visits.site_id")
                        .Options(new Options()
                            .Table("sites")
                            .Value("id")
                            .Label("name")
                        )
                    )
                    .Field(new Field("users_visits.visit_date")
                        .Validator(Validation.DateFormat(
                            Format.DATE_ISO_8601,
                            new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                        ))
                        .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
                        .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
                    )
                    .Field(new Field("sites.name").Set(false))
                    .Field(new Field("users.first_name").Set(false))
                    .Field(new Field("users.last_name").Set(false))
                    .LeftJoin("sites", "users_visits.site_id", "=", "sites.id")
                    .LeftJoin("users", "users_visits.user_id", "=", "users.id")
                    .Validator((editor, type, args) =>
                    {
                        if (type == DtRequest.RequestTypes.EditorEdit)
                        {
                            foreach (var d in args.Data)
                            {
                                var pkey = editor.PkeyToArray(d.Key);
                                var keyUserVisits = pkey["users_visits"] as Dictionary<string, object>;
                                var userVisits = d.Value as Dictionary<string, object>;
                                var submitUserVisits = userVisits["users_visits"] as Dictionary<string, object>;

                                if (keyUserVisits["user_id"] != submitUserVisits["user_id"] &&
                                    keyUserVisits["visit_date"] != submitUserVisits["visit_date"])
                                {
                                    var any = editor.Db().Any("users_visits", (q) =>
                                    {
                                        q.Where("user_id", submitUserVisits["user_id"]);
                                        q.Where("visit_date", submitUserVisits["visit_date"]);
                                    });

                                    if (any)
                                    {
                                        return "This staff member is already busy that day.";
                                    }
                                }
                            }
                        }

                        return null;
                    })
                    .Process(Request)
                    .Data();

                return Json(response);
            }
        }
    }
}