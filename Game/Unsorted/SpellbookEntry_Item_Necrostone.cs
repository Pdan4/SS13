// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Item_Necrostone : SpellbookEntry_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "A Necromantic Stone";
			this.desc = "A Necromantic stone is able to resurrect three dead individuals as skeletal thralls for you to command.";
			this.item_path = typeof(Obj_Item_Device_NecromanticStone);
			this.log_name = "NS";
			this.category = "Assistance";
		}

	}

}