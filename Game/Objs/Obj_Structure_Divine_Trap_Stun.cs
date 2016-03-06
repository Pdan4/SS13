// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Trap_Stun : Obj_Structure_Divine_Trap {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "trap-shock";
		}

		public Obj_Structure_Divine_Trap_Stun ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: traps.dm
		public override void trap_effect( Ent_Dynamic L = null ) {
			dynamic Lturf = null;

			((dynamic)L).WriteMsg( "<span class='danger'><B>You are paralyzed from the intense shock!</B></span>" );
			((Mob)L).Weaken( 5 );
			Lturf = GlobalFuncs.get_turf( L );
			new Obj_Effect_ParticleEffect_Sparks_Electricity( Lturf );
			new Obj_Effect_ParticleEffect_Sparks( Lturf );
			return;
		}

	}

}