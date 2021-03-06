// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Mimanaseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "mimana";
			this.plantname = "Mimana Tree";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mimana);
			this.lifespan = 50;
			this.endurance = 30;
			this.maturation = 6;
			this.production = 6;
			this.yield = 3;
			this.potency = 10;
			this.growthstages = 6;
			this.rarity = 10;
			this.icon_state = "seed-mimana";
		}

		public Obj_Item_Seeds_Mimanaseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}