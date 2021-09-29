using System.Threading.Tasks;
using Persistence.Repositories.Information;

namespace Domain.InformationService
{
    public class InformationService
    {
        private readonly IInformationRepository _repository;

        public InformationService()
        {
            _repository = new InformationRepository();
        }
        public async Task<string> GetInformation(string name)
        {
            
            
            return await _repository.GetInformation(name);
        }

        public async Task Insert(string name, string color)
        {
            var model = new InformationModel(name, color);
            
            await _repository.InsertInformation(model);
        }
    }
}