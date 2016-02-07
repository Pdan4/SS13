// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Blob_Core : Obj_Effect_Blob {

		public int overmind_get_delay = 0;
		public int resource_delay = 0;
		public dynamic point_rate = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 400;
			this.maxhealth = 400;
			this.explosion_block = 6;
			this.point_return = -1;
			this.atmosblock = true;
			this.icon_state = "blank_blob";
		}

		// Function from file: core.dm
		public Obj_Effect_Blob_Core ( dynamic loc = null, int? h = null, Client new_overmind = null, dynamic new_rate = null ) : base( (object)(loc) ) {
			h = h ?? 200;
			new_rate = new_rate ?? 2;

			GlobalVars.blob_cores.Add( this );
			GlobalVars.SSobj.processing.Or( this );
			this.update_icon();

			if ( !( this.overmind != null ) ) {
				this.create_overmind( new_overmind );
			}

			if ( this.overmind != null ) {
				this.update_icon();
			}
			this.point_rate = new_rate;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: core.dm
		public bool create_overmind( Client new_overmind = null, dynamic override_delay = null ) {
			dynamic C = null;
			ByTable candidates = null;
			Mob_Camera_Blob B = null;

			
			if ( this.overmind_get_delay > Game13.time && !Lang13.Bool( override_delay ) ) {
				return false;
			}
			this.overmind_get_delay = Game13.time + 150;

			if ( this.overmind != null ) {
				GlobalFuncs.qdel( this.overmind );
			}
			C = null;
			candidates = new ByTable();

			if ( !( new_overmind != null ) ) {
				candidates = GlobalFuncs.get_candidates( "blob" );

				if ( candidates.len != 0 ) {
					C = Rand13.PickFromTable( candidates );
				}
			} else {
				C = new_overmind;
			}

			if ( Lang13.Bool( C ) ) {
				B = new Mob_Camera_Blob( this.loc );
				B.key = C.key;
				B.blob_core = this;
				this.overmind = B;
				this.update_icon();

				if ( B.mind != null && !Lang13.Bool( B.mind.special_role ) ) {
					B.mind.special_role = "Blob Overmind";
				}
				return true;
			}
			return false;
		}

		// Function from file: core.dm
		public override void Life(  ) {
			dynamic b_dir = null;
			dynamic B = null;

			
			if ( !( this.overmind != null ) ) {
				this.create_overmind();
			} else if ( this.resource_delay <= Game13.time ) {
				this.resource_delay = Game13.time + 10;
				this.overmind.add_points( this.point_rate );
			}
			this.health = Num13.MinInt( this.maxhealth, ((int)( this.health + this.health_regen )) );

			if ( this.overmind != null ) {
				this.overmind.update_health();
			}
			this.Pulse_Area( this.overmind, 12, 4, 3 );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.alldirs )) {
				b_dir = _a;
				

				if ( !Rand13.PercentChance( 5 ) ) {
					continue;
				}
				B = Lang13.FindIn( typeof(Obj_Effect_Blob_Normal), Map13.GetStep( this, Convert.ToInt32( b_dir ) ) );

				if ( Lang13.Bool( B ) ) {
					((Obj_Effect_Blob)B).change_to( typeof(Obj_Effect_Blob_Shield), this.overmind );
				}
			}
			base.Life();
			return;
		}

		// Function from file: core.dm
		public override bool RegenHealth(  ) {
			return false;
		}

		// Function from file: core.dm
		public override void check_health( dynamic cause = null ) {
			base.check_health( (object)(cause) );

			if ( this.overmind != null ) {
				this.overmind.update_health();
			}
			return;
		}

		// Function from file: core.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: core.dm
		public override bool fire_act( bool? air = null, dynamic exposed_temperature = null, double? exposed_volume = null ) {
			return false;
		}

		// Function from file: core.dm
		public override dynamic Destroy(  ) {
			GlobalVars.blob_cores.Remove( this );

			if ( this.overmind != null ) {
				this.overmind.blob_core = null;
			}
			this.overmind = null;
			GlobalVars.SSobj.processing.Remove( this );
			return base.Destroy();
		}

		// Function from file: core.dm
		public override void PulseAnimation( bool? activate = null ) {
			return;
		}

		// Function from file: core.dm
		public override bool? update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Image I = null;
			Image C = null;

			this.overlays.Cut();
			this.color = null;
			I = new Image( "icons/mob/blob.dmi", "blob" );

			if ( this.overmind != null ) {
				I.color = this.overmind.blob_reagent_datum.color;
			}
			this.overlays.Add( I );
			C = new Image( "icons/mob/blob.dmi", "blob_core_overlay" );
			this.overlays.Add( C );
			return null;
		}

	}

}