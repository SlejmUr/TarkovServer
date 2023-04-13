namespace ServerLib.Json.Classes
{
    public class Body<T>
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public T data { get; set; }
    }
}
