using System;

namespace ChitChat.Client.Model
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CatID { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}
