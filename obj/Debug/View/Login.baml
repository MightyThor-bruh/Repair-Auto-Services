   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutoService.ViewAutoService.View  5   	       AutoService.View.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:AutoService.View  5   	     � Title$  Вход��5	   	   $	��450��6   $	��400��6#   
������� � WindowStartupLocation$ CenterScreen=�6B    � WindowStyle$ SingleBorderWindow=�6g    � 
ResizeMode$ CanMinimize=�6�   $��Roboto)�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5   
   �� $��..\Images\logo.png��6   $	��140��6,   $	��140��68   �� 5   
   $��1��6    �� Orientation$ Vertical=�5      $	��Top=�5      $��Center=�5      .+�5      �� $ 
Horizontal=�6   $��0,0,0,5q�62   .+�5      �� $��Email��6   $��16(�6)   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ Required=�6*   $��5��6:   $��5��6D   
����  �6O   5      �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ mail@website.com��6   $	��200��5      $��16(�5      $��0,0,0,20q�5      ��5      ��  �� Path$ Login.Login��� 5      $ 
Horizontal=�6   $��0,0,0,5q�62   .+�5      �� $��Пароль��6   $��16(�6*     5      $ Required=�6*   $��5��6:   $��5��6D   
����  �6O   5       G� 5!      -   5        	 G�Name$	 password��5!      $  мин. 8 символов��6,   $	��200��6]   $��16(�6i   �� 5"      $��
Войти��6   $��	0,30,0,10q�5#         RoundedButton#��[  5$      $	��200��5%      $��14(�5&      ���#4361ee
�������$��40��5)      ��5*      �� $ LoginCommand���5+      �� 
 �� ElementName$
 password���� 5,      $,��&Не зарегистрированы?��6   $��14(�64   $��Center=�5-      $��Center=�5.      �� 5/      $#��Создать аккаунт��6   $��14(�50      
������ ���#4361ee��52      Z� ��54      �� $ CreateAccCommand�55      56      57      