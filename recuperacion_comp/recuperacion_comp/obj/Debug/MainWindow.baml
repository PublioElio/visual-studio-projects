   M S B A M L   `   `   `  ����L  Hrecuperacion_comp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:recuperacion_comp.componentesrecuperacion_comp.componentes  5      5clr-namespace:recuperacion_comprecuperacion_comp  5      "    recuperacion_comp.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Ccomponentes+clr-namespace:recuperacion_comp.componentes     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:recuperacion_comp     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5	      $
��1000��5
      $	��800��5       � 
ResizeMode$ NoResize=�5      .��5      � ��5   
   �� 5       �� ImageSource$ /campo_futbol.png��6   .+�5   
   ,   &recuperacion_comp.componentes.marcador  -   5          Name$ Marcador��5      $��234,468,0,0q�5      $
��Left=�5      $	��Top=�5         GolesEquipo1$ 5��5         GolesEquipo2$ 3��5         	TeamName1$ Málaga��5         	TeamName2$ Madrid��5         MinutosActuales$ 92��6    	   AddedMinunes$	 8��65   �� 5   
   -   5        
 ��Name$
 LabelGolesEquipo1��5      $��
87,113,0,0q�5      $
��Left=�5      $	��Top=�5       $��Goles Equipo 1:��5!      $��14(�5"      $
��Bold"�5#      �� 5$   
   -   5        $
 LabelGolesEquipo2��5%      $��535,113,0,0q�5&      $
��Left=�5'      $	��Top=�5(      $��Goles Equipo 2:��5)      $��14(�5*      $
��Bold"�5+      �� 5,   
   -   5         ��Name$ SliderGolesEquipo1��5-      $	��271��5.      $��204,118,0,0q�5/      $
��Left=�50      $	��Top=�51       � Maximum$ 9Q�52       � Minimum$ 0Q�53      54      �� 55   
   -   5        $ SliderGolesEquipo2��56      $	��271��57      $��652,118,0,0q�58      $
��Left=�59      $	��Top=�5:      $ 9Q�5;      $ 0Q�5<      5=      �� 5>   
   -   5         ��Name$ ComboBoxTiempoPartido��5?      $	��120��5@      $��355,188,0,0q�5A      $
��Left=�5B      $	��Top=�5C      .@�5E      �� -   5         ��Name$ primer_tiempo��5E      $��Primer tiempo��62   �� 5F      -   5        $ segundo_tiempo��5F      $��Segundo tiempo��63   5G      �� 5H   
   -	   5        $
 LabelTiempoPartido��5I      $��234,185,0,0q�5J      $
��Left=�5K      $	��Top=�5L      $��Tiempo partido:��5M      $��14(�5N      $
��Bold"�5O      �� 5Q   
   -
   5         ��Name$ TextBoxAnyadirTiempo��5R      $��32��5S      $��679,191,0,0q�5T      $
��Left=�5U      $	��Top=�5V       �� 
IsReadOnly . $��0��5X       �� TextWrapping$
 Wrap=�5Y      �� 5Z   
   -   5        $
 LabelIncrementarMinutos��5[      $��530,184,0,0q�5\      $
��Left=�5]      $	��Top=�5^      $��Minutos extra:��5_      $��14(�5`      $
��Bold"�5a      �� 5c   
   -   5         ��Name$ RepeatBtnAdd��5d      $��29��5e      $��24��5f      $��716,188,0,0q�5g      $
��Left=�5h      $	��Top=�5i      $��+��5k       �� Delay$	 500��5l       �� Interval$	 100��5m      �� 5o   
   -   5        $ RepeatBtnDecrementar��5p      $��30��5q      $��24��5r      $��643,188,0,0q�5s      $
��Left=�5t      $	��Top=�5u      $��-��5v      $	 500��5w      $	 100��5x      6   5z      5{      