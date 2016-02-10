// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Whitebeets : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "whitebeet";
			this.seed_name = "white-beet";
			this.display_name = "white-beets";
			this.packet_icon = "seed-whitebeet";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Whitebeet) });
			this.plant_icon = "whitebeet";
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 0, 20 }) ).Set( "sugar", new ByTable(new object [] { 1, 5 }) );
			this.lifespan = 60;
			this.maturation = 6;
			this.production = 6;
			this.yield = 6;
			this.potency = 10;
			this.water_consumption = 6;
		}

	}

}