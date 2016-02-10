// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Vox : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoStorage), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Melee_Energy_Sword), 
				typeof(Obj_Item_Weapon_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank)
			 });
			this.slowdown = 2;
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 30 );
			this.max_heat_protection_temperature = 5000;
			this.species_restricted = new ByTable(new object [] { "Vox" });
		}

		public Obj_Item_Clothing_Suit_Space_Vox ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}