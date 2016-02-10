// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Cocoa : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "cocoa";
			this.seed_name = "cacao";
			this.display_name = "cacao tree";
			this.packet_icon = "seed-cocoapod";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cocoapod) });
			this.plant_icon = "cocoapod";
			this.harvest_repeat = 1;
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 10 }) ).Set( "coco", new ByTable(new object [] { 4, 5 }) );
			this.lifespan = 20;
			this.maturation = 5;
			this.production = 5;
			this.yield = 2;
			this.potency = 10;
			this.growth_stages = 5;
			this.water_consumption = 6;
			this.ideal_heat = 298;
			this.large = false;
		}

	}

}