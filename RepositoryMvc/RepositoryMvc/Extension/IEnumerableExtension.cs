using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryMvc.Extension
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, string> valueFunc, Func<T, string> textFunc)
        {
            return source.Select(x => new SelectListItem
            {
                Value = valueFunc(x),
                Text = textFunc(x)
            });
        }
    }
}