using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public static class HtmlHelperExtensions
    {
        public static string GetValidClass(this HtmlHelper helper, ModelStateDictionary model, string className)
        {
            return model[className]?.Errors.Count > 0 ? "valid-error" : string.Empty;
        }
    }
}