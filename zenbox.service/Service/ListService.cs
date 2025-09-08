using Microsoft.EntityFrameworkCore;
using zenbox.core.Interface;
using zenbox.data;
using zenbox.model;

namespace zenbox.service
{
    public class TaskListService : ITaskListService
    {
        protected readonly ApplicationDbContext _db;
        public TaskListService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<TasklistCollectionModel> GetLists(string userId)
        {
            return new TasklistCollectionModel()
            {
                Items =
                _db.TaskHeaders.Any(e => e.OwnerId == userId) ?
                             await _db.TaskHeaders.Where(e => e.OwnerId == userId)
                                                  .Select(e => new TasklistModel()
                                                  {
                                                      Id = e.Id,
                                                      Name = e.Name,
                                                      OwnerId = e.OwnerId,
                                                  })
                             .ToListAsync() : new List<TasklistModel>()
            };
        }

        public async Task<TasklistModel> GetList(Guid id)
        {

            var th = await _db.TaskHeaders
                              .Include(e => e.Lines)
                              .SingleOrDefaultAsync(e => e.Id == id);

            if (th != null)
            {
                return new TasklistModel()
                {
                    Id = th.Id,
                    Name = th.Name,
                    OwnerId = th.OwnerId,
                    Tasks = th.Lines.Select(e => new TaskModel()
                    {
                        Id = e.Id,
                        HeaderId = e.Header.Id,
                        Description = e.Description,
                        LastUpdated = e.LastUpdated,
                        Name = e.Name,
                        Checked = e.Checked
                    })
                    .ToList()
                };
            }

            return null;
        }

        public async Task<TasklistModel> AddList(TasklistModel listModel)
        {            
            var th = new TaskHeader()
            {
                OwnerId = listModel.OwnerId,
                Name = listModel.Name
            };

            var lines = listModel.Tasks.Select(e => new TaskLine()
            {
                Description = e.Description,
                LastUpdated = e.LastUpdated,
                Name = e.Name
            }).ToList();

            _db.TaskHeaders.Add(th);
            _db.TaskLines.AddRange(lines);
            await _db.SaveChangesAsync();

            return new TasklistModel()
            {
                Id = th.Id,
                OwnerId = th.OwnerId,
                Name = th.Name,
                Tasks = lines.Select(e => new TaskModel()
                {
                    Id = e.Id,
                    HeaderId = e.Header.Id,
                    Description = e.Description,
                    LastUpdated = e.LastUpdated
                }).ToList()
            };
        }

        public async Task DeleteList(Guid id)
        {
            var t = await _db.TaskHeaders.Include("Lines").SingleAsync(e => e.Id == id);

            _db.TaskLines.RemoveRange(t.Lines.ToList());
            _db.TaskHeaders.Remove(t);

            await _db.SaveChangesAsync();
        }
    }

}
