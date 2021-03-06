using System.ComponentModel.DataAnnotations;

namespace Books.Common.DTO
{
    public class BooksDTO
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int? Quantity { get; set; }
    }
}
