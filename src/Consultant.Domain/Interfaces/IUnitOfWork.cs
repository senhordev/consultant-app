using System;
using ConsultTeam.Domain.Core.Commands;

namespace Consultant.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
