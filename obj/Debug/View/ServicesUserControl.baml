   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View  5      *    $AutoService.View.ServicesUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5	   7   .��5
      � $	��500��6     � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��0��6   $��15q�5       �� CornerRadius$ 15��5      ���#F8F9FA �� Padding$ 10q�5      ._�5      �� -   5         ��Name$
 emps��5       %� 
ScrollUnit$ Pixel=�5      $��Disabled=�5      $��Visible=�5      ��5      ��  �� Path$ Services� =� ErrorTemplate 5      Z�  �� SelectedItem 5      �� $ SelectedService� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=���5      �� 5      .R�5      �   5      �� 5   "   $	��300 �63   �� 5    "   $	��100 �63   .+�5"      �� 
 �� Orientation$
 Vertical=�6)   $��0��6@   .+�5#   "   �� $��0,0,5,0q�6G   $��16(�6X   ��6,   �� $
 Name� 6f   Z� �� 5$   "   ��6,   �� $ Price� �� StringFormat$$ Цена услуги: {0} BYN�� 5%   ,   Z� 5&      �� 5'      $��1��6%   $��Center=�5(   %   
������ ��5*   %   Z�  5+   %   Z� ��5,   %   �� $ DataContext.DeleteCommand� �� ElementName$
 emps����5-   %   �� .��5.   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteForeverOutline=�6:   $��25��6V   $��25��6a   ���#f25c546m   5/      50      51      53      54      � 55   
   $��1��6    � RowDefinitions 56      �� 57      $��* �6    �� 58      $��* �6    .+�5:      �� $
 Vertical=�6   $
��Left=�60   $��Center=�6K   .+�5;      �� $#��Добавить услугу��6   $
��Left=�63   $��16(�6N   $��0,0,0,20q�6\   �� 5<      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��6   /  )MaterialDesignThemes.Wpf.ValidationAssist   Suppress . $	��150��5>      $��14(�5?      ��5@      �� $ NewService.Name�$ PropertyChanged=��� 5A      $ Цена��6    . $	��150��5C      $��14(�5D      $��0,10,0,0q�5F      ��5E      �� $ NewService.Price�$ PropertyChanged=�5F      �� 5G      $��Добавить��6   $
��0,20q�5H      $	��120��5I      $��14(�5J      ���#43aa8b
���������5M      �� $ 
AddCommand�5N      �� 5O      $
 Vertical=�6   $
��Left=�60   $	��Top=�6K   $��1��6c    5P      Z� y�5Q      �� $ SelectedService� !  BoolToVisibilityConverterBack �� 	Converter# [  $ PropertyChanged=�.+�5R      �� $#��Изменить данные��6   $
��Left=�63   $��16(�6N   $��0,0,0,20q�6\   �� 5T      $ Название��6    . $	��150��5V      $��14(�5W      ��5X      �� $ SelectedService.Name�$ PropertyChanged=��� 5Y      $ Цена(BYN)��6    . $	��150��5[      $��14(�5\      $��0,10,0,0q�5^      ��5]      �� $ SelectedService.Price�$ PropertyChanged=�5^      �� 5_      $��Изменить��6   $
��0,20q�5`      $	��120��5a      $��14(�5b      ���#168aad
���������5e      �� $ ChangeCommand�5f      5g      5h      5i      