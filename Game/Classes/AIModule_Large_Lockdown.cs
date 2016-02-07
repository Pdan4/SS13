// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_Lockdown : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Hostile Station Lockdown";
			this.mod_pick_name = "lockdown";
			this.description = "Overload the airlock, blast door and fire control networks, locking them down. Caution! This command also electrifies all airlocks. The networks will automatically reset after 90 seconds.";
			this.cost = 30;
			this.one_time = true;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "lockdown" );
		}

	}

}