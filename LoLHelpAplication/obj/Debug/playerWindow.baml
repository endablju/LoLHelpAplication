   M S B A M L   `   `   `  ����L  HLoLHelpAplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:LoLHelpAplication.ViewLoLHelpAplication.View  5   	   $    LoLHelpAplication.playerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6views$clr-namespace:LoLHelpAplication.View     5   	     � Title$  Player��5   	   $	��600��6   $
��1024��6%   .��5      � .+�5	   
   �� -   5        $��PlayerLabel��5	   �   $��Label��6   $
��Left=�6    $��	40,10,0,0q�6;   $	��Top=�6N   $	��298��6f   $��25(�6r   6�   �� 5
   
   $
��Left=�6.   $��	40,71,0,0q�6I   $	��Top=�6\   $	��263��6t   {�.  ��6   �� *	IdTextBox+6�   ]� 5   
   $��0��6   $��	0,10,24,0q�6$   ��.  $��2��6N   .+�5      �� $	��969��6   $��	0,38,0,10q�6%   .@�5      �� $��18(�6   $��Current Game��6(   $��219,0,-223,-2q�6>   .��5      � $��10,6,-10,-6q�6   .+�5      �� $��CurrentGame��6!   $
��Left=�6W   $��39,0,0,0q�6r   $	��Top=�6�   $	��118��6�   ��67   �� *CurrentGame+6�   (   "LoLHelpAplication.View.CurrentView  5      $	��Top=�6M   $
��Left=�6b   $	��873��6}   $��
39,36,0,36q�6�   $	��403��6�    � DataContext 6,   �� *
GameInfo+6�   5      5      �� 5      $��18(�6   $��History��6(   $��289,0,-293,-2q�69   .��5      � .+�5      �� $��0��6"   $��0��6/   $
��Left=�6�   $��
10,13,0,60q�6�   $	��281��6�   ��6?   �� *	MatchList+ �� SelectedItem 6a   �� *SelectedMatch+��5      �� 5   "    �� DataType$ ViewModel:MatchViewModel��6/   .R�5   &   �� ._�5   *   �  � ColumnDefinitions 5   .   �� 5   2   $��50 �6C   �� 5   2   $
��Auto �6C    z� SharedSizeGroup$ Names��6P   �� 5    2   $��20 �6C   .+�5$   .   �� $��1��68   ��6H   �� *ChampionString+5&   +   5'   '   5(   #   5*      ]� 5+      $��0��6$   $��1��61   $��5q�6A   ��.  .+�5,      (   "LoLHelpAplication.View.HistoryView  $	��Top=�6V   $
��Left=�6k   $	��584��6�   $��	328,0,0,0q�6�   $	��403��6�    60   �� *SelectedMatch+6�   5.      �� 5/      $��History��6!   $
��Left=�6O   $��310,422,0,0q�6j   $	��Top=�6   $��75��6�   ��63   �� *	History+6�   50      51      55      56      58      59      