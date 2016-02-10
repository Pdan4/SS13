// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_MassDriver : Obj_Machinery {

		public double? power = 1;
		public bool code = true;
		public string id_tag = "default";
		public int drive_range = 50;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 50;
			this.machine_flags = 129;
			this.icon_state = "mass_driver";
		}

		// Function from file: mass_driver.dm
		public Obj_Machinery_MassDriver ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.mass_drivers.Add( this );
			return;
		}

		// Function from file: mass_driver.dm
		public override int emag( dynamic user = null ) {
			
			if ( !( this.emagged != 0 ) ) {
				this.emagged = 1;
				GlobalFuncs.to_chat( user, "You hack the Mass Driver, radically increasing the force at which it'll throw things. Better not stand in its way." );
				return 1;
			}
			return -1;
		}

		// Function from file: mass_driver.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			this.drive();
			base.emp_act( severity );
			return null;
		}

		// Function from file: mass_driver.dm
		public void drive( dynamic amount = null ) {
			int O_limit = 0;
			dynamic target = null;
			Ent_Dynamic O = null;
			int coef = 0;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}
			this.f_use_power( ( this.power ??0) * 500 );
			O_limit = 0;
			target = GlobalFuncs.get_edge_target_turf( this, this.dir );

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Ent_Dynamic) )) {
				O = _a;
				

				if ( !Lang13.Bool( O.anchored ) || O is Obj_Mecha ) {
					O_limit++;

					if ( O_limit >= 20 ) {
						break;
					}
					this.f_use_power( 500 );
					Task13.Schedule( 0, (Task13.Closure)(() => {
						coef = 1;

						if ( this.emagged != 0 ) {
							coef = 5;
						}
						O.throw_at( target, this.drive_range * ( this.power ??0) * coef, ( this.power ??0) * coef );
						return;
					}));
				}
			}
			Icon13.Flick( "mass_driver1", this );
			return;
		}

		// Function from file: mass_driver.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			return "\n	<ul>\n	<li>" + this.format_tag( "ID Tag", "id_tag" ) + "</li>\n	</ul>";
		}

		// Function from file: mass_driver.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			Obj_Machinery_MassDriverFrame F = null;

			_default = base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.to_chat( b, "You begin to unscrew the bolts off the " + this + "..." );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( b, this, 30 ) ) {
					F = new Obj_Machinery_MassDriverFrame( GlobalFuncs.get_turf( this ) );
					F.dir = this.dir;
					F.anchored = 1;
					F.build = 4;
					F.update_icon();
					GlobalFuncs.qdel( this );
				}
				return 1;
			}
			return base.attackby( (object)(a), (object)(b), (object)(c) );
		}

		// Function from file: mass_driver.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.mass_drivers.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}