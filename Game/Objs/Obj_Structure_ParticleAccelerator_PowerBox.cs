// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_ParticleAccelerator_PowerBox : Obj_Structure_ParticleAccelerator {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.desc_holder = "This uses electromagnetic waves to focus the Alpha-Particles.";
			this.reference = "power_box";
			this.icon_state = "power_box";
		}

		public Obj_Structure_ParticleAccelerator_PowerBox ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: particle_power.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			base.update_icon( (object)(location), (object)(target) );
			return null;
		}

	}

}