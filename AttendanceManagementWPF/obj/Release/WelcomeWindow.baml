   M S B A M L   `   `   `  ���� R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  +    %AttendanceManagementWPF.WelcomeWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:AttendanceManagementWPF     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$   �� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Manual=����#022B3A$	��450��$	��800�� � 	Resources    fade �� TargetProperty W� From	 W� To g� Duration  transformEllipse��%�   &	        &	 E     �� $ Opacity�.��W� $ Opacity�$ 0X�$ 1X�$ 0:0:1D��� .��W� $ (FrameworkElement.Width)�$ 0X�$
 75.0X�W� $ (FrameworkElement.Height)�$ 0X�$
 75.0X�.��� $��Center=�$��Center=�	 � RowDefinitions	 �� $	��200 ��� $��1* �.+�� $��0��
 � ColumnDefinitions
 �� �� .+��� $��0��$	��600��.+�A� -    A�Name$ circle1��
 �� Top$ 20�� �� Left$	 100�����#007bff$��0��$��0��A� -   $ circle2��$ 90��$	 -30�����#1ec93d$��0��$��0���� -    ��Name$ welcome��$y�Hidden=�$ 50��$ 0��
�������$��Welcome��$��28(�$
��Bold"��� -   $ empName��$ 80��$�� ��
�������$��36(�$
��Bold"��� -    ��Name$ 
stackTitle��$y�Hidden=�$��1��.+��� $��1��$��28(�$��Center=�$
��Bold"�
�������$��6 6 6 0q�$��Center=�$��Employee Attendance���� $��1��$��28(�$��Center=�$
��Bold"�
�������$��6 0 6 6q�$��Center=�$��
Management���� $��75������  �� DecodePixelWidth$ 75�� �� 	UriSource$ /images/attendance.png?�� $��1��.+��� -    ��Name$ Continue��$��Continue��$��Center=�$��	0 30 0 20q�$��	12 0 12 0q�$y�Hidden=�$	��250��$��18(�
�������$��Center=�$��Center=�$��0q�$��Medium"����#007bff " MaterialDesignRaisedDarkButton#��[ 