   M S B A M L   `   `   `  ���� R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:AttendanceManagementWPF.screens.Admin%AttendanceManagementWPF.screens.Admin  ?    9AttendanceManagementWPF.screens.Admin.EmployeeDetailsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Elocal3clr-namespace:AttendanceManagementWPF.screens.Admin     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� 
Background
  ����� N� Title$ EmployeeDetailsPage��.���  � RowDefinitions �� $��60 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 
BackButton��$��12 0 0 0q�
�������$��4q�$��0q�
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 4�� $   MaterialDesignFlatAccentBgButton#��[   J� BitmapEffect F�  F� Color$ #022B3A�� F� 	Direction$	 320Q�	 F� Softness$	 1Q�
 F� ShadowDepth$
 4Q� F� Opacity$	 0.5Q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�$��24��$��24�����#022B3A�� $��Employee Details��$
��Bold"�$
��Left=�$��24 0 0 0q�$��24(����#022B3A$��Center=�$��Stretch=�$��Center=�� $��1��$��
24 24 24 0q�$	��Top=� �� $	��150 ��� $��* �.+��� $��0�����#022B3A���#022B3A$��1q� �� CornerRadius$ 4��._�� $��0q� �� $��40 ��� $��* �.+��  � ColumnDefinitions �� $��* ��� .+��� -    ��Name$ txtEmployeeName��$��0��$��Employee Name��$��22(�$��0q�$��	12 0 12 0q�
�������$
��Bold"�$
��Left=�$��Center=��� -   $ txtEmployeeID��$��1��$��Employee ID��$��22(�$��0q�$��	12 0 12 0q�
�������$
��Bold"�$��Right=�$��Center=��� $��1��$��0q�
������ 
�������$ 0 0 4 4��._��  �� �� .+�� $��0��$��	12 0 12 0q� �� �� �� .+��� $��0��$ 
Horizontal=�.+�  $ EmailOutline=�$��Center=��� $��Email: ��$��14(�$��Medium"�$��Center=��� -   $ txtEmail��$�� ��$��14(�$��Medium"�$��Center=��� $��1��$ 
Horizontal=�.+�  $ PhoneOutline=�$��Center=��� $��Contact No.: ��$��14(�$��Medium"�$��Center=��� -   $ txtContactNo��$�� ��$��14(�$��Medium"�$��Center=��� $��2��$ 
Horizontal=�.+�  $ PersonOutline=�$��Center=��� $��Role: ��$��14(�$��Medium"�$��Center=��� -   $ txtRole��$�� ��$��14(�$��Medium"�$��Center=�� $��1��$��	50 0 12 0q�$
��Left=� �� �� �� .+��� $ 
Horizontal=�.+�  $ CalendarOutline=�$��Center=��� $��Date of Birth: ��$��14(�$��Medium"�$��Center=��� -   $ txtDateofbirth��$�� ��$��14(�$��Medium"�$��Center=��� $��1��$ 
Horizontal=�.+�  $ WorkOutline=�$��Center=��� $��Job Titile: ��$��14(�$��Medium"�$��Center=��� -   $ txtJobTitle��$�� ��$��14(�$��Medium"�$��Center=��� $��2��$ 
Horizontal=�.+�  $ ShieldPersonOutline=�$��Center=��� $��Manager ID: ��$��14(�$��Medium"�$��Center=��� -	   $ txtManagerId��$�� ��$��14(�$��Medium"�$��Center=