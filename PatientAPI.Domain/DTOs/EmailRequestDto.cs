namespace PatientAPI.Domain.DTOs
{
    public class EmailRequestDto
    {
        public string From { get; set; } = null!;
        public string ToEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool IsHtml { get; set; } = true;
    }
}
