   M S B A M L   `   `   `  ����D  @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�aclr-namespace:Microsoft.Expression.Interactivity.Input;assembly=Microsoft.Expression.Interactions(Microsoft.Expression.Interactivity.Input 5
      H DImageTraveler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ImageTravelerImageTraveler 5      C&clr-namespace:ImageTraveler.ViewModelsImageTraveler.ViewModels 5         ImageTraveler.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cinchV2&clr-namespace:Cinch;assembly=Cinch.WPF     5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      J	 FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com 	 5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	 5	      jikaclr-namespace:Microsoft.Expression.Interactivity.Input;assembly=Microsoft.Expression.Interactions 	 5
      'localclr-namespace:ImageTraveler 	 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      /vm&clr-namespace:ImageTraveler.ViewModels 	 5      -   5          � Title$  
MainWindow��5      $
��1100��5      $	��650��5      $	��950��5      $	��550��5       � AllowsTransparency . 
������ -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=�5       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � WindowState 5      �� *windowState+ � 	Resources 5      &   ImageTraveler.ViewModels.Main_VM   main_vm+  %ImageTraveler.ViewModels.Main_Command  main_cmd  TitleBar_StoryBoard �� 
TargetName	 �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  TitleBar_StoryBoard2   Power  Btn_pre_storybord_1  Btn_pre_storybord_2  Btn_next_storybord_1  Btn_next_storybord_2 ��Name  Ellipse_start8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value R� KeyTime  System.Windows.Visibility   Visible R� Value   	Collapsed��%�  &	        &	      &	 &     &	 	    &	      &	 �    &	 �    &	 _    &	       5   
   6     5   
   6   �� 5    
   .��5!      U� $ TitleBar��6,   $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6M   .\�5"        $
 0��6'   $	 -43Q�63     5#      $
 0:0:0.3��6'   $ 0Q�69    5$        5%      $ EaseOut=�6$   5'      5(      U� 5)      $ TitleBar��6,   $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6M   .\�5*        $
 0��6'   $ 0Q�63   5+      5,      �� 5-   
   .��5.      U� $ TitleBar��6,   $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6M   .\�5/        $
 0:0:0.4��6'   $	 -43Q�69    50        51      $ EaseOut=�6$   $ 3Q�69   53      54      55      �� 56   
   .��57      U� $ Btn_Previous��6,   $	 (UIElement.Opacity)�6Q   .\�58        $
 0��6'   $ 0Q�63     59      $
 0:0:0.3��6'   $ 1Q�69   5:      5;      �� 5<   
   .��5=      U� $ Btn_Previous��6,   $	 (UIElement.Opacity)�6Q   .\�5>        $
 0��6'   $ 1Q�63     5?      $
 0:0:0.3��6'   $ 0Q�69   5@      5A      �� 5B   
   .��5C      U� $ Btn_Next��6,   $	 (UIElement.Opacity)�6M   .\�5D        $
 0��6'   $ 0Q�63     5E      $
 0:0:0.3��6'   $ 1Q�69   5F      5G      �� 5H   
   .��5I      U� $ Btn_Next��6,   $	 (UIElement.Opacity)�6M   .\�5J        $
 0��6'   $ 1Q�63     5K      $
 0:0:0.3��6'   $ 0Q�69   5L      5M      �� 5N   
   $ Ellipse_start��6+   .��5O      U� $ ellipse��6,   $	 (UIElement.Opacity)�6L   .\�5P        $
 0��6'   $	 0.6Q�63     5Q      $
 0:0:0.45��6'   $ 0Q�6:   5R      U� 5S      $ ellipse��6,   $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   .\�5T        $
 0��6'   $ 1Q�63     5U      $
 0:0:0.45��6'   $ 2Q�6:   5V      U� 5W      $ ellipse��6,   $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6L   .\�5X        $
 0��6'   $ 1Q�63     5Y      $
 0:0:0.45��6'   $ 2Q�6:   5Z      U� 5[      $ ellipse_image��6,   $	 (UIElement.Opacity)�6R   .\�5\        $
 0��6'   $ 1Q�63     5]      $
 0:0:0.45��6'   $ 0Q�6:   5^      U� 5_      $ ellipse_image��6,   $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6R   .\�5`        $
 0��6'   $	 0.5Q�63     5a      $
 0:0:0.45��6'   $	 1.2Q�6:   5b      U� 5c      $ ellipse_image��6,   $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6R   .\�5d        $
 0��6'   $	 0.5Q�63     5e      $
 0:0:0.45��6'   $	 1.2Q�6:   5f      *� 5g      $ ellipse_image��6+   $'	 !(UIElement.RenderTransformOrigin)�6Q   .'�5h        $ 0��6&   $ 0.5,0.5&�62     5i      $ 0:0:0.45��6&   $ 0.5,0.5&�69   5j      T� 5k      $ ellipse_image��6,   $	 (UIElement.Visibility)�6R   ..�5l      i� $ 0��6)   # Z 65   i� 5m      $ 0:0:0.45��6)   # Z 6<   5n      T� 5o      $ ellipse��6,   $	 (UIElement.Visibility)�6L   ..�5p      i� $ 0��6)   # Z 65   i� 5q      $ 0:0:0.45��6)   # Z 6<   5r      5s      5t       � Triggers 5u      :� 5v   
    :� RoutedEvent$ UIElement.MouseEnter��6    :� 
