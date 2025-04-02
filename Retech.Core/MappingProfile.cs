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

            // Ánh xạ từ OrderDTO -> Order
            CreateMap<OrderDTO, Order>();

            // Ánh xạ từ Transaction -> TransactionDTO
            CreateMap<Transaction, TransactionDTO>();

            // Ánh xạ từ TransactionDTO -> Transaction
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Category.BrandName));  

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, RequestProductDTO>();
            CreateMap<RequestProductDTO, Product>();



            CreateMap<ProductVerification, ProductVerificationDTO>(); 
            CreateMap<ProductVerificationDTO, ProductVerification>();
            CreateMap<DeviceVerificationForm, DeviceVerificationFormDTO>();
            CreateMap<DeviceVerificationFormDTO, DeviceVerificationForm>();
            CreateMap<Category, CategoryDTO>().ReverseMap();

        }
    }
}
