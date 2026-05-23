using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace VSSuite.Resources.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _isAppSettingsFlyoutOpen;
        private bool _isInformationFlyoutOpen;
        private bool _isChangelogFlyoutOpen;
        private bool _isModlistToolsFlyoutOpen;
        private bool _isModBrowserFlyoutOpen;
        private bool _isTipsFlyoutOpen;

        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public ObservableCollection<MenuItem> OptionsMenuItems { get; set; }

        public MainWindowViewModel()
        {
            // Top Menu Items (Information, Modlist Tools, Mod Browser)
            MenuItems =
            [
                new MenuItem
                {
                    Text = "Information",
                    Icon = "Information",
                    Command = new RelayCommand((sender, e) => SidebarInformation_Click(sender, e))
                },
                new MenuItem
                {
                    Text = "Modlist Tools",
                    Icon = "ClipboardText",
                    Command = new RelayCommand((sender, e) => SidebarModlistTools_Click(sender, e))
                },
                new MenuItem
                {
                    Text = "Mod Browser",
                    Icon = "SearchWeb",
                    Command = new RelayCommand((sender, e) => SidebarModBrowser_Click(sender, e))
                }
            ];

            // Bottom Menu Items (App Settings, Changelog, Tips)
            OptionsMenuItems =
            [
                new MenuItem
                {
                    Text = "App Settings",
                    Icon = "Cog",
                    Command = new RelayCommand((sender, e) => SidebarAppSettings_Click(sender, e))
                },
                new MenuItem
                {
                    Text = "Changelog",
                    Icon = "TextBoxPlus",
                    Command = new RelayCommand((sender, e) => SidebarChangelog_Click(sender, e))
                },
                new MenuItem
                {
                    Text = "Tips",
                    Icon = "HandHeart",
                    Command = new RelayCommand((sender, e) => SidebarTips_Click(sender, e))
                }
            ];
        }

        // ============ App Settings Flyout ============

        // App Settings Button Click
        private void SidebarAppSettings_Click(object? sender, RoutedEventArgs e)
        {
            OpenAppSettingsFlyout();
        }

        // App Settings Flyout
        public bool IsAppSettingsFlyoutOpen
        {
            get => _isAppSettingsFlyoutOpen;
            set
            {
                if (_isAppSettingsFlyoutOpen != value)
                {
                    _isAppSettingsFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle App Settings Flyout to Open (true)
        public void OpenAppSettingsFlyout()
        {
            if (IsAppSettingsFlyoutOpen)
            {
                IsAppSettingsFlyoutOpen = false;
            }
            IsAppSettingsFlyoutOpen = true;
        }

        // ============ Information Flyout ============

        // Information Button Click
        private void SidebarInformation_Click(object? sender, RoutedEventArgs e)
        {
            OpenInformationFlyout();
        }

        // Information Flyout
        public bool IsInformationFlyoutOpen
        {
            get => _isInformationFlyoutOpen;
            set
            {
                if (_isInformationFlyoutOpen != value)
                {
                    _isInformationFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle Information Flyout to Open (true)
        public void OpenInformationFlyout()
        {
            if (IsInformationFlyoutOpen)
            {
                IsInformationFlyoutOpen = false;
            }
            IsInformationFlyoutOpen = true;
        }

        // ============ Changelog Flyout ============

        // Changelog Button Click
        private void SidebarChangelog_Click(object? sender, RoutedEventArgs e)
        {
            OpenChangelogFlyout();
        }

        // App Settings Flyout
        public bool IsChangelogFlyoutOpen
        {
            get => _isChangelogFlyoutOpen;
            set
            {
                if (_isChangelogFlyoutOpen != value)
                {
                    _isChangelogFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle App Settings Flyout to Open (true)
        public void OpenChangelogFlyout()
        {
            if (IsChangelogFlyoutOpen)
            {
                IsChangelogFlyoutOpen = false;
            }
            IsChangelogFlyoutOpen = true;
        }

        // ============ Modlist Tools Flyout ============

        // Modlist Tools Button Click
        private void SidebarModlistTools_Click(object? sender, RoutedEventArgs e)
        {
            OpenModlistToolsFlyout();
        }

        // Modlist Tools Flyout
        public bool IsModlistToolsFlyoutOpen
        {
            get => _isModlistToolsFlyoutOpen;
            set
            {
                if (_isModlistToolsFlyoutOpen != value)
                {
                    _isModlistToolsFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle Modlist Tools Flyout to Open (true)
        public void OpenModlistToolsFlyout()
        {
            if (IsModlistToolsFlyoutOpen)
            {
                IsModlistToolsFlyoutOpen = false;
            }
            IsModlistToolsFlyoutOpen = true;
        }

        // ============ Mod Browser Flyout ============

        // Mod Browser Button Click
        private void SidebarModBrowser_Click(object? sender, RoutedEventArgs e)
        {
            OpenModBrowserFlyout();
        }

        // Mod Browser Flyout
        public bool IsModBrowserFlyoutOpen
        {
            get => _isModBrowserFlyoutOpen;
            set
            {
                if (_isModBrowserFlyoutOpen != value)
                {
                    _isModBrowserFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle Mod Browser Flyout to Open (true)
        public void OpenModBrowserFlyout()
        {
            if (IsModBrowserFlyoutOpen)
            {
                IsModBrowserFlyoutOpen = false;
            }
            IsModBrowserFlyoutOpen = true;
        }

        // ============ Tips Flyout ============

        // Tips Button Click
        private void SidebarTips_Click(object? sender, RoutedEventArgs e)
        {
            OpenTipsFlyout();
        }

        // Tips Flyout
        public bool IsTipsFlyoutOpen
        {
            get => _isTipsFlyoutOpen;
            set
            {
                if (_isTipsFlyoutOpen != value)
                {
                    _isTipsFlyoutOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        // Toggle Tips Flyout to Open (true)
        public void OpenTipsFlyout()
        {
            if (IsTipsFlyoutOpen)
            {
                IsTipsFlyoutOpen = false;
            }
            IsTipsFlyoutOpen = true;
        }

        // ============ Property Changed Helper ============
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangingUsingCustomArgs(propertyName);
        }

        private void PropertyChangingUsingCustomArgs(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Sidebar Helper Classes
    public class RelayCommand(Action<object?, RoutedEventArgs> execute, Func<object?, bool>? canExecute = null) : ICommand
    {
        private readonly Action<object?, RoutedEventArgs> _execute = execute;
        private readonly Func<object?, bool> _canExecute = canExecute ?? (param => true);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute(parameter);

        public void Execute(object? parameter)
        {
            _execute(parameter, new RoutedEventArgs());
        }
    }

    // MenuItems Model
    public class MenuItem
    {
        public string Text { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public ICommand Command { get; set; } = new RelayCommand((s, e) => { });
    }
}