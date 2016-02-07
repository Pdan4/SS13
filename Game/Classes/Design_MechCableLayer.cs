// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechCableLayer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Engineering Equipment (Cable Layer)";
			this.id = "mech_cable_layer";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_CableLayer);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}