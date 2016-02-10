// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Condensedcapsaicin : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Condensed Capsaicin";
			this.id = "condensedcapsaicin";
			this.result = "condensedcapsaicin";
			this.required_reagents = new ByTable().Set( "capsaicin", 1 ).Set( "ethanol", 5 );
			this.result_amount = 5;
		}

	}

}