   M S B A M L   `   `   `  ����E  AAnalysData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AnalysData
AnalysData  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	       AnalysData.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AnalysData     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$  
MainWindow��5
   	   $	��718��6   $��1359.5��6)   .��5      � $��	0,0,0,-21q�6   $
��Left=�6   $
��1352��69    � ColumnDefinitions 5   
   �� 5      $
��449* �6   �� 5      $
��903* �6   .+�5   
   �� -   5        $��За день��5      $
��Left=�6#   $��
202,10,0,0q�6>   $	��Top=�6R   $	��110��6j   $��20��6�   �� 5   
   -   5         ��Name$ DataList��5         DataListView#���   6%   $��21,85,101,296q�6^    � 	Resources 5      "  System.Collections.ArrayList��%   &	          5      6    5       �� View 5      �� 5      .P�5      ��  �� Width$ 50��6I   $��ID��6T    �� DisplayMemberBinding 6%   �� *id+6T   �� 5      $
��Time��6K    6%   �� *date+6K   �� 5      $��	NumberOne��6P    6%   �� *	numberOne+6P   �� 5      $��	NumberTwo��6P    6%   �� *	numberTwo+6P   5      5      >  8System.Windows.Controls.DataVisualization.Charting.Chart  5    
   $��0,435,10,43q�6       Series. 5"      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5        $��	ChartPlot��5"   +   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValuePath$ x��5$   )   	   DependentValuePath$	 y��5%   )   5)        5+   
   $��10,10,10,382q�6    $��1��66   . 5-      E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  -   5        $��ChartOne��5-   -   $ x��5/   )   $	 y��50   )   54        55   
   $��10,346,10,43q�6    $��1��66   . 57        -   5        $��
CharDelta1��57   -   $ x2��59   )   $	 y��5:   )     5<      -   5        $��
CharDelta2��5<   -   $ x2��5>   )   $	 y2��5?   )   5C      �� 5D   
   -   5        $��За час��5D      $
��Left=�6"   $��	73,10,0,0q�6=   $	��Top=�6P   $	��110��6h   $��20��6�   �� 5E   
   -   5        
 ��Name$
 	inputData��5E      $��6��6   $
��Left=�6.   $��23��6I   $��
174,35,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6~   $	��138��6�   �� 5F   
   -	   5        $
 	inputHour��5F      $��22��6   $
��Left=�6/   $��23��6J   $��
106,35,0,0q�6V   $
 Wrap=�6j   $	��Top=�6   $��50��6�   �� 5G   
   -
   5        $��Частоты1��5G      $
��Left=�6$   $��20��6?   $��
331,10,0,0q�6K   $	��Top=�6_   $��67��6w   6�   �� 5H   
   -   5        $��Частоты2��5H      $
��Left=�6$   $��20��6?   $��
331,35,0,0q�6K   $	��Top=�6_   $��67��6w   6�   �� 5I   
   -   5        $��Заполнить��5I      $
��Left=�6%   $��
268,60,0,0q�6@   $	��Top=�6T   $��75��6l   $��20��6�   �� 5J   
   $��Start��6   $
��Left=�6    $��
364,85,0,0q�6;   $	��Top=�6O   �� 5K   
   -   5        $
 viewstartDay��5K      $��2��6   $
��Left=�61   $��23��6L   $��353,113,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $��50��6�   �� 5L   
   -   5        $
 viewstartHour��5L      $��3��6   $
��Left=�62   $��23��6M   $��353,139,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $��50��6�   �� 5M   
   -   5        $
 viewstartMinute��5M      $��25��6   $
��Left=�65   $��23��6P   $��353,166,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $��50��6�   �� 5O   
   $	��End��6   $
��Left=�6   $��364,189,0,0q�69   $	��Top=�6N   �� 5P   
   -   5        $
 
viewendDay��5P      $��2��6   $
��Left=�6/   $��23��6J   $��353,216,0,0q�6V   $
 Wrap=�6k   $	��Top=�6�   $��50��6�   �� 5Q   
   -   5        $
 viewendHour��5Q      $��3��6   $
��Left=�60   $��23��6K   $��353,242,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $��50��6�   �� 5R   
   -   5        $
 viewendMinute��5R      $��26��6   $
��Left=�63   $��23��6N   $��353,269,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��50��6�   �� 5S   
   $	��Day��6   $
��Left=�6   $��23��69   $��408,108,0,0q�6E   $	��Top=�6Z   $��22��6r   �� 5T   
   $
��Hour��6   $
��Left=�6   $��27��6:   $��408,138,0,0q�6F   $	��Top=�6[   $��22��6s   �� 5U   
   $	��Min��6   $
��Left=�6   $��25��69   $��408,166,0,0q�6E   $	��Top=�6Z   $��22��6r   �� 5V   
   -   5        $��Построить��5V      $
��Left=�6%   $��
350,60,0,0q�6@   $	��Top=�6T   $��75��6l   $��20��6�   5^      5`      