// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Aloe : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Aloe";
			this.id = "aloe";
			this.result = "aloe";
			this.required_reagents = new ByTable().Set( "cream", 1 ).Set( "whiskey", 1 ).Set( "watermelonjuice", 1 );
			this.result_amount = 2;
		}

	}

}