// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Alarm_Isolation : Obj_Machinery_Alarm {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 47 });
		}

		public Obj_Machinery_Alarm_Isolation ( dynamic loc = null, int dir = 0, bool? building = null ) : base( (object)(loc), dir, building ) {
			
		}

	}

}