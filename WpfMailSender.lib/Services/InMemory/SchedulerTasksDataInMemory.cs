using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;


namespace WpfMailSender.lib.Services.InMemory
{
    public class SchedulerTasksDataInMemory : DataInMemory<SchedulerTask>, ISchedulerTaskData
    {
        public override void Edit(SchedulerTask item)
        {
            SchedulerTask task = GetById(item.Id);
            if (task is null || ReferenceEquals(task, item)) return;

            task.MailsList = item.MailsList;
            task.RecipientsList = item.RecipientsList;
            task.Sender = item.Sender;
            task.Server = item.Server;
            task.Time = item.Time;
        }
    }
}