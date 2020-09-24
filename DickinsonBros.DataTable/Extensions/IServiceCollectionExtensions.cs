using DickinsonBros.DataTable.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DickinsonBros.DataTable.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataTableService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IDataTableService, DataTableService>();
            serviceCollection.AddMemoryCache();
            return serviceCollection;
        }
    }
}
