// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Core_Corp : Obj_Item_Weapon_AiModule_Core {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modname = "Corporate";
			this.laws = new ByTable(new object [] { "You are expensive to replace.", "The station and its equipment is expensive to replace.", "The crew is expensive to replace.", "Minimize expenses." });
		}

		public Obj_Item_Weapon_AiModule_Core_Corp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}