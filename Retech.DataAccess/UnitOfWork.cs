using AutoMapper;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories;
using Retech.DataAccess.Repositories.Implementations;
using Retech.DataAccess.Repositories.Interfaces;

namespace Retech.DataAccess;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public UnitOfWork(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        Mapper = mapper;
        CategoryRepository = new CategoryRepository(dbContext);
        DeviceVerificationFormRepository = new DeviceVerificationFormRepository(dbContext);
        OrderRepository = new OrderRepository(dbContext);
        ProductRepository = new ProductRepository(dbContext);
        ProductVerificationRepository = new ProductVerificationRepository(dbContext);
        TransactionRepository = new TransactionRepository(dbContext);
        UserRepository = new UserRepository(dbContext);
        VoucherRepository = new VoucherRepository(dbContext);
        WalletRepository = new WalletRepository(dbContext);
    }

    private AppDbContext _dbContext { get; }

    public void Dispose()
    {
        try
        {
            GC.SuppressFinalize(this);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public IMapper Mapper { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IDeviceVerificationFormRepository DeviceVerificationFormRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IProductVerificationRepository ProductVerificationRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public IUserRepository UserRepository { get; }
    public IVoucherRepository VoucherRepository { get; }
    public IWalletRepository WalletRepository { get; }
    public async Task<bool> CompleteAsync(CancellationToken cancellationToken = default)
    {
        var changes = await _dbContext.SaveChangesAsync(cancellationToken);
        var saveChangesSuccessfully = changes > 0;
        return saveChangesSuccessfully;
    }
}
