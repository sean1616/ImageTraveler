   M S B A M L   `   `   `  ����D  @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�aclr-namespace:Microsoft.Expression.Interactivity.Input;assembly=Microsoft.Expression.Interactions(Microsoft.Expression.Interactivity.Input 5
      H DImageTraveler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ImageTravelerImageTraveler 5      C&clr-namespace:ImageTraveler.ViewModelsImageTraveler.ViewModels 5         ImageTraveler.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cinchV2&clr-namespace:Cinch;assembly=Cinch.WPF     5      f	 bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight 	 5      :d2http://schemas.microsoft.com/expression/blend/2008 	 5      J
 FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com 
 5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
 5	      jikaclr-namespace:Microsoft.Expression.Interactivity.Input;assembly=Microsoft.Expression.Interactions 
 5
      'localclr-namespace:ImageTraveler 
 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
 5      /vm&clr-namespace:ImageTraveler.ViewModels 
 5      -   5          � Title$  
MainWindow��5      $
��1080��5      $	��700��5      $	��350��5      $	��550��5       � AllowsTransparency . 
������ -  'System.Windows.Input.KeyboardNavigation   ControlTabNavigation$
 None=�5         TabNavigation$
 None=�5       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � WindowState 5      �� *windowState+ � 	Resources 5      &   ImageTraveler.ViewModels.Main_VM   main_vm+  %ImageTraveler.ViewModels.Main_Command  main_cmd$  ImageTraveler.BoolToVisibility  	boolToVis  TitleBar_StoryBoard	 �� 
TargetName
 �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  TitleBar_StoryBoard2   Power  Btn_pre_storybord_1  Btn_pre_storybord_2  Btn_next_storybord_1  Btn_next_storybord_2 ��Name 	 Ellipse_start8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value R� KeyTime	  System.Windows.Visibility 	  Visible R� Value 	  	Collapsed��%�  &	        &	      &	 &     &	 9     &	     &	 3    &	 �    &	 �    &	 r    &		 /      5    
   6     5!   
   6     5"   
   6!   �� 5#   
   .��5$      U� $	 TitleBar��6,   $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6M   .\�5%        $ 0��6'   $	 -43Q�63     5&      $ 0:0:0.3��6'   $ 0Q�69    5'        5(      $ EaseOut=�6$   5*      5+      U� 5,      $	 TitleBar��6,   $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6M   .\�5-        $ 0��6'   $ 0Q�63   5.      5/      �� 50   
   .��51      U� $	 TitleBar��6,   $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6M   .\�52        $ 0:0:0.4��6'   $	 -43Q�69    53        54      $ EaseOut=�6$   $ 3Q�69   56      57      58      �� 59   
   .��5:      U� $	 Btn_Previous��6,   $
 (UIElement.Opacity)�6Q   .\�5;        $ 0��6'   $ 0Q�63     5<      $ 0:0:0.3��6'   $ 1Q�69   5=      5>      �� 5?   
   .��5@      U� $	 Btn_Previous��6,   $
 (UIElement.Opacity)�6Q   .\�5A        $ 0��6'   $ 1Q�63     5B      $ 0:0:0.3��6'   $ 0Q�69   5C      5D      �� 5E   
   .��5F      U� $	 Btn_Next��6,   $
 (UIElement.Opacity)�6M   .\�5G        $ 0��6'   $ 0Q�63     5H      $ 0:0:0.3��6'   $ 1Q�69   5I      5J      �� 5K   
   .��5L      U� $	 Btn_Next��6,   $
 (UIElement.Opacity)�6M   .\�5M        $ 0��6'   $ 1Q�63     5N      $ 0:0:0.3��6'   $ 0Q�69   5O      5P      �� 5Q   
   $ Ellipse_start��6+   .��5R      U� $	 ellipse��6,   $
 (UIElement.Opacity)�6L   .\�5S        $ 0��6'   $	 0.6Q�63     5T      $ 0:0:0.45��6'   $ 0Q�6:   5U      U� 5V      $	 ellipse��6,   $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   .\�5W        $ 0��6'   $ 1Q�63     5X      $ 0:0:0.45��6'   $ 2Q�6:   5Y      U� 5Z      $	 ellipse��6,   $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6L   .\�5[        $ 0��6'   $ 1Q�63     5\      $ 0:0:0.45��6'   $ 2Q�6:   5]      U� 5^      $	 ellipse_image��6,   $
 (UIElement.Opacity)�6R   .\�5_        $ 0��6'   $ 1Q�63     5`      $ 0:0:0.45��6'   $ 0Q�6:   5a      U� 5b      $	 ellipse_image��6,   $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6R   .\�5c        $ 0��6'   $	 0.5Q�63     5d      $ 0:0:0.45��6'   $	 1.2Q�6:   5e      U� 5f      $	 ellipse_image��6,   $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6R   .\�5g        $ 0��6'   $	 0.5Q�63     5h      $ 0:0:0.45��6'   $	 1.2Q�6:   5i      *� 5j      $	 ellipse_image��6+   $'
 !(UIElement.RenderTransformOrigin)�6Q   .'�5k        $ 0��6&   $ 0.5,0.5&�62     5l      $ 0:0:0.45��6&   $ 0.5,0.5&�69   5m      T� 5n      $	 ellipse_image��6,   $
 (UIElement.Visibility)�6R   ..�5o      i� $ 0��6)   # Z 65   i� 5p      $ 0:0:0.45��6)   # Z 6<   5q      T� 5r      $	 ellipse��6,   $
 (UIElement.Visibility)�6L   ..�5s      i� $ 0��6)   # Z 65   i� 5t      $ 0:0:0.45��6)   # Z 6<   5u      5v      5w       � Triggers 5x      :� 5y   
    :� RoutedEvent$ UIElement.MouseEnter��6    :� 
