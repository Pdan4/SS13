// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza_Sassysage : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizzaslice_Sassysage);
			this.bonus_reagents = new ByTable().Set( "nutriment", 6 ).Set( "vitamin", 6 );
			this.icon_state = "sassysagepizza";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza_Sassysage ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}