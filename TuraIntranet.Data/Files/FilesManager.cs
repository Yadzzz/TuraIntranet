using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Files
{
    public class FilesManager
    {
        private List<DocumentFile> _documents;

        public FilesManager()
        {
            this._documents = new();
        }

        public List<DocumentFile> GetDocuments()
        {
            if (this._documents != null && this._documents.Count > 0)
            {
                return this._documents;
            }

            string path = "\\\\dbu-kba-01.tura.local\\Intranetshare\\Totalfilen";
            var dir = new DirectoryInfo(path);

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                this._documents.Add(this.MapDocumentFile(file));
            }

            Console.WriteLine(this._documents.Count);
            return this._documents;
        }

        private DocumentFile MapDocumentFile(FileInfo file)
        {
            DocumentFile doc = new()
            {
                Name = file.Name,
                Changed = file.LastWriteTime,
                Created = file.CreationTime,
                Type = file.Name.Substring(file.Name.LastIndexOf('.'), file.Name.Length - file.Name.LastIndexOf('.')),
                Size = file.Length / 1024,
                path = file.FullName
            };

            return doc;
        }
    }
}
