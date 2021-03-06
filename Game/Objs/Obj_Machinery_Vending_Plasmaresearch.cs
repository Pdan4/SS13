// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Plasmaresearch : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.products = new ByTable()
				.Set( typeof(Obj_Item_Clothing_Under_Rank_Scientist), 6 )
				.Set( typeof(Obj_Item_Clothing_Suit_BioSuit), 6 )
				.Set( typeof(Obj_Item_Clothing_Head_BioHood), 6 )
				.Set( typeof(Obj_Item_Device_TransferValve), 6 )
				.Set( typeof(Obj_Item_Device_Assembly_Timer), 6 )
				.Set( typeof(Obj_Item_Device_Assembly_Signaler), 6 )
				.Set( typeof(Obj_Item_Device_Assembly_ProxSensor), 6 )
				.Set( typeof(Obj_Item_Device_Assembly_Igniter), 6 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Device_Assembly_Health), 3 );
		}

		public Obj_Machinery_Vending_Plasmaresearch ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}