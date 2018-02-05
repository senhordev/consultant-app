using System.Threading.Tasks;
using ConsultTeam.Domain.Core.Commands;
using ConsultTeam.Domain.Core.Events;


namespace ConsultTeam.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}