using AutoMapper;
using Retech.Core.DTOS;
using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ánh xạ từ Order -> OrderDTO
            CreateMap<Order, OrderDTO>();

            // Ánh xạ từ OrderItem -> OrderItemDTO
            CreateMap<OrderItem, OrderItemDTO>();

            // Ánh xạ từ OrderDTO -> Order
            CreateMap<OrderDTO, Order>();

            // Ánh xạ từ OrderItemDTO -> OrderItem
            CreateMap<OrderItemDTO, OrderItem>();
            // Ánh xạ từ Transaction -> TransactionDTO
            CreateMap<Transaction, TransactionDTO>();

            // Ánh xạ từ TransactionDTO -> Transaction
            CreateMap<TransactionDTO, Transaction>();
        }
    }
}
