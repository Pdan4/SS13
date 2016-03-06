// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortaTurretConstruct : Obj_Machinery {

		public int build_step = 0;
		public string finish_name = "turret";
		public Type installation = null;
		public bool gun_charge = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/turrets.dmi";
			this.icon_state = "turret_frame";
		}

		public Obj_Machinery_PortaTurretConstruct ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return null;
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic Gun = null;

			
			switch ((int)( this.build_step )) {
				case 4:
					
					if ( !( this.installation != null ) ) {
						return null;
					}
					this.build_step = 3;
					Gun = Lang13.Call( this.installation, this.loc );
					Gun.power_supply.charge = this.gun_charge;
					Gun.update_icon();
					this.installation = null;
					this.gun_charge = false;
					a.WriteMsg( "<span class='notice'>You remove " + Gun + " from the turret frame.</span>" );
					break;
				case 5:
					a.WriteMsg( "<span class='notice'>You remove the prox sensor from the turret frame.</span>" );
					new Obj_Item_Device_Assembly_ProxSensor( this.loc );
					this.build_step = 4;
					break;
			}
			return null;
		}

		// Function from file: portable_turret.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic M = null;
			dynamic WT = null;
			dynamic E = null;
			dynamic M2 = null;
			dynamic WT2 = null;
			Obj_Machinery_PortaTurret Turret = null;
			string t = null;

			
			switch ((int)( this.build_step )) {
				case 0:
					
					if ( A is Obj_Item_Weapon_Wrench && !Lang13.Bool( this.anchored ) ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You secure the external bolts.</span>" );
						this.anchored = 1;
						this.build_step = 1;
						return null;
					} else if ( A is Obj_Item_Weapon_Crowbar && !Lang13.Bool( this.anchored ) ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 75, 1 );
						user.WriteMsg( "<span class='notice'>You dismantle the turret construction.</span>" );
						new Obj_Item_Stack_Sheet_Metal( this.loc, 5 );
						GlobalFuncs.qdel( this );
						return null;
					}
					break;
				case 1:
					
					if ( A is Obj_Item_Stack_Sheet_Metal ) {
						M = A;

						if ( Lang13.Bool( M.use( 2 ) ) ) {
							user.WriteMsg( "<span class='notice'>You add some metal armor to the interior frame.</span>" );
							this.build_step = 2;
							this.icon_state = "turret_frame2";
						} else {
							user.WriteMsg( "<span class='warning'>You need two sheets of metal to continue construction!</span>" );
						}
						return null;
					} else if ( A is Obj_Item_Weapon_Wrench ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );
						user.WriteMsg( "<span class='notice'>You unfasten the external bolts.</span>" );
						this.anchored = 0;
						this.build_step = 0;
						return null;
					}
					break;
				case 2:
					
					if ( A is Obj_Item_Weapon_Wrench ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You bolt the metal armor into place.</span>" );
						this.build_step = 3;
						return null;
					} else if ( A is Obj_Item_Weapon_Weldingtool ) {
						WT = A;

						if ( !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
							return null;
						}

						if ( ( ((Obj_Item_Weapon_Weldingtool)WT).get_fuel() ?1:0) < 5 ) {
							user.WriteMsg( "<span class='warning'>You need more fuel to complete this task!</span>" );
							return null;
						}
						GlobalFuncs.playsound( this.loc, Rand13.Pick(new object [] { "sound/items/welder.ogg", "sound/items/welder2.ogg" }), 50, 1 );
						user.WriteMsg( "<span class='notice'>You start to remove the turret's interior metal armor...</span>" );

						if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 5, user ) ) {
								return null;
							}
							this.build_step = 1;
							user.WriteMsg( "<span class='notice'>You remove the turret's interior metal armor.</span>" );
							new Obj_Item_Stack_Sheet_Metal( this.loc, 2 );
							return null;
						}
					}
					break;
				case 3:
					
					if ( A is Obj_Item_Weapon_Gun_Energy ) {
						
						if ( user is Mob_Living_Silicon_Robot ) {
							return null;
						}
						E = A;

						if ( !((Mob)user).unEquip( A ) ) {
							user.WriteMsg( new Txt( "<span class='warning'>" ).the( A ).item().str( " is stuck to your hand, you cannot put it in " ).the( this ).item().str( "!</span>" ).ToString() );
							return null;
						}
						this.installation = A.type;
						this.gun_charge = Lang13.Bool( E.power_supply.charge );
						user.WriteMsg( "<span class='notice'>You add " + A + " to the turret.</span>" );
						this.build_step = 4;
						GlobalFuncs.qdel( A );
						return null;
					} else if ( A is Obj_Item_Weapon_Wrench ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You remove the turret's metal armor bolts.</span>" );
						this.build_step = 2;
						return null;
					}
					break;
				case 4:
					
					if ( A is Obj_Item_Device_Assembly_ProxSensor ) {
						this.build_step = 5;

						if ( !((Mob)user).unEquip( A ) ) {
							user.WriteMsg( new Txt( "<span class='warning'>" ).the( A ).item().str( " is stuck to your hand, you cannot put it in " ).the( this ).item().str( "!</span>" ).ToString() );
							return null;
						}
						user.WriteMsg( "<span class='notice'>You add the proximity sensor to the turret.</span>" );
						GlobalFuncs.qdel( A );
						return null;
					}
					break;
				case 5:
					
					if ( A is Obj_Item_Weapon_Screwdriver ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
						this.build_step = 6;
						user.WriteMsg( "<span class='notice'>You close the internal access hatch.</span>" );
						return null;
					}
					break;
				case 6:
					
					if ( A is Obj_Item_Stack_Sheet_Metal ) {
						M2 = A;

						if ( Lang13.Bool( M2.use( 2 ) ) ) {
							user.WriteMsg( "<span class='notice'>You add some metal armor to the exterior frame.</span>" );
							this.build_step = 7;
						} else {
							user.WriteMsg( "<span class='warning'>You need two sheets of metal to continue construction!</span>" );
						}
						return null;
					} else if ( A is Obj_Item_Weapon_Screwdriver ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
						this.build_step = 5;
						user.WriteMsg( "<span class='notice'>You open the internal access hatch.</span>" );
						return null;
					}
					break;
				case 7:
					
					if ( A is Obj_Item_Weapon_Weldingtool ) {
						WT2 = A;

						if ( !((Obj_Item_Weapon_Weldingtool)WT2).isOn() ) {
							return null;
						}

						if ( ( ((Obj_Item_Weapon_Weldingtool)WT2).get_fuel() ?1:0) < 5 ) {
							user.WriteMsg( "<span class='warning'>You need more fuel to complete this task!</span>" );
						}
						GlobalFuncs.playsound( this.loc, Rand13.Pick(new object [] { "sound/items/welder.ogg", "sound/items/welder2.ogg" }), 50, 1 );
						user.WriteMsg( "<span class='notice'>You begin to weld the turret's armor down...</span>" );

						if ( GlobalFuncs.do_after( user, 30 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT2).remove_fuel( 5, user ) ) {
								return null;
							}
							this.build_step = 8;
							user.WriteMsg( "<span class='notice'>You weld the turret's armor down.</span>" );
							Turret = new Obj_Machinery_PortaTurret( this.loc );
							Turret.name = this.finish_name;
							Turret.installation = this.installation;
							Turret.gun_charge = this.gun_charge;
							Turret.setup();
							GlobalFuncs.qdel( this );
						}
					} else if ( A is Obj_Item_Weapon_Crowbar ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 75, 1 );
						user.WriteMsg( "<span class='notice'>You pry off the turret's exterior armor.</span>" );
						new Obj_Item_Stack_Sheet_Metal( this.loc, 2 );
						this.build_step = 6;
						return null;
					}
					break;
			}

			if ( A is Obj_Item_Weapon_Pen ) {
				t = GlobalFuncs.stripped_input( user, "Enter new turret name", this.name, this.finish_name );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}

				if ( !( Map13.GetDistance( this, Task13.User ) <= 1 ) && this.loc != Task13.User ) {
					return null;
				}
				this.finish_name = t;
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}