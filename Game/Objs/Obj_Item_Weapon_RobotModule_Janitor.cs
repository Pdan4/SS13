// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Janitor : Obj_Item_Weapon_RobotModule {

		// Function from file: robot_modules.dm
		public Obj_Item_Weapon_RobotModule_Janitor ( dynamic R = null ) : base( (object)(R) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.modules.Add( new Obj_Item_Weapon_Soap_Nanotrasen( this ) );
			this.modules.Add( new Obj_Item_Weapon_Storage_Bag_Trash( this ) );
			this.modules.Add( new Obj_Item_Weapon_Mop( this ) );
			this.modules.Add( new Obj_Item_Device_Lightreplacer_Borg( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Glass_Bucket( this ) );
			this.modules.Add( new Obj_Item_Weapon_Crowbar( this ) );
			this.emag = new Obj_Item_Weapon_ReagentContainers_Spray( this );
			((Reagents)this.emag.reagents).add_reagent( "lube", 250 );
			this.emag.name = "Lube spray";
			return;
		}

	}

}