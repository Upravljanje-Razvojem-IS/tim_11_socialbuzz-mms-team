using System;

namespace UserContentService.Entities
{
    public class Ad
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int PASId { get; set; }
    }
}
