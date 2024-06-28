using ashish_storageacc_demo.Data;

namespace ashish_storageacc_demo.Services
{
    public interface ITableStorageService
    {
        Task DeleteAttendee(string industry, string id);
        Task<AttendeeEntity> GetAttendee(string industry, string id);
        Task<List<AttendeeEntity>> GetAttendees();
        Task UpsertAttendee(AttendeeEntity attendeeEntity);
    }
}
