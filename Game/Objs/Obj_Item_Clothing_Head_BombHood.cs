// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_BombHood : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 100 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.body_parts_covered = 47105;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "bombsuit";
		}

		public Obj_Item_Clothing_Head_BombHood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}