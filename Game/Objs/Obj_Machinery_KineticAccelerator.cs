// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_KineticAccelerator : Obj_Machinery {

		public double power = 0.5;
		public int maxspeed = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/kinetic_accel.dmi";
			this.icon_state = "linacc1";
		}

		public Obj_Machinery_KineticAccelerator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: kinetic_accelerator.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			
			if ( !( O is Ent_Dynamic ) ) {
				return null;
			}

			if ( O.throwing != 0 ) {
				O.throw_speed = Num13.MinInt( this.maxspeed, ((int)( O.throw_speed + this.power )) );
			}
			return null;
		}

	}

}