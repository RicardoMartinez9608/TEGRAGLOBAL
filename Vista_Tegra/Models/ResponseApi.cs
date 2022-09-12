using System.IO;

namespace AyCWeb.Models
{
    public class ResponseApi
    {
        public string ContenidofromJson { get; set; }
        public Stream ContenidoDeStream { get; set; }
        public string Error { get; set; }
        public bool Satisfactorio { get; set; }
        public string Status { get; set; }
    }
}
