   M S B A M L   `   `   `  ????J  FWPF Tic Tac Toe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_Tic_Tac_ToeWPF_Tic_Tac_Toe  5   	       WPF_Tic_Tac_Toe.HighScore   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_Tic_Tac_Toe     5   	     ? Title$  	HighScore??5   	   $
??1280??6   $	??720??6(    ? WindowStartupLocation$ CenterScreen=?65    ? 	Resources 5	         ButtonStyle1 ?? 
TargetType ?? Property ?? Value ?? 
TargetType J? SnapsToDevicePixels J? Effect3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   	Direction   RenderingBias   ShadowDepth   Color ??Name??%  &	        ?? 5
   
   " ??6%   .?5      ??  ? ??$ Center=?6;   ?? 5       ? ??$ Center=?69   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? #??z??6!   #??z??6K   #??z??6w   $
 true??6?    5        5   "   $	 20Q?63   $	
 -90Q?6C   $ Quality=?6T   $ .7Q?6m   $ Black??6   ._?5      ?? $ contentPresenter??6/   $|?False??6I   #??z??6[   #??z??6?   $
??True??6?   # z 6?   #??z??6  5      5      5      5      5      .??5      ? .+?5   
   ?? $	??674??6   $	??585??6   ???#1D3557 ?? CornerRadius$ 20,20,20,20??6?   ??6Z   Z? ._?5      ?  ? RowDefinitions 5      ?? 5      $??0.13* ?6$   ?? 5       $??* ?6$   .+?5"      ?  ? ColumnDefinitions 5#      ?? 5$      $
??1.5* ?6+   ?? 5%      $??3* ?6+   ?? 5&      $??* ?6+   ?? 5'      $??* ?6+   .+?5)      ?? $	??140??6   $??50??6)   
???????$??Center=?6H   $??Center=?6e   $ 15,15,15,15??6?    5*        5+      $	 20Q?6/   $	
 -90Q?6?   $ Quality=?6P   $ .7Q?6i   $ Black??6{   ._?5-      ?? $??
High Score??6$   ???#1D3557 ?? TextAlignment$ Center=?6K   $??Center=?6b   $??Center=?6}   $??Consolas)?6?   $??24(?6?   5.      5/      ? 50      $??1??6   .+?51      ?? $	??510??6   $	??660??6*   $	??Top=?66   
???????$ 	0,0,15,15??6a   ??6z   Z? ._?52      &   System.Windows.Controls.DataGrid  -   5          Name$ ScoreDataGrid??52   ?     DataGridCell   	CellStyle# ?  6#     DataGridRowStyle1   RowStyle# ?  6N     DataGridColumnHeader   ColumnHeaderStyle# ?  6}      AutoGenerateColumns$ False??6/     CanUserAddRows$ False??6K  ??6?   Z? ??6?   Z?    Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54   "   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??65      CanUserResize$ False??6]      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? *name+6s     55   "   $ X Score??65   $ False??6a   $
 .20* 6w    6F   ?? *xScore+6w     56   "   $ O Score??65   $ False??6a   $
 .20* 6w    6F   ?? *oScore+6w   58      59      5:      5;      5<      ?? 5=   
   -   5        #???   5=      $
??Left=?68   $??80??6S   $??80??6_   $??	20,0,0,20q?6k   $??Bottom=?6~   ??6?   Z? ??6?   Z? .??5>      ?? $??img/back.png??6   5?      5@      5A      