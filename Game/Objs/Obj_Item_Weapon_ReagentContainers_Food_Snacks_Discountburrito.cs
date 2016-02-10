// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Discountburrito : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public ByTable ddname = new ByTable(new object [] { 
											"Spooky Dan's BOO-ritos - Texas Toast Chainsaw Massacre Flavor", 
											"Sconto Danilo's Burritos - 50% Real Mozzarella Pepperoni Pizza Party Flavor", 
											"Descuento Danito's Burritos - Pancake Sausage Brunch Flavor", 
											"Descuento Danito's Burritos - Homestyle Comfort Flavor", 
											"Spooky Dan's BOO-ritos - Nightmare on Elm Meat Flavor", 
											"Descuento Danito's Burritos - Strawberrito Churro Flavor", 
											"Descuento Danito's Burritos - Beff and Bean Flavor"
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.food_flags = 1;
			this.icon_state = "danburrito";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Discountburrito ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.name = Rand13.PickFromTable( this.ddname );
			((Reagents)this.reagents).add_reagent( "nutriment", 3 );
			((Reagents)this.reagents).add_reagent( "discount", 6 );
			((Reagents)this.reagents).add_reagent( "irradiatedbeans", 4 );
			((Reagents)this.reagents).add_reagent( "refriedbeans", 4 );
			((Reagents)this.reagents).add_reagent( "mutatedbeans", 4 );
			((Reagents)this.reagents).add_reagent( "beff", 4 );
			((Reagents)this.reagents).add_reagent( "chemical_waste", 2 );
			this.bitesize = 2;
			return;
		}

	}

}