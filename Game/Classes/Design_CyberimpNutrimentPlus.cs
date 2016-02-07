// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CyberimpNutrimentPlus : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nutriment pump implant PLUS";
			this.desc = "This implant with synthesize and pump into your bloodstream a small amount of nutriment when you are hungry.";
			this.id = "ci-nutrimentplus";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "programming", 4 ).Set( "biotech", 6 );
			this.build_type = 18;
			this.construction_time = 50;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$gold", 500 ).Set( "$uranium", 750 );
			this.build_path = typeof(Obj_Item_Organ_Internal_Cyberimp_Chest_Nutriment_Plus);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}