// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Full_Reinforced_Tinted_Frosted : Obj_Structure_Window_Full_Reinforced_Tinted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_state = "fwindow";
			this.health = 30;
			this.sheettype = typeof(Obj_Item_Stack_Sheet_Glass_Rglass);
			this.icon_state = "fwindow0";
		}

		public Obj_Structure_Window_Full_Reinforced_Tinted_Frosted ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}