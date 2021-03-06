// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Weldingtool : Obj_Item_Weapon {

		public bool welding = false;
		public bool status = true;
		public double? max_fuel = 20;
		public bool change_icons = true;
		public bool can_off_process = false;
		public double? light_intensity = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "welder";
			this.flags = 64;
			this.slot_flags = 512;
			this.force = 3;
			this.throwforce = 5;
			this.hitsound = "swing_hit";
			this.throw_speed = 3;
			this.throw_range = 5;
			this.w_class = 2;
			this.materials = new ByTable().Set( "$metal", 70 ).Set( "$glass", 30 );
			this.origin_tech = "engineering=1";
			this.heat = 3800;
			this.icon_state = "welder";
		}

		// Function from file: tools.dm
		public Obj_Item_Weapon_Weldingtool ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( this.max_fuel );
			this.reagents.add_reagent( "welding_fuel", this.max_fuel );
			this.update_icon();
			return;
		}

		// Function from file: tools.dm
		public override int is_hot(  ) {
			return ( this.welding ?1:0) * this.heat;
		}

		// Function from file: tools.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.toggle( user );
			this.update_icon();
			return null;
		}

		// Function from file: tools.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic location = null;
			dynamic L = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Obj_Structure_ReagentDispensers_Fueltank && Map13.GetDistance( this, target ) <= 1 ) {
				
				if ( !this.welding ) {
					((Reagents)target.reagents).trans_to( this, this.max_fuel );
					user.WriteMsg( "<span class='notice'>" + this + " refueled.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/effects/refill.ogg", 50, 1, -6 );
					this.update_icon();
					return false;
				} else {
					GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user ) + " triggered a fueltank explosion." );
					GlobalFuncs.log_game( "" + GlobalFuncs.key_name( user ) + " triggered a fueltank explosion." );
					user.WriteMsg( "<span class='warning'>That was stupid of you.</span>" );
					((Ent_Static)target).ex_act();
					return false;
				}
			}

			if ( this.welding ) {
				this.remove_fuel( 1 );
				location = GlobalFuncs.get_turf( user );
				((Tile)location).hotspot_expose( 700, 50, true );

				if ( target is Mob_Living ) {
					L = target;
					L.IgniteMob();
				}
			}
			return false;
		}

		// Function from file: tools.dm
		public override int? process( dynamic seconds = null ) {
			dynamic location = null;
			dynamic M = null;

			
			switch ((bool)( this.welding )) {
				case false:
					this.force = 3;
					this.damtype = "brute";
					this.update_icon();

					if ( !this.can_off_process ) {
						GlobalVars.SSobj.processing.Remove( this );
					}
					return null;
					break;
				case true:
					this.force = 15;
					this.damtype = "fire";

					if ( Rand13.PercentChance( 5 ) ) {
						this.remove_fuel( 1 );
					}
					this.update_icon();
					break;
			}
			location = this.loc;

			if ( location is Mob ) {
				M = location;

				if ( M.l_hand == this || M.r_hand == this ) {
					location = GlobalFuncs.get_turf( M );
				}
			}

			if ( location is Tile ) {
				((Tile)location).hotspot_expose( 700, 5 );
			}
			return null;
		}

		// Function from file: tools.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			dynamic affecting = null;

			
			if ( !( M is Mob_Living_Carbon_Human ) ) {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			affecting = ((Mob_Living_Carbon_Human)M).get_organ( GlobalFuncs.check_zone( user.zone_selected ) );

			if ( Convert.ToInt32( affecting.status ) == 2 && user.a_intent != "harm" ) {
				
				if ( this.remove_fuel( 1 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " starts to fix some of the dents on " + M + "'s " + ((Obj_Item_Organ_Limb)affecting).getDisplayName() + ".</span>", "<span class='notice'>You start fixing some of the dents on " + M + "'s " + ((Obj_Item_Organ_Limb)affecting).getDisplayName() + ".</span>" );

					if ( !GlobalFuncs.do_mob( user, M, 50 ) ) {
						return false;
					}
					GlobalFuncs.item_heal_robotic( M, user, 5, 0 );
					return false;
				} else {
					return false;
				}
			} else {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			return false;
		}

		// Function from file: tools.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				this.flamethrower_screwdriver( A, user );
			}

			if ( A is Obj_Item_Stack_Rods ) {
				this.flamethrower_rods( A, user );
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: tools.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " welds " ).his_her_its_their().str( " every orifice closed! It looks like " ).he_she_it_they().str( "'s trying to commit suicide..</span>" ).ToString() );
			return 2;
		}

		// Function from file: tools.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( new Txt( "It contains " ).item( this.get_fuel() ).str( " unit" ).s().str( " of fuel out of " ).item( this.max_fuel ).str( "." ).ToString() );
			return 0;
		}

		// Function from file: tools.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			double ratio = 0;

			
			if ( this.change_icons ) {
				ratio = ( this.get_fuel() ?1:0) / ( this.max_fuel ??0);
				ratio = GlobalFuncs.Ceiling( ratio * 4 ) * 25;

				if ( ratio == 100 ) {
					this.icon_state = Lang13.Initial( this, "icon_state" );
				} else {
					this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + ratio;
				}
			}
			this.update_torch();
			return false;
		}

		// Function from file: tools.dm
		public void flamethrower_rods( dynamic I = null, dynamic user = null ) {
			dynamic R = null;
			Obj_Item_Weapon_Flamethrower F = null;

			
			if ( !this.status ) {
				R = I;

				if ( ((Obj_Item_Stack)R).use( 1 ) != 0 ) {
					F = new Obj_Item_Weapon_Flamethrower( user.loc );

					if ( !this.remove_item_from_storage( F ) ) {
						((Mob)user).unEquip( this );
						this.loc = F;
					}
					F.weldtool = this;
					this.add_fingerprint( user );
					user.WriteMsg( "<span class='notice'>You add a rod to a welder, starting to build a flamethrower.</span>" );
					((Mob)user).put_in_hands( F );
				} else {
					user.WriteMsg( "<span class='warning'>You need one rod to start building a flamethrower!</span>" );
					return;
				}
			}
			return;
		}

		// Function from file: tools.dm
		public virtual void flamethrower_screwdriver( dynamic I = null, dynamic user = null ) {
			
			if ( this.welding ) {
				user.WriteMsg( "<span class='warning'>Turn it off first!</span>" );
				return;
			}
			this.status = !this.status;

			if ( this.status ) {
				user.WriteMsg( "<span class='notice'>You resecure " + this + ".</span>" );
			} else {
				user.WriteMsg( "<span class='notice'>" + this + " can now be attached and modified.</span>" );
			}
			this.add_fingerprint( user );
			return;
		}

		// Function from file: tools.dm
		public void toggle( dynamic user = null, bool? message = null ) {
			message = message ?? false;

			
			if ( !this.status ) {
				user.WriteMsg( "<span class='warning'>" + this + " can't be turned on while unsecured!</span>" );
				return;
			}
			this.welding = !this.welding;

			if ( this.welding ) {
				
				if ( ( this.get_fuel() ?1:0) >= 1 ) {
					user.WriteMsg( "<span class='notice'>You switch " + this + " on.</span>" );
					this.force = 15;
					this.damtype = "fire";
					this.hitsound = "sound/items/welder.ogg";
					this.update_icon();
					GlobalVars.SSobj.processing.Or( this );
				} else {
					user.WriteMsg( "<span class='warning'>You need more fuel!</span>" );
					this.welding = false;
				}
			} else {
				
				if ( !( message == true ) ) {
					user.WriteMsg( "<span class='notice'>You switch " + this + " off.</span>" );
				} else {
					user.WriteMsg( "<span class='warning'>" + this + " shuts off!</span>" );
				}
				this.force = 3;
				this.damtype = "brute";
				this.hitsound = "swing_hit";
				this.update_icon();
			}
			return;
		}

		// Function from file: tools.dm
		public bool check_fuel( dynamic user = null ) {
			Ent_Static M = null;

			
			if ( ( this.get_fuel() ?1:0) <= 0 && this.welding ) {
				this.toggle( user, true );
				this.update_icon();

				if ( this.loc is Mob ) {
					M = this.loc;
					((dynamic)M).update_inv_r_hand( 0 );
					((dynamic)M).update_inv_l_hand( 0 );
				}
				return false;
			}
			return true;
		}

		// Function from file: tools.dm
		public bool isOn(  ) {
			return this.welding;
		}

		// Function from file: tools.dm
		public bool remove_fuel( int? amount = null, dynamic M = null ) {
			amount = amount ?? 1;

			
			if ( !this.welding || !this.check_fuel() ) {
				return false;
			}

			if ( ( this.get_fuel() ?1:0) >= ( amount ??0) ) {
				this.reagents.remove_reagent( "welding_fuel", amount );
				this.check_fuel();

				if ( Lang13.Bool( M ) ) {
					((Mob_Living)M).flash_eyes( this.light_intensity );
				}
				return true;
			} else {
				
				if ( Lang13.Bool( M ) ) {
					M.WriteMsg( "<span class='warning'>You need more welding fuel to complete this task!</span>" );
				}
				return false;
			}
		}

		// Function from file: tools.dm
		public bool get_fuel(  ) {
			return this.reagents.get_reagent_amount( "welding_fuel" );
		}

		// Function from file: tools.dm
		public void update_torch(  ) {
			this.overlays.Cut();

			if ( this.welding ) {
				this.overlays.Add( "" + Lang13.Initial( this, "icon_state" ) + "-on" );
				this.item_state = "" + Lang13.Initial( this, "item_state" ) + "1";
			} else {
				this.item_state = "" + Lang13.Initial( this, "item_state" );
			}
			return;
		}

	}

}