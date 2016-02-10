// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses : Obj_Item_Clothing {

		public int vision_flags = 0;
		public int darkness_view = 0;
		public int invisa_view = 0;
		public bool cover_hair = false;
		public int see_invisible = 0;
		public int see_in_dark = 0;
		public bool prescription = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.body_parts_covered = 2048;
			this.slot_flags = 8;
			this.min_harm_label = 12;
			this.harm_label_examine = new ByTable(new object [] { "<span class='info'>A label is covering one lens, but doesn't reach the other.</span>", "<span class='warning'>A label covers the lenses!</span>" });
			this.species_restricted = new ByTable(new object [] { "exclude", "Muton" });
			this.icon = "icons/obj/clothing/glasses.dmi";
		}

		public Obj_Item_Clothing_Glasses ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clothing.dm
		public override void harm_label_update(  ) {
			
			if ( this.harm_labeled >= this.min_harm_label ) {
				this.vision_flags |= 1;
			} else {
				this.vision_flags &= 65534;
			}
			return;
		}

	}

}