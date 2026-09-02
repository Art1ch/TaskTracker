namespace TaskTrackerDesktop.Core.Interfaces;

public interface IDialogService
{
    void ShowDialog(string message);
    void ShowError(string errorMessage);
}
