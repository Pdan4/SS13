// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Mimana : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.filling_color = "#C0C0C0";
			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "mutetoxin", 1 ).Set( "nothing", 1 ).Set( "vitamin", 1 );
			this.icon_state = "mimanabreadslice";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Mimana ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}