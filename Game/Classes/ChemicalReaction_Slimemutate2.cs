// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimemutate2 : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Mutation Toxin";
			this.id = "mutationtoxin2";
			this.result = "amutationtoxin";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_other = true;
			this.required_container = typeof(Obj_Item_SlimeExtract_Black);
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			return;
		}

	}

}