   M S B A M L   `   `   `  ����J  FExpensesmanager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Expensesmanager.CoreExpensesmanager.Core  5      0    *Expensesmanager.MVMM.View.MyCategoriesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Expensesmanager.Core     5      $	��500��5   3     � 	Resources  5      7   1Expensesmanager.Core.BooleanToVisibilityConverter    BooleanToVisibilityConverter1   +Expensesmanager.Core.AmountToColorConverter  AmountColorConverter��%:   &	        &	        5	   
   6-     5
   
   6'   5      .��5      �� .+�5   
   �� $��Center=�6   $��0,10,0,0q�61    � Cursor$
 Hand��6C   �� 5   
   $�Meine��6   ���#8D6EEF$��28(�60   $
��Bold"�6>    �� 5   
   $�
Kategorien��6   ���#5529EE$��28(�65   $
��Bold"�6C   5      � 5   
   .+�5      A� -   5        $��ProgressRing��5      $��70��5      $��70��5      ���#8D6EEF$��7��5       �� StrokeDashArray$ 0.1 2.5R�5       �� StrokeDashCap$ Round=�5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��10,20q�5      y�5      �� *	IsLoading+ �� 	Converter# [  z�5      �� 5      -   5        RotateTransform�� �� Angle$ 0Q�5   ?    � Triggers 5!      :� 5"       :� RoutedEvent$ Loaded��6#   .[�5#      �� .��5$      �� 	 g� RepeatBehavior$	 Forever��6)   .��5%   "   W� 
 �� 
TargetName$
 RotateTransform��62    �� TargetProperty$ Angle�5&   *    W� From$ 0X�5'   *   	 W� To$	 360X�63    g� Duration$ 0:0:2D�5(   *   5)      5*      5+      5-      5.      �� 5/   
   ��50      �� 51       �� 
TargetType" ��6   .�52      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 53      �� 54       �� Binding 6&   �� *	IsLoading+ �� Value	 False6D   .a�55      ��  � y�$ Visible=�6;   56      58      .+�5<      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     HeadersVisibility$ Column=�5>         CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     RowBackground �#161a25   AlternatingRowBackground �#1d2331
������ 
������    GridLinesVisibility$
 None=�5F      ���#E0E0E0$��16(�5H         ColumnHeaderHeight$ 50Q�5I         	RowHeight$ 40Q�5J      $��10q�5K      $   HorizontalScrollBarVisibility$
 Auto=�5L      "    VerticalScrollBarVisibility$
  Auto=�5M      $	��750��5N      $	��366��5O      !   
IsReadOnly! . ��5<      �� *
Categories+  5Q      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell" P� Property# P� Value)  #System.Windows.Controls.DataGridRow��%�  '        '  ^    '  f    �� 5R      "  6   .�5S      ��  � �� �#2A2A4067   �� 5T       � �� �#A68EFF67   �� 5U       � ��$ 22(�65   �� 5V       � ��$
 Bold"�67   �� 5W       � ��$ Center=�6G   �� 5X       � ��$ 10q�64   �� 5Y       � �� �#33368   �� 5Z       � ��$ 0,0,0,2q�6<   5[      �� 5]      "  6   .�5^      ��  � �� �#E0E0E067   �� 5_       � �� �#1E1E2E68   �� 5`       � ��$ Center=�6G   �� 5a       � ��$ 10q�64   �� 5b       � ��
 ���� 67    5c      P� 5d      " �@J�IsMouseOver# . . �5e   "   ��  � �� �#3A3A5A6?   �� 5f   "    � �� �#FFFFFF6?   5g      P� 5h      " �@ 
IsSelected# . . �5i   "   ��  � �� �#A68EFF6?   �� 5j   "    � �� �#1E1E2E6?   5k      5m      �� 5o      "  6   .�5p      ��  � ��
 ���� 67   �� 5q       � ��
 ���� 68    5r      P� 5s      " �@J�IsMouseOver# . . �5t   "   ��  � �� �#3A3A5A6?   5u      P� 5v      " �@ 
IsSelected# . . �5w   "   ��  � �� �#A68EFF6?   �� 5x   "    � �� �#1E1E2E6?   5y      5{      5|      $   Columns$ 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn%   Header$
% Name��6)   &   Width5	  /System.Windows.Controls.DataGridLengthConverter$& *	 6P   1
  +System.Windows.Controls.DataGridBoundColumn' 
  Binding' 67   �� *Name+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $% Budget��6-   $& *	 6=   (   CellTemplate( 5�      �� 5�      .R�5�   "   �� $��Center=�5�   ,   ��5�   ,   �� *Budget+) �� StringFormat$) {0} CHF��5�   ,   5�      5�        5�      $% Sum. Transaktionen��6)   $& *	 6i   ' 6E   �� *SumTransactions+6i   5�      �� 5�      $��	Editieren��6   $	��100��5�      $��35��5�      ���#8D6EEF
�������$��0q�5�      $
 Hand��5�      ��5�      �� 5�      * �� 
TargetType"* ��6&   .R�5�      �� #��z��6!   #��z��5�      + �� CornerRadius$+ 10��5�      ._�5�      �� $��Center=�6/   $��Center=�5�      5�      5�      5�      5�      5�      5�      