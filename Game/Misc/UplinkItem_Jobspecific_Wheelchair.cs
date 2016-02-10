// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Wheelchair : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syndicate Wheelchair";
			this.desc = "A combat-modified motorized wheelchair. Forward thrust is sufficient to knock down and run over victims.";
			this.item = typeof(Obj_Item_SyndicateWheelchairKit);
			this.cost = 6;
			this.job = new ByTable(new object [] { "Medical Doctor", "Chief Medical Officer" });
		}

	}

}