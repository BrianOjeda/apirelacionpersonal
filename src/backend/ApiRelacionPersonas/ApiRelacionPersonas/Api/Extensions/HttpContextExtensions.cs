using Microsoft.EntityFrameworkCore;

namespace ApiRelacionPersonas.Api
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParameterPaginationHeader<T>(this HttpContext httpContext,IQueryable<T> queryable)
        {
            if(httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));


            double count = await queryable.CountAsync();

            httpContext.Response.Headers.Add("CantidadTotalRegistros", count.ToString());
        }
    }
}
