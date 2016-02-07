// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Skeleton_Eskimo : Mob_Living_SimpleAnimal_Hostile_Skeleton {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "eskimo";
			this.icon_dead = "eskimo_dead";
			this.maxHealth = 55;
			this.health = 55;
			this.melee_damage_lower = 17;
			this.melee_damage_upper = 20;
			this.deathmessage = "The skeleton collaspes into a pile of bones, its gear falling to the floor!";
			this.loot = new ByTable(new object [] { 
				typeof(Obj_Effect_Decal_Remains_Human), 
				typeof(Obj_Item_Weapon_Twohanded_Spear), 
				typeof(Obj_Item_Clothing_Shoes_Winterboots), 
				typeof(Obj_Item_Clothing_Suit_Hooded_Wintercoat)
			 });
			this.icon_state = "eskimo";
		}

		public Mob_Living_SimpleAnimal_Hostile_Skeleton_Eskimo ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}