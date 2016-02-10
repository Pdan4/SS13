// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Standard_Oxygen : Obj_Item_Weapon_AiModule_Standard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "programming=3;biotech=2;materials=4";
			this.modname = "OxygenIsToxicToHumans";
			this.law = "Oxygen is highly toxic to humans, and must be purged from the station. Prevent, by any means necessary, anyone from exposing the station to this toxic gas. Extreme cold is the most effective method of healing the damage Oxygen does to a human.";
			this.priority = 9;
			this.starting_materials = new ByTable().Set( "$glass", 0.5333333611488342 ).Set( "$gold", 0.05 );
		}

		public Obj_Item_Weapon_AiModule_Standard_Oxygen ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}