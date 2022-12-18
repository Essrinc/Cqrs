using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs.CQRS.Handlers.Commands
{
    public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;
        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        //public void Handle(UpdateStudentCommand command)
        //{
        //    var updatedStudent = _context.Students.Find(command.Id);
        //    updatedStudent.Name = command.Name;
        //    updatedStudent.Surname = command.Surname;
        //    updatedStudent.Age = command.Age;
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = await _context.Students.FindAsync(request.Id);
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            updatedStudent.Age = request.Age;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
