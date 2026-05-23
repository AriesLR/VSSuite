using NuGet.Versioning;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VSSuite.Resources.Functions.Converters
{
    public class VersionToColorConverter : IMultiValueConverter
    {
        public object Convert(object?[]? values, Type targetType, object? parameter, CultureInfo culture)
        {
            // Ensure all 3 values are present (InstalledVersion, LatestVersion, HasGlobalUpdate)
            if (values == null || values.Length < 3 ||
                values[0] == DependencyProperty.UnsetValue ||
                values[1] == DependencyProperty.UnsetValue ||
                values[2] == DependencyProperty.UnsetValue)
            {
                return System.Windows.Application.Current.TryFindResource("SecondaryAccent.Brush.WA400") ?? System.Windows.Media.Brushes.Gray;
            }

            string? installedStr = values[0]?.ToString();
            string? latestStr = values[1]?.ToString();
            bool hasVersionMismatch = values[2] is bool b && b;

            if (NuGetVersion.TryParse(installedStr, out NuGetVersion? installedVersion) &&
                NuGetVersion.TryParse(latestStr, out NuGetVersion? latestVersion))
            {
                if (installedVersion != null && latestVersion != null)
                {
                    if (latestVersion > installedVersion)
                    {
                        // Global update
                        if (hasVersionMismatch)
                        {
                            if (System.Windows.Application.Current.TryFindResource("Alr.Brushes.YellowBase") is System.Windows.Media.Brush yellowBrush) // Yellow Brush
                            {
                                return yellowBrush;
                            }
                            return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 215, 0)); // Yellow fallback
                        }

                        // Update matching version selection
                        if (System.Windows.Application.Current.TryFindResource("Alr.Brushes.GreenBase") is System.Windows.Media.Brush greenBrush) // Green Brush
                        {
                            return greenBrush;
                        }
                        return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(50, 205, 50)); // Lime Green fallback
                    }
                }
            }

            // Default Brush
            return System.Windows.Application.Current.TryFindResource("SecondaryAccent.Brush.WA400") ?? System.Windows.Media.Brushes.Gray; // Grey Brush (Gray, why do I as an American always default to Grey? Am I broken?)
        }

        // Unused
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}