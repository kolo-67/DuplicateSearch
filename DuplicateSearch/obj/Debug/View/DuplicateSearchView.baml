   M S B A M L   `   `   `  ����J  FDuplicateSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DuplicateSearch.ModelDuplicateSearch.Model  5   	   .    (DuplicateSearch.View.DuplicateSearchView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5local#clr-namespace:DuplicateSearch.Model     5   	   -   5          � Title$  DuplicateSearchView��5   	   $	��700��6%   $
��1200��62    � WindowStartupLocation$ CenterScreen=�6?    � WindowState$ 	Maximized=�5       #��� ��68   #��� ��6�    � 	Resources 5       �� MergedDictionaries �� Source �� DataType%   DuplicateSearch.Model.NameGroup �� Padding%   DuplicateSearch.Model.SizeGroup)   #DuplicateSearch.Model.NameSizeGroup � ColumnDefinitions-   'DuplicateSearch.Model.NameSizeDateGroup)   #DuplicateSearch.Model.SizeDateGroup)   #DuplicateSearch.Model.NameDateGroup�� 5   
    5	      �� 5
      $$ Skins/DuplicateSearchSkin.xaml?�6%   %�  (��       5      *, +)(�� �     5      *, +)(�� (    5      *, +)(�� E    5       *, +)(�� �    5,      *, +)(�� �    56      *, +)�� 5      "  6   .R�5      � $
��Left=�6   .+�5      �� $ 3q�6;   $��3q�6G   ��6    �� *
FileName+6G   5      5      �� 5      "  6   .R�5      � $
��Left=�6   .+�5      �� $ 3q�66   $��3q�6B   ��6    �� *Size+6B   5      5      �� 5      "  6   .R�5      � $
��Left=�6    5      �� 5      �� 5      .+�5      �� $��0��6    $ 3q�6J   $��3q�6V   ��60   �� *
FileName+6V   �� 5      $��1��6    $ 3q�6F   $��3q�6R   ��60   �� *Size+6R   5      5      �� 5       "  6   .R�5!      � $
��Left=�6    5"      �� 5#      �� 5$      �� 5%      .+�5'      �� $��0��6    $ 3q�6J   $��3q�6V   ��60   �� *
FileName+6V   �� 5(      $��1��6    $ 3q�6F   $��3q�6R   ��60   �� *Size+6R   �� 5)      $��2��6    $ 3q�6N   $��3q�6Z   ��60   �� *FileDateTime+6Z   5*      5+      �� 5,      "  6   .R�5-      � $
��Left=�6    5.      �� 5/      �� 50      .+�52      �� $��1��6    $ 3q�6F   $��3q�6R   ��60   �� *Size+6R   �� 53      $��0��6    $ 3q�6N   $��3q�6Z   ��60   �� *FileDateTime+6Z   54      55      �� 56      "  6   .R�57      � $
��Left=�6    58      �� 59      �� 5:      .+�5<      �� $��0��6    $ 3q�6J   $��3q�6V   ��60   �� *
FileName+6V   �� 5=      $��1��6    $ 3q�6N   $��3q�6Z   ��60   �� *FileDateTime+6Z   5>      5?      5@      .��5B      � 	 � RowDefinitions	 5C   
   �� 5D      $
��Auto �6   �� 5E      $
��Auto �6   �� 5F      $
��Auto �6   �� 5G      $
��Auto �6   �� 5H      .+�5J   
   � $��0��6    5K      �� 5L      $
��Auto �6#   �� 5M      �� 5N      $
��Auto �6#   .+�5P      �� $��0��6   $��
_Directory��6$   
 �� Target
 69   ��  �� ElementName$ txtDirectory���� 5Q      -   5         ��Name$ txtDirectory��5Q      $��1��6,      
InputStyle#��[  5R      ��5Q   <   �� *DirectoryStart+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5R      �� 5S      $��2��6    � ToolTip$ Define Start Directory��6%     ButtonImage#��[ 6t   ��6F   �� *GetStartDirectoryCommand+.��5T      �� $'��!Picture\OpenFileDialog_692_24.bmp��6     ImageInButton#��[ 6E   5U      5V      � 5W   
   $��1��6    5X      �� 5Y      $
��Auto �6#   �� 5Z      �� 5[      $
��Auto �6#   �� 5\      �� 5]      $
��Auto �6#   �� 5^      �� 5_      $
��Auto �6#   �� 5`      $
��Auto �6#   .+�5b      �� $��0��6   $��_Mask��6$   
 64   �� $ txtMask���� 5c      -   5        $ txtMask��5c      $��1��6'   #��[  6�   ��67   �� *Mask+$ TwoWay=�$ PropertyChanged=�6�   �� 5d      $��2��6   $��
Size _From��6$   
 69   �� $ txtSizeFrom���� 5e      -   5        $ txtSizeFrom��5e      $��3��6+   #��[  6�   ��6;   �� *
