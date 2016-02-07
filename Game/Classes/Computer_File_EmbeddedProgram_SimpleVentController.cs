// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Computer_File_EmbeddedProgram_SimpleVentController : Computer_File_EmbeddedProgram {

		public dynamic airpump_tag = null;

		// Function from file: simple_vent_controller.dm
		public override int? process( dynamic seconds = null ) {
			return 0;
		}

		// Function from file: simple_vent_controller.dm
		public override void receive_user_command( dynamic command = null ) {
			Signal signal = null;
			Signal signal2 = null;
			Signal signal3 = null;

			
			dynamic _a = command; // Was a switch-case, sorry for the mess.
			if ( _a=="vent_inactive" ) {
				signal = new Signal();
				signal.data = new ByTable().Set( "tag", this.airpump_tag ).Set( "sigtype", "command" );
				signal.data["power"] = 0;
				this.post_signal( signal );
			} else if ( _a=="vent_pump" ) {
				signal2 = new Signal();
				signal2.data = new ByTable().Set( "tag", this.airpump_tag ).Set( "sigtype", "command" );
				signal2.data["stabalize"] = 1;
				signal2.data["power"] = 1;
				this.post_signal( signal2 );
			} else if ( _a=="vent_clear" ) {
				signal3 = new Signal();
				signal3.transmission_method = 1;
				signal3.data = new ByTable().Set( "tag", this.airpump_tag ).Set( "sigtype", "command" );
				signal3.data["purge"] = 1;
				signal3.data["power"] = 1;
				this.post_signal( signal3 );
			}
			return;
		}

	}

}