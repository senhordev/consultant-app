using Consultant.Domain.Interfaces;
using Consultant.Infra.Data.Context;
using ConsultTeam.Domain.Core.Commands;

namespace Consultant.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConsultantContext _context;

        public UnitOfWork(ConsultantContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}