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

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();

            CreateMap<Voucher, VoucherDTO>();
            CreateMap<VoucherDTO, Voucher>();
            CreateMap<Voucher, ResponseVoucherDTO>().ReverseMap();

            CreateMap<E_Wallet, E_WalletDTO>();

            CreateMap<E_WalletDTO, E_Wallet>();

            CreateMap<E_Wallet, ResponseWalletDTO>();

            CreateMap<ResponseWalletDTO, E_Wallet>();


            CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore()) // Sẽ xử lý password riêng
            .ForMember(dest => dest.UserId, opt => opt.Ignore()) // Không map từ DTO
            .ForMember(dest => dest.RegistrationDate, opt => opt.Ignore()); // Sẽ set trong service

            CreateMap<UpdateUserDTO, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore()) // Không cho phép update password qua đây
            .ForMember(dest => dest.Email, opt => opt.Ignore()); // Giữ nguyên email, không cho update

            CreateMap<Review, ReviewDTO>()
            .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => src.Reviewer.UserName))
            .ForMember(dest => dest.RevieweeName, opt => opt.MapFrom(src => src.Reviewee.UserName));

            CreateMap<CreateReviewDTO, Review>();
            CreateMap<UpdateReviewDTO, Review>();
        }
    }
}
