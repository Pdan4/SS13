// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Banana : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Banana Juice";
			this.id = "banana";
			this.description = "The raw essence of a banana. HONK";
			this.color = "#863333";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( new ByTable(new object [] { "Clown" }).Contains( M is Mob_Living_Carbon_Human && Lang13.Bool( M.job ) ) || M is Mob_Living_Carbon_Monkey ) {
				((Mob_Living)M).heal_organ_damage( 1, 1 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}