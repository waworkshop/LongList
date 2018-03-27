using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace LongList
{
    public class WaRichTextBlock : UserControl
    {
        private RichTextBlock _richTextBlock;

        public WaRichTextBlock()
        {
            _richTextBlock = new RichTextBlock();
            _richTextBlock.TextWrapping = TextWrapping.WrapWholeWords;
            Content = _richTextBlock;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(WaRichTextBlock), new PropertyMetadata(string.Empty, TextPropertyChangedCallback));

        public static void TextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as WaRichTextBlock;
            if (sender != null)
            {
                sender._richTextBlock.Blocks.Clear();

                if (e.NewValue != null)
                {
                    var p = new Paragraph();
                    p.Inlines.Add(new Run { Text = (string)e.NewValue });
                    p.Inlines.Add(new InlineUIContainer
                    {
                        Child = new Image
                        {
                            Source = new BitmapImage(new Uri("ms-appx://LongList/Assets/emoji.png"))
                            {
                                DecodePixelWidth = 40,
                                DecodePixelHeight = 40
                            },
                            Width = 40,
                            Height = 40
                        }
                    });

                    sender._richTextBlock.Blocks.Add(p);
                }
            }
        }
    }
}
