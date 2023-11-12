namespace ServerLib.Controllers
{
    public class VersionController
    {
        public static string GetBranch()
        {
            return GetFile().Split("\n")[0];
        }

        public static string GetBuildDate()
        {
            return GetFile().Split("\n")[1];
        }

        public static string GetCommitId()
        {
            return GetFile().Split("\n")[2];
        }

        static string GetFile()
        {
            return Properties.Resources.BuildDate;
        }

        public static string GetAll()
        {
            return $"Build Date: {GetBuildDate().Replace("\r","")}, Branch: {GetBranch()}, CommitId: {GetCommitId()}";
        }
    }
}
