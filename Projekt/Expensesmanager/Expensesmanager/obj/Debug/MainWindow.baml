   M S B A M L   `   `   `  ����J  FExpensesmanager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ExpensesmanagerExpensesmanager  5   	   O,clr-namespace:Expensesmanager.MVMM.ViewModelExpensesmanager.MVMM.ViewModel  5   	        Expensesmanager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Expensesmanager     5   	   B	viewModel,clr-namespace:Expensesmanager.MVMM.ViewModel     5   	     � Title$  Expenses Manager��5	   	   $	��600��6"   $
��1020��6/    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5      2  ,Expensesmanager.MVMM.ViewModel.MainViewModel  5   
   .��5      �� -   5        ���#272537 �� CornerRadius$ 20��5   "   ._�5   
   � .+�5      � $��30��6   $��
10,10,10,0q�6   $	��Top=�63   $��2��6K   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��15��5      $��15��6(   ���#28C940$��0q�5       � Cursor$
 Hand��61   $��5,0,0,0q�6?    � ToolTip$ Minimize��5      ��5      �� 5      	 �� 
TargetType"	 ��6.   .R�5   "   A� #��z��6*   5       5"      �� 5$      -   5        $��15��5$      $��15��6(   ���#FF5F56$��0q�5%      $
 Hand��61   $��5,0,0,0q�6?   $ Close��5&      ��5'      �� 5(      "	 ��6.   .R�5)   "   A� #��z��6*   5*      5,      5-      5.      �� 50      $��Center=�6   $��Center=�63   �� 51      $�Expenses��6   ���#8D6EEF$��22(�6;   $
��Bold"�6I    �� 52      $�Manager��6   ���#5529EE$��22(�6:   $
��Bold"�6H   53      � 54      $��1��6   $��0,0,5,0q�6    
 � RowDefinitions
 55      �� 56      $
��Auto �6$   �� 58      $��* �6$   �� 5:      $
��Auto �6$   .+�5?      �� $��0��6   .+�5@      	� -   5        $
��Home��5@   "   $��50��61   
�������$��17(�6P      MenuButtonTheme#��[  5A       d� 	IsChecked$
 TrueY�6G   ��5B      �� *HomeViewCommand+6B   	� 5D      -   5        $��Neue Transaktion��5D   "   $��50��6=   
�������$��17(�6\   #��[  5E      ��5F      �� *NewTransactionCommand+6H   	� 5H      -   5        $��Meine Transaktionen��5H   "   $��50��6@   
�������$��17(�6_   #��[  5I      ��5J      �� *MyTransactionsCommand+6H   	� 5L      -   5        $��Neue Kategorie��5L   "   $��50��6;   
�������$��17(�6Z   #��[  5M      ��5N      �� *NewCategoryCommand+6E   	� 5O      -   5        $��Meine Kategorien��5O   "   $��50��6=   
�������$��17(�6\   #��[  5P      ��5Q      �� *MyCategoriesCommand+6E   5R      �� 5S      $��2��6   .+�5U      �� -	   5        
������ $��0q�5U   6   .��5V      �� $	��100��6$   $��30��60   $��Center=�6<    �� TextAlignment$ Center=�6Y   �� 5W      $�Hilfe��6"   
�������$��20(�6B    �� 5X      $��Segoe MDL2 Assets)�6"   $
� ��6A   $��15(�6R   ���#22c3f7 � Cursor$
 Hand��6u    5Y      _� 5Z   "     RoundedToolTipStyle#��[ 6*   .��5[   &   �� $��Hilfefenster öffnen��60   5\   #   5^      5_      �� 5b      -
   5        $	��140��5b      $��35��6)   $
 Hand��65   $��10q�6C   .��5c      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5d      �� $��Images/logoutIcon.png��6$   $��20��6C   $��20��6N   $��0,0,5,0q�6Z   �� 5e      $��Logout��6(   
�������$��16(�6I   5f      ��5h      �� 5i       �� 
StartPoint$	 0,0&�62    �� EndPoint$	 1,0&�6C   .��5j   "   �  � Color$ #8D6EEF��6/    � Offset$	 0.0Q�6?   � 5k   "   $ #5529EE��6/   $	 1.0Q�6?   5l      ��5o      �� 5p      "	 ��6.   .R�5q   "   �� #��z��6)   $ 10��6S   ._�5r   &   �� $��Center=�67   $��Center=�6T   5s   #   5t      5v      5w      5z      �� 5|      $��1��6   $��1��6*   $��10,0,0,0q�6:   ��5}      �� *CurrentView+ � ColumnDefinitions 5�      �� 5�      $	��200 �6#   �� 5�      
 5�      �� 5�      $��50 �6    �� 5�      5�      5�      5�      