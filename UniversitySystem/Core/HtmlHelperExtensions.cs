using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public static class HtmlHelperExtensions
    {
        public static string getValidClass(this HtmlHelper helper, ModelStateDictionary model)
        {
            
            if (!model.IsValid)
                return "valid-error";
            else
                return "";
        }

    }
}