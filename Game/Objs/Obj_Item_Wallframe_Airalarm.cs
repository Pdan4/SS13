// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Wallframe_Airalarm : Obj_Item_Wallframe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result_path = typeof(Obj_Machinery_Airalarm);
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "alarm_bitem";
		}

		public Obj_Item_Wallframe_Airalarm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}