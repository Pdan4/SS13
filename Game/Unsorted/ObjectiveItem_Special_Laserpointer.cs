// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ObjectiveItem_Special_Laserpointer : ObjectiveItem_Special {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "a laser pointer";
			this.targetitem = typeof(Obj_Item_Device_LaserPointer);
			this.difficulty = 5;
		}

	}

}