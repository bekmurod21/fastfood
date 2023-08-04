using Newtonsoft.Json;
using FastFood.Domain.Commons;
using FastFood.Service.Helpers;
using FastFood.Service.Exceptions;
using FastFood.Domain.Configurations;

namespace FastFood.Service.Extensions
{
    public static class CollectionExtension
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> sources,
            PaginationParams @params = null) where T:Auditable
        {
            var metaData = new PaginationMetaData(sources.Count(),@params);

            var json = JsonConvert.SerializeObject(metaData);

            if(HttpContextHelper.ResponseHeaders != null)
            {
                  if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
                      HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

                  HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);

            }
            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                    sources.OrderBy(e => e.Id)
                    .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                        throw new CustomException(400, "Please, enter valid numbers");

        }
    }
}
