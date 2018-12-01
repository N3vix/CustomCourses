using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using UwpCustomCursesLibrary.Models;

namespace UwpCustomCourses.Helpers
{
    public class INavConverter : IValueConverter
    {
        public object Convert(object v, Type t, object p, string l)
        {
            var list = new List<object>();
            foreach (var item in (v as IEnumerable<object>))
            {
                switch (item)
                {
                    case NVItem dto:
                        list.Add(ToItem(dto));
                        break;
                }
            }
            return list;
        }

        object IValueConverter.ConvertBack(object v, Type t, object p, string l)
        {
            throw new NotImplementedException();
        }

        object ToItem(NVItem item)
        {
            switch (item.ItemType)
            {
                case NVItemEnum.NVItemItem:
                    if (item.Text == "Home")
                    {
                        return new NavigationViewItem
                        {
                            Content = item.Text,
                            Icon = ToFontIcon(item.Icon),
                            IsSelected = true,
                        };
                    }
                    return new NavigationViewItem
                    {
                        Content = item.Text,
                        Icon = ToFontIcon(item.Icon),
                    };
                case NVItemEnum.NVItemHeader:
                    return new NavigationViewItemHeader()
                    {
                        Content = item.Text,
                    };
                case NVItemEnum.NVItemSeparator:
                    return new NavigationViewItemSeparator();
            }
            return null;

        }

        SymbolIcon ToFontIcon(Symbol glyph)
        {
            return new SymbolIcon { Symbol = glyph };
        }
    }
}