using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;


namespace Fresh_Janna
{
    class MainMenu
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;
        public static void Menu()
        {
            try // try start
            {
                _MainMenu = new Menu("프레시 잔나", "FreshJanna", true).SetFontStyle(System.Drawing.FontStyle.Regular, Color.Aqua); ; ;
                _MainMenu.AddToMainMenu();

                Menu orbwalkerMenu = new Menu("오브워커", "OrbWalker");
                _OrbWalker = new Orbwalking.Orbwalker(orbwalkerMenu);
                _MainMenu.AddSubMenu(orbwalkerMenu);

                var targetSelectorMenu = new Menu("타겟셀렉터", "TargetSelector");
                TargetSelector.AddToMenu(targetSelectorMenu);
                _MainMenu.AddSubMenu(targetSelectorMenu);

                var Combo = new Menu("콤보", "Combo");
                {
                    Combo.AddItem(new MenuItem("CUse_Q", "Q 사용").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_W", "W 사용").SetValue(true));                    
                    Combo.AddItem(new MenuItem("CKey", "콤보 키").SetValue(new KeyBind(32, KeyBindType.Press)));
                }
                _MainMenu.AddSubMenu(Combo);

                var Misc = new Menu("기타", "Misc");
                {
                    Misc.AddItem(new MenuItem("Flee", "도주 키").SetValue(new KeyBind('G', KeyBindType.Press)));
                    Misc.AddItem(new MenuItem("AutoE", "자동 E").SetValue(true));
                    Misc.SubMenu("자동 R").AddItem(new MenuItem("AutoRHP", "최소 체력 (%)").SetValue(new Slider(10,0,100)));
                    Misc.SubMenu("자동 R").AddItem(new MenuItem("AutoREnable", "{On/Off)").SetValue(true));
                    Misc.SubMenu("방해").AddItem(new MenuItem("InterQ", "Q 사용").SetValue(true));
                    Misc.SubMenu("방해").AddItem(new MenuItem("InterR", "R 사용").SetValue(true));
                    Misc.SubMenu("안티 갭클로저").AddItem(new MenuItem("GapQ", "Q 사용").SetValue(true));
                    Misc.SubMenu("안티 갭클로저").AddItem(new MenuItem("GapR", "R 사용").SetValue(true));
                }
                _MainMenu.AddSubMenu(Misc);

                var Draw = new Menu("드로잉", "Draw");
                {
                    Draw.AddItem(new MenuItem("Draw_Q", "Q 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_W", "W 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_E", "E 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_R", "R 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Indicator", "데미지 계산 드로잉").SetValue(true));
                }
                _MainMenu.AddSubMenu(Draw);
            } // try end     
            catch (Exception e)
            {
                Console.Write(e);
                Game.PrintChat("FreshJanna is not working. plz send message by KorFresh (Code 1)");
            }

        }
    }
}
