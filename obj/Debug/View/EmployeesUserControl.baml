   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View  5      +    %AutoService.View.EmployeesUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5	   7   .��5
      � $	��500��6     � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��0��6   $��15q�5       �� CornerRadius$ 15��5      ���#F8F9FA �� Padding$ 10q�5      ._�5      �� -   5         ��Name$
 emps��5       %� 
ScrollUnit$ Pixel=�5      $��Disabled=�5      $��Visible=�5      ��5      ��  �� Path$ 	Employees� =� ErrorTemplate 5      Z�  �� SelectedItem 5      �� $ SelectedEmp� �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=���5      �� 5      .R�5      �   5      �� 5   "   $	��300 �63   �� 5    "   $	��100 �63   .+�5"      �� 
 �� Orientation$
 Vertical=�6)   $��0��6@   .+�5#   "   �� $
 
Horizontal=�6-   $��0,0,0,5q�6F   .+�5$   &   �� $��0,0,5,0q�6K   $��16(�6\   ��60   �� $
 Name� 6j   Z� �� 5%   &   $��16(�6N   ��60   �� $ Surname� 6\   Z� 5&   #   �� 5'   "   ��6,   �� $	 Exp� �� StringFormat$ Стаж: {0} года�� 6e   Z� 5(      �� 5)      $��1��6%   $��Center=�5*   %   
������  5,   %   Z� ��5-   %   Z� ��5.   %   �� $ DataContext.DeleteCommand� �� ElementName$
 emps����5/   %   �� .��50   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteForeverOutline=�6:   $��25��6V   $��25��6a   ���#f25c546m   51      52      53      55      56      � 57   
   $��1��6    � RowDefinitions 58      �� 59      $��* �6    �� 5:      $��* �6    .+�5<      �� $
 Vertical=�6   $
��Left=�60   $��Center=�6K   .+�5=      �� $+��%Добавить сотрудника��6   $
��Left=�67   $��16(�6R   $��0,0,0,20q�6`   �� 5>      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��6   /  )MaterialDesignThemes.Wpf.ValidationAssist   Suppress . $	��150��5@      $��14(�5A      ��5B      �� $ NewEmp.Name�$ PropertyChanged=��� 5C      $ Фамилия��6    . $	��150��5E      $
��0,10q�5F      $��14(�5G      ��5H      �� $ NewEmp.Surname�$ PropertyChanged=��� 5I      -   5        $ Стаж(лет)��5I       . $	��150��5K      $��14(�5L      ��5M      �� $ 
NewEmp.Exp�$ PropertyChanged=�6`   �� 5N      $��Добавить��6   $
��0,20q�5O      $	��120��5P      $��14(�5Q      ���#43aa8b
���������5T      �� $ 
AddCommand�5U      �� 5V      $
 Vertical=�6   $
��Left=�60   $	��Top=�6K   $��1��6c    5W      Z� y�5X      �� $ SelectedEmp� !  BoolToVisibilityConverterBack �� 	Converter# [  $ PropertyChanged=�.+�5Y      �� $#��Изменить данные��6   $
��Left=�63   $��16(�6N   $��0,0,0,20q�6\   �� 5[      $ Имя��6    . $	��150��5]      $��14(�5^      ��5_      �� $ SelectedEmp.Name�$ PropertyChanged=��� 5`      $ Фамилия��6   $	��150��5a       . $
��0,10q�5c      $��14(�5d      ��5e      �� $ SelectedEmp.Surname�$ PropertyChanged=��� 5f      $ Стаж(лет)��6    . $	��150��5h      $��14(�5i      ��5j      �� $ SelectedEmp.Exp�$ PropertyChanged=��� 5k      $��Изменить��6   $
��0,20q�5l      $	��120��5m      $��14(�5n      ���#168aad
���������5q      �� $ ChangeCommand�5r      5s      5t      5u      