   M S B A M L   `   `   `  ����A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Diplom.FrameDiplom.Frame  5          Diplom.Frame.Lists   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Diplom.Frame     5        N� Title$  Lists��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 Grup��5   R   $��
15,37,15,8q�6   ���	#997D7676
���   �   
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$	 30* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+6V     5      $ ФИО��6C   $	 40* 6P    6%   �� *	Full_Name+6^     5      $0 *Средний балл аттестата��6G   $	 40* 6g    6%   �� *Average_Score+6u     5      $ Статус��6@   $	 40* 6P    6%   �� *Status+6^   5      �� 5   
   -   5         ��Name$	 LGR��5      	 �� DisplayMemberPath$
	 Name��6    $
��Left=�69   $��
185,10,0,0q�6T   $	��Top=�6h   $	��200��6�   6�   �� 5   
   -   5        
 ��Name$
 confBTN��5         BorderBrush#��[  6"   $��Подтвердить��6G   $
��Left=�6]   $��	15,10,0,0q�6x   $	��Top=�6�   $��80��6�   6�   �� 5   
   -   5        $
 rejBTN��5      #��[  6!   $��Отклонить��6F   $
��Left=�6Z   $��
100,10,0,0q�6u   $	��Top=�6�   $��80��6�   6�   �� 5   
   -   5         ��Name$ remCB��5      $)��#Скрыть зачисленных��6"   $
��Left=�6?   $��
400,12,0,0q�6Z   $	��Top=�6n   {�.  6�   �� 5   
   -   5         ��Name$ 	SearchTxb��5      $	��Top=�6A   $��
561,12,0,0q�6Y   $
��Left=�6m   $	��179��6�   5      5      