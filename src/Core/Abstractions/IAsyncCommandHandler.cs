using System.Threading.Tasks;

namespace ShipService.Infrastructure.Core.Abstractions
{
    public interface IAsyncCommandHandler<in TCommand>
        where TCommand : Command
    {
        Task<CommandRespose> HandleAsync(TCommand command);
    }
}
