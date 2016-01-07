
using LeagueSharp.Common;
using SharpDX;


namespace FreshRyze
{
    public static class MainMenu
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;

        public static void Initialize()
        {
            _MainMenu = new Menu("프레시 라이즈", "Ryze", true).SetFontStyle(System.Drawing.FontStyle.Regular, Color.Aqua); ;

            Menu orbwalkerMenu = new Menu("오브워커", "OrbWalker");
            _OrbWalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            _MainMenu.AddSubMenu(orbwalkerMenu);

            var targetSelectorMenu = new Menu("타겟셀렉터", "TargetSelector");
            TargetSelector.AddToMenu(targetSelectorMenu);
            _MainMenu.AddSubMenu(targetSelectorMenu);

            var Melee = new Menu("평타사용여부", "Melee Attack");
            {
                Melee.AddItem(new MenuItem("MCombo", "콤보").SetValue(true));
                Melee.AddItem(new MenuItem("MHarass", "견제").SetValue(true));
                Melee.AddItem(new MenuItem("MClear", "클리어").SetValue(true));
            }
            _MainMenu.AddSubMenu(Melee);

            var Combo = new Menu("콤보", "Combo");
            {
                Combo.AddItem(new MenuItem("UseQ", "Q 사용").SetValue(true));
                Combo.AddItem(new MenuItem("UseW", "W 사용").SetValue(true));
                Combo.AddItem(new MenuItem("UseE", "E 사용").SetValue(true));
                Combo.AddItem(new MenuItem("UseR", "R 사용").SetValue(true));
                //Combo.AddItem(new MenuItem("ComboSelect", "Q is Collision").SetValue(true));                
            }
            _MainMenu.AddSubMenu(Combo);

            var Harass = new Menu("견제", "Harass");
            {
                Harass.AddItem(new MenuItem("HUseQ", "Q 사용").SetValue(true));
                Harass.AddItem(new MenuItem("HUseW", "W 사용").SetValue(true));
                Harass.AddItem(new MenuItem("HUseE", "E 사용").SetValue(true));
                Harass.AddItem(new MenuItem("HManaRate", "최소 마나 (%)").SetValue(new Slider(20)));
                Harass.AddItem(new MenuItem("AutoHarass", "자동 견제").SetValue(false));
            }
            _MainMenu.AddSubMenu(Harass);

            var LaneClear = new Menu("라인클리어", "LaneClear");
            {
                LaneClear.AddItem(new MenuItem("LUseQ", "Q 사용").SetValue(true));
                LaneClear.AddItem(new MenuItem("LUseW", "W 사용").SetValue(true));
                LaneClear.AddItem(new MenuItem("LUseE", "E 사용").SetValue(true));
                LaneClear.AddItem(new MenuItem("LManaRate", "최소마나 (%)").SetValue(new Slider(20)));
            }
            _MainMenu.AddSubMenu(LaneClear);

            var JungleClear = new Menu("정글클리어", "JungleClear");
            {
                JungleClear.AddItem(new MenuItem("JUseQ", "Q 사용").SetValue(true));
                JungleClear.AddItem(new MenuItem("JUseW", "W 사용").SetValue(true));
                JungleClear.AddItem(new MenuItem("JUseE", "E 사용").SetValue(true));
                JungleClear.AddItem(new MenuItem("JManaRate", "최소 마나 (%)").SetValue(new Slider(20)));
            }
            _MainMenu.AddSubMenu(JungleClear);

            var Misc = new Menu("기타", "Misc");
            {
                Misc.AddItem(new MenuItem("AutoStack", "자동 스택").SetValue(new Slider(0, 0, 4)));
                Misc.AddItem(new MenuItem("AutoLasthit", "Q,E 자동 막타").SetValue(false));
                Misc.AddItem(new MenuItem("WGap", "자동 W 안티갭클로저").SetValue(true));
                Misc.AddItem(new MenuItem("OnlyCombo", "(WEWQ)만 사용").SetValue(false));
            }
            _MainMenu.AddSubMenu(Misc);

            var Draw = new Menu("드로잉", "Draw");
            {
                Draw.AddItem(new MenuItem("QRange", "Q 사거리").SetValue(false));
                Draw.AddItem(new MenuItem("WRange", "W 사거리").SetValue(false));
                Draw.AddItem(new MenuItem("ERange", "E 사거리").SetValue(false));
                Draw.AddItem(new MenuItem("DisplayStack", "스택 표시").SetValue(true));
                Draw.AddItem(new MenuItem("DisplayTime", "스택소멸시간 표시").SetValue(true));
                Draw.AddItem(new MenuItem("Indicator", "데미지 계산 드로잉").SetValue(true));
            }
            _MainMenu.AddSubMenu(Draw);

            var Sign = new Menu("KorFresh 제작", "");
            {
                Sign.AddItem(new MenuItem("1", "L# Forum: KorFresh"));
                Sign.AddItem(new MenuItem("2", "EMail: KorFresh@naver.com"));
                Sign.AddItem(new MenuItem("3", "Page: http://korfresh.com"));
            }
            _MainMenu.AddSubMenu(Sign);

            _MainMenu.AddToMainMenu();
        }
    }
}
