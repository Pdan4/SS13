// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Friedegg : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 1 );
			this.bitesize = 1;
			this.filling_color = "#FFFFF0";
			this.list_reagents = new ByTable().Set( "nutriment", 3 );
			this.icon_state = "friedegg";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Friedegg ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}