   M S B A M L   `   `   `  ����A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Diplom.FrameDiplom.Frame  5          Diplom.Frame.ABT   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Diplom.Frame     5        N� Title$	  ABT��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 DGA��5   S   $��30,35,30,10q�6   ���	#997D7676
���   �   
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+6V     5      $ ФИО��6C   $	 30* 6P    6%   �� *	Full_Name+6^     5      $ Паспорт��6G   $	 10* 6X    6%   �� *Passport_Data+6f     5      $ Дата рождения��6m   $	 10* 6�    6%   �� *Date_of_birth+ �� StringFormat$ {0:dd.}{0:MM.}{0:yyyy}��6�     5      $! Номер телефона��6F   $	 10* 6^    6%   �� *Phone_Number+6l     5      $% Место жительства��6L   $	 40* 6f    6%   �� *Place_of_Residence+6t     5      $  Специальность��6N   $	 15* 6e    6%   �� *Specialization1.Name+6s     5      $0 *Средний балл аттестата��6G   $	 10* 6g    6%   �� *Average_Score+6u   5      �� 5   
   -   5        	 ��Name$	 addBTN��5         BorderBrush#��[  6!   $��Добавить��6F   $
��Left=�6Y   $��	30,10,0,0q�6t   $	��Top=�6�   $��60��6�   6�   �� 5   
   -   5        $	 editBTN��5      #��[  6"   $��Изменить��6G   $
��Left=�6Z   $��	95,10,0,0q�6u   $	��Top=�6�   $��60��6�   6�   �� 5   
   -   5        $	 delBTN��5      #��[  6!   $��Удалить��6F   $
��Left=�6X   $��
160,10,0,0q�6s   $	��Top=�6�   $��60��6�   6�   �� 5   
   -   5        
 ��Name$
 	SearchTxb��5      $	��Top=�6A   $��
230,11,0,0q�6Y   $
��Left=�6m   $	��179��6�   5      5       