SizeFrom+$ TwoWay=�$ PropertyChanged=�6�   �� 5f      $��4��6   $	��_To��6$   
 62   �� $ 	txtSizeTo���� 5g      -   5        $ 	txtSizeTo��5g      $��5��6)   #��[  6�   ��69   �� *SizeTo+$ TwoWay=�$ PropertyChanged=�6�   �� 5h      $��8��6   $��Filter by Size��6Y    d� 	IsChecked 6'   �� *IsFilterBySize+$ TwoWay=�6Y   5i      � 5j   
   $��2��6    5k      �� 5l      $
��Auto �6#   �� 5m      $
��Auto �6#   �� 5n      $
��Auto �6#   �� 5o      .+�5q      �� $��0��6   $��Group by Name��6X    6'   �� *IsGroupByName+$ TwoWay=�6X   �� 5r      $��1��6   $��Group by Size��6X    6'   �� *IsGroupBySize+$ TwoWay=�6X   �� 5s      $��2��6   $��Group by DateTime��6\    6'   �� *IsGroupByDateTime+$ TwoWay=�6\   5t      �� 5u   
   $��3��6    �� Orientation$ 
Horizontal=�6"   .+�5v      �� $ Start��6   #��[ 6M    ^� ShowOnDisabled . ��6%   �� *StartSearchCommand+.��5w      �� $��Picture\player_play.png��6   #��[ 6;   5x      �� 5y      $ Delete Selected��6   #��[ 6[    . ��60   �� *DeleteSelectedCommand+.��5z      �� $'��!Picture\Clearallrequests_8816.png��6   #��[ 6E   5{      �� 5|      $  Delete all except selected��6   #��[ 6o    . ��6;   �� * DeleteAllExceptSelectedCommand+.��5}      �� $$��Picture\detachprocess_6535.png��6   #��[ 6B   5~      �� 5      $ Go to the Latest��6   #��[ 6[    . ��61   �� *GoToTheLatestCommand+.��5�      �� $!��Picture\view_top_bottom.png��6   #��[ 6?   5�      �� 5�      $ Open Directory��6   #��[ 6Y    . ��6/   �� *OpenDirectoryCommand+.��5�      �� $��Picture\folder.png��6   #��[ 66   5�      �� 5�      $ 	Open File��6   #��[ 6O    . ��6*   �� *OpenFileCommand+.��5�      �� $��Picture\BMP File.png��6   #��[ 68   5�      �� 5�      $ Open Common Directory��6   #��[ 6f    . ��66   �� *OpenCommonDirectoryCommand+.��5�      �� $��Picture\folder1.png��6   #��[ 67   5�      �� 5�      $ Compare files��6   #��[ 6W    . ��6.   �� *CompareFilesCommand+.��5�      �� $��Picture\reload.png��6   #��[ 66   5�      �� 5�      $ Compare by content��6   #��[ 6`    . ��63   �� *CompareByContentCommand+.��5�      �� $��Picture\run.png��6   #��[ 63   5�      �� 5�      $ Compare by content all��6   #��[ 6g    . ��67   �� *CompareByContentAllCommand+.��5�      �� $��Picture\hibernate.png��6   #��[ 69   5�      �� 5�      ��6   �� *StateOfProcessText+$ TwoWay=�$ PropertyChanged=�5�      � 5�   
   $��4��6    5�      �� 5�      $��2* �6#   �� 5�      $��5* �6#   	 5�      �� 5�      �� 5�      $	��100 �6    .+�5�      �� $��0��6   $��2��6x   ��6'   �� *FilesGroups+ �� SelectedItem 6K   �� *SelectedFilesGroups+6x   &   System.Windows.Controls.DataGrid  5�      $��1��6    �� AlternationCount$ 2��5�         RowBackground �#DDDDFF   AlternatingRowBackground �#CCCCEE   
IsReadOnly .     AutoGenerateColumns .  $��1q�5�   H      SelectionMode$ Single=�5�         SelectionUnit$ FullRow=�60      CanUserAddRows .     CanUserDeleteRows .  ��5�   '   �� *SelectedFilesGroups.Files+ 6Y   �� *SelectedFile+   RowStyle 5�      �� 5�       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5�      ��  �� Property � ��  �� Value$  25��63   �� 5�       � ��$  Center=�6>   �� 5�       � ��$  Center=�6E   5�      !   	CellStyle! 5�      �� 5�      *	  $System.Windows.Controls.DataGridCell" 	 6   .�5�      ��  � ��$  Center=�6>   �� 5�       � ��$  Center=�6E   5�      "   Columns" 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn#   Header$
# Name��6)   $   MinWidth$	$ 100Q�6]   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 67   �� *Name+$ OneWay=�6n   
  5�      $# Length��6)   $$ 50Q�6a   % 69   �� *Length+$ OneWay=�6q   
  5�      $# LastAccessTime��6)   $	$ 100Q�6q   % 6A   �� *LastAccessTime+$ OneWay=�6�   
  5�      $# DirectoryName��6)   $	$ 200Q�6o   % 6@   �� *DirectoryName+$ OneWay=�6�   5�      �� 5�      $��1��6D   $��1��6T   ��6   �� *SelectedFile.DirectoryName+6T   5�      5�      5�      