using System;
using Microsoft.Extensions.DependencyInjection;
using MyTodoListApi.Data;
namespace MyTodoListApi
{
    /// <summary>
    /// The scoped instance of the application dbcontext
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// A shorthand access class to get dependency injection with clean short code
        /// </summary>
        public static ToDoListDbContext AppContext => ServiceProviderContainer.Provider.GetService<ToDoListDbContext>();

    }
    public static class ServiceProviderContainer
    {
        /// <summary>
        /// the application service provider
        /// </summary>
        public static IServiceProvider Provider { get; set; }
    
    }
}
