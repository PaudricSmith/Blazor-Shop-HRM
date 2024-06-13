using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlazorShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepository;


        public AnnouncementController(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAllAnnouncements()
        {
            return Ok(await _announcementRepository.GetAllAnnouncements());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> GetAnnouncementById(int id)
        {
            var announcement = await _announcementRepository.GetAnnouncementById(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return Ok(announcement);
        }

        [HttpPost]
        public async Task<ActionResult<Announcement>> AddAnnouncement(Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest();
            }

            var createdAnnouncement = await _announcementRepository.AddAnnouncement(announcement);

            return CreatedAtAction(nameof(GetAnnouncementById), new { id = createdAnnouncement.AnnouncementId }, createdAnnouncement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Announcement>> UpdateAnnouncement(int id, [FromBody] Announcement announcement)
        {
            if (announcement == null || announcement.AnnouncementId != id)
            {
                return BadRequest();
            }

            var updatedAnnouncement = await _announcementRepository.UpdateAnnouncement(announcement);
            if (updatedAnnouncement == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnnouncement(int id)
        {
            var announcementToDelete = await _announcementRepository.GetAnnouncementById(id);
            if (announcementToDelete == null)
            {
                return NotFound();
            }

            await _announcementRepository.DeleteAnnouncement(id);

            return NoContent();
        }
    }
}
