[日本語](README.md)

# WpfTemplate

[![Build status](https://ci.appveyor.com/api/projects/status/fgo43rccop7sevjt?svg=true)](https://ci.appveyor.com/project/logue/wpftemplate)

This is MahApps WPF template based on SurfLapras's tempate.

## Description

Please use it as a template when developing MVVM using Prism, Unity, MahApps.
As a minimum function, it has functions to fly-out, dynamically switch theme, dynamically switch colors, dynamically switch language, and get information dialog (from project assembly).

## Used library (unordered)

This application uses the following libraries.

|Library Name           |Author           |Lisence   |URL
|-----------------------|-----------------|----------|-----
|MahApps.Metro          |Jan Karger, Dennis Daume, Brendan Forster, Paul Jenkins, Jake Ginnivan, Alex Mitchell|MIT|<http://mahapps.com/>
|MahApps.Metro.IconPacks|same             |same      |<https://github.com/MahApps/MahApps.Metro.IconPacks>
|Prism.Unity            |Brian Lagunas, Brian Noyes|Apache 2.0|<https://github.com/PrismLibrary>
|WpfLocalizeExtension   |Bernhard Millauer|Microsoft Public License|<https://github.com/SeriousM/WPFLocalizationExtension>

In making this template [PrismMahAppsSample](https://github.com/steve600/PrismMahAppsSample) was referred to.

## Tips

* Icons of all kinds are included, but let's limit the set to use on actual use. see <https://github.com/MahApps/MahApps.Metro.IconPacks#custom-styles-for-packicon-controls>
* I18n is done with resource files, but it is recommended because when you install [ResXFileCodeGenerator](https://marketplace.visualstudio.com/items?itemName=LongLiang.ExtendedStronglyTypedResourceGenerator-18702) from a function extension you can edit keys, original sentences and translations at once.

## Screenshots

![English](https://github.com/logue/WpfTemplate/raw/master/image/ss2.png)
![Switch to Japanese](https://github.com/logue/WpfTemplate/raw/master/image/ss1.png)
![Flyouts](https://github.com/logue/WpfTemplate/raw/master/image/ss3.png)
![Infomation](https://github.com/logue/WpfTemplate/raw/master/image/ss4.png)

## Author

[@logue256](https://twitter.com/logue256)
[@_SurfLapras](https://twitter.com/_SurfLapras)

## License

[MIT](LICENSE)
