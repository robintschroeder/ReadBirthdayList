using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReadBirthdays.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Read";
            Volume = 0.5f;
            Pitch = 1.2f;
            ReadBirthdaysCommand = new Command(async () => await ReadTodaysBirthdays());
        }

        public float Pitch { get; set; }
        public ICommand ReadBirthdaysCommand { get; }
        public float Volume { get; set; }

        private async Task ReadTodaysBirthdays()
        {
            var today = DateTime.Now.Date;
            var allBirthdays = await DataStore.GetItemsAsync();
            var todaysBirthdays = allBirthdays.Where(x => x.Birthday.Month == today.Month && x.Birthday.Day == today.Day).ToList();

            var settings = new SpeechOptions()
            {
                Volume = Volume,
                Pitch = Pitch
            };

            if (todaysBirthdays.Count > 0)
            {
                foreach (var b in todaysBirthdays)
                {
                    await TextToSpeech.SpeakAsync($"Happy Birthday {b.Name}", settings);
                    await Task.Delay(500);
                }
            }
            else
            {
                await TextToSpeech.SpeakAsync($"No Birthdays Today", settings);
            }
        }
    }
}