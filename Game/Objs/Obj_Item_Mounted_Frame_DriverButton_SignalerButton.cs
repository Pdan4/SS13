// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Mounted_Frame_DriverButton_SignalerButton : Obj_Item_Mounted_Frame_DriverButton {

		public double code = 30;
		public dynamic frequency = 1457;

		public Obj_Item_Mounted_Frame_DriverButton_SignalerButton ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: driver_button.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Device_Assembly_Signaler I = null;

			
			if ( a is Obj_Item_Weapon_Wrench ) {
				new Obj_Item_Stack_Sheet_Metal( GlobalFuncs.get_turf( this.loc ) );
				I = new Obj_Item_Device_Assembly_Signaler( GlobalFuncs.get_turf( this.loc ) );
				I.code = this.code;
				I.frequency = this.frequency;
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: driver_button.dm
		public override void do_build( dynamic on_wall = null, dynamic user = null ) {
			Obj_Item_Device_Assembly_Signaler_SignalerButton I = null;

			I = new Obj_Item_Device_Assembly_Signaler_SignalerButton( GlobalFuncs.get_turf( user ), Map13.GetDistance( user, on_wall ) );
			I.code = this.code;
			I.frequency = this.frequency;
			GlobalFuncs.qdel( this );
			return;
		}

	}

}