   M S B A M L   `   `   `  ����F  BUsuario.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Usuario.GUIUsuario.GUI  5   	       Usuario.GUI.Estadisticos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Usuario.GUI     5   	   R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  Usuarios��5	   	   $	��600��6   $
��1000��6'   ��5
      �� 5   
   .��5      �� ��5   
   �� 5       �� ImageSource$ Imagenes/AD0972_F01.jpg��6   .@�5   
   �� $��Estadisticos��6   $	��100��6(   .��5      �  � ColumnDefinitions 5      �� 5      $
��121* �6'   �� 5      $
��372* �6'    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��452* �6$   .+�5      � $��0��6   $��0��6,   $��2��69   $��15q�6N   ��5      �� 5        �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5!      �  � Color$ Black��6+    � Offset$ 0Q�69   � 5"      $ 	#FF0E1F21��6+   $ 1Q�6=   5#      .+�5%      ��  �� Orientation$ 
Horizontal=�6!   .+�5&      �� 
�������$��30��63   $	��180��6?   $��14(�6K   $��5q�6Y   .��6d   Fecha de Torneo6u   (  "System.Windows.Controls.DatePicker  5'      -   5        	  Name$	 clcFechaEstadisticos��5'   =   $��35��6%   $	��220��61   6]   5(      �� 5)      $ 
Horizontal=�6!   .+�5*      �� 
�������$��30��63   $	��180��6?   $��14(�6K   $��5q�6Y   .��6d   	Deporte6m   �� 5+      -   5        
 ��Name$
 cmbEstadisticosEquipos��5+   ;   $��25��6#   $	��220��6/   6]   5,      �� 5-      -   5         ��Name$ btnCalcularEstadisticos��5-   @   $��95��6   $��4q�6(   $��35��64   ���	#FF3A3333���	#FFFDFDFD.��5.      �� $ 
Horizontal=�6%   .+�5/      �� ���	#FFF5ECEC$
��Bold"�6;   $��14(�6M   .��6[   
Calcular6e   51      52      53      &   System.Windows.Controls.DataGrid  54      -   5          Name$ dtgTablaEstadisticos��54   E   $��0��6   $��1��6,   $��20q�69   6e     OxyPlot.Wpf.PlotView  55      -   5          Name$ Grafica��55      $��1��60   $��1��6@   $��20q�6M   56      57      5>      5?      