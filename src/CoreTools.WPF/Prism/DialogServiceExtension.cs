using System;
using Prism.Services.Dialogs;

namespace CoreTools.WPF.Prism
{
    public static class DialogServiceExtension
    {
        public static string ConfirmationDialog = nameof(ConfirmationDialog);
        public static string NotificationDialog = nameof(NotificationDialog);
        public static string ErrorDialog = nameof(ErrorDialog);
        
        public static void ShowConfirmation(this IDialogService dialogService, string title, string message,
            Action<IDialogResult> callBack)
        {
            var parameters = new DialogParameters
            {
                {"title", title},
                {"message", message}
            };
            
            dialogService.ShowDialog(ConfirmationDialog, parameters, callBack);
        }

        public static void ShowNotification(this IDialogService dialogService, string title, string message,
            Action<IDialogResult> callBack)
        {
            var parameters = new DialogParameters
            {
                {"title", title},
                {"message", message}
            };
            
            dialogService.ShowDialog(ConfirmationDialog, parameters, callBack);
        }

        public static void ShowError(this IDialogService dialogService, string title, string message, Exception ex,
            Action<IDialogResult> callBack)
        {
            var parameters = new DialogParameters
            {
                {"title", title},
                {"message", message},
                {"exception", ex}
            };

            dialogService.ShowDialog(ErrorDialog, parameters, callBack);
        }
    }
}