using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace FreshRyze
{
    class Program
    {
        public const string ChampName = "Ryze";
        public static Obj_AI_Hero Player { get { return ObjectManager.Player; } }
        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;
        public static HpBarIndicator Indicator = new HpBarIndicator();

        static void Main(string[] args)
        {
            Q = new Spell(SpellSlot.Q, 900);
            Q.SetSkillshot(0.25f, 50f, 1700, true, SkillshotType.SkillshotLine);
            W = new Spell(SpellSlot.W, 600);
            E = new Spell(SpellSlot.E,600);
            R = new Spell(SpellSlot.R);

            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (Player.ChampionName != ChampName)
            {
                Game.PrintChat(Player.ChampionName + ": No Support Champion");
                return;
            }

            MainMenu.Initialize();

            Drawing.OnDraw += OnDraw.Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            Game.OnUpdate += OnUpdate.OnGameUpdate;            
            AntiGapcloser.OnEnemyGapcloser += OnUpdate.AntiGapcloser_OnEnemyGapcloser;
            Orbwalking.BeforeAttack += Orb.Orbwalking_BeforeAttack;
        }

        static float getComboDamage(Obj_AI_Base enemy)
        {
            if (enemy != null)
            {
                float damage = 0;

                if (Q.IsReady())
                    damage += Q.GetDamage(enemy);
                if (W.IsReady())
                    damage += W.GetDamage(enemy);
                if (E.IsReady())
                    damage += E.GetDamage(enemy);
                if (R.IsReady())
                    damage += R.GetDamage(enemy);

                if (!Player.IsWindingUp)
                    damage += (float)Player.GetAutoAttackDamage(enemy, true);

                return damage;
            }
            return 0;
        }

        static void Drawing_OnEndScene(EventArgs args)
        {
            foreach (var enemy in ObjectManager.Get<Obj_AI_Hero>().Where(ene => ene.IsValidTarget() && !ene.IsZombie))
            {
                if (MainMenu._MainMenu.Item("Indicator").GetValue<bool>())
                {
                    Indicator.unit = enemy;
                    Indicator.drawDmg(getComboDamage(enemy), new ColorBGRA(255, 204, 0, 160));
                }
            }
        }
    }
}