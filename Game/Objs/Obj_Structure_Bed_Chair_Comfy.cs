// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bed_Chair_Comfy : Obj_Structure_Bed_Chair {

		public Image armrest = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "#ffffff";
			this.icon_state = "comfychair";
		}

		// Function from file: chair.dm
		public Obj_Structure_Bed_Chair_Comfy ( dynamic loc = null ) : base( (object)(loc) ) {
			this.armrest = new Image( "icons/obj/objects.dmi", "comfychair_armrest" );
			this.armrest.layer = 401;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: chair.dm
		public override void post_buckle_mob( dynamic M = null ) {
			
			if ( Lang13.Bool( this.buckled_mob ) ) {
				this.overlays.Add( this.armrest );
			} else {
				this.overlays.Remove( this.armrest );
			}
			return;
		}

	}

}