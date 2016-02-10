// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Wizrobe : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "wizrobe";
			this.gas_transfer_coefficient = 0.01;
			this.permeability_coefficient = 0.01;
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 20 ).Set( "laser", 20 ).Set( "energy", 20 ).Set( "bomb", 20 ).Set( "bio", 20 ).Set( "rad", 20 );
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_TeleportationScroll) });
			this.siemens_coefficient = 0.8;
			this.wizard_garb = true;
			this.icon_state = "wizard";
		}

		public Obj_Item_Clothing_Suit_Wizrobe ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}