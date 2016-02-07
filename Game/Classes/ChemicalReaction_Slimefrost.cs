// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimefrost : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Frost Oil";
			this.id = "m_frostoil";
			this.result = "frostoil";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 10;
			this.required_container = typeof(Obj_Item_SlimeExtract_Blue);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			return;
		}

	}

}