// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Gyro : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Gyro";
			this.id = "gyro";
			this.result = "gyro";
			this.required_reagents = new ByTable().Set( "greentea", 5 ).Set( "whiskey", 5 ).Set( "iron", 1 );
			this.result_amount = 10;
		}

	}

}