using System.Threading.Tasks;

namespace Persistence.Repositories.Information
{
    public interface IInformationRepository
    {
        Task<string> GetInformation(string name);
        Task InsertInformation(InformationModel model);
    }
}