   M S B A M L   `   `   `  ����R  NAttendanceManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AttendanceManagementWPFAttendanceManagementWPF  5   	   '    !AttendanceManagementWPF.DialogBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:AttendanceManagementWPF     5   	     � WindowStyle$
  None=�5   	    � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � ShowInTaskbar .   � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 	DialogBox��5   	   .��5      �� $	��120��5   	   $	��200��5   	    �� Padding$ 12q�5   	   $��0q�5   	   
������� �� CornerRadius$ 6��5   	   ._�5   
   � 	 � RowDefinitions	 5      �� 5      �� 5      $��* �6    .+�5      �� -   5        
 ��Name$
 txtTitle��5!      $��0��5       $��Title��5"      $��20(�5#      $
��Bold"�5$      $��Center=�5%      $
��Left=�5&      �� 5(      $��1��5)      $��Center=�5*      $��Center=�5+      .+�5,      �� -   5        $
 
txtMessage��5-      $
��Test��5.      $��20(�5/      $��Center=�50      $��Center=�51      $��	0 20 0 20q�52      �� 53      -   5         ��Name$ close��54      $��0q�56      ���#022B3A$��Center=�58      $��Ok��59      
������� $   MaterialDesignFlatAccentBgButton#��[  5;      5<      5>      5?      5@      