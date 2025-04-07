using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retech.Application.Services;
using Retech.Core.DTOS;
using Retech.DataAccess.DataContext;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRequestController : ControllerBase
    {
        private readonly IExchangeRequestService _exchangeRequestService;
        private readonly AppDbContext _context;
        public ExchangeRequestController(IExchangeRequestService exchangeRequestService, AppDbContext context)
        {
            _exchangeRequestService = exchangeRequestService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateExchangeRequestDTO createExchangeRequestDTO)
        {
            await _exchangeRequestService.CreateExchangeRequestAsync(createExchangeRequestDTO);
            return Ok( new { Message = "Create Exchange Request Successfull" });
        }

        [HttpPut("{exchangeRequestId}/accept")]
        public async Task<ActionResult> AcceptRequest(Guid exchangeRequestId)
        {
            await _exchangeRequestService.UpdateExchangeRequestStatusAsync(exchangeRequestId, "Accepted");
            return Ok(new { Message = "Exchange Request Accepted" });
        }

        [HttpPut("{exchangeRequestId}/reject")]
        public async Task<ActionResult> RejecteRequest(Guid exchangeRequestId)
        {
            await _exchangeRequestService.UpdateExchangeRequestStatusAsync(exchangeRequestId,"Rejected");
            return Ok(new { Message = "Exchange Request Rejected" });
        }
        [HttpPut("{exchangeRequestId}/complete")]
        public async Task<ActionResult> CompleteRequest(Guid exchangeRequestId)
        {
            await _exchangeRequestService.UpdateExchangeRequestStatusAsync(exchangeRequestId, "Completed");
            return Ok(new { Message = "Exchange Request Completed" });
        }

        [HttpPut("{exchangeRequestId}")]
        public async Task<ActionResult> UpdateExchangeRequest(Guid exchangeRequestId, [FromBody] UpdateExchangeRequestDTO updateExchangeRequestDTO)
        {
            updateExchangeRequestDTO.ExchangeRequestId = exchangeRequestId;
            await _exchangeRequestService.UpdateExchangeRequestAsync(updateExchangeRequestDTO);
            return Ok(new { Message = "Exchange Request Updated" });
        }

        [HttpGet("user/{userResponseId}")]
        public async Task<ActionResult<List<ExchangeRequestDTO>>> GetByUserResponseId(Guid userResponseId)
        {
            var exchangeRequests = await _exchangeRequestService.GetExchangeRequestByUserResponseId(userResponseId);
            return Ok(exchangeRequests);
        }
        [HttpGet("{exchangeRequestId}")]
        public async Task<ActionResult<List<ExchangeRequestDTO>>> GetByExchangeRequestId(Guid exchangeRequestId)
        {
            var exchangeRequests = await _exchangeRequestService.GetExchangeRequestByExchangeRequestIdAsync(exchangeRequestId);
            return Ok(exchangeRequests);
        }
    }
}
