   M S B A M L   `   `   `  ����D  @GameOfNim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GameOfNim	GameOfNim  5   	       GameOfNim.SetupWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GameOfNim     5   	     � Title$  G A M E   O F   N I M��5   	   $	��325��6'   $	��300��64    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $��3* �6   .+�5   
   �� $��0��6   $��N I M��5      $��Courier New)�5      $��Center=�5      $��Center=�5      $��50(�5      $
��Bold"�5      �� 5   
   $��1��6   $��Center=�6"   .+�5      �� $��G A M E M O D E��6   $
��Bold"�5      $��14(�5      	� 5      -   5         	�Name$	 PVP��5!       	� 	GroupName$ GameMode��5      $��PLAYER VS PLAYER��5      $��Courier New)�5      $��3q�5       5!      	� 5"      -   5        $	 PVC��5&      $ GameMode��5"      $��PLAYER VS COMPUTER��5#      $��Courier New)�5$      $��3q�5%      5&      �� 5'      $��D I F F I C U L T Y��6   $
��Bold"�5(      $��14(�5)      	� 5.      -   5        $
 Easy��52      $ 
Difficulty��5.      $��EASY DIFFICULTY��5/      $��Courier New)�50      $��3q�51      52      	� 53      -   5        $ Medium��57      $ 
Difficulty��53      $��MEDIUM DIFFICULTY��54      $��Courier New)�55      $��3q�56      57      	� 58      -   5        $
 Hard��5<      $ 
Difficulty��58      $��HARD DIFFICULTY��59      $��Courier New)�5:      $��3q�5;      5<      �� 5>      -   5         ��Name$ 
PlayButton��5D      $��5q�5>      $��P L A Y��5?      $��Courier New)�5@      $��50��5A      $	��200��5B      $��20(�5C      5E      5F      5G      5H      