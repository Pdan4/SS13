// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_Bolts : Obj_Effect_Hallucination {

		public ByTable doors = new ByTable();

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_Bolts ( dynamic loc = null, Mob_Living_Carbon T = null, int? door_number = null ) : base( (object)(loc) ) {
			door_number = door_number ?? -1;

			Image I = null;
			int? count = null;
			Obj_Machinery_Door_Airlock A = null;
			Image B = null;

			this.target = T;
			I = null;
			count = 0;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this.target, 7 ), typeof(Obj_Machinery_Door_Airlock) )) {
				A = _a;
				

				if ( ( count ??0) > ( door_number ??0) && ( door_number ??0) > 0 ) {
					break;
				}
				count++;
				I = new Image( A.icon, A, "door_locked", A.layer + 0.1 );
				this.doors.Add( I );

				if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
					((dynamic)this.target).client.images.Or( I );
				}
				Task13.Sleep( 2 );
			}
			Task13.Sleep( 100 );

			foreach (dynamic _b in Lang13.Enumerate( this.doors, typeof(Image) )) {
				B = _b;
				

				if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
					((dynamic)this.target).client.images.Remove( B );
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}