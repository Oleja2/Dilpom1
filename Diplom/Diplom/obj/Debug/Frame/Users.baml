   M S B A M L   `   `   `  ����A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Diplom.FrameDiplom.Frame  5          Diplom.Frame.Users   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Diplom.Frame     5        N� Title$  Users��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 DGG��5      $��30,35,30,10q�6    ���	#997D7676
���   �   
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6?      Width5  /System.Windows.Controls.DataGridLengthConverter$	 30* 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Login+6\     5      $ Пароль��6B   $	 90* 6R    6%   �� *
Password+6`     5      $ Роль��6I   $	 90* 6W    6%   �� *Table_Role.Role+6e   5      �� 5   
   -   5         ��Name$ addBTN��5         BorderBrush#��[  6!   $��Добавить��6F   $
��Left=�6Y   $��	30,10,0,0q�6t   $	��Top=�6�   $��60��6�   6�   �� 5   
   -   5        $ editBTN��5      #��[  6"   $��Изменить��6G   $
��Left=�6Z   $��	95,10,0,0q�6u   $	��Top=�6�   $��60��6�   6�   �� 5   
   -   5        $ delBTN��5      #��[  6!   $��Удалить��6F   $
��Left=�6X   $��
160,10,0,0q�6s   $	��Top=�6�   $��60��6�   6�   5      5      