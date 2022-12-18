using Cqrs.CQRS.Queries;
using Cqrs.CQRS.Results.Queries;
using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.CQRS.Handlers.Queries
{
    public class GetStudentsQueryHandler:IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;
        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Select(x => new GetStudentsQueryResult
            {
                Name = x.Name,
                Surname = x.Surname,
                Age = x.Age
            }).AsNoTracking().ToListAsync();
        }

        //public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        //{
        //    return _context.Students.Select(x => new GetStudentsQueryResult
        //    {
        //        Name = x.Name,
        //        Surname = x.Surname,
        //        Age = x.Age
        //    }).AsNoTracking().AsEnumerable();
        //}


    }
}
