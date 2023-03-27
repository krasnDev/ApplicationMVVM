﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace Shared.Converters
{
    /// <summary>
    /// Converts boolean value visibility of UI element, use <see cref="FalseIsCollapsed"/> when false should
    /// be converted to <see cref="Visibility.Collapsed"/> and <see cref="IsInverse"/> when true should hide element.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool FalseIsCollapsed { get; set; }

        public bool IsInverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                if (IsInverse)
                {
                    if (boolValue)
                    {
                        return FalseIsCollapsed ? Visibility.Collapsed : Visibility.Hidden;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                }
                else
                {
                    if (boolValue)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return FalseIsCollapsed ? Visibility.Collapsed : Visibility.Hidden;
                    }
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                if (IsInverse)
                {
                    return visibility != Visibility.Visible;
                }
                else
                {
                    return visibility == Visibility.Visible;
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
