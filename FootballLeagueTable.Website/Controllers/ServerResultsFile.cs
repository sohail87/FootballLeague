using System.IO;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;
using MyContext=System.Web.HttpContext;

namespace FootballLeagueTable.Website.Controllers
{
    public class ServerResultsFile
    {
        public static string FileUploadPath = MyContext.Current.Server.MapPath("~/App_Data/uploads");

        public static string Get()
        {
            return Directory.GetFiles(FileUploadPath).DefaultIfEmpty(FileUploadPath).First();
        }

        public static void DeleteAll()
        {
            Directory.GetFiles(FileUploadPath).ForEach(System.IO.File.Delete);

        }

        public static void Save(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0) return;
            var fileName = Path.GetFileName(file.FileName);
            
            var path = Path.Combine(FileUploadPath, fileName);
            file.SaveAs(path);
        }
    }
}