using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace FreshRyze
{
    public static class Orb
    {
        public static void Orbwalking_BeforeAttack(Orbwalking.BeforeAttackEventArgs args)
        {            
            if (args.Unit.IsMe)
            {                
                if (MainMenu._OrbWalker.ActiveMode == LeagueSharp.Common.Orbwalking.OrbwalkingMode.Combo && !MainMenu._MainMenu.Item("MCombo").GetValue<bool>())
                {
                    if(!Program.Q.IsReady() && !Program.W.IsReady() && !Program.W.IsReady())
                    {
                        args.Process = true;
                    } else
                    {
                        args.Process = false;
                    }                    
                }
                if (MainMenu._OrbWalker.ActiveMode == LeagueSharp.Common.Orbwalking.OrbwalkingMode.Mixed && MainMenu._MainMenu.Item("MHarass").GetValue<bool>() == false)
                {
                    args.Process = false;
                }
                if (MainMenu._OrbWalker.ActiveMode == LeagueSharp.Common.Orbwalking.OrbwalkingMode.LaneClear && MainMenu._MainMenu.Item("MClear").GetValue<bool>() == false)
                {
                    args.Process = false;
                }
            }
        }
    }
}
