   M S B A M L   `   `   `  ����V  RStarcoasters Card Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Starcoasters_Card_GeneratorStarcoasters_Card_Generator  5   	   +    %Starcoasters_Card_Generator.SetViewer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Starcoasters_Card_Generator     5   	   -   5          � Title$  
Set Viewer��5   	   $	��720��6   $
��1280��6)    � 
ResizeMode$ CanMinimize=�66   .��5	      �  � ColumnDefinitions 5   
   �� 5      $��0.25* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��0.25* �6    � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $��4.75* �6   �� 5      �� 5      $��0.25* �6   .+�5   
   �� $��1��6   $��1��6'   $��9��64   .��5       �� -   5         ��Name$ LIV_CardList��5        �� View 5!      �� 5"      .P�5$      �� $��SetCode��6)    �� DisplayMemberBinding 6:   �� *CardSetCode+�� 5%      $��Name (Primary)��6)    6A   �� *
CardName+�� 5&      $��Name (Secondary)��6)    6C   �� *CardNameSecondary+�� 5'      $
��Cost��6)    67   �� *
CardCost+�� 5(      $��Species��6)    6:   �� *CardSpecies+�� 5)      $��HP��6)    65   �� *CardHP+�� 5*      $	��ATK��6)    66   �� *	CardATK+�� 5+      $	��DEF��6)    66   �� *	CardDEF+�� 5,      $��No. Abilities��6)    6@   �� *CardAbilityCount+5-      5/      50      �� 52   
   -   5         ��Name$ BTN_Edit��52      $��1��6#   $��2��63   $��2��6@   $��	Edit Card��6T   6h   �� 53   
   -   5        $ 
BTN_Delete��53      $��3��6%   $��2��65   $��
RemoveCard��6B   6W   �� 54   
   -   5        $ BTN_Add��54      $��9��6"   $��2��62   $��Add Card��6?   6R   �� 56   
   -   5        $ BTN_ExportBleed��56      $��5��6*   $��2��6:   $��Export Bleed Cards��6G   6d   �� 57   
   -   5        $ BTN_ExportCropped��57      $��6��6,   $��2��6<   $��Export Cropped Cards��6I   6h   �� 58   
   -   5        $ BTN_ExportVassal��58      $��7��6+   $��2��6;   $��Export Vassal Cards��6H   6f   5:      5;      