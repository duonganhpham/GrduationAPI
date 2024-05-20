using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Business.UserBusiness;
using GraduationProjectAPI.DB;
using GraduationProjectAPI.Entities;
using SERP.Framework.Business;
using SERP.Framework.Common;
using SERP.Framework.DB.Extensions;
using System.Data.Entity;

namespace GraduationProjectAPI.Business.RoomBusiness
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Room> AddRoomAsync(Guid applicationId, Room room, Guid uid)
        {
            if (room.Id == Guid.Empty)
            {
                room.RomOwnerId = uid;
                room.Id = Guid.NewGuid();
                room.ApplicationId = applicationId;

                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room;
            }
            else
            {
                var roomUpdate = await GetRoomByIdAsync(applicationId, room.Id);
                if (roomUpdate == null)
                {
                    throw new ArgumentException(IUserRepository.Message_UserNotFound);
                }
                room.Address = roomUpdate.Address;
                room.WifiInternet = roomUpdate.WifiInternet;
                room.AirConditioner = roomUpdate.AirConditioner;
                room.WaterHeater = roomUpdate.WaterHeater;
                room.Refrigerator = roomUpdate.Refrigerator;
                room.WashingMachine = roomUpdate.WashingMachine;
                room.EnclosedToilet = roomUpdate.EnclosedToilet;
                room.SafedDevice = roomUpdate.SafedDevice;
                await _context.SaveChangesAsync();

                return roomUpdate;
            }
        }

        public async Task<Pagination<Room>> GetAllRoomAsync(Guid applicationId, RoomQueryModel queryModel)
        {
            queryModel.PageSize = queryModel.PageSize.HasValue ? queryModel.PageSize.Value : 20;
            queryModel.CurrentPage = queryModel.CurrentPage.HasValue ? queryModel.CurrentPage.Value : 1;

            var query = _context.Rooms.Where(x => x.ApplicationId != null);
            if (!string.IsNullOrWhiteSpace(queryModel.FullTextSearch))
            {
                query = query.Where(x =>
                x.Name.Contains(queryModel.FullTextSearch)
                );
            }
            // Ex for room sorting.
            var sortExpression = string.Empty;
            if (string.IsNullOrWhiteSpace(queryModel.Sort) || queryModel.Sort.Equals("-LastModifiedOnDate"))
            {
                // room sorting
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                sortExpression = QueryUtils.FormatSortInput(queryModel.Sort);
            }
            return await query.GetPagedAsync<Room>(queryModel.CurrentPage.Value, queryModel.PageSize.Value, sortExpression);
        }
        public async Task<Room> GetRoomByIdAsync(Guid applicationId, Guid id)
        {
            var result = await _context.Rooms
                                     .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Room> DeleteRoomAsync(Guid applicationId, Guid id)
        {
            var room = await _context.Rooms
                                    .FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
            {
                throw new ArgumentException(IRoomRepository.Message_RoomNotFound);
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
