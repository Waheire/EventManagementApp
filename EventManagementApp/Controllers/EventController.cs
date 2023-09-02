using AutoMapper;
using EventManagementApp.Entities;
using EventManagementApp.Request;
using EventManagementApp.Response;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace EventManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EventService _eventService;

        public EventController(IMapper mapper, EventService service)
        {
            _mapper = mapper;
            _eventService = service;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddEvent(AddEvent newEvent)
        {
            var eventItem = _mapper.Map<Event>(newEvent);
            var res = await _eventService.AddEventAsync(eventItem);
            return CreatedAtAction(nameof(AddEvent), new SuccessResponse(201, res));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetAllEvents()
        {
            var response = await _eventService.GetAllEventsAsync();
            var events = _mapper.Map<IEnumerable<EventResponse>>(response);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> GetEvent(Guid id)
        {
            var response = await _eventService.GetEventByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new SuccessResponse(404, "Event Does not Exist."));
            }
            var eventItem = _mapper.Map<EventResponse>(response);
            return Ok(eventItem);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessResponse>> UpdateEvent(Guid id, AddEvent UpdatedEvent)
        {
            var response = await _eventService.GetEventByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "Event Does not Exist."));
            }
            //update 
            var updatedEvent = _mapper.Map(UpdatedEvent, response);
            var res = await _eventService.UpdateEventAsync(updatedEvent);
            return Ok(new SuccessResponse(204, res));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessResponse>> DeleteEvent(Guid id)
        {
            var response = await _eventService.GetEventByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new SuccessResponse(404, "Event Does not Exist."));
            }
            //Delete
            var res = await _eventService.DeleteEventAsync(response);
            return Ok(new SuccessResponse(204, res));
        }
    }
}
