// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_CandyCorn : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 4 ).Set( "sugar", 2 );
			this.filling_color = "#FF8C00";
			this.icon_state = "candy_corn";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_CandyCorn ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}