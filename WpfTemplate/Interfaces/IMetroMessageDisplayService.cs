using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace WpfTemplate.Interfaces
{
    public interface IMetroMessageDisplayService
    {
        Task<MessageDialogResult> ShowMessageAsnyc(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);
    }
}