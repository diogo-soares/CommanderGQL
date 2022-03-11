using System.Threading;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQl.Commands;
using CommanderGQL.GraphQl.Platforms;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQl
{
    public class Mutation
    {
        public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput input,
        [ScopedService] AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken
        )
            {
            var platform = new Platform{
                Name = input.name
          
            };

            context.platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPlayload> AddCommandAsync(AddCommandInput  input,
              [ScopedService] AppDbContext context)
              {
                  var command = new Command{
                      Howto = input.howTo,
                      CommadLine = input.CommandLine,
                      PlatformId = input.PlatformId
                  };

                  context.Commands.Add(command);
                  await context.SaveChangesAsync();

                  return new AddCommandPlayload(command);
              }
    }
}