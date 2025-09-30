using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zenbox.core.Interface;
using zenbox.data;
using zenbox.model;

namespace zenbox.service
{
    public class TaskService : ITaskService
    {
        protected readonly ZenboxDbContext _db;

        public TaskService(ZenboxDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskViewmodel>> GetTasks(Guid id)
        {
            return await _db.TaskLines.Where(e => e.Header.Id == id)
                .Select(e => new TaskViewmodel()
                {
                    Id = e.Id,
                    HeaderId = e.Header.Id,
                    Name = e.Name,
                    Description = e.Description,
                    LastUpdated = e.LastUpdated,
                    Checked = e.Checked
                }).ToListAsync();
        }

        public async Task<TaskViewmodel> GetTask(Guid id)
        {
            var tl = await _db.TaskLines.FindAsync(id);

            return new TaskViewmodel()
            {
                Id = tl.Id,
                Description = tl.Description,
                LastUpdated = tl.LastUpdated,
                Name = tl.Name,
                Checked = tl.Checked
            };
        }

        public async Task<TaskViewmodel> AddTask(TaskViewmodel taskModel)
        {
            var th = await _db.TaskHeaders
                              .FindAsync(taskModel.HeaderId);

            var task = new TaskLine()
            {
                Header = th,
                Description = taskModel.Description,
                Name = taskModel.Name,
                LastUpdated = DateTime.UtcNow
            };

            _db.TaskLines.Add(task);

            await _db.SaveChangesAsync();

            taskModel.Id = task.Id;
            taskModel.LastUpdated = task.LastUpdated;

            return taskModel;
        }

        public async Task DeleteTask(Guid id)
        {
            var tl = await _db.TaskLines.FindAsync(id);

            _db.TaskLines.Remove(tl);
            await _db.SaveChangesAsync();
        }

        public async Task<TaskViewmodel> UpdateTask(TaskViewmodel taskModel)
        {
            var tl = await _db.TaskLines.FindAsync(taskModel.Id);

            tl.LastUpdated = DateTime.UtcNow;
            tl.Checked = taskModel.Checked;

            await _db.SaveChangesAsync();

            taskModel.LastUpdated = tl.LastUpdated;

            return taskModel;
        }
    }
}
