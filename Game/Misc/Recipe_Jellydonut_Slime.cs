// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Jellydonut_Slime : Recipe_Jellydonut {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "slimejelly", 5 ).Set( "flour", 5 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Slimejelly);
		}

	}

}