// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paint_Anycolor : Obj_Item_Weapon_Paint {

		public Obj_Item_Weapon_Paint_Anycolor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: paint.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic t1 = null;

			t1 = Interface13.Input( user, "Please select a color:", "Locking Computer", null, new ByTable(new object [] { "red", "blue", "green", "yellow", "violet", "black", "white" }), InputType.Any );

			if ( ((Mob)user).get_active_hand() != this || Lang13.Bool( user.stat ) || ((Mob)user).restrained() ) {
				return null;
			}

			dynamic _a = t1; // Was a switch-case, sorry for the mess.
			if ( _a=="red" ) {
				this.item_color = "C73232";
			} else if ( _a=="blue" ) {
				this.item_color = "5998FF";
			} else if ( _a=="green" ) {
				this.item_color = "2A9C3B";
			} else if ( _a=="yellow" ) {
				this.item_color = "CFB52B";
			} else if ( _a=="violet" ) {
				this.item_color = "AE4CCD";
			} else if ( _a=="white" ) {
				this.item_color = "FFFFFF";
			} else if ( _a=="black" ) {
				this.item_color = "333333";
			}
			this.icon_state = "paint_" + t1;
			this.add_fingerprint( user );
			return null;
		}

	}

}