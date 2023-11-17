<img src=".github/resources/images/banner.svg" style="width: 100%;" />

<h2 align="center">HeroIcons.Avalonia</h2>

<p align="center">
    <a href="https://www.nuget.org/packages/HeroIcons.Avalonia">
        <img src="https://img.shields.io/nuget/v/HeroIcons.Avalonia?color=1f72de" alt="Nuget">
    </a>
    <a href="#">
        <img src="https://img.shields.io/badge/-.NET%206.0-blueviolet?color=1f72de&label=NET" alt="">
    </a>
    <a href="#">
        <img src="https://img.shields.io/badge/-.NET%207.0-blueviolet?color=1f72de&label=NET" alt="">
    </a>
    <a href="#">
        <img src="https://img.shields.io/badge/-.NET%208.0-blueviolet?color=1f72de&label=NET" alt="">
    </a>
</p>

<p style="text-align: justify">The beautiful handcrafted Icons by the makers of Tailwind CSS
made available to your awesome Avalonia UI projects!
</p>

<h4 align="center">HeroIcons.Avalonia Demo App</h4>

<img src=".github/resources/images/demo.png" style="width: 100%;" />

### How to Use

Install the latest HeroIcons.Avalonia Package from [Nuget](https://www.nuget.org/packages/HeroIcons.Avalonia)

**Basic Usage**

##### Add this to your control/window namespaces

```xaml
xmlns:heroIcons="clr-namespace:HeroIconsAvalonia.Controls;assembly=HeroIconsAvalonia"
```

##### Use the HeroIcon control

```xaml
<heroIcons:HeroIcon Foreground="White" Type="Pencil" />
```
By default, the HeroIcon color is black and the icon kind is outline, whe can change these properties if needed

```xaml
<heroIcons:HeroIcon Foreground="White" Type="Pencil" Foreground="White" Kind="Solid" />
```
There are also 2 default sizes for the icon if you don't want to set the width and height,
the `Min` property switches between 24px and 20px respectively

```xaml
// By Default the icon is sized at 24px
// Set Min to True if you want the 20px or 'min' ico
// You can also set the Width/Height manually if needed
<heroIcons:HeroIcon Type="Pencil" Foreground="White" Kind="Outline" Min="True"/>
```
### Donate

If you find this project helpful, please consider donating. It helps me afford more time to create tools like this
for the community. ❤❤

### Special Message
Special thanks to [JetBrains](https://www.jetbrains.com/) for supporting this project by providing licences to the JetBrains Suite!

<a href="https://www.jetbrains.com/community/opensource/#support">
<img width="200px" src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" alt="JetBrains Logo (Main) logo.">
</a>