// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Gibber_Autogibber : Obj_Machinery_Gibber {

		public Ent_Static input_plate = null;

		// Function from file: gibber.dm
		public Obj_Machinery_Gibber_Autogibber ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic i = null;
			dynamic input_obj = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
					i = _a;
					
					input_obj = Lang13.FindIn( typeof(Obj_Machinery_Mineral_Input), Map13.GetStep( this.loc, Convert.ToInt32( i ) ) );

					if ( Lang13.Bool( input_obj ) ) {
						
						if ( input_obj.loc is Tile ) {
							this.input_plate = input_obj.loc;
							GlobalFuncs.qdel( input_obj );
							break;
						}
					}
				}

				if ( !( this.input_plate != null ) ) {
					GlobalVars.diary.WriteMsg( "a " + this + " didn't find an input plate." );
					return;
				}
				return;
			}));
			return;
		}

		// Function from file: gibber.dm
		public override bool Bumped( dynamic AM = null ) {
			dynamic M = null;

			
			if ( !( this.input_plate != null ) ) {
				return false;
			}

			if ( AM is Mob ) {
				M = AM;

				if ( M.loc == this.input_plate ) {
					M.loc = this;
					((Mob)M).gib();
				}
			}
			return false;
		}

	}

}