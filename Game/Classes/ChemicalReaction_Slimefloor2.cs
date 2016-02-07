// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimefloor2 : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bluespace Floor";
			this.id = "m_floor2";
			this.required_reagents = new ByTable().Set( "blood", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Bluespace);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Item_Stack_Tile_Bluespace P = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			P = new Obj_Item_Stack_Tile_Bluespace();
			P.amount = 25;
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}