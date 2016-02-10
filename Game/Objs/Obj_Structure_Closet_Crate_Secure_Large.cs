// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Secure_Large : Obj_Structure_Closet_Crate_Secure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_opened = "largemetalopen";
			this.icon_closed = "largemetal";
			this.redlight = "largemetalr";
			this.greenlight = "largemetalg";
			this.icon_state = "largemetal";
		}

		public Obj_Structure_Closet_Crate_Secure_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: crates.dm
		public override bool close(  ) {
			bool found = false;
			Obj_Structure S = null;
			Obj_Machinery M = null;

			found = false;

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure) )) {
				S = _a;
				

				if ( S == this ) {
					continue;
				}

				if ( !Lang13.Bool( S.anchored ) ) {
					found = true;
					S.loc = this;
					break;
				}
			}

			if ( !found ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Machinery) )) {
					M = _b;
					

					if ( !Lang13.Bool( M.anchored ) ) {
						M.loc = this;
						break;
					}
				}
			}
			base.close();
			return false;
		}

	}

}