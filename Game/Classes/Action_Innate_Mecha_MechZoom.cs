// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_Mecha_MechZoom : Action_Innate_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Zoom";
			this.button_icon_state = "mech_zoom_off";
		}

		public Action_Innate_Mecha_MechZoom ( dynamic Target = null ) : base( (object)(Target) ) {
			
		}

		// Function from file: marauder.dm
		public override void Activate(  ) {
			Obj_Mecha M = null;

			
			if ( !Lang13.Bool( this.owner ) || !( this.chassis != null ) || this.chassis.occupant != this.owner ) {
				return;
			}
			M = this.chassis;

			if ( Lang13.Bool( this.owner.client ) ) {
				((dynamic)M).zoom = !Lang13.Bool( ((dynamic)M).zoom );
				this.button_icon_state = "mech_zoom_" + ( Lang13.Bool( ((dynamic)M).zoom ) ? "on" : "off" );
				M.log_message( "Toggled zoom mode." );
				M.occupant_message( "<font color='" + ( Lang13.Bool( ((dynamic)M).zoom ) ? "blue" : "red" ) + "'>Zoom mode " + ( Lang13.Bool( ((dynamic)M).zoom ) ? "en" : "dis" ) + "abled.</font>" );

				if ( Lang13.Bool( ((dynamic)M).zoom ) ) {
					this.owner.client.view = 12;
					this.owner.WriteMsg( new Sound( "sound/mecha/imag_enh.ogg", null, null, null, 50 ) );
				} else {
					this.owner.client.view = Convert.ToInt32( Game13.view );
				}
			}
			return;
		}

	}

}