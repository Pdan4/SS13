// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Engineering : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Engineering Server";
			this.freq_listening = new ByTable(new object [] { 1357 });
			this.autolinkers = new ByTable(new object [] { "engineering" });
		}

		public Obj_Machinery_Telecomms_Server_Presets_Engineering ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}