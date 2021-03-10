using MD.PersianDateTime.Standard;
using System;
using System.Linq;

namespace GMSBackend.Framework
{
    public static class Extensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }


        public static DateTime ToDateTime(this string persiandatestr)
        {
            try
            {
                return PersianDateTime.Parse(persiandatestr, "/").ToDateTime();
            }
            catch
            {
                return DateTime.Now;
            }

        }

        public static string ToDateTimeStr(this string persiandatestr)
        {
            try
            {
                return PersianDateTime.Parse(persiandatestr, "/").ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }


        public static decimal ToDeciaml(this object obj)
        {
            try
            {
                return decimal.Parse(obj.ToString());
            }
            catch
            {
                return 0;
            }

        }
    }
}