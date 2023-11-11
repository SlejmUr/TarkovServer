using JsonLib.Classes.ProfileRelated;

namespace JsonLib.Classes.Response
{
    public class MailDialogView
    {
        public List<Profile.Message> messages { get; set; }
        public List<object> profiles { get; set; }
        public bool hasMessagesWithRewards { get; set; }
    }
}
