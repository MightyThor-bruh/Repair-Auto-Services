   M S B A M L   `   `   `  ����_  [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors  5   	   F BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View 5   	       AutoService.View.MainAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   WmbHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:AutoService.View  5   	     � Title$  Админ-панель��5
   	   $	��600��6   $	��850��6+   
������� � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$ SingleBorderWindow=�6o    � 
ResizeMode$ CanMinimize=�6�   $��Roboto)�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��700 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��530 �6   .+�5   
   �� $��Admin��6   $��Center=�6!   $��Center=�6>   $��16(�6Y   �� 5   
   $��1��6   $��0��5      $��Right=�5      $��Center=�5      $��0,0,10,0q�5      
������ ��5      Z� ��5      ��  �� Path$ BackCommand�.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Logout=�6&   $��25��64   $��25��6?   5      �� 5   
   -   5         ��Name$
 list��5!      $��1��5      $��0��5       $	��Top=�5"      	 � Cursor$
	 Hand��5#      *   $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5$      +   %Microsoft.Xaml.Behaviors.EventTrigger  5%         	EventName$ SelectionChanged��6"   *   $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5&      2   ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6-   �� $ SelectCommand�   CommandParameter 6T   ��  �� ElementName$
 list��$ SelectedItem�5'      .@�5)      �� -   5         ��Name$	 emp��5)       �� 
IsSelected . .��5*      ��  �� Orientation$ 
Horizontal=�6   .+�5+        $ Worker=�6.   $��20��6<   $��20��6G   $��0,0,10,0q�6S   �� 5,      $��Сотрудники��6    $��Center=�62   $��14(�6M   5-      5.      �� 5/      -   5        $ users��5/      .��50      �� $ 
Horizontal=�6   .+�51        $ Users=�6.   $��20��6;   $��20��6F   $��0,0,10,0q�6R   �� 52      $��Пользователи��6    $��Center=�64   $��14(�6O   53      54      �� 55      -   5        $ services��55      .��56      �� $ 
Horizontal=�6   .+�57        $ ServiceToolbox=�6.   $��20��6D   $��20��6O   $��0,0,10,0q�6[   �� 58      $��Услуги��6    $��Center=�6.   $��14(�6I   59      5:      �� 5;      -   5        $ orders��5;      .��5<      �� $ 
Horizontal=�6   .+�5=        $ OrderCheckboxAscending=�6.   $��20��6L   $��20��6W   $��0,0,10,0q�6c   �� 5>      $��Заказы��6    $��Center=�6.   $��14(�6I   5?      5@      �� 5A      -   5        $ reviews��5A      .��5B      �� $ 
Horizontal=�6   .+�5C        $ 
RateReview=�6.   $��20��6@   $��20��6K   $��0,0,10,0q�6W   �� 5D      $��Отзывы��6    $��Center=�6.   $��14(�6I   5E      5F      �� 5G      -   5        $
 cars��5G      .��5H      �� $ 
Horizontal=�6   .+�5I        $	 Car=�6.   $��20��69   $��20��6D   $��0,0,10,0q�6P   �� 5J      $��Автомобили��6    $��Center=�62   $��14(�6M   5K      5L      5M      �� 5N   
   ���#264653$��1,0,0,0q�6'   $��1��6A   $��1��6N   ._�5O      �� ��6   �� $ Current�5P      5Q      5R      