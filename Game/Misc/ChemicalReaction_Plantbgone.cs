// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Plantbgone : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Plant-B-Gone";
			this.id = "plantbgone";
			this.result = "plantbgone";
			this.required_reagents = new ByTable().Set( "toxin", 1 ).Set( "water", 4 );
			this.result_amount = 5;
		}

	}

}