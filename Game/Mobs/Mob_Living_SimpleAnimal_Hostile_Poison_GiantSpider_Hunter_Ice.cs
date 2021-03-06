// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider_Hunter_Ice : Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider_Hunter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "#72e4fa";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = 1500;
		}

		public Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider_Hunter_Ice ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}