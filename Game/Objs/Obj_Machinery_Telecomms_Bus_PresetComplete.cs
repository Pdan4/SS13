// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Bus_PresetComplete : Obj_Machinery_Telecomms_Bus {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Bus Complete";
			this.network = "tcommsat";
			this.freq_listening = new ByTable();
			this.autolinkers = new ByTable(new object [] { "processor1", "common" });
		}

		public Obj_Machinery_Telecomms_Bus_PresetComplete ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}