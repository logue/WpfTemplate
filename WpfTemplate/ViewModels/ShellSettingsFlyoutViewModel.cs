using MahApps.Metro;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Constants;
using WpfTemplate.Events;
using WpfTemplate.Interfaces;
using WpfTemplate.Model;

namespace WpfTemplate.ViewModels
{
    public class ShellSettingsFlyoutViewModel : ViewModelBase
    {
        private readonly ILocalizerService localizerService = null;

        #region CTOR
        /// <summary>
        /// CTOR
        /// </summary>
        public ShellSettingsFlyoutViewModel()
        {
            localizerService = Container.Resolve<ILocalizerService>(ServiceNames.LocalizerService);

            // create metro theme color menu items for the demo
            ApplicationThemes = ThemeManager.AppThemes
                .Select(a => new ApplicationTheme()
                {
                    Name = a.Name,
                    BorderColorBrush = a.Resources["BlackColorBrush"] as Brush,
                    ColorBrush = a.Resources["WhiteColorBrush"] as Brush
                })
                .ToList();

            // create accent colors list
            AccentColors = ThemeManager.Accents
                .Select(a => new AccentColor() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                .ToList();

            SelectedTheme = ApplicationThemes.Where(c => c.Name.Equals(Properties.Settings.Default.Theme)).FirstOrDefault();
            SelectedAccentColor = AccentColors.Where(c => c.Name.Equals(Properties.Settings.Default.Color)).FirstOrDefault();
            SelectedLanguage = SupportedLanguages.Where(c => c.Name.Equals(Properties.Settings.Default.Language)).FirstOrDefault();

            Container.Resolve<ILoggerFacade>().Log("ShellSettingsFlyoutViewModel created", Category.Info, Priority.None);
        }
        #endregion CTOR

        #region Properties
        private IList<ApplicationTheme> _applicationsThemes;

        /// <summary>
        /// List with application themes
        /// </summary>
        public IList<ApplicationTheme> ApplicationThemes
        {
            get => _applicationsThemes;
            set => SetProperty<IList<ApplicationTheme>>(ref _applicationsThemes, value);
        }

        private IList<AccentColor> _accentColors;

        /// <summary>
        /// List with accent colors
        /// </summary>
        public IList<AccentColor> AccentColors
        {
            get => _accentColors;
            set => SetProperty<IList<AccentColor>>(ref _accentColors, value);
        }

        private ApplicationTheme _selectedTheme;

        /// <summary>
        /// The selected theme
        /// </summary>
        public ApplicationTheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (SetProperty<ApplicationTheme>(ref _selectedTheme, value))
                {
                    Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
                    AppTheme appTheme = ThemeManager.GetAppTheme(value.Name);
                    ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);

                    Properties.Settings.Default.Theme = value.Name;
                    Properties.Settings.Default.Save();

                    EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(string.Format("Theme changed to {0}", value.Name));
                }
            }
        }

        private AccentColor _selectedAccentColor;

        /// <summary>
        /// Selected accent color
        /// </summary>
        public AccentColor SelectedAccentColor
        {
            get => _selectedAccentColor;
            set
            {
                if (SetProperty<AccentColor>(ref _selectedAccentColor, value))
                {
                    Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
                    Accent accent = ThemeManager.GetAccent(value.Name);
                    ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

                    Properties.Settings.Default.Color = value.Name;
                    Properties.Settings.Default.Save();

                    EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(string.Format("Accent color changed to {0}", value.Name));
                }
            }
        }

        /// <summary>
        /// Supported languages
        /// </summary>
        public IList<CultureInfo> SupportedLanguages
        {
            get
            {
                if (localizerService != null)
                {
                    return localizerService.SupportedLanguages;
                }

                return null;
            }
        }

        /// <summary>
        /// The selected language
        /// </summary>
        public CultureInfo SelectedLanguage
        {
            get => (localizerService != null) ? localizerService.SelectedLanguage : null;
            set
            {
                if (value != null && value != localizerService.SelectedLanguage)
                {
                    if (localizerService != null)
                    {
                        localizerService.SelectedLanguage = value;
                        Properties.Settings.Default.Language = value.ToString();
                        Properties.Settings.Default.Save();
                    }

                }

            }
        }
        #endregion Properties
    }
}