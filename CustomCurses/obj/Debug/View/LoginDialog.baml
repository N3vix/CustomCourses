   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   G CCustomCurses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CustomCurses.ViewCustomCurses.View 5   	   #   CustomCurses.View.LoginDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   1localclr-namespace:CustomCurses.View     5   	      LoginDialog  � DataContext#  [  5	   	    � Title$ LoginDialog��5
   	   $	��180��6   $	��400��6*   .   (System.Windows.Interactivity.Interaction   	Behaviors 5      +  %CustomCurses.View.CloseWindowBehavior  5   
      CloseTrigger 6$   �� *CloseTrigger+.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Center=�6"   .+�5      �� .��6   
Username6   �� 5      -   5        $��Username��5      $
��Left=�6&   $	��Top=�6A   $��24��6Y   $	��220��6e    �� TextWrapping$
 Wrap=�6q   ��6�   �� *
Username+�� 5      .��6   
Password6   G� 5      -   5        $��Password��5      $
��Left=�6*   $	��Top=�6E   $��24��6]   $	��220��6i    G� PasswordChar$ *��6u   5      �� 5   
   $��10q�6   $��1��6!   $��Right=�6.    �� Orientation$ 
Horizontal=�6J   .+�5      �� -   5        $��Login��5      $	��100��6"   $��24��6.   $��0,0,4,0q�6:   ��5      �� *LoginCommand+��66   ��  �� ElementName$ Password��.��6h   Login6o   �� 5      -   5        $��Cancel��5      $	��100��6#   $��24��6/   ��6;   �� *CancelCommand+.��6]   Cancel6e   5      5      5      