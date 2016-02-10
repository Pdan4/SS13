// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Tomato : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "tomato";
			this.seed_name = "tomato";
			this.display_name = "tomato plant";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato) });
			this.mutants = new ByTable(new object [] { "bluetomato", "bloodtomato" });
			this.packet_icon = "seed-tomato";
			this.plant_icon = "tomato";
			this.harvest_repeat = 1;
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 10 }) );
			this.lifespan = 25;
			this.maturation = 8;
			this.production = 6;
			this.yield = 2;
			this.potency = 10;
			this.water_consumption = 6;
			this.ideal_light = 8;
			this.ideal_heat = 298;
			this.juicy = 1;
			this.splat_type = typeof(Obj_Effect_Decal_Cleanable_TomatoSmudge);
		}

	}

}