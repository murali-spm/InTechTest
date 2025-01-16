namespace InTechCommon.Exceptions
{
    public class InTechException : Exception
    {
        public int StatusCode { get; set; }
        public string? CustomMessage { get; set; }
        public  object? Parameter { get; set; }
        public int UserId { get; set; }
        public bool IsHandled { get; set; }
        public InTechException() : base() {}

        public InTechException(string message, bool isHandled=false, int statusCode = 450) : base() {
            CustomMessage = message;
            IsHandled = isHandled;
            StatusCode = statusCode;
        }
    }
}
