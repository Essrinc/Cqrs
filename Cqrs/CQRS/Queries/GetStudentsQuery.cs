using Cqrs.CQRS.Results.Queries;
using MediatR;
using System.Collections.Generic;

namespace Cqrs.CQRS.Queries
{
    public class GetStudentsQuery:IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
