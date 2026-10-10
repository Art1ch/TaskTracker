using System.Threading.Tasks;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IDialogService
{
    Task ShowDialog(string message);
    Task ShowError(string errorMessage);
}
