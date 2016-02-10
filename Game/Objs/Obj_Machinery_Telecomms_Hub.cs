// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Hub : Obj_Machinery_Telecomms {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 80;
			this.machinetype = 7;
			this.heatgen = 40;
			this.circuitboard = "/obj/item/weapon/circuitboard/telecomms/hub";
			this.long_range_link = true;
			this.netspeed = 40;
			this.icon_state = "hub";
		}

		public Obj_Machinery_Telecomms_Hub ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: telecomunications.dm
		public override void receive_information( Game_Data signal = null, Obj_Machinery_Telecomms machine_from = null ) {
			
			if ( this.is_freq_listening( signal ) ) {
				
				if ( machine_from is Obj_Machinery_Telecomms_Receiver ) {
					this.relay_information( signal, "/obj/machinery/telecomms/bus", true );
				} else {
					this.relay_information( signal, "/obj/machinery/telecomms/relay", true );
					this.relay_information( signal, "/obj/machinery/telecomms/broadcaster", true );
				}
			}
			return;
		}

	}

}