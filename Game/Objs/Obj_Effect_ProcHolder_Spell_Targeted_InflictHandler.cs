// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_InflictHandler : Obj_Effect_ProcHolder_Spell_Targeted {

		public int amt_weakened = 0;
		public bool amt_paralysis = false;
		public double amt_stunned = 0;
		public int amt_dam_fire = 0;
		public int amt_dam_brute = 0;
		public bool amt_dam_oxy = false;
		public bool amt_dam_tox = false;
		public double amt_eye_blind = 0;
		public int amt_eye_blurry = 0;
		public string destroys = "none";
		public dynamic summon_type = null;

		public Obj_Effect_ProcHolder_Spell_Targeted_InflictHandler ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: inflict_handler.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living target = null;
			Mob_Living C_target = null;
			dynamic B = null;

			
			foreach (dynamic _b in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _b;
				
				GlobalFuncs.playsound( target, this.sound, 50, 1 );

				switch ((string)( this.destroys )) {
					case "gib":
						target.gib();
						break;
					case "gib_brain":
						
						if ( target is Mob_Living_Carbon_Human || target is Mob_Living_Carbon_Monkey ) {
							C_target = target;
							B = C_target.getorgan( typeof(Obj_Item_Organ_Internal_Brain) );

							if ( Lang13.Bool( B ) ) {
								B.loc = GlobalFuncs.get_turf( C_target );
								B.transfer_identity( C_target );
								((dynamic)C_target).internal_organs -= B;
							}
						}
						target.gib();
						break;
					case "disintegrate":
						target.dust();
						break;
				}

				if ( !( target != null ) ) {
					continue;
				}
				target.adjustBruteLoss( this.amt_dam_brute );
				target.adjustFireLoss( this.amt_dam_fire );
				target.adjustToxLoss( this.amt_dam_tox );
				target.adjustOxyLoss( this.amt_dam_oxy );
				target.Weaken( this.amt_weakened );
				target.Paralyse( this.amt_paralysis );
				target.Stun( this.amt_stunned );
				target.blind_eyes( this.amt_eye_blind );
				target.blur_eyes( this.amt_eye_blurry );

				if ( Lang13.Bool( this.summon_type ) ) {
					Lang13.Call( this.summon_type, target.loc, target );
				}
			}
			return false;
		}

	}

}