// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Reagentgrinder : Obj_Machinery {

		public bool inuse = false;
		public dynamic beaker = null;
		public dynamic limit = 10;
		public dynamic speed_multiplier = 1;
		public ByTable blend_items = new ByTable()
											.Set( typeof(Obj_Item_Stack_Sheet_Metal), new ByTable().Set( "iron", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Plasma), new ByTable().Set( "plasma", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Uranium), new ByTable().Set( "uranium", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Clown), new ByTable().Set( "banana", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Silver), new ByTable().Set( "silver", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Gold), new ByTable().Set( "gold", 20 ) )
											.Set( typeof(Obj_Item_Weapon_Grown_Nettle), new ByTable().Set( "sacid", 0 ) )
											.Set( typeof(Obj_Item_Weapon_Grown_Deathnettle), new ByTable().Set( "pacid", 0 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Charcoal), new ByTable().Set( "charcoal", 20 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Soybeans), new ByTable().Set( "soymilk", -10 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), new ByTable().Set( "ketchup", -7 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Corn), new ByTable().Set( "cornoil", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Wheat), new ByTable().Set( "flour", -5 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ricestalk), new ByTable().Set( "rice", -5 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cherries), new ByTable().Set( "cherryjelly", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Plastellium), new ByTable().Set( "plasticide", 5 ) )
											.Set( typeof(Obj_Item_Seeds), new ByTable().Set( "blackpepper", 5 ) )
											.Set( typeof(Obj_Item_Weapon_Rocksliver), new ByTable().Set( "ground_rock", 30 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Pill), new ByTable() )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food), new ByTable() )
										;
		public ByTable juice_items = new ByTable()
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), new ByTable().Set( "tomatojuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), new ByTable().Set( "carrotjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries), new ByTable().Set( "berryjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), new ByTable().Set( "banana", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato), new ByTable().Set( "potato", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Apple), new ByTable().Set( "applejuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Lemon), new ByTable().Set( "lemonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Orange), new ByTable().Set( "orangejuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Lime), new ByTable().Set( "limejuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Watermelon), new ByTable().Set( "watermelonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Watermelonslice), new ByTable().Set( "watermelonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Poisonberries), new ByTable().Set( "poisonberryjuice", 0 ) )
										;
		public ByTable holdingitems = new ByTable();
		public string targetMoveKey = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 5;
			this.active_power_usage = 100;
			this.machine_flags = 62;
			this.pass_flags = 1;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "juicer1";
			this.layer = 2.9;
		}

		// Function from file: Chemistry-Machinery.dm
		public Obj_Machinery_Reagentgrinder ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.beaker = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large( this );
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Reagentgrinder(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MicroLaser(), 
				new Obj_Item_Weapon_StockParts_ScanningModule()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public override void AltClick( Mob user = null ) {
			
			if ( !Task13.User.incapacitated() && this.Adjacent( Task13.User ) && Lang13.Bool( this.beaker ) && !( ( this.stat & 3 ) != 0 && Lang13.Bool( Task13.User.dexterity_check() ) ) ) {
				this.detach();
				return;
			}
			base.AltClick( user ); return;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			dynamic _a = href_list["action"]; // Was a switch-case, sorry for the mess.
			if ( _a=="grind" ) {
				this.grind();
			} else if ( _a=="juice" ) {
				this.juice();
			} else if ( _a=="eject" ) {
				this.eject();
			} else if ( _a=="detach" ) {
				this.detach();
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			bool is_chamber_empty = false;
			bool is_beaker_ready = false;
			string processing_chamber = null;
			string beaker_contents = null;
			dynamic dat = null;
			Obj_Item O = null;
			bool anything = false;
			Reagent R = null;
			Browser popup = null;

			is_chamber_empty = false;
			is_beaker_ready = false;
			processing_chamber = "";
			beaker_contents = "";
			dat = new ByTable();

			if ( !this.inuse ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item) )) {
					O = _a;
					
					processing_chamber += new Txt().A( O.name ).item().str( "<BR>" ).ToString();
				}

				if ( !Lang13.Bool( processing_chamber ) ) {
					is_chamber_empty = true;
					processing_chamber = "Nothing.";
				}

				if ( !Lang13.Bool( this.beaker ) ) {
					beaker_contents = "<B>No beaker attached.</B><br>";
				} else {
					is_beaker_ready = true;
					beaker_contents = "<B>The beaker contains:</B><br>";
					anything = false;

					foreach (dynamic _b in Lang13.Enumerate( this.beaker.reagents.reagent_list, typeof(Reagent) )) {
						R = _b;
						
						anything = true;
						beaker_contents += "" + R.volume + " - " + R.name + "<br>";
					}

					if ( !anything ) {
						beaker_contents += "Nothing<br>";
					}
				}
				dat += "\n	<b>Processing chamber contains:</b><br>\n	" + processing_chamber + "<br>\n	" + beaker_contents + "<hr>\n	";

				if ( is_beaker_ready && !is_chamber_empty && !( ( this.stat & 3 ) != 0 ) ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=grind'>Grind the reagents</a><BR>\n				<A href='?src=" ).Ref( this ).str( ";action=juice'>Juice the reagents</a><BR><BR>" ).ToString();
				}

				if ( this.holdingitems != null && this.holdingitems.len > 0 ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=eject'>Eject the reagents</a><BR>" ).ToString();
				}

				if ( Lang13.Bool( this.beaker ) ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=detach'>Detach the beaker</a><BR>" ).ToString();
				}
			} else {
				dat += "Please wait...";
			}
			dat = GlobalFuncs.list2text( dat );
			popup = new Browser( user, "reagentgrinder", "All-In-One Grinder", this );
			popup.set_content( dat );
			popup.open();
			GlobalFuncs.onclose( user, "reagentgrinder" );
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic attack_robot( Mob_Living_Silicon_Robot user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			((Mob)a).set_machine( this );
			this.interact( a );
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return 0;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic R = null;
			dynamic B = null;
			Obj_Item G = null;

			
			if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				return 1;
			}

			if ( a is Obj_Item_Weapon_ReagentContainers_Glass || a is Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass || a is Obj_Item_Weapon_ReagentContainers_Food_Drinks_Shaker ) {
				
				if ( Lang13.Bool( this.beaker ) ) {
					return 0;
				}

				if ( this.panel_open ) {
					GlobalFuncs.to_chat( b, "You can't load a beaker while the maintenance panel is open." );
					return 0;
				} else {
					
					if ( !Lang13.Bool( b.drop_item( a, this ) ) ) {
						GlobalFuncs.to_chat( b, new Txt( "<span class='warning'>You can't let go of " ).the( a ).item().str( "!</span>" ).ToString() );
						return null;
					}
					this.beaker = a;

					if ( b.type == typeof(Mob_Living_Silicon_Robot) ) {
						R = b;
						((Mob_Living_Silicon_Robot)R).uneq_active();
						this.targetMoveKey = R.on_moved.Add( this, "user_moved" );
					}
					this.update_icon();
					this.updateUsrDialog();
					return 1;
				}
			}

			if ( this.holdingitems != null && this.holdingitems.len >= Convert.ToDouble( this.limit ) ) {
				GlobalFuncs.to_chat( Task13.User, "The machine cannot hold any more items." );
				return 1;
			}

			if ( a is Obj_Item_Weapon_Storage_Bag_Plants || a is Obj_Item_Weapon_Storage_Bag_Chem ) {
				B = a;

				foreach (dynamic _a in Lang13.Enumerate( a.contents, typeof(Obj_Item) )) {
					G = _a;
					
					((Obj_Item_Weapon_Storage)B).remove_from_storage( G, this );
					this.holdingitems.Add( G );

					if ( this.holdingitems != null && this.holdingitems.len >= Convert.ToDouble( this.limit ) ) {
						GlobalFuncs.to_chat( b, "You fill the All-In-One grinder to the brim." );
						break;
					}
				}

				if ( !( a.contents.len != 0 ) ) {
					GlobalFuncs.to_chat( b, "You empty the " + a + " into the All-In-One grinder." );
				}
				this.updateUsrDialog();
				return 0;
			}

			if ( !GlobalFuncs.is_type_in_list( a, this.blend_items ) && !GlobalFuncs.is_type_in_list( a, this.juice_items ) ) {
				GlobalFuncs.to_chat( b, "Cannot refine into a reagent." );
				return 1;
			}

			if ( !Lang13.Bool( b.drop_item( a, this ) ) ) {
				b.WriteMsg( new Txt( "<span class='notice'>" ).The( a ).item().str( " is stuck to your hands!</span>" ).ToString() );
				return 1;
			}
			this.holdingitems.Add( a );
			this.updateUsrDialog();
			return 0;
		}

		// Function from file: Chemistry-Machinery.dm
		public override int crowbarDestroy( dynamic user = null ) {
			
			if ( Lang13.Bool( this.beaker ) ) {
				GlobalFuncs.to_chat( user, new Txt( "You can't do that while " ).the( this ).item().str( " has a beaker loaded!" ).ToString() );
				return -1;
			}
			return base.crowbarDestroy( (object)(user) );
		}

		// Function from file: Chemistry-Machinery.dm
		public override int togglePanelOpen( dynamic toggleitem = null, dynamic user = null, dynamic CC = null ) {
			
			if ( Lang13.Bool( this.beaker ) ) {
				GlobalFuncs.to_chat( user, new Txt( "You can't reach " ).the( this ).item().str( "'s maintenance panel with the beaker in the way!" ).ToString() );
				return -1;
			}
			return base.togglePanelOpen( (object)(toggleitem), (object)(user), (object)(CC) );
		}

		// Function from file: Chemistry-Machinery.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "juicer" + String13.NumberToString( !( this.beaker == null ) ?1:0 );
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public override dynamic RefreshParts(  ) {
			int T = 0;
			Obj_Item_Weapon_StockParts_MatterBin M = null;
			Obj_Item_Weapon_StockParts_MicroLaser M2 = null;

			T = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				M = _a;
				
				T += M.rating - 1;
			}
			this.limit = Lang13.Initial( this, "limit" ) + T * 5;
			T = 0;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MicroLaser) )) {
				M2 = _b;
				
				T += M2.rating - 1;
			}
			this.speed_multiplier = Lang13.Initial( this, "speed_multiplier" ) + T * 0.5;
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public void grind(  ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null;
			dynamic allowed = null;
			dynamic r_id = null;
			dynamic space = null;
			double amount = 0;
			Obj_Item_Stack_Sheet O2 = null;
			dynamic allowed2 = null;
			double? i = null;
			dynamic r_id2 = null;
			dynamic space2 = null;
			double amount2 = 0;
			Obj_Item_Weapon_Rocksliver O3 = null;
			dynamic allowed3 = null;
			dynamic r_id3 = null;
			dynamic space3 = null;
			dynamic amount3 = null;
			Obj_Item_Weapon_ReagentContainers O4 = null;
			double? amount4 = null;
			Obj_Item O5 = null;
			dynamic allowed4 = null;
			dynamic r_id4 = null;
			dynamic space4 = null;
			bool amount5 = false;

			this.power_change();

			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}

			if ( !Lang13.Bool( this.beaker ) || Lang13.Bool( this.beaker ) && ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
				return;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), ( Convert.ToDouble( this.speed_multiplier ) < 2 ? "sound/machines/blender.ogg" : "sound/machines/blenderfast.ogg" ), 50, 1 );
			this.inuse = true;
			Task13.Schedule( ((int)( 60 / Convert.ToDouble( this.speed_multiplier ) )), (Task13.Closure)(() => {
				this.inuse = false;
				this.interact( Task13.User );
				return;
			}));

			foreach (dynamic _b in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks) )) {
				O = _b;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed = this.get_allowed_snack_by_id( O );

				if ( allowed == null ) {
					break;
				}

				foreach (dynamic _a in Lang13.Enumerate( allowed )) {
					r_id = _a;
					
					space = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount = Convert.ToDouble( allowed[r_id] );

					if ( amount <= 0 ) {
						
						if ( amount == 0 ) {
							
							if ( O.reagents != null && ((Reagents)O.reagents).has_reagent( "nutriment" ) ) {
								((Reagents)this.beaker.reagents).add_reagent( r_id, Num13.MinInt( ((Reagents)O.reagents).get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
								((Reagents)O.reagents).remove_reagent( "nutriment", Num13.MinInt( ((Reagents)O.reagents).get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
							}
						} else if ( O.reagents != null && ((Reagents)O.reagents).has_reagent( "nutriment" ) ) {
							((Reagents)this.beaker.reagents).add_reagent( r_id, Num13.MinInt( Num13.Floor( ( ((Reagents)O.reagents).get_reagent_amount( "nutriment" ) ?1:0) * Math.Abs( amount ) ), Convert.ToInt32( space ) ) );
							((Reagents)O.reagents).remove_reagent( "nutriment", Num13.MinInt( ((Reagents)O.reagents).get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
						}
					} else {
						((Reagents)O.reagents).trans_id_to( this.beaker, r_id, Num13.MinInt( ((int)( amount )), Convert.ToInt32( space ) ) );
					}

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}

				if ( O.reagents.reagent_list.len == 0 ) {
					this.remove_object( O );
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Stack_Sheet) )) {
				O2 = _d;
				
				allowed2 = this.get_allowed_by_id( O2 );

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				i = null;
				i = 1;

				while (( i ??0) <= Num13.Round( O2.amount ??0, 1 )) {
					
					foreach (dynamic _c in Lang13.Enumerate( allowed2 )) {
						r_id2 = _c;
						
						space2 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
						amount2 = Convert.ToDouble( allowed2[r_id2] );
						((Reagents)this.beaker.reagents).add_reagent( r_id2, Num13.MinInt( ((int)( amount2 )), Convert.ToInt32( space2 ) ) );

						if ( Convert.ToDouble( space2 ) < amount2 ) {
							break;
						}
					}

					if ( i == Num13.Round( O2.amount ??0, 1 ) ) {
						this.remove_object( O2 );
						break;
					}
					i++;
				}
			}

			foreach (dynamic _f in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_Rocksliver) )) {
				O3 = _f;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed3 = this.get_allowed_by_id( O3 );

				foreach (dynamic _e in Lang13.Enumerate( allowed3 )) {
					r_id3 = _e;
					
					space3 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount3 = allowed3[r_id3];
					((Reagents)this.beaker.reagents).add_reagent( r_id3, Num13.MinInt( Convert.ToInt32( amount3 ), Convert.ToInt32( space3 ) ), O3.geological_data );

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}
				this.remove_object( O3 );
			}

			foreach (dynamic _g in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers) )) {
				O4 = _g;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				amount4 = O4.reagents.total_volume;
				((Reagents)O4.reagents).trans_to( this.beaker, amount4 );

				if ( !Lang13.Bool( O4.reagents.total_volume ) ) {
					this.remove_object( O4 );
				}
			}

			foreach (dynamic _i in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item) )) {
				O5 = _i;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed4 = this.get_allowed_by_id( O5 );

				foreach (dynamic _h in Lang13.Enumerate( allowed4 )) {
					r_id4 = _h;
					
					space4 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount5 = Lang13.Bool( allowed4[r_id4] );

					if ( !amount5 ) {
						
						if ( O5.reagents != null && ((Reagents)O5.reagents).has_reagent( r_id4 ) ) {
							((Reagents)this.beaker.reagents).add_reagent( r_id4, Num13.MinInt( ((Reagents)O5.reagents).get_reagent_amount( r_id4 ) ?1:0, Convert.ToInt32( space4 ) ) );
						}
					} else {
						((Reagents)this.beaker.reagents).add_reagent( r_id4, Num13.MinInt( amount5 ?1:0, Convert.ToInt32( space4 ) ) );
					}

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}
				this.remove_object( O5 );
			}
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public void juice(  ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null;
			dynamic allowed = null;
			dynamic r_id = null;
			dynamic space = null;
			int amount = 0;

			this.power_change();

			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}

			if ( !Lang13.Bool( this.beaker ) || Lang13.Bool( this.beaker ) && ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
				return;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), ( Convert.ToDouble( this.speed_multiplier ) < 2 ? "sound/machines/juicer.ogg" : "sound/machines/juicerfast.ogg" ), 30, 1 );
			this.inuse = true;
			Task13.Schedule( ((int)( 50 / Convert.ToDouble( this.speed_multiplier ) )), (Task13.Closure)(() => {
				this.inuse = false;
				this.interact( Task13.User );
				return;
			}));

			foreach (dynamic _b in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks) )) {
				O = _b;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed = this.get_allowed_juice_by_id( O );

				if ( allowed == null ) {
					break;
				}

				foreach (dynamic _a in Lang13.Enumerate( allowed )) {
					r_id = _a;
					
					space = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount = this.get_juice_amount( O );
					((Reagents)this.beaker.reagents).add_reagent( r_id, Num13.MinInt( amount, Convert.ToInt32( space ) ) );

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}
				this.remove_object( O );
			}
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public void remove_object( Obj_Item O = null ) {
			this.holdingitems.Remove( O );
			GlobalFuncs.qdel( O );
			O = null;
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public int get_juice_amount( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			
			if ( !( O is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ) ) {
				return 5;
			} else if ( Convert.ToInt32( ((dynamic)O).potency ) == -1 ) {
				return 5;
			} else {
				return Num13.Floor( Math.Sqrt( Convert.ToDouble( ((dynamic)O).potency ) ) * 5 );
			}
			return 0;
		}

		// Function from file: Chemistry-Machinery.dm
		public int get_grownweapon_amount( dynamic O = null ) {
			
			if ( !( O is Obj_Item_Weapon_Grown ) ) {
				return 5;
			} else if ( Convert.ToInt32( O.potency ) == -1 ) {
				return 5;
			} else {
				return Num13.Floor( Convert.ToDouble( O.potency ) );
			}
			return 0;
		}

		// Function from file: Chemistry-Machinery.dm
		public dynamic get_allowed_juice_by_id( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.juice_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.juice_items[i];
				}
			}
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public dynamic get_allowed_snack_by_id( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.blend_items[i];
				}
			}
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public dynamic get_allowed_by_id( Obj_Item O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.blend_items[i];
				}
			}
			return null;
		}

		// Function from file: Chemistry-Machinery.dm
		public bool is_allowed( dynamic O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: Chemistry-Machinery.dm
		public void eject(  ) {
			Obj_Item O = null;

			
			if ( Task13.User.stat != 0 ) {
				return;
			}

			if ( this.holdingitems != null && this.holdingitems.len == 0 ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item) )) {
				O = _a;
				
				O.loc = this.loc;
				this.holdingitems.Remove( O );
			}
			this.holdingitems = new ByTable();
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public void detach(  ) {
			Ent_Static R = null;

			
			if ( !Lang13.Bool( this.beaker ) ) {
				return;
			}
			((Ent_Dynamic)this.beaker).forceMove( this.loc );

			if ( this.beaker is Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Cyborg ) {
				R = this.beaker.holder.loc;

				if ( ((dynamic)R).module_state_1 == this.beaker || ((dynamic)R).module_state_2 == this.beaker || ((dynamic)R).module_state_3 == this.beaker ) {
					this.beaker.loc = R;
				} else {
					this.beaker.loc = this.beaker.holder;
				}
			}
			this.beaker = null;
			this.update_icon();
			return;
		}

		// Function from file: Chemistry-Machinery.dm
		public void user_moved( dynamic args = null ) {
			dynamic E = null;
			dynamic T = null;

			E = args["event"];

			if ( !Lang13.Bool( this.targetMoveKey ) ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":user_moved" ).ToString() );
				return;
			}
			T = args["loc"];

			if ( !this.Adjacent( T ) ) {
				
				if ( Lang13.Bool( E.holder ) ) {
					E.holder.on_moved.Remove( this.targetMoveKey );
				}
				this.detach();
			}
			return;
		}

	}

}