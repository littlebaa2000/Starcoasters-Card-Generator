   M S B A M L   `   `   `  ����V  RStarcoasters Card Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Starcoasters_Card_GeneratorStarcoasters_Card_Generator  5   	   -    'Starcoasters_Card_Generator.DeckBuilder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Starcoasters_Card_Generator     5   	   -   5          � Title$  DeckBuilder��5   	   $	��450��6   $	��800��6*   .��5	      � $��10,10,10,10q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   $��0��6$   $��2��61   $��	Your Deck��6E    �� TextAlignment$ Center=�6V   �� 5   
   $��2��6   $��0��6$   $��2��61   $��
Card Set's��6E   $ Center=�6W   �� 5   
   $��4��6   $��0��6$   $��2��61   $��Cards in Selected Set��6E   $ Center=�6b   �� 5   
   $��0��6   $��1��6'   $��2��64   .��5      �� -   5         ��Name$ LIV_Deck��5       �� View 5      �� 5      .P�5      �� $
��Name��6)    �� DisplayMemberBinding 67   �� *
CardName+�� 5      $
��Cost��6)    67   �� *
CardCost+�� 5       $��Species��6)    6:   �� *CardSpecies+5!      5#      5$      �� 5%   
   $��2��6   $��1��6'   $��2��64   .��5&      �� -   5        $ LIV_Sets��5&       5'      �� 5(      .P�5)      �� $��Set Name��6)    6;   �� *	SetName+�� 5*      $��Set Code��6)    6;   �� *	SetCode+�� 5+      $��Number Of Cards��6)    6B   �� *
SetCount+5,      5.      5/      �� 50   
   $��4��6   $��1��6'   $��2��64   .��51      �� -   5        $ 	LIV_Cards��51       52      �� 53      .P�54      �� $
��Name��6)    67   �� *
CardName+�� 55      $
��Cost��6)    67   �� *
CardCost+�� 56      $��Species��6)    6:   �� *CardSpecies+57      59      5:      �� 5;   
   -   5         ��Name$ BTN_Save��5;   B   $��0��6   $��2��6!   $��	Save Deck��6.   6B   �� 5<   
   -   5        $ BTN_add��5<   A   $��1��6   $��2��6!   $��Add Card��6.   6R   �� 5=   
   -   5        $ 
BTN_remove��5=   D   $��2��6   $��2��6!   $��Remove Card��6.   6X   5>      5?      