// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Flamethrower : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flamethrower";
			this.result = typeof(Obj_Item_Weapon_Flamethrower);
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_Weldingtool), 1 ).Set( typeof(Obj_Item_Device_Assembly_Igniter), 1 ).Set( typeof(Obj_Item_Stack_Rods), 1 );
			this.parts = new ByTable().Set( typeof(Obj_Item_Device_Assembly_Igniter), 1 ).Set( typeof(Obj_Item_Weapon_Weldingtool), 1 );
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Screwdriver) });
			this.time = 10;
			this.category = "Weaponry";
		}

	}

}