using System.Collections.Generic;

namespace Personal.Expenses.HangFire.Interfaces
{
    public interface ISchedulesContainer
    {
        void Add(ISchedules schedules);

        IEnumerable<ISchedules> GetJobs();
    }
}