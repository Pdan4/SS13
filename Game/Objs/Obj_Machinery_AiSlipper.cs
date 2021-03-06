// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_AiSlipper : Obj_Machinery {

		public int uses = 20;
		public bool disabled = true;
		public bool lethal = false;
		public bool locked = true;
		public int cooldown_time = 0;
		public double cooldown_timeleft = 0;
		public bool cooldown_on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.req_access = new ByTable(new object [] { 16 });
			this.icon = "icons/obj/device.dmi";
			this.icon_state = "motion3";
		}

		public Obj_Machinery_AiSlipper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ai_slipper.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( this.locked ) {
				
				if ( !( Task13.User is Mob_Living_Silicon || Lang13.Bool( GlobalFuncs.IsAdminGhost( Task13.User ) ) ) ) {
					Task13.User.WriteMsg( "Control panel is locked!" );
					return null;
				}
			}

			if ( Lang13.Bool( href_list["toggleOn"] ) ) {
				this.disabled = !this.disabled;
				this.icon_state = ( this.disabled ? "motion0" : "motion3" );
			}

			if ( Lang13.Bool( href_list["toggleUse"] ) ) {
				
				if ( this.cooldown_on || this.disabled ) {
					return null;
				} else {
					GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Foam), this.loc );
					this.uses--;
					this.cooldown_on = true;
					this.cooldown_time = Game13.timeofday + 100;
					this.slip_process();
					return null;
				}
			}
			this.attack_hand( Task13.User );
			return null;
		}

		// Function from file: ai_slipper.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			Ent_Static loc = null;
			Ent_Static area = null;
			string t = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( Map13.GetDistance( this, a ) > 1 ) {
				
				if ( !( a is Mob_Living_Silicon || Lang13.Bool( GlobalFuncs.IsAdminGhost( a ) ) ) ) {
					a.WriteMsg( "Too far away." );
					((Mob)a).unset_machine();
					Interface13.Browse( a, null, "window=ai_slipper" );
					return null;
				}
			}
			((Mob)a).set_machine( this );
			loc = this.loc;

			if ( loc is Tile ) {
				loc = loc.loc;
			}

			if ( !( loc is Zone ) ) {
				a.WriteMsg( "Turret badly positioned - loc.loc is " + loc + "." );
				return null;
			}
			area = loc;
			t = "<TT><B>AI Liquid Dispenser</B> (" + GlobalFuncs.format_text( area.name ) + ")<HR>";

			if ( this.locked && !( a is Mob_Living_Silicon || Lang13.Bool( GlobalFuncs.IsAdminGhost( a ) ) ) ) {
				t += "<I>(Swipe ID card to unlock control panel.)</I><BR>";
			} else {
				t += new Txt( "Dispenser " ).item( ( this.disabled ? "deactivated" : "activated" ) ).str( " - <A href='?src=" ).Ref( this ).str( ";toggleOn=1'>" ).item( ( this.disabled ? "Enable" : "Disable" ) ).str( "?</a><br>\n" ).ToString();
				t += new Txt( "Uses Left: " ).item( this.uses ).str( ". <A href='?src=" ).Ref( this ).str( ";toggleUse=1'>Activate the dispenser?</A><br>\n" ).ToString();
			}
			Interface13.Browse( a, t, "window=computer;size=575x450" );
			GlobalFuncs.onclose( a, "computer" );
			return null;
		}

		// Function from file: ai_slipper.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: ai_slipper.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( user is Mob_Living_Silicon ) {
				return this.attack_hand( user );
			} else if ( this.allowed( Task13.User ) ) {
				this.locked = !this.locked;
				user.WriteMsg( "<span class='notice'>You " + ( this.locked ? "lock" : "unlock" ) + " the device.</span>" );

				if ( this.locked ) {
					
					if ( user.machine == this ) {
						((Mob)user).unset_machine();
						Interface13.Browse( user, null, "window=ai_slipper" );
					}
				} else if ( user.machine == this ) {
					this.attack_hand( Task13.User );
				}
			} else {
				user.WriteMsg( "<span class='danger'>Access denied.</span>" );
			}
			return null;
		}

		// Function from file: tgstation.dme
		public void slip_process(  ) {
			int ticksleft = 0;

			
			while (this.cooldown_time - Game13.timeofday > 0) {
				ticksleft = this.cooldown_time - Game13.timeofday;

				if ( ticksleft > 100000 ) {
					this.cooldown_time = Game13.timeofday + 10;
				}
				this.cooldown_timeleft = ticksleft / 10;
				Task13.Sleep( 5 );
			}

			if ( this.uses <= 0 ) {
				return;
			}

			if ( this.uses >= 0 ) {
				this.cooldown_on = false;
			}
			this.power_change();
			return;
		}

		// Function from file: ai_slipper.dm
		public void setState( dynamic enabled = null, dynamic uses = null ) {
			this.disabled = this.disabled;
			this.uses = Convert.ToInt32( uses );
			this.power_change();
			return;
		}

		// Function from file: ai_slipper.dm
		public override void power_change(  ) {
			
			if ( ( this.stat & 1 ) != 0 ) {
				return;
			} else if ( Lang13.Bool( this.powered() ) ) {
				this.stat &= 65533;
			} else {
				this.icon_state = "motion0";
				this.stat |= 2;
			}
			return;
		}

	}

}