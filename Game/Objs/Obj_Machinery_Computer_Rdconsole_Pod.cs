// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Rdconsole_Pod : Obj_Machinery_Computer_Rdconsole {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = 5;
			this.req_access = new ByTable();
			this.circuit = "/obj/item/weapon/circuitboard/rdconsole/pod";
		}

		public Obj_Machinery_Computer_Rdconsole_Pod ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}