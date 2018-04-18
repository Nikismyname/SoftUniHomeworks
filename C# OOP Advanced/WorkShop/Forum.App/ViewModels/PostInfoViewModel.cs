using Forum.App.Contracts;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.ViewModels
{
    class PostInfoViewModel : IPostInfoViewModel
    {
        public PostInfoViewModel(int id, string title, int replyCount)
        {
            this.Id = id;
            this.Title = title;
            this.ReplyCount = replyCount;
        }

        public int Id { get; }

        public string Title { get; }

        public int ReplyCount { get; }
    }
}
