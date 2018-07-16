namespace FrontSharp.Requests
{
    public class UpdateTeammateRequest
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_admin { get; set; }
        public bool is_available { get; set; }
    }
}