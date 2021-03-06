// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Atropine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Atropine";
			this.id = "atropine";
			this.result = "atropine";
			this.required_reagents = new ByTable().Set( "ethanol", 1 ).Set( "acetone", 1 ).Set( "diethylamine", 1 ).Set( "phenol", 1 ).Set( "sacid", 1 );
			this.result_amount = 5;
		}

	}

}