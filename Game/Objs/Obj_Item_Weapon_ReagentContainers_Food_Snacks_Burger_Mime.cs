// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Mime : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 4 ).Set( "vitamin", 6 ).Set( "nothing", 6 );
			this.icon_state = "mimeburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Mime ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}