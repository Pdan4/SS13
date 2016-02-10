// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Borer : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Borer Egg Crate";
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_BorerEgg) });
			this.cost = 100;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure_Scisec);
			this.containername = "Borer egg crate";
			this.access = 55;
			this.group = "Science";
		}

	}

}