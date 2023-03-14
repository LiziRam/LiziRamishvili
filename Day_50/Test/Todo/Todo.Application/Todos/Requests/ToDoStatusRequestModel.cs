using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain;

namespace Todo.Application.Todos.Requests
{
    public class TodoStatusRequestModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
