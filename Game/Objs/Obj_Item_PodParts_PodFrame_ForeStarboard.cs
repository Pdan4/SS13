// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_PodParts_PodFrame_ForeStarboard : Obj_Item_PodParts_PodFrame {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.link_to = typeof(Obj_Item_PodParts_PodFrame_AftStarboard);
			this.link_angle = 180;
			this.icon_state = "pod_fs";
		}

		public Obj_Item_PodParts_PodFrame_ForeStarboard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}