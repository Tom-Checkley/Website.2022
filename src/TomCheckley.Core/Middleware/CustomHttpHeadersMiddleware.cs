using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.Middleware
{
    internal class CustomHttpHeadersMiddleware
    {
        private readonly IEnumerable<string> _Extensions = new List<string>() { ".js", ".css", ".svg", ".jpg", ".png", ".json", ".woff", ".woff2", ".webp", "mp4" };
        private readonly RequestDelegate _next;
        private readonly string _contentSecurityPolicy;
        private readonly bool _isProduction;
        private readonly string _environmentName;
        private readonly string _datacenter;

        public CustomHttpHeadersMiddleware(
            RequestDelegate next,
            IWebHostEnvironment environment,
            IConfiguration config)
        {
            _next = next;
            _isProduction = environment.IsProduction();
            _environmentName = (_isProduction ? null : environment.EnvironmentName) ?? string.Empty;
            _contentSecurityPolicy = BuildContentSecurityPolicy(_isProduction);
        }

        /// <summary>
        /// Invokes the middleware asychronosly.
        /// </summary>
        /// <param name="context">The current HTTP context.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the actions performed by the middleware.
        /// </returns>
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            context.Response.OnStarting(() =>
            {
                if (!_Extensions.Any(x => context.Request.Path.Value.EndsWith(x)))
                {
                    context.Response.Headers.Remove("Content-Security-Policy");
                    context.Response.Headers.Remove("Feature-Policy");
                    context.Response.Headers.Remove("Permissions-Policy");
                    context.Response.Headers.Remove("Referrer-Policy");
                    context.Response.Headers.Remove("X-Content-Type-Options");
                    context.Response.Headers.Remove("X-Datacenter");
                    context.Response.Headers.Remove("X-Download-Options");
                    context.Response.Headers.Remove("X-Frame-Options");
                    context.Response.Headers.Remove("X-XSS-Protection");
                    context.Response.Headers.Remove("X-Debug");
                    context.Response.Headers.Remove("X-Environment");
                    context.Response.Headers.Remove("X-Instance");
                    context.Response.Headers.Remove("X-Request-Id");
                    context.Response.Headers.Remove("X-Request-Duration");
#if !DEBUG
                    context.Response.Headers.Add("Content-Security-Policy", _contentSecurityPolicy);
#endif
                    context.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'");
                    context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");
                    context.Response.Headers.Add("Referrer-Policy", "no-referrer-when-downgrade");
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    context.Response.Headers.Add("X-Datacenter", _datacenter);
                    context.Response.Headers.Add("X-Download-Options", "noopen");
                    context.Response.Headers.Add("X-Frame-Options", "DENY");
                    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");

#if DEBUG
                    context.Response.Headers.Add("X-Debug", "true");
#endif

                    if (_environmentName != null)
                    {
                        context.Response.Headers.Add("X-Environment", _environmentName);
                    }

                    context.Response.Headers.Add("X-Instance", Environment.MachineName);
                    context.Response.Headers.Add("X-Request-Id", context.TraceIdentifier);

                    stopwatch.Stop();

                    string duration = stopwatch.Elapsed.TotalMilliseconds.ToString(
                        "0.00ms",
                        CultureInfo.InvariantCulture);

                    context.Response.Headers.Add("X-Request-Duration", duration);
                }
                return Task.CompletedTask;
            });

            await _next(context);
        }

        /// <summary>
        /// Builds the Content Security Policy to use for the website.
        /// </summary>
        /// <param name="isProduction">Whether the current environment is production.</param>
        /// <param name="options">The current site configuration options.</param>
        /// <returns>
        /// A <see cref="string"/> containing the Content Security Policy to use.
        /// </returns>
        private static string BuildContentSecurityPolicy(bool isProduction)
        {
            var builder = new StringBuilder();
            builder.Append("default-src 'self' stackpath.bootstrapcdn.com;");
            builder.Append("script-src 'self' www.gstatic.com www.googletagmanager.com www.google.com google.com ajax.googleapis.com cdnjs.cloudflare.com stackpath.bootstrapcdn.com www.google-analytics.com 'unsafe-inline' 'unsafe-eval';");
            builder.Append("style-src 'self' www.goggle.com google.com ajax.googleapis.com cdnjs.cloudflare.com fonts.googleapis.com stackpath.bootstrapcdn.com 'unsafe-inline';");
            builder.Append("img-src 'self' data: i.ytimg.com online.swagger.io www.google-analytics.com google.com;");
            builder.Append("font-src 'self' www.google.com google.com ajax.googleapis.com fonts.googleapis.com fonts.gstatic.com stackpath.bootstrapcdn.com;");
            builder.Append("frame-src 'self' www.google.com www.youtube.com www.youtube-nocookie.com;");
            builder.Append("connect-src 'self';");
            builder.Append("media-src 'none';");
            builder.Append("object-src 'none';");
            builder.Append("child-src 'none';");
            builder.Append("frame-ancestors 'none';");
            builder.Append("form-action 'self';");
            builder.Append("block-all-mixed-content;");
            builder.Append("manifest-src 'self';");

            if (isProduction)
            {
                builder.Append("upgrade-insecure-requests;");
            }

            return builder.ToString();
        }
    }
}
