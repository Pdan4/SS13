// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Slime : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "slimejelly", 5 ).Set( "vitamin", 5 );
			this.list_reagents = new ByTable().Set( "nutriment", 5 ).Set( "slimejelly", 5 ).Set( "water", 5 ).Set( "vitamin", 4 );
			this.icon_state = "slimesoup";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Slime ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}