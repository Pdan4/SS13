// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Hydronutrients : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_slogans = "Aren't you glad you don't have to fertilize the natural way?;Now with 50% less stink!;Plants are people too!";
			this.product_ads = "We like plants!;Don't you want some?;The greenest thumbs ever.;We like big plants.;Soft soil...";
			this.icon_deny = "nutri-deny";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Beezeez), 45 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer_Ez), 35 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer_L4z), 25 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer_Rh), 15 )
				.Set( typeof(Obj_Item_Weapon_Plantspray_Pests), 20 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Syringe), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Dropper), 2 )
				.Set( typeof(Obj_Item_Weapon_Storage_Bag_Plants), 5 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Ammonia), 10 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Diethylamine), 5 );
			this.pack = typeof(Obj_Structure_Vendomatpack_Hydronutrients);
			this.icon_state = "nutri";
		}

		public Obj_Machinery_Vending_Hydronutrients ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}