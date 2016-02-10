// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Inaprovaline : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Inaprovaline";
			this.id = "inaprovaline";
			this.result = "inaprovaline";
			this.required_reagents = new ByTable().Set( "oxygen", 1 ).Set( "carbon", 1 ).Set( "sugar", 1 );
			this.result_amount = 3;
		}

	}

}