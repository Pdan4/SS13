// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_HolodeckEffect : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
			this.icon = "icons/mob/screen_gen.dmi";
			this.icon_state = "x2";
		}

		public Obj_Effect_HolodeckEffect ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holo_effect.dm
		public virtual void safety( bool active = false ) {
			return;
		}

		// Function from file: holo_effect.dm
		public void tick( dynamic HC = null ) {
			return;
		}

		// Function from file: holo_effect.dm
		public virtual void deactivate( Obj_Machinery_Computer_Holodeck HC = null ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: holo_effect.dm
		public virtual dynamic activate( Obj_Machinery_Computer_Holodeck HC = null ) {
			return null;
		}

	}

}