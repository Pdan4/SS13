// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class CentcommOrder_PerUnit_Plasma : CentcommOrder_PerUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nanotrasen";
			this.requested = new ByTable().Set( typeof(Obj_Item_Stack_Sheet_Mineral_Plasma), Double.PositiveInfinity );
			this.unit_prices = new ByTable().Set( typeof(Obj_Item_Stack_Sheet_Mineral_Plasma), 0.5 );
		}

	}

}