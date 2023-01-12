namespace TuraIntranet.Services
{
    public class PageNavigationService
    {
        private string activePage = string.Empty;
        private string activeSection = string.Empty;

        public void UpdateActivePage(string page)
        {
            this.activePage = page;
        }

        public void UpdateActiveSection(string section)
        {
            this.activeSection = section;
        }

        public bool IsPageActive(string page)
        {
            return this.activePage == page;
        }

        public bool IsSectionActive(string page)
        {
            return this.activeSection == page;
        }

        public string ActiveSection
        {
            get
            {
                return this.activeSection;
            }
        }

        public string ActivePage
        {
            get
            {
                return this.activePage;
            }
        }
    }
}
