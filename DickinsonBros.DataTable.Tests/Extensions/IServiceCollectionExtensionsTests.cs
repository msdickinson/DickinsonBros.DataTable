using DickinsonBros.DataTable.Abstractions;
using DickinsonBros.DataTable.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DickinsonBros.DataTable.Tests.Extensions
{
    [TestClass]
    public class IServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddDataTableService_Should_Succeed()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddDataTableService();

            // Assert

            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IDataTableService) &&
                                           serviceDefinition.ImplementationType == typeof(DataTableService) &&
                                           serviceDefinition.Lifetime == ServiceLifetime.Singleton));


        }
    }
}
