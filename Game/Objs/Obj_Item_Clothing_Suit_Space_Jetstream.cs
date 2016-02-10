// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Jetstream : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "jetstream";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoStorage), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyNitrogen), 
				typeof(Obj_Item_Weapon_Cell)
			 });
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 30 );
			this.siemens_coefficient = 0.2;
			this.icon_state = "jetstream";
		}

		public Obj_Item_Clothing_Suit_Space_Jetstream ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}