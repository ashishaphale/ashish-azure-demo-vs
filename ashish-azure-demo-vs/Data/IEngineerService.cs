namespace ashish_azure_demo_vs.Data
{
    public interface IEngineerService
    {
        Task DeleteEngineer(string? id, string? partitionKey);
        Task<List<Engineer>> GetEngineerDetails();//aa
        Task<Engineer> GetEngineerDetailsById(string? id, string? partitionKey);
        Task UpsertEngineer(Engineer engineer);
    }
}
