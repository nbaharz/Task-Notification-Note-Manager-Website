
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class NoteService: GenericService<Note>, INoteService
    {
        private readonly INoteRepository _noteRepository;
       
        public NoteService(INoteRepository noteRepository) : base(noteRepository)
        {
            _noteRepository = noteRepository;
            
        }

        public List<Note> GetUserNotes(Guid userid)
        {
            return _noteRepository.GetSingleAsync(u => u.UserId == userid).ToList();
        }
    }
}
