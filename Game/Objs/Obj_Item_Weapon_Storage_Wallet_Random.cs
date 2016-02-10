// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Wallet_Random : Obj_Item_Weapon_Storage_Wallet {

		// Function from file: wallets.dm
		public Obj_Item_Weapon_Storage_Wallet_Random ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic item1_type = null;
			dynamic item2_type = null;
			dynamic item3_type = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			item1_type = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Spacecash), typeof(Obj_Item_Weapon_Spacecash_C10), typeof(Obj_Item_Weapon_Spacecash_C100), typeof(Obj_Item_Weapon_Spacecash_C1000) });
			item2_type = null;

			if ( Rand13.PercentChance( 50 ) ) {
				item2_type = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Spacecash), typeof(Obj_Item_Weapon_Spacecash_C10), typeof(Obj_Item_Weapon_Spacecash_C100), typeof(Obj_Item_Weapon_Spacecash_C1000) });
			}
			item3_type = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Coin_Silver), typeof(Obj_Item_Weapon_Coin_Silver), typeof(Obj_Item_Weapon_Coin_Gold), typeof(Obj_Item_Weapon_Coin_Iron), typeof(Obj_Item_Weapon_Coin_Iron), typeof(Obj_Item_Weapon_Coin_Iron) });
			Task13.Schedule( 2, (Task13.Closure)(() => {
				
				if ( Lang13.Bool( item1_type ) ) {
					Lang13.Call( item1_type, this );
				}

				if ( Lang13.Bool( item2_type ) ) {
					Lang13.Call( item2_type, this );
				}

				if ( Lang13.Bool( item3_type ) ) {
					Lang13.Call( item3_type, this );
				}
				return;
			}));
			return;
		}

	}

}