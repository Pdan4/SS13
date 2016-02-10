// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Dice_D4 : Obj_Item_Weapon_Dice {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.sides = 4;
			this.icon_state = "d4";
		}

		public Obj_Item_Weapon_Dice_D4 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: dice.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			
			if ( O is Mob_Living_Carbon_Human && !Lang13.Bool( ((dynamic)O).shoes ) ) {
				GlobalFuncs.to_chat( O, "<span class='danger'>You step on the D4!</span>" );
				((dynamic)O).apply_damage( 4, "brute", Rand13.Pick(new object [] { "l_leg", "r_leg" }) );
				((dynamic)O).Weaken( 3 );
			}
			return null;
		}

	}

}