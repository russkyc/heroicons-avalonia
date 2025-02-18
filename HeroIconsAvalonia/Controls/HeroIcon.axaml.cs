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

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using HeroIconsAvalonia.Enums;

namespace HeroIconsAvalonia.Controls
{
    public partial class HeroIcon : UserControl
    {
        static HeroIcon()
        {
            TypeProperty.Changed.AddClassHandler<HeroIcon>((sender, _) => sender.UpdateIcon());

            KindProperty.Changed.AddClassHandler<HeroIcon>((sender, _) => sender.UpdateIcon());

            ForegroundProperty.Changed.AddClassHandler<HeroIcon>((sender, _) =>
            {
                sender.Resources["Brush0"] = sender.Foreground;
                sender.UpdateIcon();

                // Force redraw of the DrawingImage.
                // Needed because of bug described in: https://github.com/AvaloniaUI/Avalonia/issues/8767
                if (sender.GetValue(IconSourceProperty) is DrawingImage di && di.Drawing != null)
                {
                    var currentDrawing = di.Drawing;
                    di.Drawing = null;
                    di.Drawing = currentDrawing;
                }
            });
        }

        private void UpdateIcon()
        {
            var resource = Resources.MergedDictionaries[(int)Kind] as ResourceDictionary;
            IconSource = resource![Type.ToString()];
        }

        public HeroIcon()
        {
            SetSize(Min);
            InitializeComponent();
        }

        public static readonly StyledProperty<bool> MinProperty = AvaloniaProperty.Register<HeroIcon, bool>(
            "Min");

        public bool Min
        {
            get => GetValue(MinProperty);
            set
            {
                SetValue(MinProperty, value);
                SetSize(value);
            }
        }

        void SetSize(bool min)
        {
            Width = min ? 20 : 24;
            Height = min ? 20 : 24;
        }

        static readonly StyledProperty<object?> IconSourceProperty = AvaloniaProperty.Register<HeroIcon, object?>(
            "IconSource");

        object? IconSource
        {
            set => SetValue(IconSourceProperty, value);
        }

        public static readonly StyledProperty<IconType> TypeProperty = AvaloniaProperty.Register<HeroIcon, IconType>(
            "Type");

        public IconType Type
        {
            get => GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly StyledProperty<IconKind> KindProperty = AvaloniaProperty.Register<HeroIcon, IconKind>(
            "Kind");

        public IconKind Kind
        {
            get => GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        // Register Foreground as a StyledProperty to support bindings
        public static new readonly StyledProperty<IBrush?> ForegroundProperty =
            AvaloniaProperty.Register<HeroIcon, IBrush?>(
                nameof(Foreground));

        public new IBrush? Foreground
        {
            get => GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }
    }
}