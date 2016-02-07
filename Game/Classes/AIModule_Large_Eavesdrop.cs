// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_Eavesdrop : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Enhanced Surveillance";
			this.mod_pick_name = "eavesdrop";
			this.description = "Via a combination of hidden microphones and lip reading software, you are able to use your cameras to listen in on conversations.";
			this.cost = 30;
			this.one_time = true;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "surveillance" );
		}

	}

}