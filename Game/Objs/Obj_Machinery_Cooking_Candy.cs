// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Cooking_Candy : Obj_Machinery_Cooking {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state_on = "mixer_on";
			this.cookSound = "sound/machines/juicer.ogg";
			this.icon_state = "mixer_off";
		}

		public Obj_Machinery_Cooking_Candy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cooking_machines.dm
		public override dynamic getFoodChoices(  ) {
			return Lang13.GetTypes( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Candy) ) - typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Candy);
		}

		// Function from file: cooking_machines.dm
		public override string validateIngredient( dynamic I = null ) {
			string _default = null;

			dynamic food = null;

			_default = base.validateIngredient( (object)(I) );

			if ( _default == "valid" && !GlobalVars.foodNesting ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.foodChoices )) {
					food = _a;
					

					if ( String13.FindIgnoreCase( I.name, food, 1, 0 ) != 0 ) {
						_default = "It's already candy.";
						break;
					}
				}
			}
			return _default;
		}

	}

}