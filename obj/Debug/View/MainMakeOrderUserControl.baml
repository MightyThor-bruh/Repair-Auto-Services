   M S B A M L   `   `   `  ����_  [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors  5      F BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View 5      /   )AutoService.View.MainMakeOrderUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      QmbHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5
   7   .��5      � $	��650��6   $	��850��6     � RowDefinitions  5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��5      $��16(�5      $��20,0,0,0q�5      
�������$
��Left=�5      $��Center=�5      ��5      ��  �� Path$ Order.Id� �� StringFormat$" Номер заказа: {0}��5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�5      $��Center=�5      .+�5      �� $'��!Оформление заказа��6   $��26(�65   $��Light"�6C   $��0,0,0,40q�6V   $��Center=�6h   �� 5      $#��Выберите машину��6   $��14(�63   $��0,0,0,10q�6A   �� 5      $	��200��5       $��30��5!      $
��Left=�5#      $��14(�5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Выберите машину��5%      ��5      �� $
 Cars� �� SelectedItem 5      �� $ SelectedCar� �� UpdateSourceTrigger$ PropertyChanged=�{�5"      �� $ CanEdit���5&      �� 5'      .R�5(      �� $ Vertical=�6)   .+�5)   "   �� $ 
Horizontal=�6-   $��0,0,0,5q�6F   .+�5*   &   �� $��0,0,5,0q�6Z   ��60   �� $ Model.Producer.Name�6Z   �� 5+   &   ��60   �� $ 
Model.Name�5,   #   �� 5-   "   $��0,0,5,0q�6o   ��6,   �� $ CreatedYear�$  Год выпуска: {0}��6o   5.      5/      51      �� 52      $#��Выберите услуги��6   $��14(�63   $��	0,40,0,10q�6A   �� 53      -   5        $��services��53      $��Center=�54       �� 
IsEditable . $��14(�58      $	��200��5:       �� 
IsReadOnly . $
��Left=�5<      	 � Cursor$
	 Hand��5=      ��55      �� $ Services�
 �� Text
 57      �� $
 Text�{�59      �� $ CanEdit� �� IsDropDownOpen 5>      �� $ DataContext.DropOpen� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >�$ PropertyChanged=���5?      �� 5@      .R�5A      �� $��Center=�6'   $
	 Hand��6B   $��Stretch=�6P    d� 	IsChecked 6u   �� *	IsChecked+.��5B   "   �� $ Vertical=�6-   .+�5C   &   �� ��60   �� $
 Name��� 5D   &   $��12(�6j   ���#6C757D��60   �� $ Price�$ Цена: {0} BYN��6x   5E   #   5F      5G      5I      �� 5J      $=��7Дата начала выполнения заказа��6   $��	0,40,0,10q�6A   $��14(�6T   (  "System.Windows.Controls.DatePicker  5K      $0 *Дата начала выполнения��6   $��14(�5L      $	��200��5N      $
��Left=�5O      {�5M      �� $ CanEdit�   SelectedDate 5P      �� $ Order.StartDate�   DisplayDateStart 5Q      �� $ 	StartDate�   DisplayDateEnd 5R      �� $ EndDate��� 5S      $��Статус заказа��6   $��	0,40,0,10q�61   $��14(�6D   �� 5T      $��14(�5V      $	��200��5W      $
��Left=�5X      {�.  $ Статус заказа��5Z      ��5T      �� $ Statuses� 5U      �� $ SelectedStatus�$ PropertyChanged=���5[      �� 5\      .R�5]      �� ��6(   �� $
 Name�5^      5`      �� 5a      $���{Невозможно редактировать, так как заказ закрыт или уже выполняется��6   $	��210��5b      $
��Left=�5c      $��0,20,0,0q�5d      $
��Wrap=�5e      ���#d62828y�5g      �� $ CanEdit� !  BoolToVisibilityConverterBack �� 	Converter# [  5h      5i      � 5j   
   $��2��6    � ColumnDefinitions 5k      �� 5l      $
��0.1* �6#   �� 5m      $��* �6#   .+�5o      �� $
��Left=�6   $��0��5p      $��Center=�5q      
������ ��5s      Z� ��5t      �� $ BackCommand�.��5u      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�6*   $��25��6A   $��25��6L   5v      �� 5w      $ 
Horizontal=�6   $��1��5x      $��Right=�5y      $��Center=�5z      .+�5{      �� ���#6C757D$��14(�5~      $��Center=�5      $��0,0,20,0q�5�      ��5{      �� $ 	Order.Sum�$ PropertyChanged=�$% Сумма заказа {0} BYN�� =� ErrorTemplate 5|      Z� 5�      �� 5�      $��Оформить��6   $
��20,0q�5�      $	��150��5�      $��14(�5�      ���#2a9d8f
�������$��30��5�      y�5�      �� $ IsEdit�# [  ��5�      �� $ MakeCommand��� 5�      $��Отменить��6   $	��150��5�      $��14(�5�      ���#e63946
�������$��30��5�      y�5�      �� $ IsEdit�  BoolToVisibilityConverter# [ ��5�      �� $ CancelCommand��� 5�      $��Изменить��6   $
��20,0q�5�      $	��150��5�      $��14(�5�      ���#0096c7
�������$��30��5�      y�5�      �� $ IsEdit�# [ ��5�      �� $ ChangeCommand�5�      5�      5�      5�      