// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Table_Woodentable : Obj_Structure_Table {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.parts = typeof(Obj_Item_Weapon_TableParts_Wood);
			this.health = 50;
			this.autoignition_temperature = 573.1500244140625;
			this.fire_fuel = 5;
			this.icon_state = "woodtable";
		}

		public Obj_Structure_Table_Woodentable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tables_racks.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}