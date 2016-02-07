// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_SlimeTerritory : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Territory";
			this.id = "s_territory";
			this.required_reagents = new ByTable().Set( "blood", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Cerulean);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Item_Areaeditor_Blueprints_Slime P = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			P = new Obj_Item_Areaeditor_Blueprints_Slime();
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}