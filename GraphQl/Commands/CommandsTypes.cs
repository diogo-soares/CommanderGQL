using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQl.Commands
{
    public class CommandsType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Respresents any executable command"); 

            descriptor
                     .Field(c => c.Platform)
                     .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                     .UseDbContext<AppDbContext>()
                     .Description("this is the platform to which the command belongs");           
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}