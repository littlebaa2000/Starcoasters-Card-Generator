   M S B A M L   `   `   `  ����V  RStarcoasters Card Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Starcoasters_Card_GeneratorStarcoasters_Card_Generator  5   	   ,    &Starcoasters_Card_Generator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Starcoasters_Card_Generator     5   	   -   5          � Title$  Starcoasters Set Editor��5   	   $	��720��6)   $
��1280��66    � 
ResizeMode$ CanMinimize=�6C   .��5	      �  � ColumnDefinitions 5   
   �� 5      $��0.25* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��0.25* �6    � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $
��6.5* �6   �� 5      �� 5      $��0.25* �6   .+�5   
   �� $��1��6   $��1��6'   $��5��64   .��5      �� -   5         ��Name$ LIV_SetList��5       �� View 5      �� 5      .P�5       �� $��Set Name��6)    �� DisplayMemberBinding 6;   �� *	SetName+�� 5!      $��Set Code��6)    6;   �� *	SetCode+�� 5"      $��Number Of Cards��6)    6B   �� *
SetCount+5#      5%      5&      �� 5(   
   -   5         ��Name$ BTN_Edit��5(      $��1��6#   $��2��63   $��Edit Set��6@   6S   �� 5)   
   -   5        $ 
BTN_Delete��5)      $��2��6%   $��2��65   $��
Delete Set��6B   6W   �� 5*   
   -   5        $ 
BTN_Create��5*      $��4��6%   $��2��65   $��New Set��6B   6T   �� 5+   
   -   5        $ 
BTN_Battle��5+      $��3��6%   $��2��65   $��Battle Mode��6B   6X   �� 5,   
   -   5        $ BTN_DeckBuilder��5,      $��5��6*   $��2��6:   $��Deck Builder��6G   6^   5-      5.      