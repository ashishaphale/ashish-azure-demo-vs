using ashish_storageacc_demo.Data;
using Azure;
using Azure.Data.Tables;

namespace ashish_storageacc_demo.Services
{
    public class TableStorageService : ITableStorageService
    {
        private const string tableName = "Attendees";
        private readonly IConfiguration _configuration;
        private readonly TableServiceClient _tableServiceClient;
        private readonly TableClient _tableClient;

        public TableStorageService(IConfiguration configuration, TableServiceClient tableServiceClient, TableClient tableClient)
        {
            this._configuration = configuration;
            _tableServiceClient = tableServiceClient;
            _tableClient = tableClient;
        }
        public async Task DeleteAttendee(string industry, string id)
        {
            //var tableClient = _tableServiceClient.GetTableClient(tableName);
            //await tableClient.DeleteEntityAsync(industry, id);
            await _tableClient.DeleteEntityAsync(industry, id);
        }

        public async Task<AttendeeEntity> GetAttendee(string industry, string id)
        {
            //var tableClient = _tableServiceClient.GetTableClient(tableName);
            //return await tableClient.GetEntityAsync<AttendeeEntity>(industry, id);
            return await _tableClient.GetEntityAsync<AttendeeEntity>(industry, id);
        }

        public async  Task<List<AttendeeEntity>> GetAttendees()
        {
            //var tableClient = _tableServiceClient.GetTableClient(tableName);
            Pageable<AttendeeEntity> attendeeEntities = _tableClient.Query<AttendeeEntity>();
            return attendeeEntities.ToList();
        }

        public async Task UpsertAttendee(AttendeeEntity attendeeEntity)
        {
            try
            {
                //var tableClient = _tableServiceClient.GetTableClient(tableName);
                //await tableClient.UpsertEntityAsync(attendeeEntity);
                await _tableClient.UpsertEntityAsync(attendeeEntity);
            }
            catch(Exception ex) { var message = ex.Message; }
        }

        private async Task<TableClient> GetTableClient()
        {
            //var _tableServiceClient = new TableServiceClient(_configuration["StorageConnectionString"]);
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();

            return tableClient;
        }
    }
}
