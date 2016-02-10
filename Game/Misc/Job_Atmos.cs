// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Atmos : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Atmospheric Technician";
			this.flag = 128;
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 3;
			this.spawn_positions = 2;
			this.supervisors = "the chief engineer";
			this.selection_color = "#fff5cc";
			this.idtype = typeof(Obj_Item_Weapon_Card_Id_Engineering);
			this.access = new ByTable(new object [] { 18, 10, 11, 23, 12, 13, 32, 24 });
			this.minimal_access = new ByTable(new object [] { 24, 12, 14, 32, 11, 13 });
			this.pdaslot = 15;
			this.pdatype = typeof(Obj_Item_Device_Pda_Atmos);
			this.department = "Engineering";
		}

		// Function from file: engineering.dm
		public override bool equip( dynamic H = null ) {
			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_HeadsetEng(  ), 8 );

			dynamic _a = H.backbag; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack( H ), 1 );
			} else if ( _a==3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelNorm( H ), 1 );
			} else if ( _a==4 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Satchel( H ), 1 );
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_AtmosphericTechnician( H ), 14 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Black( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Belt_Utility_Atmostech( H ), 6 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Engineer( H ), 5 );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Engineer( H.back ), 18 );
			}
			return true;
		}

	}

}