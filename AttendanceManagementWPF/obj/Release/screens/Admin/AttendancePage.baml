   M S B A M L   `   `   `  ���� R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  ,    &AttendanceManagementWPF.AttendancePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:AttendanceManagementWPF     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  AttendancePage��.��� $��0q� � RowDefinitions �� $��80 ��� .+�� $��0�����#022B3A � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� $��0��$��Accepted Attendance List��$��Center=�$��Center=�$��18(�$��	12 0 24 0q�
�������$��Medium"��� -    ��Name$ sortby��$��1�� "  MaterialDesignOutlinedComboBox#��[  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Sort By��$��16(�$��12 10 12 10q�
�������$��Medium"�   
Background �#022B3A   
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����
�������$��2q�$��Center=�$��Center=�.@��� $��Daily��
���   �$��15(��� $��Weekly��
���   �$��15(��� $��Monthly��
���   �$��15(�(  "System.Windows.Controls.DatePicker  -     Name$ 	startdate��$��2��$��Center=�$��Center=�
�������$��2q� �#022B3A
 �����
 ����� $  MaterialDesignOutlinedDatePicker#��[ $ 
Start Date��$��16(�$y�	Collapsed=�
�������$��Medium"�  -   $ enddate��$��3��#��[ $ End Date��
�������
�������$��2q� �#022B3A
 �����
 �����$��Medium"�$��16(�$y�	Collapsed=�$��Center=��� -   	 ��Name$	 
updateSort��$��4��$��Update��$��Center=�$��	12 0 12 0q�$��18(����#022B3A$��Center=�$��Center=�$��0q�$��Medium"�
������� $  MaterialDesignRaisedAccentButton#��[ &   System.Windows.Controls.DataGrid  -   
  Name$
 gridProducts��$��1��   AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�   
IsReadOnly . $��0q�$��0q�   CanUserResizeRows .   MaterialDesignDataGrid#��[    CanUserAddRows .   � 	Resources   test �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  elemntStyle��%F  &	       &	 �     �� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 0q���  � ��
 ���� ��  � ��$ Stretch=���  � ��$ 18(���  � ��$ Medium"���  � �� �#022B3A�� " ��.���  � ��$ Center=���  � ��$ Center=���  � �� �#022B3A   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Id��   MinWidth$ 80Q�   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
EmployeeId+   ElementStyle �� elemntStyle��" ��.���  � ��$ Center=�  $ Employee Name��$	 120Q�   Width5	  /System.Windows.Controls.DataGridLengthConverter$ 1*	 # [ # [  �� *EmployeeName+  $ 
Project Id��$	 120Q�$ 1*	 # [ # [  �� *	ProjectId+  $ Project Name��$	 120Q�$ 1*	 # [ # [  �� *ProjectName+  $
 Date��$	 120Q�$ 1*	 # [ # [  �� *DateOfAttendance+ �� StringFormat$ 
dd/MM/yyyy��