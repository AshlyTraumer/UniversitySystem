using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public static class HtmlHelperExtensions
    {
        public static string GetValidClass(this HtmlHelper helper, ModelStateDictionary model, string className)
        {
            if (model[className]?.Errors.Count > 0)
                return "valid-error";
            else
                return "";
        }

    }
}