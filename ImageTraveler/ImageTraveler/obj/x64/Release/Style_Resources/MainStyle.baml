   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Btn_Group_Style  �� 
TargetType �� Property �� Value  Btn_Grid_Style �� Triggers :� RoutedEvent g� FillBehavior �� TargetProperty	 �� To g� Duration  Btn_load_Style	 �� BasedOn
 �� 
TargetType J� SnapsToDevicePixels � Triggers �� 
TargetName R� KeyTime R� Value �� 	UriSource � RowDefinitions  Btn_Fit_Style  Btn_Stop_Style  Btn_previous_Style  Btn_Media_previous_Style  Btn_FullScreen_Style  Btn_Media_play_pause_Style 	 Btn_next_Style 
 Btn_Media_next_Style  Btn_rotation_Style  Btn_Delete_Style  Btn_Volume_Style  	Image_Btn  
ImageStyle g� 	BeginTime�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %E  &	        &	 6     &	 �    7   7  &	 �    7   7  &	 �    7   7  &	 
    7   7  &	 #    7   7  &	 T    7   7  &	 p    7   7  &		 D    7   7  &	
 `    7   7  &	 �    7   7  &	 �    7   7  &	 )    7   7  &	 �    &	 ~    �� "  ��.���  � ��$ 2q���  � {� . �� "  � :� $ Grid.MouseLeave��.[��� .���� .���� $ HoldEnd=�$/ )(Grid.Background).(SolidColorBrush.Color)�$ TransparentX�$ 0:0:0.3D�:� $ Grid.MouseEnter��.[��� .���� .���� $ HoldEnd=�$/ )(Grid.Background).(SolidColorBrush.Color)�$
 GrayX�$ 0:0:0.3D�:� $ Grid.MouseDown��.[��� .���� .���� $
 Stop=�$/ )(Grid.Background).(SolidColorBrush.Color)�$ 	LightGrayX�$ 0:0:0.1D��� 8	   "  ��.���  � �� �� "
 ��.R�� $��GridName��
������  . 8��  :� $ Grid.MouseLeave��.[��� .���� .���� $ HoldEnd=�$/ )(Grid.Background).(SolidColorBrush.Color)�$ TransparentX�$ 0:0:0.3D�:� $ Grid.MouseEnter��.[��� .���� .���� $ HoldEnd=�$/ )(Grid.Background).(SolidColorBrush.Color)�$
 GrayX�$ 0:0:0.3D�T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $  ../Resources/001-share.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.05D�..�i� $ 0:0:0�� �� $" ../Resources/002-share-1.png?�:� $ Grid.MouseDown��.[��� .���� .���� $
 Stop=�$/ )(Grid.Background).(SolidColorBrush.Color)�$ 	LightGrayX�$ 0:0:0.1D�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��3��
������ $��2���� $��	ImageName��$��1��$��0q�$ ��../Resources/001-share.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Fit-1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Fit-2.png?�.+��  �� $
��0.1* ��� �� $
��0.1* �.+��� $��	ImageName��$��1��$��1��$��../Resources/Fit-1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Stop-1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Stop-2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��../Resources/Stop-1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/上_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/上_2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��../Resources/上_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $# ../Resources/media_back_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $# ../Resources/media_back_2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$#��../Resources/media_back_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Fit-1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/Fit-2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��../Resources/Fit-1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8�� .+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��1��$��Uniform=����� *mediaBtn_play_pause+�� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/下_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $ ../Resources/下_2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��../Resources/下_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $# ../Resources/media_jump_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $# ../Resources/media_jump_2.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$#��../Resources/media_jump_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $3 -../Resources/rotating-arrow-to-the-left_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $3 -../Resources/rotating-arrow-to-the-left_1.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$3��-../Resources/rotating-arrow-to-the-left_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8��  :� $ Grid.MouseEnter��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $% ../Resources/cancel-music_1.png?�:� $ MouseLeftButtonDown��.[��� .���� .��T� $ HoldEnd=�$ 	ImageName��$ Source�$ 0:0:0.3D�..�i� $ 0:0:0�� �� $% ../Resources/cancel-music_1.png?�.+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$%��../Resources/cancel-music_1.png��$��Uniform=��� 8	   "  ��.���  � �� �� "
 ��.R�� 
������  . 8�� .+��  �� $
��0.2* ��� �� $
��0.2* �.+��� $��	ImageName��$��1��$��Uniform=����� *mediaBar_volume_btn_sourcce+�� "  ��.���  � ��$ 2q���  � {� . ��  �@J�SnapsToDevicePixels . ��  � y� �� *
Visible1+�� "  ��.���  � �� �� "
 ��.R�� 
������  . .+��� $��	ImageName��$��1��$��0,8,0,8q�$��../Resources/上_1.png��$��Uniform=� :� $ Image.MouseLeftButtonDown��.[��� .���� .��T� $ 0:0:0X�$ (Source)�..�i� $ 0:0:0�� �� $ ../Resources/上_2.png?�:� $ Image.MouseLeftButtonUp��.[��� .���� .��T� $ 0:0:0X�$ (Image.Source)�..�i� $ 0:0:0�� �� $ ../Resources/上_1.png?