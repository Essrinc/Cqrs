using Cqrs.CQRS.Results.Queries;
using MediatR;

namespace Cqrs.CQRS.Queries
{
    public class GetStudentByIdQuery:IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
