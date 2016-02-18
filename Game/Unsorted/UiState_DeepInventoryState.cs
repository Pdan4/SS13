// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UiState_DeepInventoryState : UiState {

		// Function from file: deep_inventory.dm
		public override int can_use_topic( Game_Data src_object = null, dynamic user = null ) {
			
			if ( !((Ent_Static)user).contains( src_object ) ) {
				return -1;
			}
			return ((Mob)user).shared_ui_interaction( src_object );
		}

	}

}