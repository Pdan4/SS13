// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ButcheringProduct_Skin_Xeno : ButcheringProduct_Skin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result = typeof(Obj_Item_Stack_Sheet_Xenochitin);
			this.verb_name = "remove chitin";
			this.verb_gerund = "removing chitin";
		}

		// Function from file: butchering.dm
		public ButcheringProduct_Skin_Xeno (  ) {
			this.amount = Rand13.Int( 1, 3 );
			return;
		}

		// Function from file: butchering.dm
		public override dynamic spawn_result( dynamic location = null, Mob_Living parent = null, int? drop_amount = null ) {
			base.spawn_result( (object)(location), parent, drop_amount );

			if ( !( this.amount != 0 ) ) {
				new Obj_Item_Stack_Sheet_Animalhide_Xeno( location );
			}
			return null;
		}

	}

}