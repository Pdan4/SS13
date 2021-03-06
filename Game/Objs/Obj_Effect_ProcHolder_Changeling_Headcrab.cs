// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Headcrab : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "We will be placed in control of a small, fragile creature. We may attack a corpse like this to plant an egg which will slowly mature into a new form for us.";
			this.chemical_cost = 20;
			this.dna_cost = 1;
			this.req_human = true;
		}

		public Obj_Effect_ProcHolder_Changeling_Headcrab ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: headcrab.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			Mind M = null;
			ByTable organs = null;
			Obj_Item_Organ_Internal I = null;
			Mob_Living_Carbon_Human H = null;
			Mob_Living_Silicon S = null;
			dynamic turf = null;
			Mob_Living_SimpleAnimal_Hostile_Headcrab crab = null;
			Obj_Item_Organ_Internal I2 = null;

			M = user.mind;
			organs = user.getorganszone( "head", true );

			foreach (dynamic _a in Lang13.Enumerate( organs, typeof(Obj_Item_Organ_Internal) )) {
				I = _a;
				
				I.Remove( user, true );
			}
			GlobalFuncs.explosion( GlobalFuncs.get_turf( user ), 0, 0, 2, 0, null, null, null, true );

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( user, 2 ), typeof(Mob_Living_Carbon_Human) )) {
				H = _b;
				
				H.WriteMsg( "<span class='userdanger'>You are blinded by a shower of blood!</span>" );
				H.Stun( 1 );
				H.blur_eyes( 20 );
				H.adjust_eye_damage( 5 );
				H.confused += 3;
			}

			foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRange( user, 2 ), typeof(Mob_Living_Silicon) )) {
				S = _c;
				
				S.WriteMsg( "<span class='userdanger'>Your sensors are disabled by a shower of blood!</span>" );
				S.Weaken( 3 );
			}
			turf = GlobalFuncs.get_turf( user );
			Task13.Schedule( 5, (Task13.Closure)(() => {
				crab = new Mob_Living_SimpleAnimal_Hostile_Headcrab( turf );

				foreach (dynamic _d in Lang13.Enumerate( organs, typeof(Obj_Item_Organ_Internal) )) {
					I2 = _d;
					
					I2.loc = crab;
				}
				crab.origin = M;

				if ( crab.origin != null ) {
					crab.origin.active = true;
					crab.origin.transfer_to( crab );
					crab.WriteMsg( "<span class='warning'>You burst out of the remains of your former body in a shower of gore!</span>" );
				}
				return;
			}));
			user.gib();
			GlobalFuncs.feedback_add_details( "changeling_powers", "LR" );
			return 1;
		}

	}

}