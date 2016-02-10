// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Sliders_Carp : Recipe_Sliders {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Carpmeat) });
			this.result = typeof(Obj_Item_Weapon_Storage_Fancy_FoodBox_SliderBox_Carp);
		}

		// Function from file: recipes_microwave.dm
		public override dynamic make_food( Obj_Machinery_Microwave container = null ) {
			dynamic C = null;

			C = Lang13.FindIn( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Carpmeat), container );

			if ( C.poisonsacs != null ) {
				this.result = typeof(Obj_Item_Weapon_Storage_Fancy_FoodBox_SliderBox_Toxiccarp);
			}
			base.make_food( container );
			return null;
		}

	}

}