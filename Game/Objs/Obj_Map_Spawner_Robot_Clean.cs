// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Robot_Clean : Obj_Map_Spawner_Robot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.toSpawn = new ByTable(new object [] { typeof(Obj_Machinery_Bot_Cleanbot) });
			this.icon_state = "robot_clean";
		}

		public Obj_Map_Spawner_Robot_Clean ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}