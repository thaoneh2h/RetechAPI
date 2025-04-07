using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using System;

namespace Retech.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        public ChatHub(AppDbContext context, IMemoryCache cache, IMapper mapper)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task SendMessage(Guid exchangeRequestId, Guid senderId, string message)
        {
            var cacheKey = $"ExchangeRequest_{exchangeRequestId}";
            if (!_cache.TryGetValue(cacheKey, out ExchangeRequestDTO exchangeRequestDTO))
            {
                var exchangeRequest = await _context.ExchangeRequest
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.ExchangeRequestId == exchangeRequestId);
                if (exchangeRequest == null)
                {
                    Console.WriteLine("Exchange request not found.");
                    return;
                }

                exchangeRequestDTO = _mapper.Map<ExchangeRequestDTO>(exchangeRequest);

                // Lưu vào cache trong 20 phút
                _cache.Set(cacheKey, exchangeRequestDTO, TimeSpan.FromMinutes(20));
            }

            if (exchangeRequestDTO.ExchangeStatus != "Accepted")
            {
                Console.WriteLine("Chat is not allowed until the request is accepted.");
                return;
            }

            if (exchangeRequestDTO.UserOfferId != senderId && exchangeRequestDTO.UserResponseId != senderId)
            {
                Console.WriteLine("Unauthorized: You are not part of this exchange.");
                return;
            }

            var receiverId = exchangeRequestDTO.UserOfferId == senderId ? exchangeRequestDTO.UserResponseId : exchangeRequestDTO.UserOfferId;

            await Clients.Group(exchangeRequestId.ToString()).SendAsync("ReceiveMessage", senderId, message);

            _ = Task.Run(async () =>
            {
                try
                {
                    var newMessage = new Message
                    {
                        MessageId = Guid.NewGuid(),
                        ExchangeRequestId = exchangeRequestId,
                        SenderId = senderId,
                        ReceiverId = receiverId,
                        Content = message,
                        SendDate = DateTime.UtcNow
                    };

                    _context.Message.Add(newMessage);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving message: {ex.Message}");
                }
            });
        }

        public async Task JoinExchangeRoom(Guid exchangeRequestId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, exchangeRequestId.ToString());
        }

        public async Task LeaveExchangeRoom(Guid exchangeRequestId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, exchangeRequestId.ToString());
        }
    }
}
