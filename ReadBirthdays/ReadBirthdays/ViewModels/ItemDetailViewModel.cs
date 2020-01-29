using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ReadBirthdays.Models;
using Xamarin.Forms;

namespace ReadBirthdays.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }

        public Item Item { get; set; }

        public async Task DeleteItemAsync()
        {
            var retValue = await DataStore.DeleteItemAsync(Item.Id);
        }
    }
}