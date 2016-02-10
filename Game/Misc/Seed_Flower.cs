// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Flower : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "harebells";
			this.seed_name = "harebell";
			this.display_name = "harebells";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Harebell) });
			this.packet_icon = "seed-harebell";
			this.plant_icon = "harebell";
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 20 }) );
			this.lifespan = 100;
			this.maturation = 7;
			this.production = 1;
			this.yield = 2;
			this.growth_stages = 4;
			this.nutrient_consumption = 0.15;
		}

	}

}