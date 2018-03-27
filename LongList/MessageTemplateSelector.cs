using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LongList
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var message = item as Message;
            if (message != null)
            {
                switch (message.MessageType)
                {
                    case MessageType.ImageAndVideo:
                        return (DataTemplate)Application.Current.Resources["ImageMessageTemplate"];
                    case MessageType.InlineVideo:
                        return (DataTemplate)Application.Current.Resources["InlineVideoMessageTemplate"];
                    case MessageType.Text:
                    default:
                        return (DataTemplate)Application.Current.Resources["DefaultTextMessageTemplate"];
                }
            }

            return null;
        }
    }
}
