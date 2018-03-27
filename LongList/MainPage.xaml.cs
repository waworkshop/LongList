using LongList.ViewModels;

namespace LongList
{
    public sealed partial class MainPage
    {
        public MainPageViewModel ViewModel { get; }

        public MainPage()
        {
            InitializeComponent();

            ViewModel = new MainPageViewModel();

            DataContext = this;
        }

        private void MessagesListView_ContainerContentChanging(Windows.UI.Xaml.Controls.ListViewBase sender, Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
        {
            if (args.InRecycleQueue) return;
            var person = (Message)args.Item;
            args.ItemContainer.HorizontalAlignment = person.IsSent ? Windows.UI.Xaml.HorizontalAlignment.Right : Windows.UI.Xaml.HorizontalAlignment.Left;
        }
    }
}
