   M S B A M L   `   `   `  ����I  EKursachBorisov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:KursachBorisovKursachBorisov  5      #    KursachBorisov.AddNewQuestion   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:KursachBorisov     5        N� Title$  AddNewQuestion��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $
��100* �6   .+�5   
   �� $/��)Наименование предмета��6   $��0��60   $��0��6=   $��Center=�6M   $��Center=�6j   �� 5   
   -   5         ��Name$ Subject��5      $��0��6$   $��1��61    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$
 Name��5      $��5q�5       �� SelectedValue 5      �� *Id+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *Id+$ TwoWay=�5      �� 5   
   $��Текст вопроса��6   $��1��6(   $��0��65   $��Center=�6E   $	��100��6`   $
��Left=�6l   �� 5   
   $��Сложность��6   $��1��6$   $��0��61   $��Center=�6A   $	��100��6\   $��Center=�6h   �� 5   
   -   5        $ DifficultyBox��5      $��1��6*   $��0��67   $��Center=�6G   $	��100��6b   $��Right=�6n   $��5q�6�   $��40��6�   �� 5   
   $��Картинка��6   $��1��6#   $��1��60   �� 5    
   -   5        	 ��Name$	 QuestionText��5       $��2��6(   $��0��65   $��5q�6E   �� 5!   
   -   5        
 ��Name$
 SubjectLabel��5!      $��0��6&   $��1��63   $��5q�6C   �� 5"   
   -   5         ��Name$ QuestionPicture��5"      $��2��6)   $��1��66   $��68,45.8,58,91.6q�6F   �� 5#   
   -   5         ��Name$ BtnAdd��5#      $��Добавить��6!   $��2��64   $��1��6A   $��109,281.8,97,18.6q�6Q   6l   5$      5%      