// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_DoctorDelight : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Doctor's Delight";
			this.id = "doctorsdelight";
			this.description = "A gulp a day keeps the Medibot away! A mixture of juices that heals most damage types fairly quickly at the cost of hunger.";
			this.color = "#FF8CFF";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjustBruteLoss( -0.5 );
			((Mob_Living)M).adjustFireLoss( -0.5 );
			((Mob_Living)M).adjustToxLoss( -0.5 );
			((Mob_Living)M).adjustOxyLoss( -0.5 );

			if ( M.nutrition != 0 && M.nutrition - 2 > 0 ) {
				
				if ( !( Lang13.Bool( M.mind ) && M.mind.assigned_role == "Medical Doctor" ) ) {
					M.nutrition -= 2;
				}
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}