namespace Club_in_API.UserType.Model
{
    public class ExceptionHandlerCustom : Exception
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
