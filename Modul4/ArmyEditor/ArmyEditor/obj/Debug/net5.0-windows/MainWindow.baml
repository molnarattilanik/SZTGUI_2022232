   M S B A M L   `   `   `  ����E  AArmyEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ArmyEditor
ArmyEditor  5   	   7 clr-namespace:ArmyEditor.HelpersArmyEditor.Helpers  5   	   =#clr-namespace:ArmyEditor.ViewModelsArmyEditor.ViewModels  5   	       ArmyEditor.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ArmyEditor     5   	   4helpers clr-namespace:ArmyEditor.Helpers     5   	   3vms#clr-namespace:ArmyEditor.ViewModels     5   	     � Title$  Army Editor��5
   	   $	��450��6   $	��800��6*    � 	Resources 5      /  )ArmyEditor.Helpers.NumberToColorConverter   colorconvert��%   &	          5   
   6)   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $��Stretch=�6p   ��6"   �� *	Barrack+ �� SelectedItem 6B   �� *SelectedFromBarracks+��5      �� 5      .R�5      �� 
���   �$��1q�61   ._�5      �  5      �� 5   "   $��1* �63   �� 5   "   $��1* �63    � RowDefinitions 5      �� 5   "   $��1* �60   �� 5   "   $��1* �60   �� 5    "   $��1* �60   .+�5"      �� $��14(�6=   $
��Bold"�6K   ��6$   �� *Type+6K   �� 5#       �� ContentStringFormat$ 
Power: {0}��6>   $��1��6_   ��6$   �� *Power+6_   �� 5$      $ 
Speed: {0}��6>   $��1��6_   $��1��6l   ��6$   �� *Speed+6l   � 5%       � Maximum$ 10Q�6*   $��10q�67   $��2��6�   $��10��6�    � Value 6C   �� *Power+��6[   �� *Power+ �� 	Converter# [  6�   � 5&      $ 10Q�6*   $��10q�67   $��2��6�   $��10��6�   $��1��6�    6C   �� *Speed+��6[   �� *Speed+# [  6�   5'      5(      5)      5+      �� 5,   
   $��1��6   .+�5-      �� $��Center=�6   $��14(�68   $ 
Cost: {0}$��5.   -   ��6   �� *	AllCost+6-   �� 5/      $��Add To Army��6   $��10q�6P   $��10q�6\   ��6+   �� *AddToArmyCommand+6\   �� 50      $��Remove From Army��6   $��10q�6Z   $��10q�6f   ��60   �� *RemoveFromArmyCommand+6f   �� 51      $��Edit Trooper��6   $��10q�6S   $��10q�6_   ��6,   �� *EditTrooperCommand+6_   �� 52      $��Center=�6   $��14(�68   $ 
Power: {0}��53   .   ��6   �� *
AVGPower+6.   � 54      $��20��6   $ 10Q�6&   $��10q�55   B    6   �� *
AVGPower+	 �� Mode$	 OneWay=���56      �� *
AVGPower+$	 OneWay=�# [  �� 57      $��Center=�6   $��14(�68   $ 
Speed: {0}��58   .   ��6   �� *
AVGSpeed+6.   � 59      $��20��6   $ 10Q�6&   $��10q�5:   B    6   �� *
AVGSpeed+$	 OneWay=���5;      �� *
AVGSpeed+$	 OneWay=�# [  5<      �� 5=   
   $��2��6   $��16(�6i   ��6"   �� *Army+ 6?   �� *SelectedFromArmy+��5>      �� 5?      .R�5@      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5A      �� ��6    �� *Type+�� 5B      $ [{0}]��6:   ��6    �� *Power+6:   �� 5C      $ [{0}]��6:   ��6    �� *Speed+6:   5D      5E      5G      5H      5I      