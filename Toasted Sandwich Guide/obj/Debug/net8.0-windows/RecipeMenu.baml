   M S B A M L   `   `   `  ����O  KToastedSandwichGuide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ToastedSandwichGuideToastedSandwichGuide  5   	   %    ToastedSandwichGuide.RecipeMenu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ToastedSandwichGuide     5   	     � Title$  Recipe��5   	   $	��914��6   $
��1474��6%   
�������.��5
      � .+�5   
   �� -   5         ��Name$ BackgroundImage��5      $
��Left=�6)   $	��914��6D   $��0,0,0,0q�6Q   $	��Top=�6b   $
��1474��6z   $��/Images/background.jpg��6�   �� 5   
   -   5        $ OpenBook��5      $
��Left=�6"   $	��392��6=   $��	34,10,0,0q�6J   $	��Top=�6]   $	��844��6u   $"��/Images/open-recipe-book.png��6�    J� OpacityMask 5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFE6E9ED��6#    � Offset$ 1Q�65   5      5      �� 5   
   -   5         ��Name$ ViewRecipesButton��5      $��View Recipes��6,   $
��Left=�6C   $��116,177,0,0q�6^   $	��Top=�6s   $	��236��6�   ���	#FFF5F7FA
���   �$��0q�6�   $��29��6�   $��Bahnschrift SemiBold)�6�   $��20(�6  �� 5   
   -   5        $ SearchRecipeButton��5      $��Search for a Recipe��6-   $
��Left=�6K   $��116,131,0,0q�6f   $	��Top=�6{   $	��236��6�   ���	#FFF5F7FA
���   �$��0q�6�   $��29��6�   $��Bahnschrift SemiBold)�6  $��20(�6'  �� 5   
   -   5        $ CreateRecipeButton��5      $��Create a Recipe��6-   $
��Left=�6G   $��
116,84,0,0q�6b   $	��Top=�6v   $	��236��6�   ���	#FFF5F7FA
���   �$��0q�6�   $��29��6�   $��Bahnschrift SemiBold)�6�   $��20(�6  �� 5   
   -   5        $ ScaleRecipeButton��5      $��Scale a Recipe��6,   $
��Left=�6E   $��116,217,0,0q�6`   $	��Top=�6u   $	��236��6�   ���	#FFF5F7FA
���   �$��0q�6�   $��37��6�   $��Bahnschrift SemiBold)�6�   $��20(�6  �� 5   
   -   5        $
 Exit��5      $
��Exit��6   $
��Left=�6.   $��116,259,0,0q�6I   $	��Top=�6^   $	��236��6v   ���	#FFF5F7FA
���   �$��0q�6�   $��43��6�   $��Bahnschrift SemiBold)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ RecipeNameLabel��5      $
��Name��6)   $
��Left=�68   $��
416,84,0,0q�6S   $	��Top=�6g   $��90��6   ���	#FFE6E9ED$��29��6�   $��Bahnschrift SemiBold)�6�   $��20(�6�   �� 5   
   -	   5        	 ��Name$	 recipeNameTextBox��5      $
��Left=�6-   $��
506,84,0,0q�6H   
 �� TextWrapping$

 Wrap=�6\   $	��Top=�6p   $	��140��6�   $��29��6�   ���	#FFE6E9ED$��1q�6�   $��Bahnschrift SemiBold)�6�   $��20(�6  �� 5   
   -
   5        $ NumberOfIngredients��5      $��Number of ingredients��6-   $
��Left=�6M   $��416,131,0,0q�6h   $	��Top=�6}   $��41��6�   ���	#FFE6E9ED$��Bahnschrift SemiBold)�6�   $��20(�6�   �� 5   
   -   5        $ 	 NumberOfIngredientsTextBox��5      $
��Left=�66   $��627,131,0,0q�6Q   $

 Wrap=�6f   $	��Top=�6z   $��37��6�   $��29��6�    J� RenderTransformOrigin$ -0.116,0.542&�6�   ���	#FFE6E9ED$��Bahnschrift SemiBold)�6�   $��20(�6  �� 5!   
   -   5        $ ScaleRecipeLabel��5!      $��Scale Factor��6*   $
��Left=�6A   $��416,131,0,0q�6\   $	��Top=�6q   $��41��6�   ���	#FFE6E9ED$��Bahnschrift SemiBold)�6�   $��20(�6�   �� 5#   
   -   5        $ NumberOfSteps��5#      $��Number of steps��6'   $
��Left=�6A   $��416,176,0,0q�6\   $	��Top=�6q   $��41��6�   ���	#FFE6E9ED$��Bahnschrift SemiBold)�6�   $��20(�6�   �� 5$   
   -   5        $	 NumberOfStepsTextBox��5$      $
��Left=�60   $��575,177,0,0q�6K   $

 Wrap=�6`   $	��Top=�6t   $��42��6�   $��29��6�   $ -0.116,0.542&�6�   ���	#FFE6E9ED$��Bahnschrift SemiBold)�6�   $��20(�6  �� 5&   
   -   5        $" AddNumIngredientsAndNumSteps��5&      $
��Left=�67   $��617,177,0,0q�6R   $	��Top=�6g   $��29��6   $��42��6�   ���	#FFE6E9ED���	#FFE6E9ED.��5'      �� -   5        $ AddImage��5'      $��Images/add.png��6&   6@   5(      � 5*   
   .+�5+      �� $
��Left=�6   $	��188��64   $	��Top=�6A   $
��1364��6Y   $��
60,569,0,0q�6f   .+�5,      �� -   5         ��Name$ ScrollDisplay��5,      $	��186��66   $
��1358��6C   $��Bahnschrift SemiBold)�6P   .��5-      �� -   5         ��Name$ 
pnlDisplay��5-   !   $	��328��65   $
��1233��6B   5.      5/      �� 51      -   5        $��SaveIngredientsAndSteps��51      $��1332,780,0,0q�64   ��6u   Z� .��52      �� $��Images/add.png��6   62   53      �� 55      -   5        $��Scale��55      $��620,295,801,566q�6"   ��6f   Z� .��56      �� $��Images/right.png��6   64   57      �� 59      -   5        $��SearchForRecipeNameButton��59      $
��Left=�66   $��
646,84,0,0q�6Q   $	��Top=�6e   $��29��6}   $��27��6�   .��5:      �� $��Images/magnifier.png��6   
 �����6L   5;      5<      � 5>   
   $��10,10,-10,-11q�6   .+�5?      �� $
��Left=�6   $	��276��64   $	��Top=�6A   $	��249��6Y   $��
408,39,0,0q�6e   .+�5@      �� -   5         ��Name$ RecipeDisplay��5@      $	��329��63   ���	#FFE6E9ED$	��278��6W   $��Bahnschrift SemiBold)�6c   �� 6�   .F�5A      �� -   5        $ pnlRecipeDisplay��5A   %   $	��328��6?   $
��1233��6L   5B      6+   5C      5D      5E      5F      