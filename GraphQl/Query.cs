using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQl
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> BlahPlatform([ScopedService] AppDbContext context)
        {
            return context.platforms;
        }
        
        [UseDbContext(typeof(AppDbContext))]
         [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}