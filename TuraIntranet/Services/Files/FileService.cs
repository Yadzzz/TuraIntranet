namespace TuraIntranet.Services.Files
{
    public class FileService
    {
        private TuraIntranet.Data.Files.FilesManager _filesManager;

        public FileService()
        {
            this._filesManager = new();
        }

        public List<Data.Files.DocumentFile> GetDocumentFiles()
        {
            return this._filesManager.GetDocuments();
        }
    }
}
