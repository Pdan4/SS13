// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Engineering_Engine_SingGen : SupplyPack_Engineering_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Singularity Generator Crate";
			this.contains = new ByTable(new object [] { typeof(Obj_Machinery_TheSingularitygen) });
			this.crate_name = "singularity generator crate";
		}

	}

}