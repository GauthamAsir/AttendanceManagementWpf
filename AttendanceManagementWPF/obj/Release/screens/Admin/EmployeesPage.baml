   M S B A M L   `   `   `  ���� R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  +    %AttendanceManagementWPF.EmployeesPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:AttendanceManagementWPF     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  EmployeesPage��.��� .+��� .���  � RowDefinitions �� $��60 ��� $��* �.+�� ���#022B3A � ColumnDefinitions �� $��2* ��� �� .+��� $��	Employees��
�������$��Center=�$��18(�� $��1��$��Center=�$��	12 0 12 0q�$��Center=�$	��180�� �� $��24 ��� $��* �.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��0��$��Bottom=�   Kind$ Search=�
�������$��18��$��0 0 0 0q�$��18���� -    ��Name$ txtSearchEmployee�� %  !MaterialDesignFloatingHintTextBox#��[  $��1��$��Medium"�$��6 0 6 0q�
�������.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��   
Foreground
 �����$��12(�.���� -    ��Name$ btnAddEmployee��$��2��$��Add Employee +��$��0 0 12 0q�$��	12 0 12 0q�$��18(�$y�Visible=�$��Right=�$��0q�$��Medium"�
�������
���   � $  MaterialDesignFlatAccentBgButton#��[ � $��1��.+�&   System.Windows.Controls.DataGrid  -   	  Name$	 gridEmployeeDetails��$	��Top=�
   VerticalGridLinesBrush

 �����
�������   	RowHeight$ 50Q�   AutoGenerateColumns .  $��20(�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 180    
IsReadOnly .  � 	Resources   test �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  elemntStyle��%y  &	       &	 �     �� "  .���  � ��$ Center=���  � ��$ 	12 0 12 0q���  � ��$ Center=���  � ��$ 0q���  � ��
 ���� ��  � ��$ Stretch=���  � ��$ 16(���  � ��$ Medium"���  � �� �#022B3A�� " ��.���  � ��$ Center=���  � ��$ 14(���  � ��$ Center=���  � �� �#022B3A   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Employee ID��   MinWidth$ 80Q�   HeaderStyle# [ 1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [  	  Binding �� *
EmployeeId+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  $
 Name��$ 80Q�   Width$ 1* # [ # [  �� *	FirstName+$ TwoWay=�$ PropertyChanged=�  $ Contact��$ 80Q�$ 1* # [ # [  �� *	ContactNo+$ TwoWay=�$ PropertyChanged=�  $ 	Job Title��$ 80Q�$ 1* # [ # [  �� *
JobTitle+$ TwoWay=�$ PropertyChanged=�4
  .System.Windows.Controls.DataGridTemplateColumn
  -   datagrid3dottemplate��   
IsReadOnly .  
  CellTemplate �� .R�o� $��0q�$��0q�$��Center=�$��Center=�}�.    MaterialDesignMenu#��[ $��Center=�$��Center=�.@�m� $��0q�$
��More��$��6 0 6 0q�  MaterialDesignMenuItem#���  $��Center=�$��Center=� m� Icon   $��0q�$��0q�$ ChevronDown=�.@�m�  m�Name$ menuItemMore��-   $��Center=�$
��More��#��[ m� $ menuItemUpdate��-   $��Center=�#��[ $��Update��m� $ menuItemRemove��-   $��Center=�#��[ $��Remove��