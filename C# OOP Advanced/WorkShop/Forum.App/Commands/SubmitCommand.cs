using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    class SubmitCommand : ICommand
    {
        private IPostService postService;
        private ISession session;
        private ICommandFactory commandFactory;

        public SubmitCommand(IPostService postService, ISession session, ICommandFactory commandFactory)
        {
            this.postService = postService;
            this.session = session;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);
            string replyContent = args[1];
            int userId = int.Parse(args[2]);

            this.postService.AddReplyToPost(postId, replyContent, userId);

            this.session.Back();
            this.session.Back();

            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");
            var manu = viewPostCommand.Execute(postId.ToString());
            return manu;
        }
    }
}
