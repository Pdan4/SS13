// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Item_Staffdoor : SpellbookEntry_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Staff of Door Creation";
			this.desc = "A particular staff that can mold solid metal into ornate doors. Useful for getting around in the absence of other transportation. Does not work on glass.";
			this.item_path = typeof(Obj_Item_Weapon_Gun_Magic_Staff_Door);
			this.log_name = "SD";
			this.cost = 1;
			this.category = "Mobility";
		}

	}

}