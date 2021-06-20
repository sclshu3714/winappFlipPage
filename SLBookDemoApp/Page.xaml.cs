using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SLMitsuControls;

namespace SLBookDemoApp
{
    public partial class Page : UserControl, IDataProvider
    {
        public Page()
        {
            InitializeComponent();
        }

        private List<Button> pages;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pages = new List<Button>
            {
                new Button { Content = "Page 0"},
                new Button { Content = "Page 1", Background = new SolidColorBrush(Colors.Green) },
                new Button { Content = "Page 2", Background = new SolidColorBrush(Colors.Yellow) },
                new Button { Content = "Page 3", Background = new SolidColorBrush(Colors.Red) }
            };

            int i = 0;
            foreach (var b in pages)
            {
                if (i % 2 == 0)
                    b.Click += Button_Click;
                else
                    b.Click += Button_Click_1;
                i++;
            }

            book.SetData(this);
        }

        #region IDataProvider Members

        public object GetItem(int index)
        {
            return pages[index];
        }

        public int GetCount()
        {
            return pages.Count;
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            book.AnimateToNextPage(500);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            book.AnimateToPreviousPage(500);
        }
    }
}
