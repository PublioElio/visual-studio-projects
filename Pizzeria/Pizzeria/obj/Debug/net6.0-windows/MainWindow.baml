   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��805��6)    J� RenderTransformOrigin$ 0.5,0.5&�65    � 	Resources 5
         BotonRedondeado �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� EndPoint
 �� 
StartPoint � Color � Offset J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Color   Opacity��%�  &	        �� 5   
   " ��6(   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   ���	#FF9E0D0D$��1q�6K   ��5      �� 5   "   $	 0.5,1&�66   $
 0.5,0&�6G   .��5   &   � $ 	#FFF7C0B3��63   � 5   &   $ White��63   $ 1Q�6A   5   #    5        5   "   $ 5Q�63   $ Black��6C   $	 0.5Q�6Q   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5       � -   5         �Name$ ventanaPrincipal��5       .+�5!   
   �� -   5         ��Name$ gbMasa��5!      $��Tipo de masa��6#   $��413,35,201,303q�69   ���	#FFD02626.��5"      �� -   5         ��Name$ 
spTipoMasa��5"      $��	10,0,10,0q�6-   $��48��6@   .+�5#      	� -   5         	�Name$ rbQueso��5#      $��Masa rellena de queso��6/   
���   �6b   	� 5$      -   5        $ rbFina��5$      $��	Masa fina��6.   6B   	� 5%      -   5        $ 	rbClasica��5%      $��Masa clásica��61   6H   5&      5'      �� 5(   
   -   5        $ gbBebida��5(      $��Bebida��6%   $��230,35,438,276q�65   ���	#FFD02626.��5)      �� -   5        $ 	spBebidas��5)      $��	10,0,10,0q�6,   $��61��6?   .+�5*      	� -	   5        $ rbCola��5*      $��	Coca-Cola��6.    d� 	IsChecked$ FalseY�6[   	� 5+      -
   5        $ rb7up��5+      $	��7up��6-   6;   	� 5,      -   5        $ rbFanta��5,      $��Fanta Naranja��6/   6G   	� 5-      -   5        $ rbAgua��5-      $
��Agua��6.   6=   5.      5/      �� 50   
   -   5        $ gbIngredientes��50      $��Ingredientes��6+   $��230,173,438,60q�6A   ���	#FFD02626.��51      �� -   5        $ spIngredientes��51      $��	10,0,10,0q�61   $	��153��6D   .+�52      �� -   5         ��Name$ cbMozzarella��52      $��
Mozzarella��61   �� 53      -   5        $ cbJamon��53      $��Jamón��6,   �� 54      -   5        $ cbChamp��54      $��Champiñones��6,   �� 55      -   5        $ cbSalchichas��55      $��
Salchichas��61   �� 56      -   5        $ cbPimientos��56      $��	Pimientos��60   �� 57      -   5        $ cbAtun��57      $��Atún��6+   �� 58      -   5        $ cbAceitunas��58      $��	Aceitunas��60   �� 59      -   5        $ cbPepperoni��59      $��	Pepperoni��60   �� 5:      -   5        $ cbPollo��5:      $��Pollo��6,   �� 5;      -   5        $ cbBacon��5;      $��Bacon��6,   5<      5=      �� 5>   
   -   5         ��Name$ 	miListado��5>      $��413,201,201,95q�6P   ���	#FFECA6916h   �� 5?   
   -   5         ��Name$ 	labelInfo��5?      $��Información del pedido:��6#   $
��Left=�6E   $��27��6`   $��413,169,0,0q�6l   $	��Top=�6�   $	��152��6�   $��Segoe UI Semibold)�6�   ���	#FFD026266�   �� 5@   
   -   5         ��Name$ pedir��5@      #��[  6    $��PEDIR��6I   $
��Left=�6Y   $��430,369,0,0q�6t   $	��Top=�6�   $��
Nirmala UI)�6�   $��70��6�   ���	#FFB31616$��29��6�   �� 5A   
   -   5        $ reset��5A      #��[  6    $��RESET��6I   $
��Left=�6Y   $��533,369,0,0q�6t   $	��Top=�6�   $��
Nirmala UI)�6�   $��71��6�   ���	#FFB31616$��29��6�   �� 5B   
   -   5         ��Name$ mario��5B      $
��Left=�6   $	��264��6:   $��	565,0,0,0q�6G   $	��Top=�6Z   $	��233��6r   $
��Fill=�6~   ��5C      �� 5D       �� 	UriSource$ 
/mario.png?�6   5F      �� 5G   
   -   5        $ 	imgBebida��5G      $
��Left=�6#   $	��124��6>   $��	56,46,0,0q�6K   $	��Top=�6^   $	��121��6v   $
��Fill=�6�   �� 5H   
   -   5        $ imgMasa��5H      $
��Left=�6!   $��82��6<   $��
45,233,0,0q�6H   $	��Top=�6\   $	��152��6t   $
��Fill=�6�   5I      5J      