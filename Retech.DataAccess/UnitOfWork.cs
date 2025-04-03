using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Retech.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public UnitOfWork(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        //Mapper = mapper;
        //
        // add thêm ở đây
        //
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
    public async Task<bool> CompleteAsync(CancellationToken cancellationToken = default)
    {
        var changes = await _dbContext.SaveChangesAsync(cancellationToken);
        var saveChangesSuccessfully = changes > 0;
        return saveChangesSuccessfully;
    }
}
