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
��Bold"�6H   53      �� 54      $��1��6   .+�55      	� -   5        $
��Home��55      $��50��6-   
�������$��17(�6L      MenuButtonTheme#��[  56      
 d� 	IsChecked$

 TrueY�6G   ��57      �� *HomeViewCommand+6B   	� 59      -   5        $��New Transaction��59      $��50��68   
�������$��17(�6W   #��[  5:      ��5;      �� *NewTransactionCommand+6H   	� 5=      -   5        $��My Transactions��5=      $��50��68   
�������$��17(�6W   #��[  5>      ��5?      �� *MyTransactionsCommand+6H   5A   	   �� 5C      $��1��6   $��1��6*   $��10,0,0,0q�6:   ��5D      �� *CurrentView+ � ColumnDefinitions 5H      �� 5I      $	��200 �6#   �� 5J       � RowDefinitions 5L      �� 5M      $��50 �6    �� 5N      5Q      5R      5S      