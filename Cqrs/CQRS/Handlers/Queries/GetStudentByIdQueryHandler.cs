using Cqrs.CQRS.Queries;
using Cqrs.CQRS.Results.Queries;
using Cqrs.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cqrs.CQRS.Handlers.Queries
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;
        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student =  await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            };
        }

        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _context.Set<Student>().Find(query.Id);
        //    return new GetStudentByIdQueryResult
        //    {
        //        Name = student.Name,
        //        Surname = student.Surname,
        //        Age = student.Age
        //    };
        //}
    }
}
