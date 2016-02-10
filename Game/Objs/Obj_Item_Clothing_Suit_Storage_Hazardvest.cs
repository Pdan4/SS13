// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Storage_Hazardvest : Obj_Item_Clothing_Suit_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hazard";
			this.blood_overlay_type = "armor";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Device_Analyzer), 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Device_Multitool), 
				typeof(Obj_Item_Device_Radio), 
				typeof(Obj_Item_Device_TScanner), 
				typeof(Obj_Item_Weapon_Crowbar), 
				typeof(Obj_Item_Weapon_Screwdriver), 
				typeof(Obj_Item_Weapon_Weldingtool), 
				typeof(Obj_Item_Weapon_Wirecutters), 
				typeof(Obj_Item_Weapon_Wrench), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyNitrogen), 
				typeof(Obj_Item_Device_DeviceAnalyser)
			 });
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "hazard";
		}

		public Obj_Item_Clothing_Suit_Storage_Hazardvest ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}