   M S B A M L   `   `   `  ����J  FDuplicateSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DuplicateSearch.ViewModelDuplicateSearch.ViewModel  5   	   )    #DuplicateSearch.View.ShowFolderView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9local'clr-namespace:DuplicateSearch.ViewModel     5   	   -   5          � Title$  
FolderView��5   	   $	��500��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�5   !   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      �� 5      $
��Auto �6   .+�5   
   �� $��Select subdirectories��6   R� 5   
   -   5        $��1��5      $��10q�6N   ��6    �� *ComputerFiles.Chields+��5      �� 5       �� DataType:   4DuplicateSearch.ViewModel.FileSystemElementViewModel"  6K    �� ItemsSource 6+   �� *	Chields+.R�5      Q� -   5         Q� 
IsExpanded 5   #   �� *
IsExpanded+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5       �� Orientation$ 
Horizontal=�6)   .+�5   "   �� 	 d� 	IsChecked	 6+   �� *
IsSelected+�� 5   "   ��6,   �� *Name+5      5      5      5      � 5   
   $��2��6   
 � ColumnDefinitions
 5      �� 5      �� 5       .+�5"      �� -   5        $��0��5"      $��70��6%   $��Ok��60   $��10q�6v   ��6=   �� *	OkCommand+6v   �� 5#      -   5        $��1��5#      $��70��6%   $��Cancel��60   $��10q�6~   ��6A   �� *CancelCommand+6~   5$      5&      5'      