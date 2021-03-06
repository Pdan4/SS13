// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Selfrepair : Obj_Item_Borg_Upgrade {

		public double repair_amount = -1;
		public bool repair_tick = true;
		public int msg_cooldown = 0;
		public int? on = 0;
		public int powercost = 10;
		public Mob_Living_Silicon_Robot cyborg = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
			this.icon_state = "cyborg_upgrade5";
		}

		public Obj_Item_Borg_Upgrade_Selfrepair ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		public override int? process( dynamic seconds = null ) {
			string msgmode = null;

			
			if ( !this.repair_tick ) {
				this.repair_tick = true;
				return null;
			}

			if ( this.cyborg != null && this.cyborg.stat != 2 && Lang13.Bool( this.on ) ) {
				
				if ( Convert.ToDouble( this.cyborg.cell.charge ) < this.powercost * 2 ) {
					this.cyborg.WriteMsg( "<span class='warning'>Self-repair module deactivated. Please recharge.</span>" );
					this.deactivate();
					return null;
				}

				if ( Convert.ToDouble( this.cyborg.health ) < Convert.ToDouble( this.cyborg.maxHealth ) ) {
					
					if ( Convert.ToDouble( this.cyborg.health ) < 0 ) {
						this.repair_amount = -2.5;
						this.powercost = 30;
					} else {
						this.repair_amount = -1;
						this.powercost = 10;
					}
					this.cyborg.adjustBruteLoss( this.repair_amount );
					this.cyborg.adjustFireLoss( this.repair_amount );
					this.cyborg.updatehealth();
					this.cyborg.cell.use( this.powercost );
				} else {
					this.cyborg.cell.use( 5 );
				}
				this.repair_tick = false;

				if ( Game13.time - 2000 > this.msg_cooldown ) {
					msgmode = "standby";

					if ( Convert.ToDouble( this.cyborg.health ) < 0 ) {
						msgmode = "critical";
					} else if ( Convert.ToDouble( this.cyborg.health ) < Convert.ToDouble( this.cyborg.maxHealth ) ) {
						msgmode = "normal";
					}
					this.cyborg.WriteMsg( "<span class='notice'>Self-repair is active in <span class='boldnotice'>" + msgmode + "</span> mode.</span>" );
					this.msg_cooldown = Game13.time;
				}
			} else {
				this.deactivate();
			}
			return null;
		}

		// Function from file: robot_upgrades.dm
		public void deactivate(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			this.on = GlobalVars.FALSE;
			this.update_icon();
			return;
		}

		// Function from file: robot_upgrades.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.cyborg != null ) {
				this.icon_state = "selfrepair_" + ( Lang13.Bool( this.on ) ? "on" : "off" );
			} else {
				this.icon_state = "cyborg_upgrade5";
			}
			return false;
		}

		// Function from file: robot_upgrades.dm
		public override void ui_action_click(  ) {
			this.on = !Lang13.Bool( this.on ) ?1:0;

			if ( Lang13.Bool( this.on ) ) {
				this.cyborg.WriteMsg( "<span class='notice'>You activate the self-repair module.</span>" );
				GlobalVars.SSobj.processing.Or( this );
			} else {
				this.cyborg.WriteMsg( "<span class='notice'>You deactivate the self-repair module.</span>" );
				GlobalVars.SSobj.processing.Remove( this );
			}
			this.update_icon();
			return;
		}

		// Function from file: robot_upgrades.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob )]
		public override bool f_action( Mob_Living_Silicon_Robot R = null ) {
			dynamic U = null;

			
			if ( base.f_action( R ) ) {
				return false;
			}
			U = Lang13.FindIn( typeof(Obj_Item_Borg_Upgrade_Selfrepair), R );

			if ( Lang13.Bool( U ) ) {
				Task13.User.WriteMsg( "<span class='warning'>This unit is already equipped with a self-repair module.</span>" );
				return false;
			}
			this.cyborg = R;
			this.icon_state = "selfrepair_off";
			this.action_button_name = "Toggle Self-Repair";
			return true;
		}

	}

}