SourceName$ TitleBar_ControlGrid��6:   .[�5w      �� -   5         ��Name$) #TitleBar_StoryBoard_BeginStoryboard��5w      #��[ 6K   5x      :� 5y   
   $ FrameworkElement.Loaded��6   .[�5z      �� -   5        $* $TitleBar_StoryBoard2_BeginStoryboard��5z      #��[ 6L   �� 5{      -   5        $) #Btn_pre_storybord_1_BeginStoryboard��5{      #��[ 6K   �� 5|      -   5        $) #Btn_pre_storybord_2_BeginStoryboard��5|      #��[ 6K   �� 5}      -   5        $* $Btn_next_storybord_1_BeginStoryboard��5}      #��[ 6L   �� 5~      -   5        $* $Btn_next_storybord_2_BeginStoryboard��5~      #��[ 6L   5      :� 5�   
   $ UIElement.MouseLeave��6   $ TitleBar_ControlGrid��6:   .[�5�      �� -   5        $+ %TitleBar_StoryBoard2_BeginStoryboard1��5�      #��[ 6M   5�      :� 5�   
   $ UIElement.MouseEnter��6   $ Btn_Previous��6:   .[�5�      �� -	   5        $* $Btn_pre_storybord_1_BeginStoryboard1��5�      #��[ 6L   5�      :� 5�   
   $ UIElement.MouseEnter��6   $ Btn_Next��6:   .[�5�      �� -
   5        $* $Btn_pre_storybord_1_BeginStoryboard2��5�      #��[ 6L   5�      :� 5�   
   $ UIElement.MouseLeave��6   $ Btn_Next��6:   .[�5�      �� -   5        $+ %Btn_next_storybord_2_BeginStoryboard1��5�      #��[ 6M   5�      :� 5�   
   $ UIElement.MouseLeave��6   $ Btn_Previous��6:   .[�5�      �� -   5        $* $Btn_pre_storybord_2_BeginStoryboard1��5�      #��[ 6L   5�       � DataContext 5�        5�   
   .	  (System.Windows.Interactivity.Interaction 	  Triggers 5�      /
  )System.Windows.Interactivity.EventTrigger
  5�   
    
  	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowLoadedCommand+5�      
  5�   
   $ 
MouseWheel��6   . 5�      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .     Command  6!   �� *WindowMouseWheel+6F   5�      
  5�   
   $ 	MouseDown��6   . 5�         .   6!   �� *WindowMouseDown+6E   5�      
  5�   
   $ KeyDown��6   . 5�         .   6!   �� *	WindowKey+6?   5�      9  3Microsoft.Expression.Interactivity.Input.KeyTrigger  5�   
   
!   Key$! Escape��6   . 5�         6$   �� *EscKey+5�      .��5�      � -   5        " �Name$" mainGrid��5�   	   
���   � 5�   
   # �� MergedDictionaries$ �� Source�� 5�      # 5�      �� 5�      $$$ Style_Resources/MainStyle.xaml?�6)   %    5�      % � RowDefinitions% 5�   
   �� 5�      $
��0.7* �6   $��70��6*   �� 5�      $��6* �6   �� 5�      $
��1.3* �6   $	��140��6*   .+�5�   
   � -   5        $" TitleBar_ControlGrid��5�      $��0��5�      & K� ZIndex$& 3��5�      
������  5�      :� 5�      $ Grid.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      �� ' g� FillBehavior$' HoldEnd=�5�   !   $1	 +(Button.Background).(SolidColorBrush.Color)�5�   !   	( �� To$( TransparentX�5�   !   ) g� Duration$) 0:0:0.3D�5�   !   5�      5�      5�       5�      
  5�      $ 
MouseEnter��6!   . 5�         6,   �� *MouseMoveCommand+5�      % 5�      �� 5�      $��40 �6    �� 5�      $��30 �6    .+�5�      �� -   5        * ��Name$* TitleBar��5�      $��0��5�      $& 3��5�      ���#7a7a7a+ J� RenderTransformOrigin$+ 0.5,0.5&�5�      , J� Opacity, 5�      �� *GroupOpacity[0]+z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      ._�5�      � - � ColumnDefinitions- 5�      �� 5�      $��40 �6+   �� 5�      �� 5�      $��40 �6+   �� 5�      $��40 �6+   �� 5�      $��40 �6+   .+�5�      �� $��0��5�      $��4,12,0,8q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� *titleBar_ico_source+�� 5�      -   5        . ��Name$. TextBlock_Title��5�      $��1��5�      $��10,6,0,8q�5      $
��Left=�5     $��Bottom=�5     $��Gen Jyuu Gothic)�5     $��14(�5     
���������5     �� *
titleBar+� 5	     $��0��5
     $��2��5     
������  5     
  5     $ MouseLeftButtonUp��6-   . 5  "      68   �� *MouseLeftButtonUp+5     
  5     $ 	MouseMove��6-   . 5  "      .   65   �� *TitleBar_MouseMove+6\   5     
  5     $ MouseLeftButtonDown��6-   . 5  "      .   65   �� *TitleBar_MouseLeftButtonDown+6f   5     5     �� 5     $��2��6    	 Btn_style_min#��� 	 5     ��5     �� *Grid_minimize_MouseDown+ 5     / �� 
TargetType0 �� Property1 �� Value2 �� 
TargetType3 ��Name4 ��Name5 J� SnapsToDevicePixels6 �� Triggers7 P� Property8 P� Value��%o  &		       �� 5      "/ ��5!  $   .�5"  "   �� 0 � ��1 5#  &   �� 5$  *   "2 ��6:   .R�5%  .   �  5&  2   :� 5'  6   $ UIElement.MouseLeave��6C   $ grid2��5(  C   .[�5)  :   �� .��5*  >   �� .��5+  B   �� $' HoldEnd=�6Q   $ 	rectangle��5,  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�5-  Q   $( TransparentX�5.  Q   $) 0:0:0.3D�5/  Q   50  ?   51  ;   52  7   :� 53  6   $ UIElement.MouseEnter��6C   $ grid2��54  C   .[�55  :   �� .��56  >   �� .��57  B   �� $' HoldEnd=�6Q   $ 	rectangle��58  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�59  Q   $( 	LightGrayX�5:  Q   $) 0:0:0.3D�5;  Q   5<  ?   5=  ;   5>  7   .+�5@  2   � $" grid2��67   % 5A  6   �� 5B  :   $
��0.7* �6H   �� 5C  :   �� 5D  :   $
��0.7* �6H   .+�5F  6   �� $3 	rectangle��6@   $��3��5G  @   
������ 5H  @   �� 5I  6   $4 	ImageName��6<   $��1��5J  <   $5��/Resources/004-arrow-down-sign-to-navigate_1.png��5K  <   $��Uniform=�5L  <   5M  3   �� 5N  2   #��z��6C   #��z��5O  C   ��. #5 z5 5Q  C   5R  /   6 5S  .   P� 5T  2   7 �@J�	IsFocused8 . 5U  :   P� 5V  2   7 �@��IsDefaulted8 . 5W  :   P� 5X  2   7 �@J�IsMouseOver8 . 5Y  :   P� 5Z  2   7 � ��8 . 5[  :   P� 5\  2   7 � {�8 .  5]  :   5_  +   5a  #   5b     5c     5d     �� 5g     $��3��6    
 Btn_style_gen#��� 
 5i     ��5h     �� *#!Grid_generalize_maximum_MouseDown+ 5j     ��%[  &	
       �� 5k     "/ ��5l  $   .�5m  "   �� 0 � ��1 5n  &   �� 5o  *   "2 ��6:   .R�5p  .   �  5q  2   :� 5r  6   $ UIElement.MouseLeave��6C   $ grid2��5s  C   .[�5t  :   �� .��5u  >   �� .��5v  B   �� $' HoldEnd=�6Q   $ 	rectangle��5w  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�5x  Q   $( TransparentX�5y  Q   $) 0:0:0.3D�5z  Q   5{  ?   5|  ;   5}  7   :� 5~  6   $ UIElement.MouseEnter��6C   $ grid2��5  C   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $' HoldEnd=�6Q   $ 	rectangle��5�  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�5�  Q   $( 	LightGrayX�5�  Q   $) 0:0:0.3D�5�  Q   5�  ?   5�  ;   5�  7   .+�5�  2   � $" grid2��67   % 5�  6   �� 5�  :   $
��0.7* �6H   �� 5�  :   �� 5�  :   $
��0.7* �6H   .+�5�  6   �� $3 	rectangle��6@   $��3��5�  @   
������ 5�  @   �� 5�  6   $4 	ImageName��6<   $��1��5�  <   $!��Resources/001-browser_1.png��5�  <   $��Uniform=�5�  <   5�  3   �� 5�  2   #��z��6C   #��z��5�  C   ��. #5 z5 5�  C   5�  /   6 5�  .   P� 5�  2   7 �@J�	IsFocused8 . 5�  :   P� 5�  2   7 �@��IsDefaulted8 . 5�  :   P� 5�  2   7 �@J�IsMouseOver8 . 5�  :   P� 5�  2   7 � ��8 . 5�  :   P� 5�  2   7 � {�8 .  5�  :   5�  +   5�  #   5�     5�     5�     �� 5�     $��4��6   #��� 
 5�     ��5�     �� *Grid_close_MouseDown+ 5�     ��%\  &	
       �� 5�     "/ ��5�  $   .�5�  "   �� 0 � ��1 5�  &   �� 5�  *   "2 ��6:   .R�5�  .   �  5�  2   :� 5�  6   $ UIElement.MouseLeave��6C   $ grid2��5�  C   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $' HoldEnd=�6Q   $ 	rectangle��5�  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�5�  Q   $( TransparentX�5�  Q   $) 0:0:0.3D�5�  Q   5�  ?   5�  ;   5�  7   :� 5�  6   $ UIElement.MouseEnter��6C   $ grid2��5�  C   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $' HoldEnd=�6Q   $ 	rectangle��5�  Q   $*	 $(Shape.Fill).(SolidColorBrush.Color)�5�  Q   $( 	LightGrayX�5�  Q   $) 0:0:0.3D�5�  Q   5�  ?   5�  ;   5�  7   .+�5�  2   � $" grid2��67   % 5�  6   �� 5�  :   $
��0.7* �6H   �� 5�  :   �� 5�  :   $
��0.7* �6H   .+�5�  6   �� $3 	rectangle��6@   $��3��5�  @   
������ 5�  @   �� 5�  6   $4 	ImageName��6<   $��1��5�  <   $"��Resources/cancel-music_1.png��5�  <   $��Uniform=�5�  <   5�  3   �� 5�  2   #��z��6C   #��z��5�  C   ��. #5 z5 5�  C   5�  /   6 5�  .   P� 5�  2   7 �@J�	IsFocused8 . 5�  :   P� 5�  2   7 �@��IsDefaulted8 . 5�  :   P� 5�  2   7 �@J�IsMouseOver8 . 5�  :   P� 5�  2   7 � ��8 . 5�  :   P� 5�  2   7 � {�8 .  5�  :   5�  +   5�  #   5�     5�     5�     5�     5�     5�     � 5  
   -   5        $" Grid_PicBoxView��5     $��0��5     $��3��5     $& 1��5     |�.  9 � ContextMenu9 5     �� 5     .@�5     m� -   5        : m�Name$: Btn_Pointer��5     $��Pointer��64   m� 5     -   5        $: Btn_Pen��5     $	��Pen��60   m� 5     $
��Drag��6   �� 5     m� 5     $��Setting��6   5     .+�5     �� z�5     T� 5     ; T� X; 6)   �� *picX+< T� Y< 5  )   �� *picY+._�5     (� -   5        = (�Name$= ViewBox_Image��5     $+ 0.5,0.5&�5     > � LayoutTransform> 5     �� 5     ? �� Angle? 6*   �� *	rotaAngle+.��5     �� -   5        $4 
PicBoxView��5     " 	 WpfAnimatedGif.ImageBehavior@   	AutoStart@ . 5 . $+ 0.5,0.5&�5$     A   AnimatedSourceA 5      �� *	picSource+B   RepeatBehaviorB 5"     �� *RepeatBehavior+z�5%     V� 5&     .~�5'  "   �� C �� ScaleXC 61   �� *	scaleXY+D �� ScaleYD 5(  1   �� *	scaleXY+�� 5)  "   �� 5*  "   5+     5-     5.     5/     50     �� 53  
   -   5        $* Initial_Border��54     $��1��55     $��4��56     
���   �& 57     �� *zIndex_group[0]+._�5<     (� -   5        $+ 0.5,0.5&�5<  (   5>     5?     � 5B  
   -   5        $��0��5C     $��5��5D     $& 1��5E     .+�5I     (� .��5J      � -   5        E  �Name$E 
Frame_main��5J     F  � NavigationUIVisibility$F Hidden=�6,   5K     5L     � 5Q  
   -   5        $
" grid��5R     $��0��5S     $��3��5T     $& 1��5U     - 5V     �� 5W     $��30��6#   �� 5X     $��15.5* �6#   �� 5Y     $��30��6#   .+�5[     �� -   5        G ��Name$G Btn_Previous��5\     $��0��5]     |�.  $, 0Q�5`       ButtonStyle1#���  5a     ��5^     �� *
PreCommand+ 5b     H J� OpacityMaskI �� 
StartPointJ �� EndPointK � OffsetL � Color��%   &	       �� 5c     "/ ��61   .�5d     �� 0 � ��1 5e     �� 5f  "   "2 ��62   .R�5g  &   � .+�5h  *   � $" grid2��6/   % 5i  .   �� 5j  2   $
��0.2* �6@   �� 5k  2   �� 5l  2   $
��0.2* �6@   - 5n  .   �� 5o  2   �� 5p  2   $��5* �6C   �� 5q  2   .+�5s  .   �� $3 	rectangle��5t  1   $��3��5u  1   $��3��5v  1   
���   �H 5x  2   �� 5y  6   $I 0,0.5&�6J   $J 1,0.5&�6]   .��5z  :   � $K 0Q�6G   $L Black��6R   � 5{  :   $K 1Q�6G   $L Transparent��6R   5|  7   5~  /   �� 5  .   $4 	ImageName��5�  1   $��1��5�  1   $��1��5�  1   $��0q�5�  1   $$��Resources/Image_Previous_1.png��5�  1   $��Uniform=�5�  1   5�  +   �� 5�  *   #��z��5�  -   #��z��5�  -   ��. #5 z5 5�  -   5�  '   6 5�  &   P� 5�  *   7 �@J�	IsFocused8 . 6G   P� 5�  *   7 �@��IsDefaulted8 . 6I   P� 5�  *   7 �@J�IsMouseOver8 . 6I   P� 5�  *   7 � ��8 . 6G   P� 5�  *   7 � {�8 .  6G   5�  #   5�     5�     5�     5�     �� 5�     -   5        $G Btn_Next��5�     $��2��5�     |�.  $, 0Q�5�     #���  5�     ��5�     �� *NextCommand+ 5�     ��%  &	       �� 5�     "/ ��61   .�5�     �� 0 � ��1 5�     �� 5�  "   "2 ��62   .R�5�  &   � .+�5�  *   � $" grid2��6/   % 5�  .   �� 5�  2   $
��0.2* �6@   �� 5�  2   �� 5�  2   $
��0.2* �6@   - 5�  .   �� 5�  2   �� 5�  2   $��5* �6C   �� 5�  2   .+�5�  .   �� $3 	rectangle��5�  1   $��3��5�  1   $��3��5�  1   
���   �H 5�  2   �� 5�  6   $I 1,0.5&�6J   $J 0,0.5&�6]   .��5�  :   � $L Black��6G   � 5�  :   $K 1Q�6G   $L Transparent��6R   5�  7   5�  /   �� 5�  .   $4 	ImageName��5�  1   $��1��5�  1   $��1��5�  1   $��0q�5�  1   $ ��Resources/Image_Next_1.png��5�  1   $��Uniform=�5�  1   5�  +   �� 5�  *   #��z��5�  -   #��z��5�  -   ��. #5 z5 5�  -   5�  '   6 5�  &   P� 5�  *   7 �@J�	IsFocused8 . 6G   P� 5�  *   7 �@��IsDefaulted8 . 6I   P� 5�  *   7 �@J�IsMouseOver8 . 6I   P� 5�  *   7 � ��8 . 6G   P� 5�  *   7 � {�8 .  6G   5�  #   5�     5�     5�     5�     A� 5�     -   5        M A�Name$M ellipse��5�     $��1��5�     $��60��5�     $��60��5�     $��Center=�5�     $��Center=�5�     ���	#FFA4A4A4$, 0Q�5�     $+ 0.5,0.5&�5�     $y�	Collapsed=�5�     z�5�     V� 5�     .~�5�     �� �� 5�     �� 5�     T� 5�     5�     5�     �� 5�     -   5        $4 ellipse_image��5�     $��1��5�     $��60��5�     $��60��5�     $��Center=�5�     $��Center=�5�     $, 0Q�5�     $+ 0.5,0.5&�5�     $��Resources/下_1.png��5�     $y�	Collapsed=�5�     z�5�     V� 5�     .~�5�     �� $	C 0.5Q�6)   $	D 0.5Q�66   �� 5�     �� 5�     T� 5�     $; 2Q�6-   5�     5      5     � 5  
   $��2��5     $& 3��5     |�.  .+�5	      � -   5        $E 	Frame_bar��5
     $F Hidden=�5     5     �� 5  
   $��3��6   $& 5��5     
��� ���$	��0.5q�5     , 5     �� *GroupOpacity[0]+5     5     