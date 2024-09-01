using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace wmsApi.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new
            {
                currentPage,
                itemsPerPage,
                totalItems,
                totalPages
            };
#pragma warning disable ASP0019 // Suggest using IHeaderDictionary.Append or the indexer
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader));
#pragma warning restore ASP0019 // Suggest using IHeaderDictionary.Append or the indexer
        }
    }
}