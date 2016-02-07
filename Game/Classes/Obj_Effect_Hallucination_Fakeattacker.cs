// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_Fakeattacker : Obj_Effect_Hallucination {

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_Fakeattacker ( dynamic loc = null, Mob_Living_Carbon T = null ) : base( (object)(loc) ) {
			Mob_Living_Carbon_Human clone = null;
			string clone_weapon = null;
			Mob_Living_Carbon_Human H = null;
			Obj_Effect_FakeAttacker F = null;

			this.target = T;
			clone = null;
			clone_weapon = null;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Carbon_Human) )) {
				H = _a;
				

				if ( H.stat != 0 || Lang13.Bool( H.lying ) ) {
					continue;
				}
				clone = H;
				break;
			}

			if ( !( clone != null ) ) {
				return;
			}
			F = new Obj_Effect_FakeAttacker( GlobalFuncs.get_turf( this.target ), this.target );

			if ( Lang13.Bool( clone.l_hand ) ) {
				
				if ( !Lang13.Bool( Lang13.FindIn( clone.l_hand, GlobalVars.non_fakeattack_weapons ) ) ) {
					clone_weapon = clone.l_hand.name;
					F.weap = clone.l_hand;
				}
			} else if ( Lang13.Bool( clone.r_hand ) ) {
				
				if ( !Lang13.Bool( Lang13.FindIn( clone.r_hand, GlobalVars.non_fakeattack_weapons ) ) ) {
					clone_weapon = clone.r_hand.name;
					F.weap = clone.r_hand;
				}
			}
			F.name = clone.name;
			F.my_target = this.target;
			F.weapon_name = clone_weapon;
			F.left = new Image( clone, null, null, null, GlobalVars.WEST );
			F.right = new Image( clone, null, null, null, GlobalVars.EAST );
			F.up = new Image( clone, null, null, null, GlobalVars.NORTH );
			F.down = new Image( clone, null, null, null, GlobalVars.SOUTH );
			F.updateimage();
			GlobalFuncs.qdel( this );
			return;
		}

	}

}