// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun_Energy), 
				typeof(Obj_Item_Weapon_ReagentContainers_Spray_Pepper), 
				typeof(Obj_Item_Weapon_Gun_Projectile), 
				typeof(Obj_Item_AmmoStorage), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Handcuffs), 
				typeof(Obj_Item_Weapon_Gun_Lawgiver)
			 });
			this.body_parts_covered = 6;
			this.max_heat_protection_temperature = 600;
			this.siemens_coefficient = 0.6;
		}

		public Obj_Item_Clothing_Suit_Armor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}