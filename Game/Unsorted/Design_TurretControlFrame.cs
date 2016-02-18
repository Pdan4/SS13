// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_TurretControlFrame : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Turret control frame";
			this.id = "turret_control";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 12000 );
			this.build_path = typeof(Obj_Item_Wallframe_TurretControl);
			this.category = new ByTable(new object [] { "initial", "Construction" });
		}

	}

}