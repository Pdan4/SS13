// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Cloak : Obj_Item_Clothing {

		public Obj_Item_Clothing_Cloak ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cloaks.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( "<span class='suicide'>" + user + " is strangling themself with " + this + "! It looks like they're trying to commit suicide.</span>" );
			return 8;
		}

	}

}