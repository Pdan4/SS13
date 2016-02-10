// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_BombSuit : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bombsuit";
			this.w_class = 4;
			this.gas_transfer_coefficient = 0.01;
			this.permeability_coefficient = 0.01;
			this.slowdown = 2;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 100 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.max_heat_protection_temperature = 600;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "bombsuit";
		}

		public Obj_Item_Clothing_Suit_BombSuit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}