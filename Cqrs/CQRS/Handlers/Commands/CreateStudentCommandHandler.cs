using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs.CQRS.Handlers.Commands
{
    public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;
        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        //public void Handle(CreateStudentCommand command)
        //{
        //    _context.Students.Add(new Student { Name = command.Name, Surname = command.Surname, Age = command.Age});
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student { Name = request.Name, Surname = request.Surname, Age = request.Age });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
