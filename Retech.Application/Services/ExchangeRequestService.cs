using AutoMapper;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public class ExchangeRequestService : IExchangeRequestService
    {
        private readonly IMapper _mapper;
        private readonly IExchangeRequestRepository _exchangeRequestRepository;
        public ExchangeRequestService(IMapper mapper, IExchangeRequestRepository exchangeRequestRepository)
        {
            _mapper = mapper;
            _exchangeRequestRepository = exchangeRequestRepository;
        }
        public async Task CreateExchangeRequestAsync(CreateExchangeRequestDTO createExchangeRequestDTO)
        {
            if (await _exchangeRequestRepository.CheckIsProcessing(createExchangeRequestDTO.UserOfferId, createExchangeRequestDTO.UserResponseId))
            {
                throw new Exception("An exchange request is already in progress.");
            }

            var exchangeRequest = _mapper.Map<ExchangeRequest>(createExchangeRequestDTO);

            exchangeRequest.CreatedDate = DateTime.Now;
            exchangeRequest.ExchangeStatus = "Pending";

            await _exchangeRequestRepository.AddAsync(exchangeRequest);
        }

        public async Task<ExchangeRequestDTO> GetExchangeRequestByExchangeRequestIdAsync(Guid exchangeRequestId)
        {
            var exchangeRequest = await _exchangeRequestRepository.GetByIdAsync(exchangeRequestId);
            if (exchangeRequest == null)
            {
                throw new Exception("Exchange Request Not Found");
            }
            return _mapper.Map<ExchangeRequestDTO>(exchangeRequest);
        }

        public async Task<List<ExchangeRequestDTO>> GetExchangeRequestByUserResponseId(Guid userResponseId)
        {
            var exchangeRequests = await _exchangeRequestRepository.GetExchangeRequestsByUserResponseId(userResponseId);

            return _mapper.Map<List<ExchangeRequestDTO>>(exchangeRequests);
        }

        public async Task UpdateExchangeRequestAsync(UpdateExchangeRequestDTO updateExchangeRequestDTO)
        {
            var exchangeRequest = await _exchangeRequestRepository.GetByIdAsync(updateExchangeRequestDTO.ExchangeRequestId);
            if (exchangeRequest == null)
            {
                throw new Exception("Exchange Request Not Found");
            }
            _mapper.Map(updateExchangeRequestDTO, exchangeRequest);
            _exchangeRequestRepository.UpdateAsync(exchangeRequest);

        }

        public async Task UpdateExchangeRequestStatusAsync(Guid exchangeRequestId, string status)
        {
            var exchangeRequest = await _exchangeRequestRepository.GetByIdAsync(exchangeRequestId);
            if (exchangeRequest == null)
            {
                throw new Exception("Exchange Request Not Found");
            }
            exchangeRequest.ExchangeStatus = status;
            _exchangeRequestRepository.UpdateAsync(exchangeRequest);
        }
    }
}
