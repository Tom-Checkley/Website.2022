using Microsoft.AspNetCore.Html;
using System.Collections.Specialized;
using System.Web;
using Umbraco.Extensions;

namespace TomCheckley.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces line breaks with br tags and outputs as a HtmlString.
        /// </summary>
        /// <param name="value">The raw string.</param>
        /// <returns>The string as a HtmlString.</returns>
        public static IHtmlContent ToHtmlString(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                value = string.Empty;
            }

            value = value.Replace("\n", "<br />");
            value = value.Replace("\r", "");    // Don't convert \r as well or we might end up with double the line breaks
            return new HtmlString(value);
        }

        /// <summary>
        /// Method to add or replace the query string value in a string.
        /// </summary>
        /// <param name="url">The base URL to update. This does not need to contain a query string already, and does not need to contain the domain part.</param>
        /// <param name="key">The string representing the key of the query string value that will be updated.</param>
        /// <param name="value">The string that we will be updating the query string value to.</param>
        /// <param name="encode">Whether the query string value should be UTF8 encoded.</param>
        /// <returns>A URL containing the updated query string.</returns>
        public static string UpdateQueryStringValue(this string url, string key, string value, bool encode = true)
        {
            if (url.IsNullOrWhiteSpace())
            {
                return null;
            }

            string urlPart = url;
            string qsPart = string.Empty;
            if (url.Contains("?"))
            {
                string[] uriParts = url.Split('?');
                urlPart = uriParts.First();
                qsPart = uriParts.Last();
            }

            if (encode)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(qsPart);
                qs.Set(key, value);
                return urlPart + "?" + qs.ToString();
            }
            else
            {
                string output = urlPart + "?";
                if (!qsPart.IsNullOrWhiteSpace())
                {
                    output += qsPart + "&";
                }
                return output + key + "=" + value;
            }
        }
    }
}
