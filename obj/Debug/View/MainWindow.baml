   M S B A M L   `   `   `  ����_  [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors  5   	   F BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View 5   	   !   AutoService.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   WmbHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:AutoService.View  5   	     � Title$  Главная��5
   	   $	��680��6   $	��950��6&   
������� � WindowStartupLocation$ CenterScreen=�6E    � 
ResizeMode$ CanMinimize=�6j   $��Roboto)�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��850 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��500 �6   �� 5      $��50 �6   .+�5   
   �� ���#fafafa._�5      �� $��60��6   $��60��6     � Cursor$
 Hand��6,   $��0q�6:    �� CornerRadius$ 50��5      $��Center=�5      ._�5      A� ��5      �� 5       j� Stretch$ UniformToFill=�6%    �� ImageSource 6=   �� 	 �� Path$	 CurrentCustomer.Image�6r   
 J� InputBindings
 5      d� 5       d� MouseAction$ 	LeftClicke�6'    �� Command 6?   �� $	 ChangeImageCommand�5       5!      5"      �� 5#   
   -   5         ��Name$
 list��5&      $��1��5#      $��0,50,0,0q�5$      $��0��5%      $	��Top=�5'      $��Center=�5(      $��Stretch=�5)      $
 Hand��5*      *   $Microsoft.Xaml.Behaviors.Interaction   Triggers 5+      +   %Microsoft.Xaml.Behaviors.EventTrigger  5,         	EventName$ SelectionChanged��6"   *   $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5-      2   ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6-   �� $	 SelectCommand�   CommandParameter 6T   ��  �� ElementName$
 list��$	 SelectedItem�5.      .@�50      �� -   5         ��Name$
 main��50       �� 
IsSelected . .��51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
AccountBox=�6*   $��30��6<   $��25��6G   52      �� 53      -   5        $ orders��53      .��54        $ OrderCheckboxAscending=�6*   $��25��6H   $��25��6S   55      �� 56      -   5        $ reviews��56      .��57        $ 
RateReview=�6*   $��25��6<   $��25��6G   58      �� 59      -   5        $
 emps��59      .��5:        $ Worker=�6*   $��25��68   $��25��6C   5;      5<      �� 5=   
   $��2��6   $��0��5>      
������ $��Center=�5@      $��Center=�5B      ��5A      Z� ��5C      �� $	 BackCommand�.��5D        $ Logout=�6&   $��25��64   $��25��6?   5E      �� 5F   
   $��0��6   $��3��5G      $��1��5H      ._�5I      �� ��6   �� $	 Current�5J      5K      5L      