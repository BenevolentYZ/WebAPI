using System.ComponentModel.DataAnnotations;

namespace TaskManagementDomain.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskType { get; set; }

    }
}
