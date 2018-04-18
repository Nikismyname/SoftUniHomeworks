using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.ViewModels
{
    public class ContentViewModel
    {
        private const int lineLength = 37;

        public string[] Content { get; }

        public ContentViewModel(string content)
        {
            this.Content = GetLines(content);
        }

        private string[] GetLines (string content)
        {
            char[] contentChars = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+= lineLength)
            {
                var line = contentChars.Skip(i).Take(lineLength).ToArray();

                lines.Add(string.Join("", line));
            }

            return lines.ToArray();
        }
    }
}
