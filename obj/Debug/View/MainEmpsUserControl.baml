   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View  5      *    $AutoService.View.MainEmpsUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5	   7   .��5
      � $	��650��6   $	��850��6     � RowDefinitions  5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   .+�5   
   �� $��Сотрудники��6   $
��Left=�5      $��Center=�5      $��26(�5      $��20,0,0,0q�5      $��Light"�5      �� 5   
   -   5         ��Name$ reviews��5      $��1��5      $��10q�5       �� Padding$ 10q�5       �� CornerRadius$ 20��5      ���#F8F9FA._�5      �� ��6   ��  �� Path$
 Emps���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5    "    �� 
TargetType" ��62   .R�5!   &   �� $��Bd��5&   9   $��3,0,0,3q�5!   -   # z��5"   9   $ 5��5#   9   #��z��5$   9   
������ 	 J� SnapsToDevicePixels	 . ._�5(   *   �� #��z��6;   #��z��5)       
 �� ContentStringFormat �� ContentStringFormat# z
 5*       #��z��5+       #��z��5,       #	 z	 5-       5.   '    �� Triggers 5/   &   ]� 50   *    ]� 
Conditions 51   .   �� 52   2    �� Property �@��IsSelectionActive �� Value .  6b   �� 53   2    �@��
IsSelected . 6[   ./�55   .   ��  �� 
TargetName$ Bd��6Q    � ��
 ���� 56      �� 57   .   $ Bd��6S    � �� 58   2   ��59   6   Transparent��6S   5;   /   5<   +   ]� 5=   *    5>   .   �� 5?   2    �@��IsSelectionActive . 6b   �� 5@   2    �@��
IsSelected . 6[   ./�5B   .   �� $ Bd��6Q    � ��
 ���� 6a   �� 5C   .   $ Bd��6S    � �� 5D   2   ��5E   6   Transparent��6S   5G   /   5H   +   P� 5I   *    P� Property � {� P� Value .  . �5J   .   �� $ Bd��6W    � �� 5K   2   C� 5L   6    C� ResourceKey# Z��6F   5N   /   5O   +   5Q   #   5S      5T      ��5V      �� 5W      .R�5X      �� ���#dee2e6$	��800��66   $ 20q�6B   $��0,0,0,1q�6O   ���#495057$ 10��6   ._�5Y      ��  �� Orientation$ 
Horizontal=�6)   $��Stretch=�5Z   )   .+�5[   "   �� $ Vertical=�6-   $��Center=�5\   -   .+�5]   &   �� $ 
Horizontal=�61   $��0,0,0,10q�6J   .+�5^   *   �� $��20(�6O   $��0,0,5,0q�6]   $��Light"�6n   ��64   �� $
 Name�6n   �� 5_   *   $��20(�6R   $��Center=�6`   $��Light"�6{   ��64   �� $ Surname�6{   5`   '   �� 5a   &   $��16(�6u   ���#ee9b00$��DemiBold"�6�   ��60   �� $ 
Experience� �� StringFormat$&  Опыт работы {0} лет��6�   5b   #   5c      5d      5e      5g      5h      5i      5j      