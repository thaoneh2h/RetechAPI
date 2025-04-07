using Microsoft.EntityFrameworkCore;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class ExchangeRequestRepository : IExchangeRequestRepository
    {
        private readonly AppDbContext _context;

        public ExchangeRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ExchangeRequest exchangeRequest)
        {
            await _context.ExchangeRequest.AddAsync(exchangeRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIsProcessing(Guid UserOfferId, Guid UserResponseId)
        {
            bool exists = await _context.ExchangeRequest
                .AnyAsync(e => e.UserOfferId == UserOfferId &&
                               e.UserResponseId == UserResponseId &&
                               (e.ExchangeStatus == "Pending" || e.ExchangeStatus == "Accepted"));

            return exists;
        }

        public async Task<ExchangeRequest?> GetByIdAsync(Guid exchangeRequestId)
        {
            return await _context.ExchangeRequest.FirstOrDefaultAsync(er => er.ExchangeRequestId == exchangeRequestId);
        }

        public async Task<List<ExchangeRequest>> GetExchangeRequestsByUserResponseId(Guid userResponseId)
        {
            var exchangeRequests = await _context.ExchangeRequest
                .Where(e => e.UserResponseId == userResponseId)
                .OrderBy(e => e.CreatedDate)
                .ToListAsync();

            return exchangeRequests;
        }
        public void UpdateAsync(ExchangeRequest exchangeRequest)
        {
            _context.ExchangeRequest.Update(exchangeRequest);
            _context.SaveChanges();
        }
    }
}
