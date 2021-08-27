namespace ShipService.Infrastructure.Cqrs.Repository.Contract
{
    public interface IDbConnectionSettingsProvider
    {
        string GetDbConnectionString(IUnitOfWork unitOfWork);
    }
}
