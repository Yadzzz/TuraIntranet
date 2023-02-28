namespace TuraIntranet.Services
{
    public class ActivityLoggerService
    {
        public List<Activity> Activities { get; set; }

        public ActivityLoggerService()
        {
            this.Activities = new List<Activity>();
        }

        public void LogActivity(string user, string action)
        {
            if (this.Activities == null)
            {
                this.Activities = new List<Activity>();
            }

            this.Activities.Add(new Activity(user, action));
        }
    }

    public class Activity
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Action { get; set; }

        public Activity(string user, string action)
        {
            this.Date = DateTime.Now;
            this.User = user;
            this.Action = action;
        }
    }
}
