// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Reflector_Box : Obj_Structure_Reflector {

		public dynamic box_rotations = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.finished = true;
			this.buildstacktype = typeof(Obj_Item_Stack_Sheet_Mineral_Diamond);
			this.buildstackamount = 1;
			this.icon_state = "reflector_box";
		}

		public Obj_Structure_Reflector_Box ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: reflector.dm
		public override bool get_reflection( int srcdir = 0, dynamic pdir = null ) {
			dynamic new_dir = null;

			new_dir = GlobalVars.box_rotations["" + srcdir]["" + pdir];
			return Lang13.Bool( new_dir );
		}

	}

}