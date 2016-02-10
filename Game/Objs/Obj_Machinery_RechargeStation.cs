// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_RechargeStation : Obj_Machinery {

		public Ent_Static occupant = null;
		public ByTable acceptable_upgradeables = new ByTable(new object [] { typeof(Obj_Item_Weapon_Cell) });
		public ByTable upgrade_holder = new ByTable();
		public dynamic upgrading = 0;
		public double upgrade_finished = -1;
		public dynamic manipulator_coeff = 1;
		public dynamic transfer_rate_coeff = 1;
		public int capacitor_stored = 0;
		public dynamic capacitor_max = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 5;
			this.active_power_usage = 1000;
			this.machine_flags = 46;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "borgcharger0";
		}

		// Function from file: rechargestation.dm
		public Obj_Machinery_RechargeStation ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.build_icon();
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_RechargeStation(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_MatterBin()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: vgstation13.dme
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			Ent_Static R = null;

			
			if ( !( AM is Mob_Living_Silicon ) || AM is Mob_Living_Silicon_Ai ) {
				return false;
			}
			R = AM;
			this.mob_enter( R );
			return false;
		}

		// Function from file: rechargestation.dm
		public override int crowbarDestroy( dynamic user = null ) {
			
			if ( this.occupant != null ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>You can't do that while this charger is occupied.</span>" );
				return -1;
			}
			return base.crowbarDestroy( (object)(user) );
		}

		// Function from file: rechargestation.dm
		public override int togglePanelOpen( dynamic toggleitem = null, dynamic user = null, dynamic CC = null ) {
			
			if ( this.occupant != null ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>You can't do that while this charger is occupied.</span>" );
				return -1;
			}
			return base.togglePanelOpen( (object)(toggleitem), (object)(user), (object)(CC) );
		}

		// Function from file: rechargestation.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return null;
			}

			if ( this.occupant != null ) {
				this.occupant.emp_act( severity );
				this.go_out();
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: rechargestation.dm
		public override dynamic relaymove( Mob M = null, double? direction = null ) {
			
			if ( Lang13.Bool( M.stat ) ) {
				return null;
			}
			this.go_out();
			return null;
		}

		// Function from file: rechargestation.dm
		public override bool allow_drop(  ) {
			return false;
		}

		// Function from file: rechargestation.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic removed = null;

			
			if ( a == this.occupant ) {
				
				if ( Lang13.Bool( this.upgrading ) ) {
					GlobalFuncs.to_chat( a, "<span class='notice'>You interrupt the upgrade process.</span>" );
					this.upgrading = 0;
					this.upgrade_finished = -1;
					return 0;
				} else if ( this.upgrade_holder.len != 0 ) {
					this.upgrading = Interface13.Input( a, "Choose an item to swap out.", "Upgradeables", null, this.upgrade_holder, InputType.Null | InputType.Any );

					if ( !Lang13.Bool( this.upgrading ) ) {
						this.upgrading = 0;
						return null;
					}

					if ( Interface13.Alert( a, "You have chosen " + this.upgrading + ", is this correct?", null, "Yes", "No" ) == "Yes" ) {
						this.upgrade_finished = Game13.timeofday + 600 / Convert.ToDouble( this.manipulator_coeff );
						GlobalFuncs.to_chat( a, new Txt( "The upgrade should complete in approximately " ).item( 60 / Convert.ToDouble( this.manipulator_coeff ) ).str( " seconds, you will be unable to exit " ).the( this ).item().str( " during this unless you cancel the process." ).ToString() );
						Task13.Schedule( 0, (Task13.Closure)(() => {
							GlobalFuncs.do_after( a, this, 600 / Convert.ToDouble( this.manipulator_coeff ), null, GlobalVars.FALSE );
							return;
						}));
						return null;
					} else {
						this.upgrading = 0;
						GlobalFuncs.to_chat( a, "You decide not to apply the upgrade" );
						return null;
					}
				}
			} else if ( this.Adjacent( a ) ) {
				
				if ( this.upgrade_holder.len != 0 ) {
					removed = Interface13.Input( a, "Choose an item to remove.", this.upgrade_holder[1], null, this.upgrade_holder, InputType.Null | InputType.Any );

					if ( !Lang13.Bool( removed ) ) {
						return null;
					}
					((Mob)a).put_in_hands( removed );

					if ( removed.loc == this ) {
						removed.loc = GlobalFuncs.get_turf( this );
					}
					this.upgrade_holder.Remove( removed );
				}
			}
			return null;
		}

		// Function from file: rechargestation.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: rechargestation.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			return 0;
		}

		// Function from file: rechargestation.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( GlobalFuncs.is_type_in_list( a, this.acceptable_upgradeables ) ) {
				
				if ( !Lang13.Bool( Lang13.FindIn( a.type, this.upgrade_holder ) ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.upgrade_holder.Add( a );
						GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You add " ).the( a ).item().str( " to " ).the( this ).item().str( ".</span>" ).ToString() );
						return null;
					}
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).The( this ).item().str( " already contains something resembling a " ).item( a.name ).str( ".</span>" ).ToString() );
					return null;
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
				return null;
			}
			return null;
		}

		// Function from file: rechargestation.dm
		public void mob_enter( Ent_Static R = null ) {
			Obj O = null;

			
			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				return;
			}

			if ( Convert.ToInt32( ((dynamic)R).stat ) == 2 ) {
				return;
			}

			if ( !( R is Mob_Living_Silicon ) ) {
				GlobalFuncs.to_chat( R, "<span class='notice'><B>Only non-organics may enter the recharger!</B></span>" );
				return;
			}

			if ( this.occupant != null ) {
				GlobalFuncs.to_chat( R, "<span class='notice'><B>The cell is already occupied!</B></span>" );
				return;
			}
			((Mob)R).stop_pulling();

			if ( R != null && Lang13.Bool( ((dynamic)R).client ) ) {
				((dynamic)R).client.perspective = GlobalVars.EYE_PERSPECTIVE ?1:0;
				((dynamic)R).client.eye = this;
			}
			R.loc = this;
			this.occupant = R;
			this.add_fingerprint( R );
			this.build_icon();
			this.use_power = 2;

			foreach (dynamic _a in Lang13.Enumerate( this.upgrade_holder, typeof(Obj) )) {
				O = _a;
				

				if ( O is Obj_Item_Weapon_Cell ) {
					
					if ( !Lang13.Bool( ((dynamic)R).cell ) ) {
						GlobalFuncs.to_chat( Task13.User, "<big><span class='notice'>Power Cell replacement available.</span></big>" );
					} else if ( Convert.ToDouble( ((dynamic)O).maxcharge ) > Convert.ToDouble( ((dynamic)R).cell.maxcharge ) ) {
						GlobalFuncs.to_chat( Task13.User, "<span class='notice'>Power Cell upgrade available.</span></big>" );
					}
				}
			}
			return;
		}

		// Function from file: rechargestation.dm
		public void restock_modules(  ) {
			Ent_Static R = null;
			ByTable um = null;
			Obj O = null;
			Obj S = null;
			Obj F = null;
			Obj C = null;
			Obj B = null;
			Obj C2 = null;
			Obj C3 = null;
			Obj C4 = null;
			Obj B2 = null;
			Obj D = null;
			Obj LR = null;
			dynamic S2 = null;

			
			if ( this.occupant != null ) {
				
				if ( this.occupant is Mob_Living_Silicon_Robot ) {
					R = this.occupant;

					if ( Lang13.Bool( ((dynamic)R).module ) && Lang13.Bool( ((dynamic)R).module.modules ) ) {
						um = R.contents | ((dynamic)R).module.modules;

						foreach (dynamic _a in Lang13.Enumerate( um, typeof(Obj) )) {
							O = _a;
							

							if ( O is Obj_Item_Stack ) {
								S = O;

								if ( !( S is Obj_Item_Stack_CableCoil ) && !( S is Obj_Item_Stack_Medical ) ) {
									continue;
								}

								if ( Convert.ToDouble( ((dynamic)S).amount ) < Convert.ToDouble( ((dynamic)S).max_amount ) ) {
									((dynamic)S).amount += 2;
								}

								if ( Convert.ToDouble( ((dynamic)S).amount ) > Convert.ToDouble( ((dynamic)S).max_amount ) ) {
									((dynamic)S).amount = ((dynamic)S).max_amount;
								}
							}

							if ( O is Obj_Item_Device_Flash ) {
								F = O;

								if ( Lang13.Bool( ((dynamic)F).broken ) ) {
									((dynamic)F).broken = 0;
									((dynamic)F).times_used = 0;
									F.icon_state = "flash";
								}
							}

							if ( O is Obj_Item_Weapon_Gun_Energy_Taser_Cyborg ) {
								C = O;

								if ( Convert.ToDouble( ((dynamic)C).power_supply.charge ) < Convert.ToDouble( ((dynamic)C).power_supply.maxcharge ) ) {
									((Obj_Item_Weapon_Cell)((dynamic)C).power_supply).give( ((dynamic)C).charge_cost );
									C.update_icon();
								} else {
									((dynamic)C).charge_tick = 0;
								}
							}

							if ( O is Obj_Item_Weapon_Melee_Baton ) {
								B = O;

								if ( Lang13.Bool( ((dynamic)B).bcell ) ) {
									((dynamic)B).bcell.charge = ((dynamic)B).bcell.maxcharge;
								}
							}

							if ( O is Obj_Item_Weapon_Gun_Energy_Laser_Cyborg ) {
								C2 = O;

								if ( Convert.ToDouble( ((dynamic)C2).power_supply.charge ) < Convert.ToDouble( ((dynamic)C2).power_supply.maxcharge ) ) {
									((Obj_Item_Weapon_Cell)((dynamic)C2).power_supply).give( ((dynamic)C2).charge_cost );
									C2.update_icon();
								} else {
									((dynamic)C2).charge_tick = 0;
								}
							}

							if ( O is Obj_Item_Weapon_Gun_Energy_Lasercannon_Cyborg ) {
								C3 = O;

								if ( Convert.ToDouble( ((dynamic)C3).power_supply.charge ) < Convert.ToDouble( ((dynamic)C3).power_supply.maxcharge ) ) {
									((Obj_Item_Weapon_Cell)((dynamic)C3).power_supply).give( ((dynamic)C3).charge_cost );
									C3.update_icon();
								}
							}

							if ( O is Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Cyborg ) {
								C4 = O;

								if ( Convert.ToDouble( ((dynamic)C4).power_supply.charge ) < Convert.ToDouble( ((dynamic)C4).power_supply.maxcharge ) ) {
									((Obj_Item_Weapon_Cell)((dynamic)C4).power_supply).give( ((dynamic)C4).charge_cost );
									C4.update_icon();
								} else {
									((dynamic)O).charge_tick = 0;
								}
							}

							if ( O is Obj_Item_Weapon_ReagentContainers_Food_Condiment_Enzyme ) {
								
								if ( ( ((Reagents)O.reagents).get_reagent_amount( "enzyme" ) ?1:0) < 50 ) {
									((Reagents)O.reagents).add_reagent( "enzyme", 2 );
								}
							}

							if ( O is Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Robot ) {
								B2 = O;

								if ( Lang13.Bool( ((dynamic)B2).reagent ) && ( ((Reagents)B2.reagents).get_reagent_amount( ((dynamic)B2).reagent ) ?1:0) < Convert.ToDouble( ((dynamic)B2).volume ) ) {
									((Reagents)B2.reagents).add_reagent( ((dynamic)B2).reagent, 2 );
								}
							}

							if ( O is Obj_Item_Weapon_Melee_Defibrillator ) {
								D = O;
								((dynamic)D).charges = Lang13.Initial( D, "charges" );
							}

							if ( O is Obj_Item_Device_Lightreplacer_Borg ) {
								LR = O;
								((dynamic)LR).Charge( R );
							}
						}

						if ( R != null ) {
							
							if ( Lang13.Bool( ((dynamic)R).module ) ) {
								((Obj_Item_Weapon_RobotModule)((dynamic)R).module).respawn_consumable( R );
							}
						}

						if ( Lang13.Bool( ((dynamic)R).module.emag ) ) {
							
							if ( ((dynamic)R).module.emag is Obj_Item_Weapon_ReagentContainers_Spray ) {
								S2 = ((dynamic)R).module.emag;

								if ( S2.name == "Polyacid spray" ) {
									((Reagents)S2.reagents).add_reagent( "pacid", 2 );
								} else if ( S2.name == "Lube spray" ) {
									((Reagents)S2.reagents).add_reagent( "lube", 2 );
								}
							}
						}
					}
				}
			}
			return;
		}

		// Function from file: rechargestation.dm
		public void go_out(  ) {
			Ent_Dynamic x = null;

			
			if ( !( this.occupant != null ) ) {
				return;
			}

			if ( Lang13.Bool( this.upgrading ) ) {
				GlobalFuncs.to_chat( this.occupant, new Txt( "<span class='notice'>The upgrade hasn't completed yet, interface with " ).the( this ).item().str( " again to halt the process.</span>" ).ToString() );
				return;
			}

			if ( Lang13.Bool( ((dynamic)this.occupant).client ) ) {
				((dynamic)this.occupant).client.eye = ((dynamic)this.occupant).client.mob;
				((dynamic)this.occupant).client.perspective = GlobalVars.MOB_PERSPECTIVE ?1:0;
			}
			this.occupant.loc = this.loc;
			this.occupant = null;
			this.build_icon();
			this.use_power = 1;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				x = _a;
				
				Interface13.Stat( null, ( this.upgrade_holder | this.component_parts ).Contains( x ) );

				if ( !( x is Ent_Dynamic ) ) {
					x.forceMove( this.loc );
				}
			}
			return;
		}

		// Function from file: rechargestation.dm
		public bool process_capacitors(  ) {
			
			if ( this.capacitor_stored >= Convert.ToDouble( this.capacitor_max ) ) {
				
				if ( this.idle_power_usage != Lang13.Initial( this, "idle_power_usage" ) ) {
					this.idle_power_usage = Lang13.Initial( this, "idle_power_usage" );
				}
				return false;
			}
			this.idle_power_usage = Lang13.Initial( this, "idle_power_usage" ) + this.transfer_rate_coeff * 100;
			this.capacitor_stored = Num13.MinInt( ((int)( this.capacitor_stored + Convert.ToDouble( this.transfer_rate_coeff * 20 ) )), Convert.ToInt32( this.capacitor_max ) );
			return true;
		}

		// Function from file: rechargestation.dm
		public void process_occupant(  ) {
			Ent_Static R = null;
			int juicetofill = 0;

			
			if ( this.occupant != null ) {
				
				if ( this.occupant is Mob_Living_Silicon_Robot ) {
					R = this.occupant;

					if ( Lang13.Bool( ((dynamic)R).stat ) || !Lang13.Bool( ((dynamic)R).client ) ) {
						this.go_out();
						return;
					}
					this.restock_modules();

					if ( !Lang13.Bool( ((dynamic)R).cell ) ) {
						return;
					} else if ( Convert.ToDouble( ((dynamic)R).cell.charge ) >= Convert.ToDouble( ((dynamic)R).cell.maxcharge ) ) {
						((dynamic)R).cell.charge = ((dynamic)R).cell.maxcharge;
						return;
					} else {
						
						if ( this.capacitor_stored != 0 ) {
							juicetofill = Convert.ToInt32( ((dynamic)R).cell.maxcharge - ((dynamic)R).cell.charge );

							if ( this.capacitor_stored > juicetofill ) {
								this.capacitor_stored -= juicetofill;
								((dynamic)R).cell.charge = ((dynamic)R).cell.maxcharge;
							} else {
								((dynamic)R).cell.charge = ((dynamic)R).cell.charge + this.capacitor_stored;
								this.capacitor_stored = 0;
							}
						}
						((dynamic)R).cell.charge = Num13.MinInt( Convert.ToInt32( ((dynamic)R).cell.charge + this.transfer_rate_coeff * 200 + ( this.occupant is Mob_Living_Silicon_Robot_Mommi ? this.transfer_rate_coeff * 100 : ((dynamic)( 0 )) ) ), Convert.ToInt32( ((dynamic)R).cell.maxcharge ) );
						return;
					}
				}
			}
			return;
		}

		// Function from file: rechargestation.dm
		public void build_icon(  ) {
			
			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				this.icon_state = "borgcharger";
			} else if ( this.occupant != null ) {
				this.icon_state = "borgcharger1";
			} else {
				this.icon_state = "borgcharger0";
			}
			return;
		}

		// Function from file: rechargestation.dm
		public void process_upgrade(  ) {
			
			if ( !Lang13.Bool( this.upgrading ) ) {
				return;
			}

			if ( !( this.occupant != null ) || !( this.occupant is Mob_Living_Silicon_Robot ) ) {
				this.upgrading = 0;
				this.upgrade_finished = -1;
				return;
			}

			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( this.occupant, "<span class='warning'>Upgrade interrupted due to power failure, movement lock is released.</span>" );
				this.upgrading = 0;
				this.upgrade_finished = -1;
				return;
			}

			if ( Game13.timeofday >= this.upgrade_finished && this.upgrade_finished != -1 ) {
				
				if ( this.upgrading is Obj_Item_Weapon_Cell ) {
					
					if ( Lang13.Bool( ((dynamic)this.occupant).cell ) ) {
						((dynamic)this.occupant).cell.loc = GlobalFuncs.get_turf( this );
					}
					this.upgrade_holder.Remove( this.upgrading );
					this.upgrading.loc = this.occupant;
					((dynamic)this.occupant).cell = this.upgrading;
					((dynamic)this.occupant).cell.charge = ((dynamic)this.occupant).cell.maxcharge;
					this.upgrading = 0;
					this.upgrade_finished = -1;
					GlobalFuncs.to_chat( this.occupant, "<span class='notice'>Upgrade completed.</span>" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/Ping.ogg", 50, 0 );
				}
			}
			return;
		}

		// Function from file: rechargestation.dm
		public override dynamic process(  ) {
			this.process_upgrade();

			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				return null;
			}

			if ( this.occupant != null ) {
				this.process_occupant();
			} else {
				this.process_capacitors();
			}
			return 1;
		}

		// Function from file: rechargestation.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						new Obj_Item_Weapon_Circuitboard_RechargeStation( this.loc );
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						this.anchored = 0;
						this.build_icon();
					}
					break;
			}
			return false;
		}

		// Function from file: rechargestation.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.go_out();
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: rechargestation.dm
		public override dynamic RefreshParts(  ) {
			int T = 0;
			Obj_Item_Weapon_StockParts_Manipulator M = null;
			Obj_Item_Weapon_StockParts_Capacitor C = null;

			T = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _a;
				
				T += M.rating - 1;
			}
			this.manipulator_coeff = Lang13.Initial( this, "manipulator_coeff" ) + T;
			T = 0;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Capacitor) )) {
				C = _b;
				
				T += C.rating - 1;
			}
			this.transfer_rate_coeff = Lang13.Initial( this, "transfer_rate_coeff" ) + T * 0.2;
			this.capacitor_max = Lang13.Initial( this, "capacitor_max" ) + T * 750;
			this.active_power_usage = this.transfer_rate_coeff * 1000;
			return null;
		}

		// Function from file: rechargestation.dm
		[Verb]
		[VerbInfo( group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void move_inside(  ) {
			this.mob_enter( Task13.User );
			return;
		}

		// Function from file: rechargestation.dm
		[Verb]
		[VerbInfo( group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void move_eject(  ) {
			
			if ( Task13.User.stat != 0 ) {
				return;
			}
			this.go_out();
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}