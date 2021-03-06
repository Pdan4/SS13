// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Shieldwall : Obj_Machinery {

		public bool needs_power = false;
		public bool active = true;
		public int delay = 5;
		public dynamic last_active = null;
		public dynamic U = null;
		public dynamic gen_primary = null;
		public dynamic gen_secondary = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 3;
			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "shieldwall";
		}

		// Function from file: shieldgen.dm
		public Obj_Machinery_Shieldwall ( dynamic A = null, dynamic B = null ) : base( (object)(A) ) {
			Mob_Living L = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.gen_primary = A;
			this.gen_secondary = B;

			if ( Lang13.Bool( A ) && Lang13.Bool( B ) ) {
				this.needs_power = true;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this.loc ), typeof(Mob_Living) )) {
				L = _a;
				
				this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " is suddenly occupying the same space as " ).the( L ).item().str( "'s organs!</span>" ).ToString() );
				L.gib();
			}
			return;
		}

		// Function from file: shieldgen.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( height == 0 ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 2 ) != 0 ) {
				return Rand13.PercentChance( 20 );
			} else if ( mover is Obj_Item_Projectile ) {
				return Rand13.PercentChance( 10 );
			} else {
				return !this.density;
			}
			return false;
		}

		// Function from file: shieldgen.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			dynamic G = null;

			
			if ( this.needs_power ) {
				
				switch ((int?)( severity )) {
					case 1:
						
						if ( Rand13.PercentChance( 50 ) ) {
							G = this.gen_primary;
						} else {
							G = this.gen_secondary;
						}
						G.storedpower -= 200;
						break;
					case 2:
						
						if ( Rand13.PercentChance( 50 ) ) {
							G = this.gen_primary;
						} else {
							G = this.gen_secondary;
						}
						G.storedpower -= 50;
						break;
					case 3:
						
						if ( Rand13.PercentChance( 50 ) ) {
							G = this.gen_primary;
						} else {
							G = this.gen_secondary;
						}
						G.storedpower -= 20;
						break;
				}
			}
			return false;
		}

		// Function from file: shieldgen.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			dynamic G = null;

			
			if ( this.needs_power ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					G = this.gen_primary;
				} else {
					G = this.gen_secondary;
				}
				G.storedpower -= Convert.ToDouble( P.damage );
			}
			base.bullet_act( (object)(P), (object)(def_zone) );
			return null;
		}

		// Function from file: shieldgen.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.needs_power ) {
				
				if ( this.gen_primary == null || this.gen_secondary == null ) {
					GlobalFuncs.qdel( this );
					return null;
				}

				if ( !Lang13.Bool( this.gen_primary.active ) || !Lang13.Bool( this.gen_secondary.active ) ) {
					GlobalFuncs.qdel( this );
					return null;
				}

				if ( Rand13.PercentChance( 50 ) ) {
					this.gen_primary.storedpower -= 10;
				} else {
					this.gen_secondary.storedpower -= 10;
				}
			}
			return null;
		}

		// Function from file: shieldgen.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			return null;
		}

	}

}