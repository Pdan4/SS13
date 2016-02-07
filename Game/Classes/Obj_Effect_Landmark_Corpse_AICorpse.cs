// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_AICorpse : Obj_Effect_Landmark_Corpse {

		public Obj_Effect_Landmark_Corpse_AICorpse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: corpse.dm
		public override void createCorpse( bool death = false, string ckey = null ) {
			dynamic A = null;
			AiLaws_Default_Asimov L = null;
			Obj_Item_Device_Mmi B = null;
			Mob_Living_Silicon_Ai M = null;

			A = Lang13.FindIn( typeof(Mob_Living_Silicon_Ai), this.loc );

			if ( Lang13.Bool( A ) ) {
				return;
			}
			L = new AiLaws_Default_Asimov();
			B = new Obj_Item_Device_Mmi();
			M = new Mob_Living_Silicon_Ai( this.loc, L, B, true );
			M.name = this.name;
			M.real_name = this.name;
			M.aiPDA.toff = true;
			M.death();
			GlobalFuncs.qdel( this );
			return;
		}

	}

}