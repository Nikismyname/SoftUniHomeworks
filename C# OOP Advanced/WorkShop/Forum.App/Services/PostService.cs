using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Services
{
    class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyPostTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyPostCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyPostContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyPostCategory || emptyPostContent || emptyPostTitle)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            Category category = EnsureCategory(postCategory);

            int postId = this.forumData.Posts.Any() ? this.forumData.Posts.Last().Id+1 : 1;

            User author = this.userService.GetUserById(userId);

            Post newPost = new Post(postId,postTitle,postContent,category.Id,author.Id,new List<int>());
            this.forumData.Posts.Add(newPost);
            author.Posts.Add(newPost.Id);
            category.Posts.Add(newPost.Id);
            this.forumData.SaveChanges();

            return postId;
        }

        private Category EnsureCategory(string postCategory)
        {
            var category = this.forumData.Categories.FirstOrDefault(x=>x.Name == postCategory);

            if (category != null)
            {
                return category;
            }

            int categoryId = this.forumData.Categories.Any() ? this.forumData.Categories.Last().Id + 1 : 1;
            category = new Category(categoryId,postCategory, new List<int>());
            this.forumData.Categories.Add(category);
            this.forumData.SaveChanges();
            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (string.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException("Reply content must be filled!");
            }

            User user = this.userService.GetUserById(userId);
            Post post = this.forumData.Posts.FirstOrDefault(x=>x.Id == postId);

            if( user == null || post == null)
            {
                throw new InvalidOperationException("User or Post do not exist!");
            }

            int replyId = this.forumData.Replies.Any() ? this.forumData.Replies.Last().Id + 1 : 1;
            var reply = new Reply(replyId,replyContents,userId,postId);
            post.Replies.Add(replyId);
            this.forumData.Replies.Add(reply);
            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData
                .Categories.Select(x => new CategoryInfoViewModel(x.Id, x.Name, x.Posts.Count));
            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string name = this.forumData.Categories.FirstOrDefault(x => x.Id == categoryId)?.Name;

            if(name == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return name;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> categoryPostInfo = this.forumData
                .Posts
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new PostInfoViewModel(x.Id, x.Title, x.Replies.Count));

            return categoryPostInfo;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(x=>x.Id == postId);
            var postView = new PostViewModel(post.Title,this.userService.GetUserName(post.AuthorId),post.Content,this.GetPostReplies(post.Id));
            return postView;
        }

        public IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            var replyes = this.forumData.Posts.SingleOrDefault(x => x.Id == postId)
                .Replies
                .Select(x => this.forumData.Replies.SingleOrDefault(y => y.Id == x))
                .Select(x => new ReplyViewModel(this.userService.GetUserName(x.AuthorId),x.Content));
            return replyes;
        }
    }
}
