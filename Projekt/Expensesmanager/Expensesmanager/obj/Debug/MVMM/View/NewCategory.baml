   M S B A M L   `   `   `  ����J  FExpensesmanager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Expensesmanager.MVMM.ViewExpensesmanager.MVMM.View  5   	   +    %Expensesmanager.MVMM.View.NewCategory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Expensesmanager.MVMM.View     5   	   $	��500��5   .   .��5	      � .+�5
      �� $��Center=�6   $��0,40,0,0q�6-     � Cursor$
  Hand��6?   �� 5      $
�Neue��6   ���#8D6EEF$��28(�63   $
��Bold"�6A    �� 5      $�	Kategorie��6   ���#5529EE$��28(�68   $
��Bold"�6F   5      �� 5      $��Center=�6   $��Center=�6,   $	��300��6I   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   �� $��84��6   $��20��6   �� 5      $�Bezeichnung:��6   
�������$��14(�6A    �� 5      $�*��6   ���#d047636#   5      �� 5   
   -   5         ��Name$ categoryName��5      $��Right=�5         RoundedInputBoxTheme#��[  5      $	��200��5      
 � Tag$ Essen��5      5   	   �� 5$      $��0 20 0 0q�6   .+�5%   
   �� $��Beschreibung:��6   
�������6)   �� 5&   
   -   5        $ categorytxtDescription��5&       �� 	MaxLength$	 255��5'      $��60��5(       �� TextWrapping$
 Wrap=�5)       �� AcceptsReturn . ���#101721
�������#���   5.      �� 5/   
   -   5         ��Name$ categorycharCount��5/      
�������$��10(�6A   $��Right=�6O   $��0/255��50      51   	   �� 54      $��0 20 0 0q�6   .+�56   
   �� $ 
Horizontal=�6   .+�57      �� $	��100��6    $��20��6,   �� 58      $�Budget: ��6   
�������$��14(�6A    �� 59      $�*��6   ���#d047636'    �� 5:      $��Segoe MDL2 Assets)�6   $
� ��6=   $��12(�6N   ���#22c3f7 � Cursor$
 Hand��6q   	 � ToolTip	 5;      _� 5<        RoundedToolTipStyle#��[ 6&   .��5=   "   �� .+�5>   &   �� $��Positiv = Guthaben��60   �� 5?   &   $��Negativ = Spaaren��60   5@   #   5A      5C      �� 5E      -   5        $ 	txtBudget��5E      #��[  5F      $	��200��5G      $ 
+/- 220.00��5H      5I      �� 5M   
   $ 
Horizontal=�6   $��Center=�6.   $��0,20,0,0q�6K   .+�5N      �� -   5        $��Zurücksetzen��5N      $	��140��5O      $��35��5P      ���#8D6EEF
�������$��0q�5S      $��	10,0,10,0q�5T      $
  Hand��5U      ��5W      �� 5X      
 �� 
TargetType"
 ��6    .R�5Y      �� #��z��6   #��z��5Z   %    �� CornerRadius$ 10��5[   %   ._�5\      �� $��Center=�6%   $��Center=�5]   3   5^      5_      5a      �� 5b      -   5        $��Submit��5b      $	��140��5c      $��35��5d      ���#5529EE
�������$��0q�5g      $
  Hand��5h      $��	10,0,10,0q�5i      ��5k      �� 5l      "
 ��6    .R�5m      �� #��z��6   #��z��5n   %   $ 10��5o   %   ._�5p      �� $��Center=�6%   $��Center=�5q   3   5r      5s      5u      5v      �� 5y   
   -   5        $ categorylblError��5y      ���#d04763$��Center=�5{      $y�	Collapsed=�5|      $#��Nicht alle Felder ausgefüllt��5}      5~   	   5      5�      5�      