SourceName$ TitleBar_ControlGrid��6:   .[�5z      �� -   5         ��Name$) #TitleBar_StoryBoard_BeginStoryboard��5z      #��[ 6K   5{      :� 5|   
   $ FrameworkElement.Loaded��6   .[�5}      �� -   5        $* $TitleBar_StoryBoard2_BeginStoryboard��5}      #��[ 6L   �� 5~      -   5        $) #Btn_pre_storybord_1_BeginStoryboard��5~      #��[ 6K   �� 5      -   5        $) #Btn_pre_storybord_2_BeginStoryboard��5      #��[ 6K   �� 5�      -   5        $* $Btn_next_storybord_1_BeginStoryboard��5�      #��[ 6L   �� 5�      -   5        $* $Btn_next_storybord_2_BeginStoryboard��5�      #��[ 6L   5�      :� 5�   
   $ UIElement.MouseLeave��6   $ TitleBar_ControlGrid��6:   .[�5�      �� -   5        $+ %TitleBar_StoryBoard2_BeginStoryboard1��5�      #��[ 6M   5�      :� 5�   
   $ UIElement.MouseEnter��6   $ Btn_Previous��6:   .[�5�      �� -	   5        $* $Btn_pre_storybord_1_BeginStoryboard1��5�      #��[ 6L   5�      :� 5�   
   $ UIElement.MouseEnter��6   $ Btn_Next��6:   .[�5�      �� -
   5        $* $Btn_pre_storybord_1_BeginStoryboard2��5�      #��[ 6L   5�      :� 5�   
   $ UIElement.MouseLeave��6   $ Btn_Next��6:   .[�5�      �� -   5        $+ %Btn_next_storybord_2_BeginStoryboard1��5�      #��[ 6M   5�      :� 5�   
   $ UIElement.MouseLeave��6   $ Btn_Previous��6:   .[�5�      �� -   5        $* $Btn_pre_storybord_2_BeginStoryboard1��5�      #��[ 6L   5�       � DataContext 5�        5�   
   .
  (System.Windows.Interactivity.Interaction 
  Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowLoadedCommand+5�        5�   
   $ 
MouseWheel��6   . 5�      / 	 )GalaSoft.MvvmLight.Command.EventToCommand      PassEventArgsToCommand  . !   Command! 6!   �� *WindowMouseWheel+6F   5�        5�   
   $ 	MouseDown��6   . 5�          . ! 6!   �� *WindowMouseDown+6E   5�        5�   
   $ KeyDown��6   . 5�          . ! 6!   �� *	WindowKey+6?   5�      9  3Microsoft.Expression.Interactivity.Input.KeyTrigger  5�   
   
"   Key$" Escape��6   . 5�         6$   �� *EscKey+5�      # J� InputBindings# 5�      �� 5�   
   
$ �� Key$$ Space��6   % �� Command% 6!   �� *	WindowKey+.��5�      � -   5        & �Name$& mainGrid��5�      
���   � 5�   
   ' �� MergedDictionaries( �� Source�� 5�      ' 5�      �� 5�      $$( Style_Resources/MainStyle.xaml?�6)   %    5�      ) � RowDefinitions) 5�   
   �� 5�      $
��0.7* �6   $��70��6*   �� 5�      $��6* �6   �� 5�      $
��1.3* �6   $	��140��6*   .+�5�   
   � -   5        $& TitleBar_ControlGrid��5�      $��0��5�      * K� ZIndex$* 3��5�      
������ y�5�      �� *isBarAnimation++ �� 	Converter#+ [  5�      :� 5�      $ Grid.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      �� , g� FillBehavior$, HoldEnd=�5�   !   $1
 +(Button.Background).(SolidColorBrush.Color)�5�   !   	- �� To$- TransparentX�5�   !   . g� Duration$. 0:0:0.3D�5�   !   5�      5�      5�       5�        5�      $ 
MouseEnter��6!   . 5�         6,   �� *MouseMoveCommand+5�      ) 5�      �� 5�      $��40 �6    �� 5�      $��30 �6    .+�5�      �� -   5        / ��Name$/ TitleBar��5�      $��0��5�      $* 3��5�      ���#7a7a7a0 J� RenderTransformOrigin$0 0.5,0.5&�5�      1 J� Opacity1 5�      �� *GroupOpacity[0]+z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      ._�5�      � 2 � ColumnDefinitions2 5�      �� 5�      $��40 �6+   �� 5�      �� 5�      $��40 �6+   �� 5�      $��40 �6+   �� 5�      $��40 �6+   .+�5�      �� $��0��5�      $��4,12,0,8q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� *titleBar_ico_source+�� 5      -   5        3 ��Name$3 TextBlock_Title��5     $��1��5     $��10,6,0,8q�5     $
��Left=�5     $��Bottom=�5     $��Gen Jyuu Gothic)�5     $��14(�5     
���������5
     �� *
titleBar+� 5     $��0��5     $��2��5     
������  5       5     $ MouseLeftButtonUp��6-   . 5  "      68   �� *MouseLeftButtonUp+5       5     $ 	MouseMove��6-   . 5  "       . ! 65   �� *TitleBar_MouseMove+6\   5       5     $ MouseLeftButtonDown��6-   . 5  "       . ! 65   �� *TitleBar_MouseLeftButtonDown+6f   5     5     �� 5     $��2��5      ��.   
 Btn_style_min#��� 
 5#     ��5!     �� *Grid_minimize_MouseDown+ 5$     4 �� 
TargetType5 �� Property6 �� Value7 �� 
TargetType8 ��Name9 ��Name: J� SnapsToDevicePixels; �� Triggers< P� Property= P� Value��%K  &	
       �� 5%     "4 ��6:   .�5&  "   �� 5 � ��6 5'  &   �� 5(  *   "7 ��6:   .R�5)  .   �  5*  2   :� 5+  6   $ UIElement.MouseLeave��6C   $ grid2��6f   .[�5,  :   �� .��5-  >   �� .��5.  B   �� $, HoldEnd=�5/  E   $	 	rectangle��50  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�51  E   $- TransparentX�52  E   $. 0:0:0.3D�53  E   54  ?   55  ;   56  7   :� 57  6   $ UIElement.MouseEnter��6C   $ grid2��6f   .[�58  :   �� .��59  >   �� .��5:  B   �� $, HoldEnd=�5;  E   $	 	rectangle��5<  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5=  E   $- 	LightGrayX�5>  E   $. 0:0:0.3D�5?  E   5@  ?   5A  ;   5B  7   .+�5D  2   � $& grid2��67   ) 5E  6   �� 5F  :   $
��0.7* �6H   �� 5G  :   �� 5H  :   $
��0.7* �6H   .+�5J  6   �� $8 	rectangle��5K  9   $��3��5L  9   
������ 5M  9   �� 5N  6   $9 	ImageName��5O  9   $��1��5P  9   $��Resources/Min_white.png��5Q  9   $��Uniform=�5R  9   5S  3   �� 5T  2   #��z��5U  5   #��z��5V  5   ��. #: z: 5X  5   5Y  /   ; 5Z  .   P� 5[  2   < �@J�	IsFocused= . 6O   P� 5\  2   < �@��IsDefaulted= . 6Q   P� 5]  2   < �@J�IsMouseOver= . 6Q   P� 5^  2   < � ��= . 6O   P� 5_  2   < � {�= .  6O   5a  +   5c  #   5d     5e     5f     �� 5i     $��3��5j     ��.    Btn_style_gen#���  5m     ��5k     �� *#!Grid_generalize_maximum_MouseDown+ 5n     ��%H  &	       �� 5o     "4 ��6:   .�5p  "   �� 5 � ��6 5q  &   �� 5r  *   "7 ��6:   .R�5s  .   �  5t  2   :� 5u  6   $ UIElement.MouseLeave��6C   $ grid2��6f   .[�5v  :   �� .��5w  >   �� .��5x  B   �� $, HoldEnd=�5y  E   $	 	rectangle��5z  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5{  E   $- TransparentX�5|  E   $. 0:0:0.3D�5}  E   5~  ?   5  ;   5�  7   :� 5�  6   $ UIElement.MouseEnter��6C   $ grid2��6f   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $, HoldEnd=�5�  E   $	 	rectangle��5�  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5�  E   $- 	LightGrayX�5�  E   $. 0:0:0.3D�5�  E   5�  ?   5�  ;   5�  7   .+�5�  2   � $& grid2��67   ) 5�  6   �� 5�  :   $
��0.7* �6H   �� 5�  :   �� 5�  :   $
��0.7* �6H   .+�5�  6   �� $8 	rectangle��5�  9   $��3��5�  9   
������ 5�  9   �� 5�  6   $9 	ImageName��5�  9   $��1��5�  9   $��Resources/normal.png��5�  9   $��Uniform=�5�  9   5�  3   �� 5�  2   #��z��5�  5   #��z��5�  5   ��. #: z: 5�  5   5�  /   ; 5�  .   P� 5�  2   < �@J�	IsFocused= . 6O   P� 5�  2   < �@��IsDefaulted= . 6Q   P� 5�  2   < �@J�IsMouseOver= . 6Q   P� 5�  2   < � ��= . 6O   P� 5�  2   < � {�= .  6O   5�  +   5�  #   5�     5�     5�     �� 5�     $��4��5�     ��.  #���  5�     ��5�     �� *Grid_close_MouseDown+ 5�     ��%P  &	       �� 5�     "4 ��6:   .�5�  "   �� 5 � ��6 5�  &   �� 5�  *   "7 ��6:   .R�5�  .   �  5�  2   :� 5�  6   $ UIElement.MouseLeave��6C   $ grid2��6f   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $, HoldEnd=�5�  E   $	 	rectangle��5�  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5�  E   $- TransparentX�5�  E   $. 0:0:0.3D�5�  E   5�  ?   5�  ;   5�  7   :� 5�  6   $ UIElement.MouseEnter��6C   $ grid2��6f   .[�5�  :   �� .��5�  >   �� .��5�  B   �� $, HoldEnd=�5�  E   $	 	rectangle��5�  E   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5�  E   $- 	LightGrayX�5�  E   $. 0:0:0.3D�5�  E   5�  ?   5�  ;   5�  7   .+�5�  2   � $& grid2��67   ) 5�  6   �� 5�  :   $
��0.7* �6H   �� 5�  :   �� 5�  :   $
��0.7* �6H   .+�5�  6   �� $8 	rectangle��5�  9   $��3��5�  9   
������ 5�  9   �� 5�  6   $9 	ImageName��5�  9   $��1��5�  9   $"��Resources/cancel-music_1.png��5�  9   $��Uniform=�5�  9   5�  3   �� 5�  2   #��z��5�  5   #��z��5�  5   ��. #: z: 5�  5   5�  /   ; 5�  .   P� 5�  2   < �@J�	IsFocused= . 6O   P� 5�  2   < �@��IsDefaulted= . 6Q   P� 5�  2   < �@J�IsMouseOver= . 6Q   P� 5�  2   < � ��= . 6O   P� 5�  2   < � {�= .  6O   5�  +   5�  #   5�     5�     5�     5�     5�     5�      � 5   
   -   5        >  �Name$> Frame_main_for_txt��5     $��0��5     $��3��5     ?  � NavigationUIVisibility$? Hidden=�5     � 5  
   -   5        $& Grid_PicBoxView��5     $��0��5	     $��3��5
     $* 1��5     |�.  @ � ContextMenu@ 5     �� 5     .@�5     m� -   5        A m�Name$A Btn_Pointer��5     $��Pointer��5     m� 5     -   5        $A Btn_Pen��5     ���	#FFFD0000$	��Pen��5     m� 5     $
��Drag��6   m� 5     -   5        $A Btn_Save��5     $
��Save��5     �� 5      m� 5!     -   5        $A Btn_Background��5"     $��
Background��5$     m� 5%     $��Setting��6   5&     .+�5)     �� -   5        $/ 	PicBorder��5)     z�5*     T� 5+     B T� XB 6)   �� *picX+C T� YC 6<   �� *picY+._�5-     (� -   5        D (�Name$D ViewBox_Image��5-     $0 0.5,0.5&�61   E � LayoutTransformE 5.     �� 5/     F �� AngleF 6*   �� *	rotaAngle+.��51     �� -   5        $9 
PicBoxView��52     " 
 WpfAnimatedGif.ImageBehaviorG   	AutoStartG . $0 0.5,0.5&�56     : . H   AnimatedSourceH 53     �� *	picSource+I   RepeatBehaviorI 55     �� *RepeatBehavior+z�58     V� 59     .~�5:  "   �� J �� ScaleXJ 61   �� *	scaleXY+K �� ScaleYK 6L   �� *	scaleXY+�� 5;  "   �� 5<  "   5=     5?     5@     5A     �� 5C     -   5        L ��Name$
L Ink1��5D     M �� 
Background
M ���� N �� EditingMode$	N Ink=�5H     $y�	Collapsed=�5I     ��5E     �� *ActualWidth+O �� ElementName$O 	PicBorder��P �� Mode$P OneWay=���5F     �� *ActualHeight+$O 	PicBorder��$P OneWay=�Q �� DefaultDrawingAttributesQ 5J     *  $System.Windows.Ink.DrawingAttributes  5K     R   Width$R 6Q�6(   S   Color$	S Red��62   5M     5N     � 5b  
   -   5        $��0��5c     $��5��5d     $* 1��5e     .+�5i     (� .��5j      � -   5        $> 
Frame_main��5j     $? Hidden=�6,   5k     5m     � 5r  
   -   5        $
& grid��5s     $��0��5t     $��3��5u     $* 1��5v     2 5w     �� 5x     $��30��6#   �� 5y     $��15.5* �6#   �� 5z     $��30��6#   .+�5}     �� -   5        T ��Name$T Btn_Previous��5~     $��0��5     |�.  $1 0Q�5�       ButtonStyle_Gradient_L#���  5�     
U � Tag$'U !../Resources/Image_Previous_1.png��5�     ��5�     �� *
PreMedia+V � FocusVisualStyleV 5�     Z� 5�     �� 5�     -   5        $T Btn_Next��5�     $��2��5�     |�.  $1 0Q�5�       ButtonStyle_Gradient_R#���  5�     $#U ../Resources/Image_Next_1.png��5�     ��5�     �� *	NextMedia+V 5�     Z� 5�     A� 5�     -    5        W A�Name$W ellipse��5�     $��1��5�     $��60��5�     $��60��5�     $��Center=�5�     $��Center=�5�     ���	#FFA4A4A4$1 0Q�5�     $0 0.5,0.5&�5�     $y�	Collapsed=�5�     z�5�     V� 5�     .~�5�     �� �� 5�     �� 5�     T� 5�     5�     5�     �� 5�     -!   5        $9 ellipse_image��5�     $��1��5�     $��60��5�     $��60��5�     $��Center=�5�     $��Center=�5�     $1 0Q�5�     $0 0.5,0.5&�5�     $��Resources/下_1.png��5�     $y�	Collapsed=�5�     z�5�     V� 5�     .~�5�     �� $	J 0.5Q�6)   $	K 0.5Q�66   �� 5�     �� 5�     T� 5�     $B 2Q�6-   5�     5�     5�     � 5�  
   $��2��5�     $* 3��5�     |�.  V 5�     Z� y�5�     �� *isBarAnimation+#+ [ .+�5�      � -"   5        $> 	Frame_bar��5�     $? Hidden=�5�     5�     �� 5�  
   $��3��5�     $* 5��5�     
��� ���$	��0.5q�5�     1 5�     �� *GroupOpacity[0]+� 5�  
   $��0��6   $��4��6   ) 5�     �� 5�     �� 5�     $��9* �6    2 5�     �� 5�     �� 5�     $��9* �6#   .+�5�     �� -#   5        $9 img_girl_background��5�     $��1��5�     $��1��5�     $��Right=�5�     $��Bottom=�5�     $'��!Resources/1442760789 - 複製.jpg��5�     $y�Hidden=�5�     * 5�     �� *zIndex_group[0]+5�     5�     5�     5�     