using MediatR;
using MediatRHandler.Repository;

namespace MediatRHandler
{

    public class TodoQuery : IRequest<List<TodoQueryDto>>
    {

    }

    public record TodoQueryDto(int Id, string Description, bool Done);

    public class TodoQueryHandler : IRequestHandler<TodoQuery, List<TodoQueryDto>>
    {
        private readonly TodoRepository _Repository;

        public TodoQueryHandler(TodoRepository repository)
        {
            _Repository = repository;
        }

        public Task<List<TodoQueryDto>> Handle(TodoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_Repository.Get().Select(q => new TodoQueryDto(q.Id, q.Description, q.Done)).ToList()); 
        }
    }
}