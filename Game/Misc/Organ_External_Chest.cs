// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_External_Chest : Organ_External {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "chest";
			this.icon_name = "torso";
			this.display_name = "chest";
			this.max_damage = 150;
			this.min_broken_damage = 75;
			this.body_part = 2;
			this.has_fat = true;
			this.vital = true;
			this.encased = "ribcage";
		}

		public Organ_External_Chest ( dynamic P = null ) : base( (object)(P) ) {
			
		}

	}

}