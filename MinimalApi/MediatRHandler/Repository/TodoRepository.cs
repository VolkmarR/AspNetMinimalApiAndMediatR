using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRHandler.Repository
{

    public class TodoRepository
    {
        public record Todo(int Id, string Description, bool Done);

        int _NextID = 1;
        List<Todo> _Todo = new() { new Todo(0, "dummy", false)};

        public IReadOnlyList<Todo> Get()
            => _Todo;

        public void Add(string description)
            => _Todo.Add(new Todo(_NextID++, description, false));
    }
}
