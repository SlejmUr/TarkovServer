namespace ServerLib.Json
{
    public class LoginProfile
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Edition { get; set; }
        public string Password { get; set; }
    }
    public class NicknameValidate
    {
        public string Nickname { get; set; }
    }
    public class Changes
    {
        public string Change { get; set; }
    }
    public class Voices
    {
        public string Voice { get; set; }
    }
    public class Create
    {
        public string Side { get; set; }
        public string VoiceId { get; set; }
        public string HeadId { get; set; }
        public string Nickname { get; set; }
    }
}
