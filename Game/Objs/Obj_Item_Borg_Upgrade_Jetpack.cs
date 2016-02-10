// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Jetpack : Obj_Item_Borg_Upgrade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
			this.icon_state = "cyborg_upgrade3";
		}

		public Obj_Item_Borg_Upgrade_Jetpack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		public override bool action( Mob_Living_Silicon_Robot R = null ) {
			Obj_Item_Weapon_Tank_Jetpack carbondioxide = null;

			
			if ( base.action( R ) ) {
				return false;
			}

			if ( R.module is Obj_Item_Weapon_RobotModule_Miner || R.module is Obj_Item_Weapon_RobotModule_Engineering || R is Mob_Living_Silicon_Robot_Mommi ) {
				R.module.modules.Add( new Obj_Item_Weapon_Tank_Jetpack_Carbondioxide( R.module ) );

				foreach (dynamic _a in Lang13.Enumerate( R.module.modules, typeof(Obj_Item_Weapon_Tank_Jetpack) )) {
					carbondioxide = _a;
					
					R.internals = this;
				}
				return true;
			} else {
				GlobalFuncs.to_chat( R, "<span class='warning'>Upgrade mounting error!  No suitable hardpoint detected!</span>" );
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>There's no mounting point for the module!</span>" );
				return false;
			}
		}

	}

}