// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_SlimeCorpse : Obj_Effect_Landmark_Corpse {

		public string mobcolour = "grey";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/mob/slimes.dmi";
			this.icon_state = "grey baby slime";
		}

		public Obj_Effect_Landmark_Corpse_SlimeCorpse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: corpse.dm
		public override void createCorpse( bool death = false, string ckey = null ) {
			dynamic A = null;
			Mob_Living_SimpleAnimal_Slime M = null;

			A = Lang13.FindIn( typeof(Mob_Living_SimpleAnimal_Slime), this.loc );

			if ( Lang13.Bool( A ) ) {
				return;
			}
			M = new Mob_Living_SimpleAnimal_Slime( this.loc );
			M.colour = this.mobcolour;
			M.adjustToxLoss( 9001 );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}