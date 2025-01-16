namespace InTechBlazoreClient.Components.Models
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; }
    }
}
