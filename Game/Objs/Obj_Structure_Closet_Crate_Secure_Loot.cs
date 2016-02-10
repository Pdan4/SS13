// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Secure_Loot : Obj_Structure_Closet_Crate_Secure {

		public int code = 0;
		public dynamic lastattempt = null;
		public int attempts = 3;
		public int min = 1;
		public int max = 10;

		// Function from file: abandonedcrates.dm
		public Obj_Structure_Closet_Crate_Secure_Loot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.code = Rand13.Int( this.min, this.max );
			return;
		}

		// Function from file: abandonedcrates.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.locked ) {
				
				if ( a is Obj_Item_Weapon_Card_Emag ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>The crate unlocks!</span>" );
					this.locked = false;
				}

				if ( a is Obj_Item_Device_Multitool ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>DECA-CODE LOCK REPORT:</span>" );

					if ( this.attempts == 1 ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>* Anti-Tamper Bomb will activate on next failed access attempt.</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>* Anti-Tamper Bomb will activate after " + this.attempts + " failed access attempts.</span>" );
					}

					if ( this.lastattempt == null ) {
						GlobalFuncs.to_chat( b, "<span class='notice'> has been made to open the crate thus far.</span>" );
						return null;
					}

					if ( this.code > Convert.ToDouble( this.lastattempt ) ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>* Last access attempt lower than expected code.</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>* Last access attempt higher than expected code.</span>" );
					}
				} else {
					base.attackby( (object)(a), (object)(b), (object)(c) );
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: abandonedcrates.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic input = null;
			dynamic T = null;
			dynamic item = null;

			
			if ( this.locked ) {
				GlobalFuncs.to_chat( a, "<span class='notice'>The crate is locked with a Deca-code lock.</span>" );
				input = Interface13.Input( Task13.User, "Enter digit from " + this.min + " to " + this.max + ".", "Deca-Code Lock", "", null, InputType.Num );

				if ( GlobalFuncs.in_range( this, a ) ) {
					input = ( Convert.ToDouble( input ) <= 0 ? ((dynamic)( 0 )) : ( Convert.ToDouble( input ) >= 10 ? ((dynamic)( 10 )) : input ) );

					if ( input == this.code ) {
						GlobalFuncs.to_chat( a, "<span class='notice'>The crate unlocks!</span>" );
						this.locked = false;
					} else if ( input == null || Convert.ToDouble( input ) > this.max || Convert.ToDouble( input ) < this.min ) {
						GlobalFuncs.to_chat( a, "<span class='notice'>You leave the crate alone.</span>" );
					} else {
						GlobalFuncs.to_chat( a, "<span class='warning'>A red light flashes.</span>" );
						this.lastattempt = input;
						this.attempts--;

						if ( this.attempts == 0 ) {
							GlobalFuncs.to_chat( a, "<span class='danger'>The crate's anti-tamper system activates!</span>" );
							T = GlobalFuncs.get_turf( this.loc );
							GlobalFuncs.explosion( T, 0, 0, 0, 1 );

							foreach (dynamic _a in Lang13.Enumerate( this.contents )) {
								item = _a;
								
								GlobalFuncs.qdel( item );
							}
							GlobalFuncs.qdel( this );
							return null;
						}
					}
				} else {
					GlobalFuncs.to_chat( a, "<span class='notice'>You attempt to interact with the device using a hand gesture, but it appears this crate is from before the DECANECT came out.</span>" );
					return null;
				}
			} else {
				return base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

	}

}