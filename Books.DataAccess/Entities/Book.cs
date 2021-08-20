#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Books.DataAccess.Entities
{
    public partial class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int? Quantity { get; set; }
    }
}
