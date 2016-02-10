// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Pacid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Polytrinic acid";
			this.id = "pacid";
			this.result = "pacid";
			this.required_reagents = new ByTable().Set( "sacid", 1 ).Set( "chlorine", 1 ).Set( "potassium", 1 );
			this.result_amount = 3;
		}

	}

}