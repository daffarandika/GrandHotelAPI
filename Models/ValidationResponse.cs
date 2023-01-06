namespace GrandHotelAPI.Models
{
    public class ValidationResponse
    {
        public bool IsValid;
        public string Message;
        public ValidationResponse(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
