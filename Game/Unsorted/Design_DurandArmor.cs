// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandArmor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Armor (\"Durand\")";
			this.id = "durand_armor";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_DurandArmor);
			this.materials = new ByTable().Set( "$metal", 50000 ).Set( "$uranium", 30000 );
			this.construction_time = 600;
			this.category = new ByTable(new object [] { "Durand" });
		}

	}

}