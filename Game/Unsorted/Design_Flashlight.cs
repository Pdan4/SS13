// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Flashlight : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flashlight";
			this.id = "flashlight";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 20 );
			this.build_path = typeof(Obj_Item_Device_Flashlight);
			this.category = new ByTable(new object [] { "initial", "Tools" });
		}

	}

}