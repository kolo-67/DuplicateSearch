using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.ViewModel
{
    //----------------------------------------------------------------------------------------------------------------------
    // class DuplicateSearchDataViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public class DuplicateSearchDataViewModel : INotifyPropertyChanged
    {
        public DuplicateSearchDataViewModel()
        {
        }
        public DuplicateSearchDataViewModel(DuplicateSearchDataStore pDuplicateSearchData)
        {
            DirectoryStart = pDuplicateSearchData.DirectoryStart;
            Mask = pDuplicateSearchData.Mask;
            SizeFrom = pDuplicateSearchData.SizeFrom;
            SizeTo = pDuplicateSearchData.SizeTo;
            IsFilterBySize= pDuplicateSearchData.IsFilterBySize;
            IsGroupByName = pDuplicateSearchData.IsGroupByName;
            IsGroupBySize = pDuplicateSearchData.IsGroupBySize;
            IsGroupByDateTime = pDuplicateSearchData.IsGroupByDateTime;
        }
        public DuplicateSearchDataStore ToData()
        {
            DuplicateSearchDataStore result = new DuplicateSearchDataStore();
            result.DirectoryStart = DirectoryStart;
            result.Mask = Mask;
            result.SizeFrom = SizeFrom;
            result.SizeTo = SizeTo;
            result.IsFilterBySize= IsFilterBySize;
            result.IsGroupByName = IsGroupByName;
            result.IsGroupBySize = IsGroupBySize;
            result.IsGroupByDateTime = IsGroupByDateTime;
            return result;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        //----------------------------------------------------------------------------------------------------------------------    
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       //----------------------------------------------------------------------------------------------------------------------    
        private string directoryStart;
        public string DirectoryStart
        {
            get { return directoryStart; }
            set
            {
                directoryStart = value;
                OnPropertyChanged("DirectoryStart");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private string mask;
        public string Mask
        {
            get { return mask; }
            set
            {
                mask = value;
                OnPropertyChanged("Mask");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private long sizeFrom;
        public long SizeFrom
        {
            get { return sizeFrom; }
            set
            {
                sizeFrom = value;
                OnPropertyChanged("SizeFrom");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private long sizeTo;
        public long SizeTo
        {
            get { return sizeTo; }
            set
            {
                sizeTo = value;
                OnPropertyChanged("SizeTo");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isFilterBySize;
        public bool IsFilterBySize
        {
            get { return isFilterBySize; }
            set
            {
                isFilterBySize = value;
                OnPropertyChanged("IsFilterBySize");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupByName;
        public bool IsGroupByName
        {
            get { return isGroupByName; }
            set
            {
                isGroupByName = value;
                OnPropertyChanged("IsGroupByName");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupBySize;
        public bool IsGroupBySize
        {
            get { return isGroupBySize; }
            set
            {
                isGroupBySize = value;
                OnPropertyChanged("IsGroupBySize");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupByDateTime;
        public bool IsGroupByDateTime
        {
            get { return isGroupByDateTime; }
            set
            {
                isGroupByDateTime = value;
                OnPropertyChanged("IsGroupByDateTime");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------
    // class DuplicateSearchData
    //----------------------------------------------------------------------------------------------------------------------    
    [Serializable]
    public class DuplicateSearchDataStore
    {
        //----------------------------------------------------------------------------------------------------------------------    
        public string DirectoryStart {get; set;}
        //----------------------------------------------------------------------------------------------------------------------    
        public string Mask { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public long SizeFrom {get; set;}
        //----------------------------------------------------------------------------------------------------------------------    
        public long SizeTo { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public bool IsFilterBySize {get; set;}
        //----------------------------------------------------------------------------------------------------------------------    
        public bool IsGroupByName { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public bool IsGroupBySize { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public bool IsGroupByDateTime {get; set;}
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
