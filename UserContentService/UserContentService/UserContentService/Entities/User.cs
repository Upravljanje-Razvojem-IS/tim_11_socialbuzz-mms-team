using System.Collections.Generic;

namespace UserContentService.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        public List<Ad> Ads { get; set; }
        public List<Content> Contents { get; set; }

        public User()
        {
            this.Ads = new List<Ad>();
            this.Contents = new List<Content>();
        }
    }
}
