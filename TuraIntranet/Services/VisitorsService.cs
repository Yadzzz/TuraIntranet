namespace TuraIntranet.Services
{
    public class VisitorsService
    {
        private object _lockObj = new object();
        private int _totalWebsiteVisits;
        private int _totalPageVisits;

        public void IncrementWebsiteVisits()
        {
            lock(this._lockObj)
            {
                this._totalWebsiteVisits++;
            }
        }
        public void IncrementPageVisit()
        {
            lock(this._lockObj)
            {
                this._totalPageVisits++;
            }
        }

        public string GetTotalWebsiteVisits()
        {
            lock(this._lockObj)
            {
                return this._totalWebsiteVisits.ToString();
            }
        }

        public string GetTotalPageVisit()
        {
            lock(this._lockObj)
            {
                return this._totalPageVisits.ToString();
            }
        }
    }
}
