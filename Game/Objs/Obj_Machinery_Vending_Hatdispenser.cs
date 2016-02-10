// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Hatdispenser : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.vend_reply = "Take care now!";
			this.product_ads = "Buy some hats!;A bare head is absoloutly ASKING for a robusting!";
			this.product_slogans = "Warning, not all hats are dog/monkey compatable. Apply forcefully with care.;Apply directly to the forehead.;Who doesn't love spending cash on hats?!;From the people that brought you collectable hat crates, Hatlord!";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Clothing_Head_Bowlerhat), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Beaverhat), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Boaterhat), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Fedora), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Fez), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Blue), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Green), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Grey), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Orange), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Purple), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Red), 10 )
				.Set( typeof(Obj_Item_Clothing_Head_Soft_Yellow), 10 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Clothing_Head_Bearpelt), 5 );
			this.premium = new ByTable().Set( typeof(Obj_Item_Clothing_Head_Soft_Rainbow), 1 );
			this.pack = typeof(Obj_Structure_Vendomatpack_Hatdispenser);
			this.icon_state = "hats";
		}

		public Obj_Machinery_Vending_Hatdispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}