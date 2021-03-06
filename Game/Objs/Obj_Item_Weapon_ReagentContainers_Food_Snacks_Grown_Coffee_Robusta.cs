// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Robusta : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_CoffeeRobustaSeed);
			this.icon_state = "coffee_robusta";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Robusta ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			potency = potency ?? 20;

			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "morphine", Num13.Round( ( potency ??0) / 20, 1 ) + 1 );
			return false;
		}

	}

}