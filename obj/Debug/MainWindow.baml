   M S B A M L   `   `   `  ����>  :ASU, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ASUASU  5   	       ASU.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ASU     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $
��ABox��5
      $
��Left=�6   $��23��6:   $��
10,246,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $��Введите A��6n   $	��Top=�6   $	��307��6�   6�   �� 5   
   -   5        $
��BBox��5      $
��Left=�6   $��23��6:   $��
10,274,0,0q�6F   $
 Wrap=�6Z   $��Введите B��6n   $	��Top=�6   $	��307��6�   6�   �� 5   
   -   5        $
��CBox��5      $
��Left=�6   $��
10,302,0,0q�6:   $	��Top=�6N   $	��307��6f   6r   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGBox��5      $
��Left=�6"   $	��314��6=   $��
343,10,0,0q�6J   $	��Top=�6^   $	��439��6v      CanUserAddRows .    CanUserDeleteRows .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ f(x, y)��6A      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *	func_xy+6R     5      $ x��6;   $ * 6F   	 6%   �� *x+6F     5      $ y��6;   $ * 6F   	 6%   �� *y+6F   5      �� 5   
   -   5        $
��LBox��5      $
��Left=�6   $	��231��69   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��307��6q   ��5      �� 5      .R�5      � 
 � ColumnDefinitions
 5      �� 5      $	��120 �6/    z� SharedSizeGroup$ Column1��6;   �� 5      $	��150 �6/   $ Column2��6;   .+�5      �� $��0��6$   $��45��6P   $��16(�6\   ��64   �� *
TypeOfFunc+6\   �� 5      $��1��6$   $��45��6P   $��14(�6\   ��64   �� *
MeanOfFunc+6\   5      5      5!      �� 5"   
   -   5        $��CLabel��5"      $��Выберите C��6   $
��Left=�63   $��
10,300,0,0q�6N   $	��Top=�6b   $��29��6z   {�.   J� IsHitTestVisible .  
���   �6�   5%      5&      