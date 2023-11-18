using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO_B.E.Data;
using TODO_B.E.Models;

namespace TODO_B.E.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public NotesController(AppDbContext appDbContext)
        {
            this.appDbContext=appDbContext;
        }

        //add notes to database (post)
        [HttpPost]
        public async Task<ActionResult<List<Notes>>> AddNote(Notes newNote)
        {

            if (newNote != null)
            { 
               appDbContext.Note.Add(newNote);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Note.ToListAsync());
            }
            return BadRequest("Object is not formed properly");
        }

        //get all notes (get)
        [HttpGet]
        public async Task<ActionResult<List<Notes>>> GetAllNotes()
        { 
            var notes = await appDbContext.Note.ToListAsync();
            return Ok(notes);
        }

        //update notes (put)
        [HttpPut]
        public async Task<ActionResult<Notes>> UpdateNotes(Notes updateNote)
        {
            if (updateNote != null)
            { 
               var note = await appDbContext.Note.FirstOrDefaultAsync(e => e.Id == updateNote.Id);
                note!.Content=updateNote.Content;
                await appDbContext.SaveChangesAsync();
                return Ok(note);

            }
            return BadRequest("User not found");
        }

        //delete notes (delete)

        [HttpDelete]
        public async Task<ActionResult<List<Notes>>> DeleteNote(int id)
        {
            var note = await appDbContext.Note.FirstOrDefaultAsync(e => e.Id == id);
            if (note != null)
            { 
               appDbContext.Note.Remove(note);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Note.ToArrayAsync());
            }
            return NotFound();

        }
    }
}
