using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;


namespace Fresh_LeBlanc
{
    class MainMenu
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;
        public static void Menu()
        {
            try // try start
            {
                _MainMenu = new Menu("프레시 르블랑", "FreshLeBlanc", true).SetFontStyle(System.Drawing.FontStyle.Regular, Color.Aqua); ;
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
                    Combo.AddItem(new MenuItem("CUse_WReturn", "W 복귀 사용").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_E", "E 사용").SetValue(true));
                    Combo.SubMenu("R 사용").AddItem(new MenuItem("CUse_Q2", "Q 사용").SetValue(true));
                    Combo.SubMenu("R 사용").AddItem(new MenuItem("CUse_W2", "W 사용").SetValue(true));
                    Combo.SubMenu("R 사용").AddItem(new MenuItem("CUse_W2Return", "W 복귀 사용").SetValue(true));
                    Combo.SubMenu("R 사용").AddItem(new MenuItem("CUse_E2", "E 사용").SetValue(true));
                    Combo.AddItem(new MenuItem("CUseE_Hit", "E 정확도").SetValue(new Slider(3, 1, 6)));
                    Combo.AddItem(new MenuItem("CKey", "콤보 키").SetValue(new KeyBind(32, KeyBindType.Press)));
                }
                _MainMenu.AddSubMenu(Combo);

                var Harass = new Menu("견제", "Harass");
                {
                    Harass.AddItem(new MenuItem("HKey", "견제 키").SetValue(new KeyBind('C', KeyBindType.Press)));
                    Harass.SubMenu("자동 견제").AddItem(new MenuItem("AUse_Q", "Q 사용").SetValue(true));
                    Harass.SubMenu("자동 견제").AddItem(new MenuItem("AUse_W", "W 사용").SetValue(true));
                    Harass.SubMenu("자동 견제").AddItem(new MenuItem("AUse_E", "E 사용").SetValue(true));
                    Harass.AddItem(new MenuItem("AManarate", "최소 마나 (%)").SetValue(new Slider(20)));
                    Harass.SubMenu("자동 견제").AddItem(new MenuItem("AHToggle", "자동 견제 (On/Off)").SetValue(false));
                }
                _MainMenu.AddSubMenu(Harass);

                var KillSteal = new Menu("킬스틸", "KillSteal");
                {
                    KillSteal.AddItem(new MenuItem("KUse_Q", "Q 사용").SetValue(true));
                    KillSteal.AddItem(new MenuItem("KUse_W", "W 사용").SetValue(true));
                    KillSteal.AddItem(new MenuItem("KUse_E", "E 사용").SetValue(true));
                    KillSteal.SubMenu("R 사용").AddItem(new MenuItem("KUse_Q2", "Q 사용").SetValue(true));
                    KillSteal.SubMenu("R 사용").AddItem(new MenuItem("KUse_W2", "W 사용").SetValue(true));
                    KillSteal.SubMenu("R 사용").AddItem(new MenuItem("KUse_E2", "E 사용").SetValue(true));
                }
                _MainMenu.AddSubMenu(KillSteal);

                var Misc = new Menu("기타", "Misc");
                {
                    Misc.AddItem(new MenuItem("ERCC", "CC로 E + R 사용").SetValue(new KeyBind('G', KeyBindType.Press)));
                    Misc.AddItem(new MenuItem("Flee", "W + R 도주").SetValue(new KeyBind('T', KeyBindType.Press)));
                    Misc.AddItem(new MenuItem("Pet", "패시브가 나와 적 사이로 이동").SetValue(true));
                }
                _MainMenu.AddSubMenu(Misc);

                var Draw = new Menu("드로잉", "Draw");
                {
                    Draw.AddItem(new MenuItem("Draw_Q", "Q 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_W", "W 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_E", "E 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Draw_WR", "W + R 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Indicator", "데미지 계산 드로잉").SetValue(true));
                    Draw.AddItem(new MenuItem("WTimer", "W 소멸시간 표시").SetValue(true));
                    Draw.AddItem(new MenuItem("REnable", "R 상태 표시 ").SetValue(true));
                }
                _MainMenu.AddSubMenu(Draw);
            } // try end     
            catch (Exception e)
            {
                Console.Write(e);
                Game.PrintChat("FreshLeBlanc is not working. plz send message by KorFresh (Code 1)");
            }

        }
    }
}
