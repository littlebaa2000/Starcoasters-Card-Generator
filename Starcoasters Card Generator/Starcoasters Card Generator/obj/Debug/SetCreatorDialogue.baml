   M S B A M L   `   `   `  ����V  RStarcoasters Card Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Starcoasters_Card_GeneratorStarcoasters_Card_Generator  5   	   4    .Starcoasters_Card_Generator.SetCreatorDialogue   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Starcoasters_Card_Generator     5   	     � Title$  SetCreatorDialogue��5   	   $	��150��6$   $	��300��61    � 
ResizeMode$ NoResize=�6=   .��5	      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��3* �6   �� 5      $��3* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��1.5* �6   �� 5      �� 5      $��2* �6   �� 5      .+�5   
   �� -   5         ��Name$ TBX_SetName��5      $��1��6'   $��2��67   $��1��6K    �� 	IsEnabled .  �� TextAlignment$ Center=�6t   6�   �� 5   
   -   5         ��Name$ TBL_SetCodePreviewer��5      $��1��62   $��2��6B   $��
Set Code: ��6O    �� TextAlignment$ Right=�6a   �� 5   
   -   5        $ TBL_SetCode��5      $��2��6)   $��2��69   $
��xxxx��6F   $
 Left=�6R   �� 5   
   -   5        	 ��Name$	 BTN_MakeSet��5      $��1��6&   $��3��66   $��Create��6C   6T   �� 5   
   -   5        $	 
BTN_Cancel��5      $��2��6%   $��3��65   $��Cancel��6B   6S   5      5       