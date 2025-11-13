namespace MVC_3.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        // Usado na view para decidir se exibe o RequestId
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}