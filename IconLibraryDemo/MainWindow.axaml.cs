// MIT License
// 
// Copyright (c) 2023 Russell Camo (Russkyc)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using HeroIconsAvalonia.Enums;
using HeroIconsAvalonia.Controls;

namespace IconLibraryDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        GetIcons();
        PopulateBrushComboBox();
    }

    void GetIcons()
    {
        var icons = Enum.GetValues(typeof(IconType)).Cast<IconType>()
            .ToList();
        foreach (var icon in icons)
        {
            IconGrid.Children.Add(new HeroIcon
            {
                Margin = new Thickness(18),
                Type = icon
            });
        }

        foreach (var icon in icons)
        {
            IconGrid.Children.Add(new HeroIcon
            {
                Margin = new Thickness(18),
                Type = icon,
                Kind = IconKind.Solid
            });
        }
    }
    void PopulateBrushComboBox()
    {
        var brushes = typeof(Brushes).GetProperties()
                                .Select(p => p.Name)
                                .ToList();
        BrushComboBox.ItemsSource = brushes;
        // set default brush as Black
        BrushComboBox.SelectedItem = "Black";
    }

    private void BrushComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BrushComboBox.SelectedItem is string brushName)
        {
            var brush = (IBrush)(typeof(Brushes).GetProperty(brushName)?.GetValue(null) ?? Brushes.Black);
            if (brush != null)
            {
                foreach (var child in IconGrid.Children.OfType<HeroIcon>())
                {
                    child.Foreground = brush;
                }
            }
        }
    }

}