namespace MovieServiceExample.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int MovieDiscount { get; set; }
    }
}
