   M S B A M L   `   `   `  ���� R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  /    )AttendanceManagementWPF.AddAttendanceUser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:AttendanceManagementWPF     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� 
Background
  ����� N� Title$ AttendanceUser��.���  � RowDefinitions �� $��60 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 
BackButton��$��0��$��12 0 0 0q�
�������$��4q�$��0q�
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 4�� $   MaterialDesignFlatAccentBgButton#��[   J� BitmapEffect F�  F� Color$ #022B3A�� F� 	Direction$	 320Q�	 F� Softness$	 1Q�
 F� ShadowDepth$
 4Q� F� Opacity$	 0.5Q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�$��24��$��24�����#022B3A�� $��Add Attendance��$
��Bold"�$
��Left=�$��12 0 0 0q�$��24(����#022B3A$��Center=�$��Stretch=�$��Center=��� -    ��Name$ Message��$��1��$��18(�$��Center=�$��Center=�$
��Bold"�$F��@You are not into any project or All your projects are completed.���� -   $��projectsList��$��1��$��12q�$��12q� �� SelectionMode$ Single=�$	��600��$
��Left=�$
��Left=�$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R��� ���� .R��� ���� .R��� $
��Left=�
�������$��	0 12 0 12q� �� CornerRadius$ 6�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #022B3A��   ShadowDepth$ 2Q�   Opacity$	 0.4Q�   
BlurRadius$ 6Q�._��  � ColumnDefinitions �� �� .+��� $��Center=�$ Vertical=�$��0��$��	0 12 0 12q�$
��Left=�.+�� $��Center=� �� �� .+��� $��0��$��Project ID: ��$��15(�$��Medium"�$��Center=�$��Center=�$��12 0 0 0q��� $��1��$��18(�$��Center=�$��Center=�$
��Bold"�$��6 0 6 0q�$��3 0 3 0q����� *	ProjectId+� $��Center=� �� �� .+��� $��0��$��Project Name: ��$��15(�$��Medium"�$��Center=�$��Center=�$��12 0 0 0q��� $��1��$��18(�$��Center=�$��Center=�$
��Bold"�$��6 0 6 0q�$��3 0 3 0q����� *ProjectName+�� $ addAttendanceButton��-   $��1��$��Add Attendance��$��Center=�$��	12 0 12 0q�$��	12 0 12 0q�$��18(�$��Center=�$��Center=�$��0q�$��Medium"����#EF1F1F " MaterialDesignRaisedDarkButton#��[ 