// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Nettleseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "nettle";
			this.plantname = "Nettles";
			this.product = typeof(Obj_Item_Weapon_Grown_Nettle_Basic);
			this.lifespan = 30;
			this.endurance = 40;
			this.maturation = 6;
			this.production = 6;
			this.yield = 4;
			this.potency = 10;
			this.growthstages = 5;
			this.plant_type = 1;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Deathnettleseed) });
			this.icon_state = "seed-nettle";
		}

		public Obj_Item_Seeds_Nettleseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}