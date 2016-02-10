// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Reset : Obj_Item_Weapon_AiModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modname = "Reset";
			this.origin_tech = "programming=3;materials=4";
			this.starting_materials = new ByTable().Set( "$glass", 0.5333333611488342 ).Set( "$gold", 0.05 );
		}

		public Obj_Item_Weapon_AiModule_Reset ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: AI_modules.dm
		public override bool upload( dynamic laws = null, dynamic target = null, dynamic sender = null, bool? notify_target = null ) {
			base.upload( (object)(laws), (object)(target), (object)(sender), notify_target );

			if ( !( target is Mob && GlobalFuncs.is_special_character( target ) != 0 ) ) {
				laws.set_zeroth_law( "" );
			}
			laws.clear_supplied_laws();
			laws.clear_ion_laws();

			if ( target is Mob ) {
				GlobalFuncs.to_chat( target, "" + sender.real_name + " attempted to reset your laws using a reset module." );
			}
			return true;
		}

		// Function from file: AI_modules.dm
		public override void updateLaw(  ) {
			return;
		}

	}

}