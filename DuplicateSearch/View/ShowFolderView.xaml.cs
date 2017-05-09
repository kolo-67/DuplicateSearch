using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuplicateSearch.View
{
    /// <summary>
    /// Interaction logic for ShowFolderView.xaml
    /// </summary>
    public partial class ShowFolderView : Window
    {
        public ShowFolderView()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty ExpandedCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "ExpandedCommand",
                                                                        typeof(ICommand),
                                                                        typeof(ShowFolderView));
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ExpandedCommand
        {
            get { return (ICommand)GetValue(ExpandedCommandProperty); }
            set { SetValue(ExpandedCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void TreeViewItem_OnExpanded(object sender, RoutedEventArgs e)
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void trw_Products_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            if (item != null)
                ExpandedCommand.Execute(item.DataContext);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Binding myBinding = new Binding("ExpandedCommand");
            myBinding.Source = DataContext;
            BindingOperations.SetBinding(this, ShowFolderView.ExpandedCommandProperty, myBinding);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
