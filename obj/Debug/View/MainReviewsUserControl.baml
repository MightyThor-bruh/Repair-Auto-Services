   M S B A M L   `   `   `  ����_  [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors  5      F BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View 5      -   'AutoService.View.MainReviewsUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      QmbHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5
   7   .��5      � $	��650��6   $	��850��6     � RowDefinitions  5   
   �� 5      $
��0.3* �6   �� 5      $
��1.7* �6   �� 5      $��* �6   .+�5   
   �� $��Отзывы��6   $
��Left=�5      $��Center=�5      $��26(�5      $��20,0,0,0q�5      $��Light"�5      �� 5   
   -   5         ��Name$ reviews��5      $��1��5      $��10q�5       �� Padding$ 10q�5       �� CornerRadius$ 20��5      ���#F8F9FA._�5      �� ��6   ��  �� Path$ Reviews���5      �� 5       �� 
TargetType" ��6   .�5       ��  �� Property � �� �� Value 5!      �� 5"   "    �� 
TargetType" ��62   .R�5#   &   �� $��Bd��5(   9   $��3,0,0,3q�5#   -   # z��5$   9   $ 5��5%   9   #��z��5&   9   
������ 	 J� SnapsToDevicePixels	 . ._�5*   *   �� #��z��6;   #��z��5+       
 �� ContentStringFormat �� ContentStringFormat# z
 5,       #��z��5-       #��z��5.       #	 z	 5/       50   '    �� Triggers 51   &   ]� 52   *    ]� 
Conditions 53   .   �� 54   2    �� Property �@��IsSelectionActive �� Value .  6b   �� 55   2    �@��
IsSelected . 6[   ./�57   .   ��  �� 
TargetName$ Bd��6Q    � ��
 ���� 58      �� 59   .   $ Bd��6S    � �� 5:   2   ��5;   6   Transparent��6S   5=   /   5>   +   ]� 5?   *    5@   .   �� 5A   2    �@��IsSelectionActive . 6b   �� 5B   2    �@��
IsSelected . 6[   ./�5D   .   �� $ Bd��6Q    � ��
 ���� 6a   �� 5E   .   $ Bd��6S    � �� 5F   2   ��5G   6   Transparent��6S   5I   /   5J   +   P� 5K   *    P� Property � {� P� Value .  . �5L   .   �� $ Bd��6W    � �� 5M   2   C� 5N   6    C� ResourceKey# Z��6F   5P   /   5Q   +   5S   #   5U      5V      ��5X      �� 5Y      .R�5Z      �  � ColumnDefinitions 5[      �� 5\   "   $��* �63   �� 5]   "   $
��0.2* �63   .+�5_      ��  �� Orientation$ 
Horizontal=�6)   $
��Left=�5`   )   .+�5a   "   �� $��50��6)   $��50��64    � Cursor$
 Hand��6@   $��0q�6N   $ 50��5b   )   $	��Top=�5c   )   $��Center=�5d   )   $��0,0,10,0q�5e   )   ._�5f   &   A� ��5g   *   �� 5h   .    j� Stretch$ UniformToFill=�69    �� ImageSource 6Q   �� $ Customer.Image�6   5j   '   5k   #   �� 5l   "   $ Vertical=�6-   $��Center=�5m   -   .+�5n   &   �� $ 
Horizontal=�61   $��0,0,0,10q�6J   .+�5o   *   �� $��18(�6r   $��Light"�6�   ��64   �� $ Customer.Email� �� StringFormat$ {0} | ��6�   �� 5p   *   $��16(�6T   $��Center=�6b   $��Light"�6}   ��64   �� $ 	CreatedAt�6}   5q   '   �� 5s   &   $��16(�6L   ���#ee9b00$��DemiBold"�6o   ��60   �� $ Title�6o   �� 5t   &   $��14(�6R   $	��600��6`   $
��Wrap=�6l   ��60   �� $ Description�6l   5u   #   5v      �� 5w      $��1��6%   
������ $��Center=�5y   %   $��Center=�5z   %   ��5{   %   Z� ��5|   %   �� $ DataContext.DeleteCommand� �� ElementName$ reviews��y�5}   %   �� $ 	CanDelete�   BoolToVisibilityConverter �� 	Converter# [  ��5~   %   �� .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteForever=�6:   $��25��6O   $��25��6Z   5�      5�      5�      5�      5�      �� 5�   
   $ Vertical=�6   $��2��5�      $��20,0,0,0q�5�      $
��Left=�5�      .+�5�      ��   MaterialDesignTextBox#��[ 6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Заголовок��5�      $	��400��5�      $��Center=�5�      $��14(�5�      $
��0,10q�5�      ��5�      �� $ AddReview.Title� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5�      �� 5�      #��[ 6   $ Комментарий��5�        �� AcceptsReturn  . ! �� TextWrapping$
! Wrap=�5�      $	��400��5�      $	��100��5�      $	��Top=�5�      $��14(�5�      $
��0,10q�5�      ��5�      �� $ AddReview.Description�$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��Добавить��6   $	��120��5�      $
��Left=�5�      $��14(�5�      ���#43aa8b
���������5�      �� $ 
AddCommand�5�      5�      5�      