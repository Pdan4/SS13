// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Lasercon : Obj_Machinery_Computer {

		public ByTable lasers = new ByTable();
		public dynamic id = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "atmos";
		}

		// Function from file: LaserComputer.dm
		public Obj_Machinery_Computer_Lasercon ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Machinery_ZeroPointEmitter las = null;

			Task13.Schedule( 1, (Task13.Closure)(() => {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_ZeroPointEmitter) )) {
					las = _a;
					

					if ( las.id == this.id ) {
						this.lasers.Add( las );
					}
				}
				return;
			}));
			return;
		}

		// Function from file: LaserComputer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? i = null;
			double? d = null;
			Obj_Machinery_ZeroPointEmitter laser = null;
			double new_power = 0;
			dynamic laser2 = null;
			double? amt = null;
			Obj_Machinery_ZeroPointEmitter laser3 = null;
			double new_freq = 0;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( href_list["close"] ) ) {
				Interface13.Browse( Task13.User, null, "window=laser_control" );
				Task13.User.machine = null;
				return null;
			} else if ( Lang13.Bool( href_list["input"] ) ) {
				i = String13.ParseNumber( href_list["input"] );
				d = i;

				foreach (dynamic _a in Lang13.Enumerate( this.lasers, typeof(Obj_Machinery_ZeroPointEmitter) )) {
					laser = _a;
					
					new_power = laser.energy + ( d ??0);
					new_power = Num13.MaxInt( ((int)( new_power )), ((int)( 0.0 )) );
					new_power = Num13.MinInt( ((int)( new_power )), ((int)( 0.01 )) );
					laser.energy = new_power;
					this.updateDialog();
				}
			} else if ( Lang13.Bool( href_list["online"] ) ) {
				laser2 = href_list["online"];
				laser2.active = !Lang13.Bool( laser2.active );
				this.updateDialog();
			} else if ( Lang13.Bool( href_list["freq"] ) ) {
				amt = String13.ParseNumber( href_list["freq"] );

				foreach (dynamic _b in Lang13.Enumerate( this.lasers, typeof(Obj_Machinery_ZeroPointEmitter) )) {
					laser3 = _b;
					
					new_freq = laser3.frequency + ( amt ??0);
					new_freq = Num13.MaxInt( ((int)( new_freq )), 1 );
					new_freq = Num13.MinInt( ((int)( new_freq )), 20000 );
					laser3.frequency = new_freq;
					this.updateDialog();
				}
			}
			return null;
		}

		// Function from file: LaserComputer.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string t = null;
			Obj_Machinery_ZeroPointEmitter laser = null;

			
			if ( Map13.GetDistance( this, user ) > 1 || ( this.stat & 3 ) != 0 ) {
				
				if ( !( user is Mob_Living_Silicon ) ) {
					user.machine = null;
					Interface13.Browse( user, null, "window=laser_control" );
					return null;
				}
			}
			t = "<TT><B>Laser status monitor</B><HR>";

			foreach (dynamic _a in Lang13.Enumerate( this.lasers, typeof(Obj_Machinery_ZeroPointEmitter) )) {
				laser = _a;
				
				t += "Zero Point Laser<br>";
				t += new Txt( "Power level: <A href = '?src=" ).Ref( laser ).str( ";input=-0.005'>-</A> <A href = '?src=" ).Ref( laser ).str( ";input=-0.001'>-</A> <A href = '?src=" ).Ref( laser ).str( ";input=-0.0005'>-</A> <A href = '?src=" ).Ref( laser ).str( ";input=-0.0001'>-</A> " ).item( laser.energy ).str( "MeV <A href = '?src=" ).Ref( laser ).str( ";input=0.0001'>+</A> <A href = '?src=" ).Ref( laser ).str( ";input=0.0005'>+</A> <A href = '?src=" ).Ref( laser ).str( ";input=0.001'>+</A> <A href = '?src=" ).Ref( laser ).str( ";input=0.005'>+</A><BR>" ).ToString();
				t += new Txt( "Frequency: <A href = '?src=" ).Ref( laser ).str( ";freq=-10000'>-</A> <A href = '?src=" ).Ref( laser ).str( ";freq=-1000'>-</A> " ).item( laser.freq ).str( " <A href = '?src=" ).Ref( laser ).str( ";freq=1000'>+</A> <A href = '?src=" ).Ref( laser ).str( ";freq=10000'>+</A><BR>" ).ToString();
				t += "Output: " + ( laser.active ? new Txt( "<B>Online</B> <A href = '?src=" ).Ref( laser ).str( ";online=1'>Offline</A>" ).ToString() : new Txt( "<A href = '?src=" ).Ref( laser ).str( ";online=1'>Online</A> <B>Offline</B> " ).ToString() ) + "<BR>";
			}
			t += "<hr>";
			t += new Txt( "<A href='?src=" ).Ref( this ).str( ";close=1'>Close</A><BR>" ).ToString();
			Interface13.Browse( user, t, "window=laser_control;size=500x800" );
			user.machine = this;
			return null;
		}

		// Function from file: LaserComputer.dm
		public override dynamic process(  ) {
			base.process();
			this.updateDialog();
			return null;
		}

	}

}