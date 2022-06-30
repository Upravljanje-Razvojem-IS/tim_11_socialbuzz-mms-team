using System;
using UserContentService.DTOs.UserDTOs;

namespace UserContentService.DTOs.AdDTOs
{
    public class AdReadDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public UserReadDTO User { get; set; }
    }
}
