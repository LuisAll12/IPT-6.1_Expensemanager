   M S B A M L   `   `   `  ����J  FExpensesmanager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Expensesmanager.CoreExpensesmanager.Core  5      2    ,Expensesmanager.MVMM.View.MyTransactionsView   5      ,local"clr-namespace:Expensesmanager.Core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��500��5   3     � Cursor$
  Hand��6@    � 	Resources 5      7   1Expensesmanager.Core.BooleanToVisibilityConverter    BooleanToVisibilityConverter1   +Expensesmanager.Core.AmountToColorConverter  AmountColorConverter��%:   &	        &	        5	   
   6-     5
   
   6'   5      .��5      �� .+�5   
   �� $��Center=�6   $��0,10,0,0q�61   $
  Hand��6C   �� 5      $�Meine��6   ���#8D6EEF$��28(�64   $
��Bold"�6B    �� 5      $�Transaktionen��6   ���#5529EE$��28(�6<   $
��Bold"�6J   5      � 5   
   .+�5      A� -   5        $��ProgressRing��5      $��70��5      $��70��5      ���#8D6EEF$��7��5       �� StrokeDashArray$ 0.1 2.5R�5       �� StrokeDashCap$ Round=�5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��10,20q�5      y�5      �� *	IsLoading+ �� 	Converter# [  z�5      �� 5      -   5        RotateTransform�� �� Angle$ 0Q�5   ?    � Triggers 5!      :� 5"       :� RoutedEvent$ Loaded��6#   .[�5#      �� .��5$      �� 	 g� RepeatBehavior$	 Forever��6)   .��5%   "   W� 
 �� 
TargetName$
 RotateTransform��62    �� TargetProperty$ Angle�5&   .    W� From$ 0X�5'   .   	 W� To$	 360X�67    g� Duration$ 0:0:2D�5(   .   5)      5*      5+      5-      5.      �� 5/   
   ��50      �� 51       �� 
TargetType" ��6   .�52      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 53      �� 54       �� Binding 6&   �� *	IsLoading+ �� Value	 False6D   .a�55      ��  � y�$ Visible=�6;   56      58      .+�5<      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     HeadersVisibility$ Column=�5?         CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     RowBackground �#161a25   AlternatingRowBackground �#1d2331
������ 
������    GridLinesVisibility$
 None=�5G      ���#E0E0E0$��16(�5I         ColumnHeaderHeight$ 50Q�5J         	RowHeight$ 40Q�5K      $��10q�5L      $   HorizontalScrollBarVisibility$
 Auto=�5M      "    VerticalScrollBarVisibility$
  Auto=�5N      $	��750��5O      $	��366��5P      !   
IsReadOnly! . ��5<      �� *	Records+" �� SelectedItem" 5=      �� *SelectedRecord+# �� Mode$# TwoWay=� 5R      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell$ P� Property% P� Value)  #System.Windows.Controls.DataGridRow��%�  '        '  ^    '  f    �� 5S      "  6   .�5T      ��  � �� �#2A2A4067   �� 5U       � �� �#A68EFF67   �� 5V       � ��$ 22(�65   �� 5W       � ��$
 Bold"�67   �� 5X       � ��$ Center=�6G   �� 5Y       � ��$ 10q�64   �� 5Z       � �� �#33368   �� 5[       � ��$ 0,0,0,2q�6<   5\      �� 5^      "  6   .�5_      ��  � �� �#E0E0E067   �� 5`       � �� �#1E1E2E68   �� 5a       � ��$ Center=�6G   �� 5b       � ��$ 10q�64   �� 5c       � ��
 ���� 67    5d      P� 5e      $ �@J�IsMouseOver% . . �5f   "   ��  � �� �#3A3A5A6?   �� 5g   "    � �� �#FFFFFF6?   5h      P� 5i      $ �@ 
IsSelected% . . �5j   "   ��  � �� �#A68EFF6?   �� 5k   "    � �� �#1E1E2E6?   5l      5n      �� 5p      "  6   .�5q      ��  � ��
 ���� 67   �� 5r       � ��
 ���� 68    5s      P� 5t      $ �@J�IsMouseOver% . . �5u   "   ��  � �� �#3A3A5A6?   5v      P� 5w      $ �@ 
IsSelected% . . �5x   "   ��  � �� �#A68EFF6?   �� 5y   "    � �� �#1E1E2E6?   5z      5|      5}      &   Columns& 5      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn'   Header$' Amount��6-   (   Width5	  /System.Windows.Controls.DataGridLengthConverter$( *	 6=   )   CellTemplate) 5�      �� 5�      .R�5�   "   �� $��Center=�5�       ��5�   ,   �� *Amount+* �� StringFormat$* {0} CHF����5�       �� *Amount+# [ 5�       5�      5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      $
' Date��6)   $( *	 6o   1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ 67   �� *Date+$* {0:dd.MM.yyyy}��6o   
  5�      $' Category��6)   $( *	 6X   + 6;   �� *
Category+6X   5�      �� 5�      , �� Orientation$, 
Horizontal=�6   $��Center=�62   $��0,20,0,0q�6O   .+�5�      �� $��	Editieren��6   $	��100��5�      $��35��5�      ���#8D6EEF
�������$��0q�5�      $
  Hand��5�      ��5�      �� *EditCommand+��5�      �� 5�      - �� 
TargetType"- ��6*   .R�5�      �� #��z��6%   #��z��5�      . �� CornerRadius$. 10��5�      ._�5�   "   �� $��Center=�63   $��Center=�5�   '   5�      5�      5�      �� 5�      $��Löschen��6   $	��100��5�      $��35��5�      ���#8D6EEF
�������$��0q�5�      $
  Hand��5�      ��5�      �� *DeleteCommand+��5�      �� 5�      "- ��6*   .R�5�      �� #��z��6%   #��z��5�   %   $. 10��5�   %   ._�5�   "   �� $��Center=�63   $��Center=�5�      5�      5�      5�      5�      5�      5�      5�      