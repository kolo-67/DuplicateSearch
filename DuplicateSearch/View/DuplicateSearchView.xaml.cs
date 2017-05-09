using DuplicateSearch.Contracts;
using DuplicateSearch.ViewModel;
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
    /// Interaction logic for DuplicateSearchView.xaml
    /// </summary>
    //-------------------------------------------------------------------------------------------------------------------
    // class DuplicateSearchView
    //-------------------------------------------------------------------------------------------------------------------
    public partial class DuplicateSearchView : Window
    {
        //-------------------------------------------------------------------------------------------------------------------
        public DuplicateSearchView()
        {
            InitializeComponent();
            DataContext = new DuplicateSearchViewModel();
        }
        //-------------------------------------------------------------------------------------------------------------------
        void DuplicateSearchAction_FolderDialogQuery(object obj)
        {
            ShowFolderView folderView = new ShowFolderView();
            folderView.DataContext = obj;
            folderView.ShowDialog();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IDuplicateSearchActionQueriable duplicateSearchAction = DataContext as IDuplicateSearchActionQueriable;
            if (duplicateSearchAction != null)
            {
                duplicateSearchAction.FolderDialogQuery += DuplicateSearchAction_FolderDialogQuery;
            }
 
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
