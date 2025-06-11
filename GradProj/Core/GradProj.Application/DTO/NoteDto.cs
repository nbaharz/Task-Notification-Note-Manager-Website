using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.DTO
{
    public class NoteDto
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}
