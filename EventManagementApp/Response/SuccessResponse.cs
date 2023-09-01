namespace EventManagementApp.Response
{
    public class SuccessResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public SuccessResponse(int code, string message)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
