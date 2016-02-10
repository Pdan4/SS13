// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Excavationdrill : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Excavation Drill";
			this.desc = "Advanced archaeological drill combining ultrasonic excitation and bluespace manipulation to provide extreme precision. The diamond tip is adjustable from 1 to 30 cms.";
			this.id = "excavationdrill";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "powerstorage", 3 ).Set( "engineering", 3 ).Set( "bluespace", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 4000 ).Set( "$glass", 1000 ).Set( "$silver", 1000 ).Set( "$diamond", 500 );
			this.category = "Mining";
			this.build_path = typeof(Obj_Item_Weapon_Pickaxe_Excavationdrill);
		}

	}

}