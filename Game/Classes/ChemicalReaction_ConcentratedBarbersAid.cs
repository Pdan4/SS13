// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_ConcentratedBarbersAid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "concentrated_barbers_aid";
			this.id = "concentrated_barbers_aid";
			this.result = "concentrated_barbers_aid";
			this.required_reagents = new ByTable().Set( "barbers_aid", 1 ).Set( "mutagen", 1 );
			this.result_amount = 2;
		}

	}

}