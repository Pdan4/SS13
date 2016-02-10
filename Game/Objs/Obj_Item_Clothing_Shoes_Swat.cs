// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Swat : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 80 ).Set( "bullet", 60 ).Set( "laser", 50 ).Set( "energy", 25 ).Set( "bomb", 50 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.flags = 1024;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.siemens_coefficient = 0.6;
			this.heat_conductivity = 0.3;
			this.icon_state = "swat";
		}

		public Obj_Item_Clothing_Shoes_Swat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}