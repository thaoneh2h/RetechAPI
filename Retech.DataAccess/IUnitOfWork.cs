using AutoMapper;
using Retech.DataAccess.Repositories.Interfaces;


namespace Retech.DataAccess
{
    public interface IUnitOfWork
    {
        IMapper Mapper { get; }
        ICategoryRepository CategoryRepository { get; }
        IDeviceVerificationFormRepository DeviceVerificationFormRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductVerificationRepository ProductVerificationRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserRepository UserRepository { get; }
        IVoucherRepository VoucherRepository { get; }
        IWalletRepository WalletRepository { get; }
        Task<bool> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
