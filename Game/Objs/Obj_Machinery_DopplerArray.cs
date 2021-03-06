// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DopplerArray : Obj_Machinery {

		public bool integrated = false;
		public int max_dist = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.verb_say = "states coldly";
			this.icon = "icons/obj/machines/research.dmi";
			this.icon_state = "tdoppler";
		}

		// Function from file: doppler_array.dm
		public Obj_Machinery_DopplerArray ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.doppler_arrays.Add( this );
			return;
		}

		// Function from file: doppler_array.dm
		public override void power_change(  ) {
			
			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-broken";
			} else if ( Lang13.Bool( this.powered() ) && Lang13.Bool( this.anchored ) ) {
				this.icon_state = Lang13.Initial( this, "icon_state" );
				this.stat &= 65533;
			} else {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-off";
				this.stat |= 2;
			}
			return;
		}

		// Function from file: doppler_array.dm
		public void sense_explosion( dynamic epicenter = null, dynamic devastation_range = null, dynamic heavy_impact_range = null, dynamic light_impact_range = null, double took = 0, dynamic orig_dev_range = null, dynamic orig_heavy_range = null, dynamic orig_light_range = null ) {
			dynamic zone = null;
			int distance = 0;
			int direct = 0;
			ByTable messages = null;
			Ent_Static helm = null;
			dynamic message = null;

			
			if ( ( this.stat & 2 ) != 0 ) {
				return;
			}
			zone = GlobalFuncs.get_turf( this );

			if ( zone.z != epicenter.z ) {
				return;
			}
			distance = Map13.GetDistance( epicenter, zone );
			direct = Map13.GetDistance( zone, epicenter );

			if ( distance > this.max_dist ) {
				return;
			}

			if ( !( ( direct & this.dir ) != 0 ) && !this.integrated ) {
				return;
			}
			messages = new ByTable(new object [] { 
				"Explosive disturbance detected.", 
				"Epicenter at: grid (" + epicenter.x + "," + epicenter.y + "). Temporal displacement of tachyons: " + took + " seconds.", 
				"Factual: Epicenter radius: " + devastation_range + ". Outer radius: " + heavy_impact_range + ". Shockwave radius: " + light_impact_range + "."
			 });

			if ( Convert.ToDouble( devastation_range ) < Convert.ToDouble( orig_dev_range ) || Convert.ToDouble( heavy_impact_range ) < Convert.ToDouble( orig_heavy_range ) || Convert.ToDouble( light_impact_range ) < Convert.ToDouble( orig_light_range ) ) {
				messages.Add( "Theoretical: Epicenter radius: " + orig_dev_range + ". Outer radius: " + orig_heavy_range + ". Shockwave radius: " + orig_light_range + "." );
			}

			if ( this.integrated ) {
				helm = this.loc;

				if ( !( helm != null ) || !( helm is Obj_Item_Clothing_Head_Helmet_Space_Hardsuit ) ) {
					return;
				}
				((dynamic)helm).display_visor_message( "Explosion detected! Epicenter: " + devastation_range + ", Outer: " + heavy_impact_range + ", Shock: " + light_impact_range );
			} else {
				
				foreach (dynamic _a in Lang13.Enumerate( messages )) {
					message = _a;
					
					this.say( message );
				}
			}
			return;
		}

		// Function from file: doppler_array.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( user.incapacitated() ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.__CallVerb("Rotate Tachyon-doppler Dish" );
			}
			return false;
		}

		// Function from file: doppler_array.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( !Lang13.Bool( this.anchored ) && !this.isinspace() ) {
					this.anchored = 1;
					this.power_change();
					user.WriteMsg( "<span class='notice'>You fasten " + this + ".</span>" );
				} else if ( Lang13.Bool( this.anchored ) ) {
					this.anchored = 0;
					this.power_change();
					user.WriteMsg( "<span class='notice'>You unfasten " + this + ".</span>" );
				}
				GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: doppler_array.dm
		public override int? process( dynamic seconds = null ) {
			return 26;
		}

		// Function from file: doppler_array.dm
		public override dynamic Destroy(  ) {
			GlobalVars.doppler_arrays.Remove( this );
			return base.Destroy();
		}

		// Function from file: doppler_array.dm
		[Verb]
		[VerbInfo( name: "Rotate Tachyon-doppler Dish", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void rotate(  ) {
			
			if ( !( Task13.User != null ) || !( Task13.User.loc is Tile ) ) {
				return;
			}

			if ( Task13.User.stat != 0 || Task13.User.restrained() || !Task13.User.canmove ) {
				return;
			}
			this.dir = Num13.Rotate( this.dir, 90 );
			return;
		}

	}

}