using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Persistence.Repositories.Information
{
    public class InformationRepository : IInformationRepository
    {
        public async Task<string> GetInformation(string name)
        {
            var sql = "SELECT * FROM  [dbo].[Information] WHERE BrandName = @BrandName";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@BrandName", name);
            
            return await Startup.Query(command);
        }

        public async Task InsertInformation(InformationModel model)
        {
            var sql = "INSERT INTO [dbo].[Information] (BrandName, Color) VALUES (@BrandName,@Color)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@BrandName", model.BrandName);
            command.Parameters.AddWithValue("@Color", model.Color);

            await Startup.Insert(command);
        }
    }
}