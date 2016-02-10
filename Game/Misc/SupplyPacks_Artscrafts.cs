// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Artscrafts : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Arts and Crafts supplies";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Storage_Fancy_Crayons), 
				typeof(Obj_Item_Device_Camera), 
				typeof(Obj_Item_Device_CameraFilm), 
				typeof(Obj_Item_Device_CameraFilm), 
				typeof(Obj_Item_Weapon_Storage_PhotoAlbum), 
				typeof(Obj_Item_Stack_PackageWrap), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Red), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Green), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Blue), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Yellow), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Violet), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Black), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_White), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Paint_Remover), 
				typeof(Obj_Item_Mounted_Poster), 
				typeof(Obj_Item_Stack_PackageWrap_Gift), 
				typeof(Obj_Item_Stack_PackageWrap_Gift), 
				typeof(Obj_Item_Stack_PackageWrap_Gift)
			 });
			this.cost = 10;
			this.containertype = "/obj/structure/closet/crate";
			this.containername = "Arts and Crafts crate";
		}

	}

}