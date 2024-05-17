using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_mobile.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string title, string message, string buttonLabel);
    }

    public class DialogService : IDialogService
    {
        public async Task ShowAlertAsync(string title, string message, string buttonLabel)
        {
            if (Application.Current.MainPage is Page page)
            {
                await page.DisplayAlert(title, message, buttonLabel);
            }
        }
    }


}
