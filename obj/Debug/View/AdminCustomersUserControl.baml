   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View  5      0    *AutoService.View.AdminCustomersUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5	   7   .��5
      � $	��480��6   $	��650��6   .+�5   
   ��   �� Padding$  10q�6    �� CornerRadius$ 20��5      ���#F8F9FA._�5      �� ��6   ��  �� Path$ 	Customers���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� $��Bd��5   9   $��3,0,0,3q�5   -   #  z��5   9   $ 5��5   9   #��z��5   9   
������  J� SnapsToDevicePixels . ._�5   *   �� #��z��6;   #��z��5        �� ContentStringFormat	 �� ContentStringFormat#	 z 5       #��z��5       #��z��5       # z 5        5!   '   
 �� Triggers
 5"   &   ]� 5#   *    ]� 
Conditions 5$   .   �� 5%   2    �� Property �@��IsSelectionActive �� Value .  6b   �� 5&   2    �@��
IsSelected . 6[   ./�5(   .   ��  �� 
TargetName$ Bd��6Q    � ��
 ���� 5)      �� 5*   .   $ Bd��6S    � �� 5+   2   ��5,   6   Transparent��6S   5.   /   5/   +   ]� 50   *    51   .   �� 52   2    �@��IsSelectionActive . 6b   �� 53   2    �@��
IsSelected . 6[   ./�55   .   �� $ Bd��6Q    � ��
 ���� 6a   �� 56   .   $ Bd��6S    � �� 57   2   ��58   6   Transparent��6S   5:   /   5;   +   P� 5<   *    P� Property � {� P� Value .  . �5=   .   �� $ Bd��6W    � �� 5>   2   C� 5?   6    C� ResourceKey# Z��6F   5A   /   5B   +   5D   #   5F      5G      ��5I      �� 5J      .R�5K      ��  �� Orientation$ 
Horizontal=�6%   $
��Left=�5L   )   .+�5M      �� $��50��6%   $��50��60    � Cursor$
 Hand��6<   $��0q�6J   $ 50��5N   )   $	��Top=�5O   )   $��Center=�5P   )   $��0,0,10,0q�5Q   )   ._�5R   "   A� ��5S   &   �� 5T   *    j� Stretch$ UniformToFill=�65    �� ImageSource 6M   �� $ Image�6r   5V   #   5W      �� 5X      $ Vertical=�6)   $��Center=�5Y   -   .+�5Z   "   �� $��18(�6H   $��Light"�6V   ��6,   �� $ Email�6V   �� 5[   "   $ 
Horizontal=�6-   .+�5\   &   �� $��14(�6K   $��0,0,5,0q�6Y   ��60   �� $
 Name�6Y   �� 5]   &   $��14(�6N   ��60   �� $ Surname�6N   5^   #   5_      5`      5a      5c      5d      5e      5f      