using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Application = System.Windows.Application;

namespace VSSuite.Resources.Functions.Services
{
    public static class MessageService
    {
        private static MetroWindow GetMainWindow()
        {
            return (Application.Current.MainWindow as MetroWindow)!;
        }

        // Show Progress Bar
        public static async Task ShowProgress(string title, string message, Func<IProgress<double>, Task> operation)
        {
            if (Application.Current.MainWindow is not MetroWindow mainWindow)
                throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");

            var controller = await mainWindow.ShowProgressAsync(title, message);
            controller.SetIndeterminate();

            try
            {
                var progress = new Progress<double>(value => controller.SetProgress(value));
                await operation(progress);
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        // Yes/No
        public static async Task<bool> ShowYesNo(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No"
            };

            var result = await mainWindow.ShowMessageAsync(
                title,
                message,
                MessageDialogStyle.AffirmativeAndNegative,
                settings
            );

            return result == MessageDialogResult.Affirmative;
        }

        // Info
        public static async Task ShowInfo(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            await mainWindow.ShowMessageAsync(title, message, MessageDialogStyle.Affirmative);
        }

        // Warning
        public static async Task ShowWarning(string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            await mainWindow.ShowMessageAsync("Warning", message, MessageDialogStyle.Affirmative);
        }

        // Error
        public static async Task ShowError(string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            await mainWindow.ShowMessageAsync("Error", message, MessageDialogStyle.Affirmative);
        }

        // ============ Additional dialogs for VSSuite ============

        // Yes/Cancel
        public static async Task<bool> ShowYesCancel(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "Cancel"
            };

            var result = await mainWindow.ShowMessageAsync(
                title,
                message,
                MessageDialogStyle.AffirmativeAndNegative,
                settings
            );

            return result == MessageDialogResult.Affirmative;
        }

        // Ok
        public static async Task<bool> ShowOk(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");

            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "OK"
            };

            var result = await mainWindow.ShowMessageAsync(
                title,
                message,
                MessageDialogStyle.Affirmative,
                settings
            );

            return result == MessageDialogResult.Affirmative;
        }

        // Modlist Output
        public static async Task ShowModOutput(string title, string message, string textboxText)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Ok",
                NegativeButtonText = "Copy Output",
                AnimateShow = true,
                AnimateHide = true
            };

            // Remove ** for display, keep original for clipboard
            string displayText = textboxText?.Replace("**", "") ?? "";

            var result = await mainWindow.ShowMessageAsync(title, $"{message}\n\n{displayText}", MessageDialogStyle.AffirmativeAndNegative, settings);

            if (result == MessageDialogResult.Negative)
            {
                System.Windows.Clipboard.SetText(textboxText ?? string.Empty); // Copy to clipboard copies using markdown formatting
            }
        }

        // TextBox input dialog for inputting mod page links
        public static async Task<string> ShowInput(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Ok",
                NegativeButtonText = "Cancel",
                DefaultText = "",
                AnimateShow = true,
                AnimateHide = true
            };

            var result = await mainWindow.ShowInputAsync(title, message, settings);

            return result ?? string.Empty;
        }

        // Folder browser dialog for startup
        public static async Task<bool> ShowBrowseCancel(string title, string message)
        {
            var mainWindow = GetMainWindow() ?? throw new InvalidOperationException("Main window is not a MetroWindow or has not been set.");
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Browse",
                NegativeButtonText = "Cancel"
            };

            var result = await mainWindow.ShowMessageAsync(
                title,
                message,
                MessageDialogStyle.AffirmativeAndNegative,
                settings
            );

            return result == MessageDialogResult.Affirmative;
        }
    }
}