   M S B A M L   `   `   `  ????J  FWPF Tic Tac Toe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_Tic_Tac_ToeWPF_Tic_Tac_Toe  5   	        WPF_Tic_Tac_Toe.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_Tic_Tac_Toe     5   	     ? Title$  	Home Page??5   	   $
??1280??6   $	??720??6(    ? WindowStartupLocation$ CenterScreen=?65    ? 	Resources 5	         FocusVisual ?? Property ?? Value ?? StrokeDashArray J? SnapsToDevicePixels  Button.Static.Background ?? Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 ?? 
TargetType	 ?? 
TargetType
 ??Name ?? CornerRadius J? Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   RenderingBias   ShadowDepth   Color ??Name ?? Triggers P? Property P? Value ?? 
TargetName??%V  &	        &	 ?     &	 ?     &	 ?     &	     &	 ?    &	 b    &	 ?    &	 ?    &		 ?    &	
 ?    7   7  7  7  7  7  7  7 	 ?? 5
   
   .?5      ??  ? ?? 5      ?? 5      .R?5      ?? $??2q?6$   $	 1 2R?6/   #??? ??6E   $
 true??6?   $??1??6?   5      5      5      ?? 5   
   $ 	#FFDDDDDD??6;   ?? 5   
   $ 	#FF707070??67   ?? 5   
   $ 	#FFBEE6FD??6>   ?? 5   
   $ 	#FF3C7FB1??6:   ?? 5   
   $ 	#FFC4E5F6??6<   ?? 5   
   $ 	#FF2C628B??68   ?? 5   
   $ 	#FFF4F4F4??6=   ?? 5   
   $ 	#FFADB2B5??69   ?? 5   
   $ 	#FF838383??6=   ?? 5   
   " ??6%   .?5      ??  ?@?FocusVisualStyle8   61   ?? 5       ? ?? 6,   Z? ?? 5       ? ??$ 1q?60   ?? 5        ? ??$	 233??6&   ?? 5!       ? ??$ 50??6'   ?? 5"       ? ??$ Consolas)?6+   ?? 5#       ? ??$ 36(?6)   ?? 5$       ? ??$
 Bold"?6+   ?? 5%       ? ??$ 0,0,0,0q?6'   ?? 5&       ? ??$ 1q?6(   ?? 5'       ? ?? 5(      ?? 5)      "	 ??6&   .R?5*      ?? $
 border??6!   #??z??61   #??z??6[   #??z??6?   $
 true??6?   $ 20,20,20,20??6?    5+        5,   "   $ 15Q?63   $	 -90Q?6C   $ Quality=?6T   $ 2Q?6m   $ Black??6~   ._?5.      ?? $ contentPresenter??6/   $|?False??6I   #??z??6[   #??z??6?   $
??True??6?   # z 6?   #??z??6  5/       50      P? 51       ?@??IsDefaulted$
 true??6=   . ?52   "   ?? $ border??6@   # ? ??6T    ? ??53      P? 54       ?@J?IsMouseOver$
 true??6=   . ?55   "   ?? $ border??6?   8   ? ??6S   ?? 56   "   $ border??6@   8   ? ??6T   57      P? 58       ? ??$
 true??6;   . ?59   "   ?? $ border??6?   8   ? ??6S   ?? 5:   "   $ border??6@   8   ? ??6T   5;      P? 5<       ? {?$ false??6;   . ?5=   "   ?? $ border??6?   8   ? ??6S   ?? 5>   "   $ border??6@   8   ? ??6T   ?? 5?   "   $ contentPresenter??6K   8   ? ??6i   5@      5B      5D      5E      5F      .??5H      ? .+?5I   
   ? $??Center=?6   $??Bottom=?6,   $??0,0,0,40q?6G   $	??120??6Y   $	??534??6f   .+?5J      ?? -   5        #??? 
 5J      $??New Game??6<   ???	#FFFF2F41???	#FFF9FEFF$
??Left=?6}   $	??Top=?6?   6?   ?? 5K      -   5        #??? 
 5K      $??Setting??6<   ???	#FF1D3557???	#FFF9FEFF$??Right=?6|   $	??Top=?6?   6?   ?? 5L      -   5        #??? 
 5L      $??
High Score??6<   ???#F9FEFF???#1D3557$??Center=?6{   $??Bottom=?6?   6?   5M      ?? 5O   
   $??/img/logo.png??6   $	??437??6'   $	??443??63   $??Center=?6@   $	??Top=?6]   $??0,50,0,0q?6u   5P      5R      