namespace MVC.Data.DTO
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Result { get; set; }
    }
}
