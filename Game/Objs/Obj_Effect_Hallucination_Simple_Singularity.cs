// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_Simple_Singularity : Obj_Effect_Hallucination_Simple {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.image_icon = "icons/effects/224x224.dmi";
			this.image_state = "singularity_s7";
			this.image_layer = 6;
			this.px = -96;
			this.py = -96;
		}

		public Obj_Effect_Hallucination_Simple_Singularity ( dynamic loc = null, Ent_Static T = null ) : base( (object)(loc), T ) {
			
		}

		// Function from file: Hallucination.dm
		public void Eat( dynamic OldLoc = null, dynamic Dir = null ) {
			int target_dist = 0;

			target_dist = Map13.GetDistance( this, this.target );

			if ( target_dist <= 3 ) {
				((dynamic)this.target).hal_screwyhud = 1;
				((dynamic)this.target).SetSleeping( 20 );
				Task13.Schedule( Rand13.Int( 50, 100 ), (Task13.Closure)(() => {
					((dynamic)this.target).hal_screwyhud = 0;
					((dynamic)this.target).SetSleeping( 0 );
					return;
				}));
			}
			return;
		}

	}

}