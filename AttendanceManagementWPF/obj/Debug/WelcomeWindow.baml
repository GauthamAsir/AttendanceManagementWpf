   M S B A M L   `   `   `  ����R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  5   	   +    %AttendanceManagementWPF.WelcomeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:AttendanceManagementWPF     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$   ��5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ Manual=�5   	   ���#022B3A$	��450��5   	   $	��800��6    � 	Resources 5         fade �� TargetProperty W� From	 W� To g� Duration  transformEllipse��%b  &	        &	 �     �� 5   
   $ Opacity�5      .��5      W� $ Opacity�5      $ 0X�5      $ 1X�6   $ 0:0:1D�6!   5      �� 5   
   .��5      W� $ (FrameworkElement.Width)�5      $ 0X�5      $
 75.0X�6   W� 5      $ (FrameworkElement.Height)�5      $ 0X�5      $
 75.0X�6   5       5"      .��5$      � $��Center=�5%   	   $��Center=�5&   	   	 � RowDefinitions	 5)   
   �� 5*      $	��200 �6   �� 5+      $��1* �6   .+�5.   
   � $��0��5/      
 � ColumnDefinitions
 51      �� 52      �� 53      .+�56      �� $��0��57      $	��600��58      .+�5:      A� -   5         A�Name$ circle1��5;      
 �� Top$ 20��5<       �� Left$	 100��5=      ���#007bff$��0��5?      $��0��5@      A� 5B      -   5        $ circle2��5C      $ 90��5D      $	 -30��5E      ���#1ec93d$��0��5G      $��0��5H      �� 5J      -   5         ��Name$ welcome��5K      $y�Hidden=�5L      $ 50��5M      $ 0��5N      
�������$��Welcome��5P      $��28(�5Q      $
��Bold"�5R      �� 5T      -   5        $ empName��5U      $ 80��5V      $�� ��5W      
�������$��36(�5Y      $
��Bold"�5Z      5\      �� 5^      -   5         ��Name$ 
stackTitle��5_      $y�Hidden=�5`      $��1��5a      .+�5c      �� $��1��5d      $��28(�5e      $��Center=�5f      $
��Bold"�5g      
�������$��6 6 6 0q�5i      $��Center=�5j      $��Employee Attendance��5k      �� 5m      $��1��5n      $��28(�5o      $��Center=�5p      $
��Bold"�5q      
�������$��6 0 6 6q�5s      $��Center=�5t      $��
Management��5u      �� 5w      $��75��6   ��5x      �� 5y       �� DecodePixelWidth$ 75��5z       �� 	UriSource$ /images/attendance.png?�5{      5}      5      5�      � 5�   
   $��1��5�      .+�5�      �� -   5         ��Name$ Continue��5�      $��Continue��5�      $��Center=�5�      $��	0 30 0 20q�5�      $��	12 0 12 0q�5�      $y�Hidden=�5�      $	��250��5�      $��18(�5�      
�������$��Center=�5�      $��Center=�5�      $��0q�5�      $��Medium"�5�      ���#007bff " MaterialDesignRaisedDarkButton#��[ 5�      5�      5�      5�      5�      