   M S B A M L   `   `   `  ����R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  5      /    )AttendanceManagementWPF.AddAttendanceUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AttendanceManagementWPF     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� 
Background
  ����� N� Title$ AttendanceUser��5      .��5   
   �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   �� $��0��5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5         ��Name$ 
BackButton��5      $��0��5      $��12 0 0 0q�5      
�������$��4q�5      $��0q�5       
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 4��5"       $   MaterialDesignFlatAccentBgButton#��[  5#       J� BitmapEffect 5%      F� 5&       F� Color$ #022B3A��5'       F� 	Direction$	 320Q�5(      	 F� Softness$	 1Q�5)      
 F� ShadowDepth$
 4Q�5*       F� Opacity$	 0.5Q�5+      .��5.      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�5/      $��24��50      $��24��51      ���#022B3A52      53      �� 54      $��Add Attendance��55      $
��Bold"�56      $
��Left=�57      $��12 0 0 0q�58      $��24(�59      ���#022B3A$��Center=�5;      $��Stretch=�5<      $��Center=�5=      5?      �� 5A   
   -   5         ��Name$ Message��5D      $��1��5C      $��18(�5E      $��Center=�5F      $��Center=�5G      $
��Bold"�5H      $F��@You are not into any project or All your projects are completed.��5I      �� 5K   
   -   5        $��projectsList��5T      $��1��5L      $��12q�5M      $��12q�5N       �� SelectionMode$ Single=�5O      $	��600��5P      $
��Left=�5Q      $
��Left=�5R      $	��Top=�5S      ��5U      �� 5V       �� 
TargetType" ��6   .�5W      ��  �� Property � �� �� Value
 ���� 5X      �� 5Y       � �� 5Z      �� 5[       �� 
TargetType" ��5\   !   .R�5]   "   �� 5^      5`      5a      ��5d      �� 5e      .R�5f      �� 6'   5g      ��5j      �� 5k      .R�5l      �� $
��Left=�5m      
�������$��	0 12 0 12q�5o   !    �� CornerRadius$ 6��5p   !    J� Effect 5q      3  -System.Windows.Media.Effects.DropShadowEffect  5r         Color$ #022B3A��5s   -      ShadowDepth$ 2Q�5t   -      Opacity$	 0.4Q�5u   -      
BlurRadius$ 6Q�5v   -   ._�5y      �  � ColumnDefinitions 5{      �� 5|   "   �� 5}   "   .+�5�      �� $��Center=�5�   %   $ Vertical=�5�   )   $��0��5�   -   $��	0 12 0 12q�5�   )   $
��Left=�5�   )   .+�5�   "   � $��Center=�5�   )    5�   &   �� 5�   *   �� 5�   *   .+�5�   &   �� $��0��5�   -   $��Project ID: ��5�   -   $��15(�5�   (   $��Medium"�5�   (   $��Center=�5�   0   $��Center=�5�   0   $��12 0 0 0q�5�   (   �� 5�   &   $��1��5�   -   $��18(�5�   (   $��Center=�5�   0   $��Center=�5�   0   $
��Bold"�5�   0   $��6 0 6 0q�5�   0   $��3 0 3 0q�5�   (   ��5�   -   �� *	ProjectId+5�   (   5�   #   � 5�   "   $��Center=�5�   )    5�   &   �� 5�   *   �� 5�   *   .+�5�   &   �� $��0��5�   -   $��Project Name: ��5�   -   $��15(�5�   (   $��Medium"�5�   (   $��Center=�5�   0   $��Center=�5�   0   $��12 0 0 0q�5�   (   �� 5�   &   $��1��5�   -   $��18(�5�   (   $��Center=�5�   0   $��Center=�5�   0   $
��Bold"�5�   0   $��6 0 6 0q�5�   0   $��3 0 3 0q�5�   (   ��5�   -   �� *ProjectName+5�   (   5�   #   5�      �� 5�      $ addAttendanceButton��5�   %   -   5        $��1��5�   %   $��Add Attendance��5�   %   $��Center=�5�   %   $��	12 0 12 0q�5�   %   $��	12 0 12 0q�5�   %   $��18(�5�   %   $��Center=�5�   %   $��Center=�5�   %   $��0q�5�   %   $��Medium"�5�   %   ���#EF1F1F " MaterialDesignRaisedDarkButton#��[ 5�   %   5�      5�      5�      5�      5�      5     5     