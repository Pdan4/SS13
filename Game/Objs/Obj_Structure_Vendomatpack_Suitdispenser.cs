// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Vendomatpack_Suitdispenser : Obj_Structure_Vendomatpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.targetvendomat = typeof(Obj_Machinery_Vending_Suitdispenser);
			this.icon_state = "suits";
		}

		public Obj_Structure_Vendomatpack_Suitdispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}