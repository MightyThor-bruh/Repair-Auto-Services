   M S B A M L   `   `   `  ����_  [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors  5      F BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View 5      0   *AutoService.View.AdminMakeOrderUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      WmbHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *localclr-namespace:AutoService.View  5      $��Roboto)�5
   7   .��5      � $	��500��6   $	��650��6     � RowDefinitions  5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6U   $��14(�6b   
���������6   ��  �� Path$ Order.Id� �� StringFormat$" Номер заказа: {0}��6p   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      ��  �� Orientation$ Vertical=�6   $��0��5      $
��Left=�5      .+�5      �� $/��)Выберите пользователя��6   $��14(�69   $��0,0,0,10q�6G   �� 5      $	��180��5      $��30��5       �� 
IsEditable .  w� TextPath$ Email��5!       �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .  $��14(�5$      $
��0,10q�5%      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$)	 #Начните вводить Email��5&      ��5      �� $ 	Customers�
 �� SelectedItem
 5      �� $ SelectedCustomer� �� UpdateSourceTrigger$ PropertyChanged=���5'      �� 5(      .R�5)      �� ��6(   �� $ Email�5*      5,      �� 5-      $	��180��5/      $��30��50      $��14(�51      $
��0,10q�52      $#	 Выберите машину��53      ��5-      �� $
 Cars�
 5.      �� $ SelectedCar�$ PropertyChanged=���54      �� 55      .R�56      �� $ Vertical=�6)   .+�57   "   �� $ 
Horizontal=�6-   $��0,0,0,5q�6F   .+�58   &   �� $��0,0,5,0q�6Z   ��60   �� $ Model.Producer.Name�6Z   �� 59   &   ��60   �� $ 
Model.Name�5:   #   �� 5;   "   $��0,0,5,0q�6o   ��6,   �� $ CreatedYear�$  Год выпуска: {0}��6o   5<      5=      5?      5@      �� 5A      $ Vertical=�6   $��1��60   $
��Left=�5B      .+�5C      �� $+��%Выберите сотрудника��6   $��14(�5D      $��0,0,0,10q�5E      5F      �� 5G      $	��180��5I      $��30��5J       .  . $ FullName��5M       .  $��14(�5O      $
��0,10q�5P      $*	 $Начните вводить имя��5Q      ��5G      �� $ 	EmpsNames�
 5H      �� $ SelectedEmp�$ PropertyChanged=���5R      �� 5S      .R�5T      �� ��6(   �� $ FullName�5U      5W      5Y      �� 5Z      $ Vertical=�6   $��2��5[      .+�5\      �� $#��Выберите услуги��6   $��14(�63   $��0,0,0,10q�6A   �� 5]      -   5        $��services��5]      $��Center=�5^       . $��14(�5b       �� 
IsReadOnly . $��Stretch=�5d       � Cursor$
 Hand��5e      ��5_      �� $ Services� �� Text 5a      �� $
 Text� �� IsDropDownOpen 5f      �� $ DataContext.DropOpen� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >�$ PropertyChanged=���5g      �� 5h      .R�5i      �� $��Center=�6'   $
 Hand��6B   $��Stretch=�6P    d� 	IsChecked 6u   �� *	IsChecked+.��5j   "   �� $ Vertical=�6-   .+�5k   &   �� ��60   �� $
 Name��� 5l   &   $��12(�6j   ���#6C757D��60   �� $ Price�$ Цена: {0} BYN��6x   5m   #   5n      5o      5q      �� 5r      $=��7Дата начала выполнения заказа��6   $��	0,40,0,10q�6A   $��14(�6T   (  "System.Windows.Controls.DatePicker  5s      $0	 *Дата начала выполнения��6   $��14(�5t         SelectedDate 5u      �� $ Order.StartDate�   DisplayDateStart 5v      �� $ 	StartDate�   DisplayDateEnd 5w      �� $ EndDate��� 5x      $��Статус заказа��6   $��	0,40,0,10q�61   $��14(�6D   �� 5y      $��14(�5{      $	 Статус заказа��5}      ��5y      �� $ Statuses�
 5z      �� $ SelectedStatus�$ PropertyChanged=�{�5|      �� $ IsEdit���5~      �� 5      .R�5�      �� ��6(   �� $
 Name�5�      5�      �� 5�      $\��VНевозможно редактировать, так как заказ закрыт��6   $	��210��5�      $
��Left=�5�      $��	0,120,0,0q�5�      $
��Wrap=�5�      ���#d62828y�5�      �� $ CanEdit� !  BoolToVisibilityConverterBack �� 	Converter# [  5�      5�      � 5�   
   $��2��6    5�      �� 5�      $
��0.1* �6#   �� 5�      $��* �6#   .+�5�      �� $
��Left=�6   $��0��5�      $��Center=�5�      
������ ��5�      Z� ��5�      �� $ BackCommand�.��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�6*   $��25��6A   $��25��6L   5�      �� 5�      $ 
Horizontal=�6   $��1��5�      $��Right=�5�      $��Center=�5�      .+�5�      �� ���#6C757D$��14(�5�      $��Center=�5�      $��0,0,20,0q�5�      ��5�      �� $ 	Order.Sum�$ PropertyChanged=�$% Сумма заказа {0} BYN�� =� ErrorTemplate 5�      Z� 5�      �� 5�      $��Оформить��6   $
��15,0q�5�      $	��150��5�      $��14(�5�      ���#2a9d8f
�������$��30��5�      y�5�      �� $ IsEdit�# [  ��5�      �� $ MakeCommand��� 5�      $��Изменить��6   $
��15,0q�5�      $	��150��5�      $��14(�5�      ���#0096c7
�������$��30��5�      y�5�      �� $ IsEdit�  BoolToVisibilityConverter# [ ��5�      �� $ ChangeCommand�5�      5�      5�      5�      