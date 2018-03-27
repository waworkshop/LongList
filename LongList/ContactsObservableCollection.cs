using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace LongList
{
    public class ContactsObservableCollection : ObservableCollection<Message>, ISupportIncrementalLoading
    {
        private uint messageCount = 0;

        public bool HasMoreItems { get; } = true;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CreateMessages(count);

            return Task.FromResult(
                new LoadMoreItemsResult()
                {
                    Count = count
                }).AsAsyncOperation();
        }

        private void CreateMessages(uint count)
        {
            for (uint i = 0; i < count; i++)
            {
                Insert(0, new Message
                {
                    Name = $"{messageCount}",
                    MessageType = (MessageType)rand.Next(3),
                    Description = $"{CreateRandomMessage()}",
                    IsSent = 0 == messageCount++ % 2,
                    DisplayTime = DateTime.Now.ToString()
                });
            }
        }

        private static Random rand = new Random();
        private static string fillerText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        public static string CreateRandomMessage()
        {
            return fillerText.Substring(0, rand.Next(5, fillerText.Length));
        }
    }
}
