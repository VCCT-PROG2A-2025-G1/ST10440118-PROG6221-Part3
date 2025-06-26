using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_CYBERCHATBOT
{
    internal class Tasks
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            string status = IsComplete ? "Completed" : "Pending";
            return $"Title: {Title}\nDescription: {Description}\nReminder: {Reminder}\nStatus: {status}\n";
        }
    }
}
