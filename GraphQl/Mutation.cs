using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQl.Platforms;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQl
{
    public class Mutations
    {
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
        [ScopedService] AppDbContext context)
        {
            var platform = new Platform{
                Name = input.name
            };

            context.platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }
    }
}