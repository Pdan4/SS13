// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_Rsf_Cards : RcdSchematic_Rsf {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Deck of cards";
			this.spawn_type = typeof(Obj_Item_Toy_Cards);
		}

		public RcdSchematic_Rsf_Cards ( dynamic n_master = null ) : base( (object)(n_master) ) {
			
		}

	}

}