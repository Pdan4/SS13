// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Mushroom : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "mushrooms";
			this.seed_name = "chanterelle";
			this.seed_noun = "spores";
			this.display_name = "chanterelle mushrooms";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Chanterelle) });
			this.mutants = new ByTable(new object [] { "reishi", "amanita", "plumphelmet" });
			this.packet_icon = "mycelium-chanter";
			this.plant_icon = "chanter";
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 25 }) );
			this.lifespan = 35;
			this.maturation = 7;
			this.production = 1;
			this.yield = 5;
			this.growth_stages = 3;
			this.water_consumption = 6;
			this.light_tolerance = 6;
			this.ideal_heat = 288;
		}

	}

}