// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_OdysseusLeftLeg : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Left Leg (\"Odysseus\")";
			this.id = "odysseus_left_leg";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_OdysseusLeftLeg);
			this.materials = new ByTable().Set( "$metal", 7000 );
			this.construction_time = 130;
			this.category = new ByTable(new object [] { "Odysseus" });
		}

	}

}