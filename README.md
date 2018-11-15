[English](README.en.md)

# WpfTemplate

[![Build status](https://ci.appveyor.com/api/projects/status/fgo43rccop7sevjt?svg=true)](https://ci.appveyor.com/project/logue/wpftemplate)

SurfLapras氏のテンプレートをベースに色々拡張したMVVMなWPFアプリケーションのテンプレートです。

## 説明

PrismやUnity、MahAppsを利用したMVVM開発を行う際のテンプレートとしてお使いください。最低限の機能として、フライアウト、テーマの動的切り替え、色の動的切り替え、言語の動的切替、情報ダイアログ（プロジェクトのアセンブリより取得）する機能が予め入っています。

## 使用ライブラリ（順不同）

本アプリケーションは、以下のライブラリを使用しています。このような素晴らしいライブラリを作成・公開されている方々に感謝します。

|ライブラリ名           |作者様           |ライセンス|URL
|-----------------------|-----------------|----------|-----
|MahApps.Metro          |Jan Karger, Dennis Daume, Brendan Forster, Paul Jenkins, Jake Ginnivan, Alex Mitchell|MIT|<http://mahapps.com/>
|MahApps.Metro.IconPacks|同上             |同上      |<https://github.com/MahApps/MahApps.Metro.IconPacks>
|Prism.Unity            |Brian Lagunas, Brian Noyes|Apache 2.0|<https://github.com/PrismLibrary>
|WpfLocalizeExtension   |Bernhard Millauer|Microsoft Public License|<https://github.com/SeriousM/WPFLocalizationExtension>

このテンプレートを作る上で[PrismMahAppsSample](https://github.com/steve600/PrismMahAppsSample)を参考にしました。

## Tips

* アイコンは全種類入れてありますが、実際使う上では使うセットは制限しましょう。参考：<https://github.com/MahApps/MahApps.Metro.IconPacks#custom-styles-for-packicon-controls>
* 多言語化は、リソースファイルで行いますが、[ResXFileCodeGenerator](https://marketplace.visualstudio.com/items?itemName=LongLiang.ExtendedStronglyTypedResourceGenerator-18702)を機能拡張からインストールすると、キーと原文と翻訳文を一度に編集できるのでおすすめです。

## スクリーンショット

![日本語の例](https://github.com/logue/WpfTemplate/raw/master/image/ss1.png)
![英語表記にした例](https://github.com/logue/WpfTemplate/raw/master/image/ss2.png)
![設定フライアウト](https://github.com/logue/WpfTemplate/raw/master/image/ss3.png)
![情報画面](https://github.com/logue/WpfTemplate/raw/master/image/ss4.png)

## 作者

[@logue256](https://twitter.com/logue256)
[@_SurfLapras](https://twitter.com/_SurfLapras)

## ライセンス

[MIT](LICENSE)
