using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQl
{
    public class Query
    {
        public IQueryable<Platform> BlahPlatform([Service] AppDbContext context)
        {
            return context.platforms;
        }
    }
}