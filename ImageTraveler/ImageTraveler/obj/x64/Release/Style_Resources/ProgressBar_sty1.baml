   M S B A M L   `   `   `  ����   ImageTraveler4    .ImageTraveler.Style_Resources.ProgressBar_sty1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 	Resources     SliderButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType  SliderThumbStyle��%�  &	        &	 �     �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 18����  � ��$ 18����  � �� �� " n�.R�� .+�A� $��4��$��15��$��0,3,0,0q�
����  �A� $��12��$��15��$��	-0,-4,0,0q�
����  �.��� .+��� .+��� -    ��Name$ MySlider��$��-6,0,0,0q� � Maximum$ 10Q� � Value$ 1Q����� " ��.R��  � RowDefinitions �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� 	 m�Name$	 TopTick��$��4��
 m� 	Placement$	
 Top=� J� SnapsToDevicePixels . $y�	Collapsed=���  ��Name$ TrackBackground��$��1��$��4��$��0q�$��1q� �� CornerRadius$ 2��]�  ]�Name$ 
PART_Track��$��1�� ]� DecreaseRepeatButton �� $��Slider.DecreaseLarge��#��[   ]� Thumb n� #��[  ]� IncreaseRepeatButton �� $��Slider.IncreaseLarge��#��[  m� $	 
BottomTick��$��2��$��4�� m� Fill# z��$
 Bottom=� . $y�	Collapsed=� �� Triggers P�  P� Property �@��TickPlacement P� Value$ TopLeft=�. ���  �� 
TargetName$ TopTick�� � y�$ Visible=�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=�� -    �Name$ MyProgressBar��$��12��
�������
������ 
����  �$	 100Q� �� *Value+ �� ElementName$ MySlider���  � ColumnDefinitions �� �� �� �� �� .+�A� $��4��$��4��$��Right=�
����ح�A� $��1��$��4��$��4��$��Right=�
����ح�A� $��2��$��4��$��4��$��Right=�
����ح�A� $��3��$��4��$��4��$��Right=�
����ح