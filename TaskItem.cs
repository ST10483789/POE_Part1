using System;

namespace POE_Part2
{
    internal class TaskItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool Completed { get; set; }

        public override string ToString()
        {
            if (Completed)
                return "✔ " + Title + " (" + ReminderDate.ToShortDateString() + ")";

            return Title + " (" + ReminderDate.ToShortDateString() + ")";
        }
    }
}
