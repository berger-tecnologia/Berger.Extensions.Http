using System.Security.Claims;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace Berger.Extensions.Http
{
    public static class HttpContextHelper
    {
        public static string GetIp(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public static string GetIp(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public static string GetHeader(this IHttpContextAccessor accessor, string header)
        {
            return accessor.HttpContext.Request.Headers[header].ToString();
        }
        public static string GetHeader(this HttpContext context, string header)
        {
            return context.Request.Headers[header].ToString();
        }
        public static string GetClaims(this HttpContext context, string claim)
        {
            return GetClaims(context.User, claim);
        }
        public static string GetClaims(this AuthorizationHandlerContext context, string claim)
        {
            return GetClaims(context.User, claim);
        }
        public static string GetClaims(ClaimsPrincipal claimPrincipal, string claim)
        {
            return claimPrincipal.FindFirstValue(claim);
        }
        public static string GetBearer(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.GetBearer();
        }
        public static string GetBearer(this HttpContext context)
        {
            var token = context.GetHeader(HeaderNames.Authorization);

            if (!string.IsNullOrEmpty(token))
                return token.Replace("Bearer ", string.Empty);

            return string.Empty;
        }
    }
}