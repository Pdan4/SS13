// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Abductor : Obj_Effect_Landmark_Corpse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mobname = "???";
			this.mob_species = typeof(Species_Abductor);
			this.corpseuniform = typeof(Obj_Item_Clothing_Under_Color_Grey);
			this.corpseshoes = typeof(Obj_Item_Clothing_Shoes_Combat);
		}

		public Obj_Effect_Landmark_Corpse_Abductor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}