// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_ChiefEngineer : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Chief Engineer";
			this.flag = 32;
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the captain";
			this.selection_color = "#ffeeaa";
			this.idtype = typeof(Obj_Item_Weapon_Card_Id_Ce);
			this.req_admin_notify = 1;
			this.access = new ByTable(new object [] { 10, 11, 23, 12, 17, 13, 24, 14, 18, 19, 32, 63, 56, 59, 60, 61, 16, 501 });
			this.minimal_access = new ByTable(new object [] { 10, 11, 23, 12, 17, 13, 24, 14, 18, 19, 32, 63, 56, 59, 60, 61, 16, 501 });
			this.minimal_player_age = 7;
			this.pdaslot = 15;
			this.pdatype = typeof(Obj_Item_Device_Pda_Heads_Ce);
			this.department = "Engineering";
			this.head_position = true;
		}

		// Function from file: engineering.dm
		public override bool equip( dynamic H = null ) {
			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_Heads_Ce(  ), 8 );

			dynamic _a = H.backbag; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Industrial( H ), 1 );
			} else if ( _a==3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelEng( H ), 1 );
			} else if ( _a==4 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Satchel( H ), 1 );
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_ChiefEngineer( H ), 14 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Brown( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Head_Hardhat_White( H ), 11 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Belt_Utility_Full( H ), 6 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Gloves_Black( H ), 10 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Engineer( H ), 5 );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Engineer( H.back ), 18 );
			}
			return true;
		}

	}

}