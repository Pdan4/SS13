// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechMousetrapMortar : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "H.O.N.K Mousetrap Mortar";
			this.id = "mech_mousetrap_mortar";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_MousetrapMortar);
			this.materials = new ByTable().Set( "$metal", 20000 ).Set( "$bananium", 5000 );
			this.construction_time = 300;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}