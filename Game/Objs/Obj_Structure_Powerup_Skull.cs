// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Powerup_Skull : Obj_Structure_Powerup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "skull";
		}

		public Obj_Structure_Powerup_Skull ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bomberman.dm
		public override void apply_power( dynamic dispenser = null ) {
			ByTable diseases = null;
			dynamic disease = null;
			Mob_Living L_other = null;
			dynamic target = null;
			Ent_Static L_self = null;
			dynamic T_self = null;
			dynamic T_other = null;
			Ent_Static M = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/bomberman/disease.ogg", 50, 1 );
			diseases = new ByTable(new object [] { "Low Power Disease", "Constipation ", "Diarrhea", "Slow Pace Disease", "Rapid Pace Disease", "Change", "Fire" });
			disease = Rand13.PickFromTable( diseases );
			GlobalFuncs.to_chat( dispenser.loc, "<span class='danger'>" + disease + ( disease != "Fire" && disease != "Change" ? " for 40 seconds" : "" ) + "!!</span>" );

			dynamic _b = disease; // Was a switch-case, sorry for the mess.
			if ( _b=="Low Power Disease" ) {
				dispenser.small_bomb = true;
				dispenser.cure( disease );
			} else if ( _b=="Constipation" ) {
				dispenser.no_bomb = true;
				dispenser.cure( disease );
			} else if ( _b=="Diarrhea" ) {
				dispenser.spam_bomb = true;
				dispenser.cure( disease );
			} else if ( _b=="Slow Pace Disease" ) {
				dispenser.slow = true;
				dispenser.cure( disease );
			} else if ( _b=="Rapid Pace Disease" ) {
				dispenser.fast = true;
				dispenser.speed_bonus = 10;
				dispenser.cure( disease );
			} else if ( _b=="Change" ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
					L_other = _a;
					
					target = Lang13.FindIn( typeof(Obj_Item_Weapon_Bomberman), L_other );

					if ( Lang13.Bool( target ) ) {
						L_self = this.loc;
						T_self = GlobalFuncs.get_turf( L_self );
						T_other = GlobalFuncs.get_turf( L_other );
						L_self.loc = T_other;
						L_other.loc = T_self;
						GlobalFuncs.playsound( T_self, "sound/bomberman/disease.ogg", 50, 1 );
						GlobalFuncs.playsound( T_other, "sound/bomberman/disease.ogg", 50, 1 );
						GlobalFuncs.qdel( this );
						return;
					}
				}
			} else if ( _b=="Fire" ) {
				
				if ( dispenser.loc is Mob_Living_Carbon ) {
					M = dispenser.loc;
					((dynamic)M).adjust_fire_stacks( 0.5 );
					M.on_fire = true;
					((dynamic)M).update_icon = 1;
					GlobalFuncs.playsound( M.loc, "sound/effects/bamf.ogg", 50, 0 );
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}