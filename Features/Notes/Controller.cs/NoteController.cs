using Microsoft.AspNetCore.Mvc;

namespace apief
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _notesService;
        private readonly IIdentityUser _identity;

        public NoteController(INoteService noteService, IIdentityUser identityUser)
        {
            _notesService = noteService;
            _identity = identityUser;
        }


        [HttpPost]
        public async Task<IActionResult> PostNote(NoteDto noteDto)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var createdNote = await _notesService.CreateNoteAsync(noteDto, identity.id);
                return Ok(new ApiResponse(success: true, data: createdNote));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetNote()
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var response = await _notesService.GetNotesAsync(identity.id);
                return Ok(new ApiResponse(success: true, data: response));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }


        [HttpPut("noteId")]
        public async Task<IActionResult> PutNote(Guid noteId, NoteDto note)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var updateNote = await _notesService.UpdateNoteAsync(noteId, note, identity.id);
                return Ok(new ApiResponse(success: true, data: updateNote));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }


        [HttpDelete("noteId")]
        public async Task<IActionResult> DeleteNote(Guid noteId)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                await _notesService.DeleteNoteAsync(noteId, identity.id);
                return Ok(new ApiResponse(success: true, data: Ok()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }
    }
}