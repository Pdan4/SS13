// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Singularity_Narsie_Large_Calm : Obj_Machinery_Singularity_Narsie_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announce = false;
			this.move_self = false;
		}

		// Function from file: narsie.dm
		public Obj_Machinery_Singularity_Narsie_Large_Calm ( dynamic loc = null, int? starting_energy = null, bool? temp = null ) : base( (object)(loc), starting_energy, temp ) {
			GlobalVars.narsie_cometh = true;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.narsie_cometh = false;
			return;
		}

		// Function from file: narsie.dm
		public override void pickcultist(  ) {
			
			if ( !this.move_self ) {
				return;
			} else {
				base.pickcultist();
			}
			return;
		}

	}

}