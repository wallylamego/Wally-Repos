using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using DataTables;
using EditorNetCoreDemo.Models;

namespace EditorNetCoreDemo.Controllers
{
    /// <summary>
    /// This controller is used by the majority of Editor examples as it
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
    public class StaffViewController : Controller
    {
        [Route("api/staff-view")]
        [HttpGet]
        [HttpPost]
        public ActionResult Staff()
        {
            var dbType = Environment.GetEnvironmentVariable("DBTYPE");
            var dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION"); 

            using (var db = new Database(dbType, dbConnection))
            {
                var response = new Editor(db, "users")
					.ReadTable("staff_newyork")
                    .Field(new Field("first_name")
                        .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("last_name"))
                    .Field(new Field("phone"))
                    .Field(new Field("city"))
                    .Process(Request)
                    .Data();

                return Json(response);
            }
        }
    }
}
