using System.Collections.ObjectModel;

namespace LongList.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; } = new ContactsObservableCollection();
    }
}
