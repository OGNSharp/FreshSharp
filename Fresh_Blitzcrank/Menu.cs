using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;


namespace Fresh_Britzcrank
{
    class MainMenu
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;
        public static void Menu()
        {
            try // try start
            {
                _MainMenu = new Menu("프레시 블리츠크랭크", "FreshBlitzcrank", true).SetFontStyle(System.Drawing.FontStyle.Regular, Color.Aqua); ; ;
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
                    Combo.AddItem(new MenuItem("CUse_E", "E 사용").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_R", "R 사용").SetValue(true));
                    Combo.AddItem(new MenuItem("CUseQ_Hit", "그랩정확도 (3추천)").SetValue(new Slider(6,1,6)));
                    Combo.AddItem(new MenuItem("CKey", "콤보 키").SetValue(new KeyBind(32, KeyBindType.Press)));
                }
                _MainMenu.AddSubMenu(Combo);                

                var Misc = new Menu("기타", "Misc");
                {                    
                    foreach(var enemy in ObjectManager.Get<Obj_AI_Hero>())
                    {
                        if(enemy.Team != Program.Player.Team)
                        {
                            Misc.SubMenu("그랩설정").AddItem(new MenuItem("GrabSelect" + enemy.ChampionName, enemy.ChampionName)).SetValue(new StringList(new[] { "사용", "미사용", "자동" }));
                        }
                    }
                    Misc.SubMenu("방해").AddItem(new MenuItem("InterQ", "Q 사용").SetValue(true));
                    Misc.SubMenu("방해").AddItem(new MenuItem("InterE", "E 사용").SetValue(true));
                    Misc.SubMenu("방해").AddItem(new MenuItem("InterR", "R 사용").SetValue(true));
                }
                _MainMenu.AddSubMenu(Misc);

                var Draw = new Menu("드로잉", "Draw");
                {
                    Draw.AddItem(new MenuItem("Draw_Q", "Q 사거리").SetValue(false));                    
                    Draw.AddItem(new MenuItem("Draw_R", "R 사거리").SetValue(false));
                    Draw.AddItem(new MenuItem("Indicator", "데미지 계산 드로잉").SetValue(true));
                }
                _MainMenu.AddSubMenu(Draw);
            } // try end     
            catch (Exception e)
            {
                Console.Write(e);
                Game.PrintChat("FreshBlitzcrank is not working. plz send message by KorFresh (Code 1)");
            }           
            
        }
    }
}
