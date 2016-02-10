// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage : Obj_Item_Weapon {

		public ByTable can_hold = new ByTable();
		public ByTable cant_hold = new ByTable();
		public ByTable is_seeing = new ByTable();
		public dynamic max_w_class = 2;
		public int max_combined_w_class = 14;
		public int? storage_slots = 7;
		public Game_Data boxes = null;
		public Game_Data closer = null;
		public bool use_to_pickup = false;
		public bool display_contents_with_number = false;
		public bool allow_quick_empty = false;
		public bool allow_quick_gather = false;
		public bool collection_mode = true;
		public Type foldable = null;
		public int foldable_amount = 1;
		public int? internal_store = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/storage.dmi";
		}

		// Function from file: storage.dm
		public Obj_Item_Weapon_Storage ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.allow_quick_empty ) {
				this.verbs.Add( typeof(Obj_Item_Weapon_Storage).GetMethod( "quick_empty" ) );
			} else {
				this.verbs.Remove( typeof(Obj_Item_Weapon_Storage).GetMethod( "quick_empty" ) );
			}

			if ( this.allow_quick_gather ) {
				this.verbs.Add( typeof(Obj_Item_Weapon_Storage).GetMethod( "toggle_gathering_mode" ) );
			} else {
				this.verbs.Remove( typeof(Obj_Item_Weapon_Storage).GetMethod( "toggle_gathering_mode" ) );
			}
			this.boxes = GlobalFuncs.getFromPool( typeof(Obj_Screen_Storage) );
			((dynamic)this.boxes).name = "storage";
			((dynamic)this.boxes).master = this;
			((dynamic)this.boxes).icon_state = "block";
			((dynamic)this.boxes).screen_loc = "7,7 to 10,8";
			((dynamic)this.boxes).layer = 19;
			this.closer = GlobalFuncs.getFromPool( typeof(Obj_Screen_Close) );
			((dynamic)this.closer).master = this;
			((dynamic)this.closer).icon_state = "x";
			((dynamic)this.closer).layer = 20;
			this.orient2hud();
			return;
		}

		// Function from file: storage.dm
		public override dynamic stripped( dynamic wearer = null, dynamic stripper = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				I = _a;
				
				I.stripped( wearer, stripper );
			}
			return null;
		}

		// Function from file: storage.dm
		public override void OnMobDeath( Mob holder = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				I = _a;
				
				I.OnMobDeath( holder );
			}
			return;
		}

		// Function from file: storage.dm
		public override bool preattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, dynamic click_parameters = null ) {
			dynamic gather_location = null;
			ByTable rejections = null;
			bool success = false;
			bool failure = false;
			Obj_Item I = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( this.use_to_pickup ) {
				
				if ( this.collection_mode ) {
					
					if ( target.loc is Tile ) {
						
						if ( !this.can_be_inserted( target ) ) {
							return false;
						}
						gather_location = target.loc;
					} else if ( target is Tile ) {
						gather_location = target;
					} else {
						return false;
					}
					rejections = new ByTable();
					success = false;
					failure = false;

					foreach (dynamic _a in Lang13.Enumerate( gather_location, typeof(Obj_Item) )) {
						I = _a;
						
						Interface13.Stat( null, rejections.Contains( I.type ) );

						if ( I is Obj_Item ) {
							continue;
						}

						if ( Lang13.Bool( I.anchored ) ) {
							continue;
						}

						if ( !this.can_be_inserted( I ) ) {
							rejections.Add( I.type );
							failure = true;
							continue;
						}
						success = true;
						this.handle_item_insertion( I, true );
					}

					if ( success && !failure ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You put everything into " ).the( this ).item().str( ".</span>" ).ToString() );
						return true;
					} else if ( success ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You put some things into " ).the( this ).item().str( ".</span>" ).ToString() );
						return true;
					} else {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You fail to pick anything up with " ).the( this ).item().str( ".</span>" ).ToString() );
						return false;
					}
				} else if ( this.can_be_inserted( target ) ) {
					this.handle_item_insertion( target );
					return true;
				}
			}
			return false;
		}

		// Function from file: storage.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Ent_Dynamic AM = null;

			base.Destroy( (object)(brokenup) );
			this.close_all();
			GlobalFuncs.returnToPool( this.boxes );
			GlobalFuncs.returnToPool( this.closer );
			this.boxes = null;
			this.closer = null;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				GlobalFuncs.qdel( AM );
			}
			this.contents = null;
			return null;
		}

		// Function from file: storage.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			bool found = false;
			dynamic M = null;

			
			if ( ((Mob)user).get_active_hand() == this ) {
				
				if ( this.verbs.Find( typeof(Obj_Item_Weapon_Storage).GetMethod( "quick_empty" ) ) != 0 ) {
					this.__CallVerb("Empty Contents" );
					return null;
				}
			}

			if ( this.contents.len != 0 ) {
				return null;
			}

			if ( !( this.foldable is Type ) ) {
				return null;
			}
			found = false;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( null, 1 ) )) {
				M = _a;
				

				if ( M.s_active == this ) {
					this.close( M );
				}

				if ( M == user ) {
					found = true;
				}
			}

			if ( !found ) {
				return null;
			}
			GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You fold " ).the( this ).item().str( " flat.</span>" ).ToString() );
			Lang13.Call( this.foldable, GlobalFuncs.get_turf( this ), this.foldable_amount );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: storage.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			Obj O = null;

			
			if ( !( this.loc is Mob_Living ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					O = _a;
					
					O.ex_act( severity );
				}
			}
			base.ex_act( severity, (object)(child) );
			return false;
		}

		// Function from file: storage.dm
		public override dynamic emp_act( int severity = 0 ) {
			Obj O = null;

			
			if ( !( this.loc is Mob_Living ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					O = _a;
					
					O.emp_act( severity );
				}
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: storage.dm
		public override int recycle( Game_Data rec = null ) {
			
			if ( this.contents != null ) {
				this.mass_remove( GlobalFuncs.get_turf( this ) );
			}
			return base.recycle( rec );
		}

		// Function from file: storage.dm
		public override bool throw_at( dynamic target = null, double? range = null, dynamic speed = null, bool? _override = null ) {
			this.close_all();
			base.throw_at( (object)(target), range, (object)(speed), _override );
			return false;
		}

		// Function from file: storage.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: storage.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic H = null;
			Ent_Static maxloc = null;
			int? i = null;
			dynamic M = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );

			if ( a is Mob_Living_Carbon_Human ) {
				H = a;

				if ( ( H.l_store == this || H.r_store == this ) && !Lang13.Bool( ((Mob)H).get_active_hand() ) ) {
					return base.attack_hand( (object)(a), (object)(b), (object)(c) );
				}
			}
			this.orient2hud( a );
			maxloc = this.loc;

			if ( Lang13.Bool( this.internal_store ) ) {
				i = null;
				i = 1;

				while (( i++ ??0) <= ( this.internal_store ??0)) {
					
					if ( maxloc == a ) {
						break;
					}

					if ( maxloc.loc != null ) {
						maxloc = maxloc.loc;
					}
				}
			}

			if ( maxloc == a ) {
				
				if ( a.s_active != null ) {
					((dynamic)a.s_active).close( a );
				}
				this.show_to( a );
			} else {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( null, 1 ) )) {
					M = _a;
					

					if ( M.s_active == this ) {
						this.close( M );
					}
				}
			}
			this.add_fingerprint( a );
			return null;
		}

		// Function from file: storage.dm
		public override dynamic MouseDrop( Mob over_object = null, dynamic src_location = null, Ent_Static over_location = null, dynamic src_control = null, dynamic over_control = null, string _params = null ) {
			Mob M = null;
			Mob L = null;

			
			if ( Task13.User is Mob_Living_Carbon_Human || Task13.User is Mob_Living_Carbon_Monkey ) {
				M = Task13.User;

				if ( over_object is Obj_Structure_Table && M.Adjacent( over_object ) ) {
					L = Task13.User;

					if ( L is Mob_Living && !( L.incapacitated() || L.lying == true ) ) {
						this.empty_contents_to( over_object );
					}
				}

				if ( !( over_object is Obj_Screen ) ) {
					return base.MouseDrop( over_object, (object)(src_location), over_location, (object)(src_control), (object)(over_control), _params );
				}

				if ( !( this.loc == Task13.User ) || this.loc != null && this.loc.loc == Task13.User ) {
					return null;
				}
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );

				if ( !M.restrained() && !Lang13.Bool( M.stat ) ) {
					
					switch ((string)( over_object.name )) {
						case "r_hand":
							M.u_equip( this, false );
							M.put_in_r_hand( this );
							break;
						case "l_hand":
							M.u_equip( this, false );
							M.put_in_l_hand( this );
							break;
					}
					this.add_fingerprint( Task13.User );
					return null;
				}

				if ( over_object == Task13.User && GlobalFuncs.in_range( this, Task13.User ) || Task13.User.contents.Find( this ) != 0 ) {
					
					if ( Task13.User.s_active != null ) {
						((Obj_Item_Weapon_Storage)Task13.User.s_active).close( Task13.User );
					}
					this.show_to( Task13.User );
					return null;
				}
			}
			return null;
		}

		// Function from file: storage.dm
		public override dynamic dropped( dynamic user = null ) {
			base.dropped( (object)(user) );
			return null;
		}

		// Function from file: storage.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic M = null;
			dynamic T = null;

			
			if ( !this.Adjacent( b, 3 ) ) {
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( b is Mob_Living_Silicon_Robot ) {
				
				if ( b is Mob_Living_Silicon_Robot_Mommi ) {
					M = b;

					if ( Lang13.Bool( ((Mob_Living_Silicon_Robot_Mommi)M).is_in_modules( a ) ) ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>You can't throw away something built into you.</span>" );
						return null;
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>You're a robot. No.</span>" );
					return null;
				}
			}

			if ( !this.can_be_inserted( a ) ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Tray ) {
				T = a;

				if ( ((Obj_Item_Weapon_Tray)T).calc_carry() > 0 ) {
					
					if ( Rand13.PercentChance( 85 ) ) {
						GlobalFuncs.to_chat( b, new Txt( "<span class='warning'>The tray won't fit in " ).the( this ).item().str( ".</span>" ).ToString() );
						return null;
					} else {
						b.drop_item( a, b.loc );
						GlobalFuncs.to_chat( b, "<span class='warning'>God damnit!</span>" );
						return null;
					}
				}
			}
			return this.handle_item_insertion( a );
		}

		// Function from file: storage.dm
		public virtual void mass_remove( dynamic A = null ) {
			Obj_Item O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				O = _a;
				
				this.remove_from_storage( O, A );
			}
			return;
		}

		// Function from file: storage.dm
		public bool close_all(  ) {
			bool _default = false;

			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.is_seeing )) {
				M = _a;
				
				this.close( M );
				_default = true;
			}
			return _default;
		}

		// Function from file: storage.dm
		public ByTable can_see_contents(  ) {
			ByTable cansee = null;
			dynamic M = null;

			cansee = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.is_seeing )) {
				M = _a;
				

				if ( M.s_active == this && Lang13.Bool( M.client ) ) {
					cansee.Or( M );
				} else {
					this.is_seeing.Remove( M );
				}
			}
			return cansee;
		}

		// Function from file: storage.dm
		public virtual bool remove_from_storage( dynamic W = null, dynamic new_location = null, bool? force = null ) {
			force = force ?? false;

			dynamic A = null;
			Obj_Item_Weapon_Storage F = null;
			dynamic M = null;
			dynamic M2 = null;
			dynamic A2 = null;

			
			if ( !( W is Obj_Item ) ) {
				return false;
			}

			if ( !( force == true ) && new_location is Obj_Item_Weapon_Storage ) {
				A = new_location;

				if ( !((Obj_Item_Weapon_Storage)A).can_be_inserted( W, true ) ) {
					return false;
				}
			}

			if ( this is Obj_Item_Weapon_Storage_Fancy ) {
				F = this;
				F.update_icon( 1 );
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( GlobalFuncs.get_turf( this ), 1 ) )) {
				M = _a;
				

				if ( M.s_active == this ) {
					
					if ( Lang13.Bool( M.client ) ) {
						M.client.screen -= W;
					}
				}
			}

			if ( Lang13.Bool( new_location ) ) {
				M2 = null;

				if ( this.loc is Mob ) {
					M2 = this.loc;
					((Obj_Item)W).dropped( M2 );
				}

				if ( new_location is Mob ) {
					M2 = new_location;
					((Mob)M2).put_in_active_hand( W );
				} else if ( new_location is Obj_Item_Weapon_Storage ) {
					A2 = new_location;
					((Obj_Item_Weapon_Storage)A2).handle_item_insertion( W, true );
				} else {
					((Ent_Dynamic)W).forceMove( new_location );
				}
			} else {
				((Ent_Dynamic)W).forceMove( GlobalFuncs.get_turf( this ) );
			}

			if ( Task13.User != null ) {
				this.orient2hud( Task13.User );

				if ( Task13.User.s_active != null ) {
					((dynamic)Task13.User.s_active).show_to( Task13.User );
				}
			}

			if ( Lang13.Bool( W.maptext ) ) {
				W.maptext = "";
			}
			((Obj_Item)W).on_exit_storage( this );
			this.update_icon();
			return true;
		}

		// Function from file: storage.dm
		public virtual bool handle_item_insertion( dynamic W = null, bool? prevent_warning = null ) {
			prevent_warning = prevent_warning ?? false;

			dynamic M = null;

			
			if ( !( W is Obj_Item ) ) {
				return false;
			}

			if ( Task13.User != null ) {
				Task13.User.u_equip( W, true );
				Task13.User.update_icons();
			}
			((Ent_Dynamic)W).forceMove( this );
			((Obj_Item)W).on_enter_storage( this );

			if ( Task13.User != null ) {
				
				if ( Task13.User.client != null && Task13.User.s_active != this ) {
					Task13.User.client.screen.Remove( W );
				}
				this.add_fingerprint( Task13.User );

				if ( !( prevent_warning == true ) && !( W is Obj_Item_Weapon_Gun_Energy_Crossbow ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, Task13.User ) )) {
						M = _a;
						

						if ( M == Task13.User ) {
							GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You put " ).the( W ).item().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
						} else {
							Interface13.Stat( null, Map13.FetchInRange( null, 1 ).Contains( M ) );

							if ( M == Task13.User ) {
								M.show_message( new Txt( "<span class='notice'>" ).item( Task13.User ).str( " puts " ).the( W ).item().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
							} else if ( Lang13.Bool( W ) && Convert.ToDouble( W.w_class ) >= 3 ) {
								M.show_message( new Txt( "<span class='notice'>" ).item( Task13.User ).str( " puts " ).the( W ).item().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
							}
						}
					}
				}
				this.orient2hud( Task13.User );

				if ( Task13.User.s_active != null ) {
					((dynamic)Task13.User.s_active).show_to( Task13.User );
				}
			}
			this.update_icon();
			return true;
		}

		// Function from file: storage.dm
		public virtual bool can_be_inserted( dynamic W = null, bool? stop_messages = null ) {
			stop_messages = stop_messages ?? false;

			dynamic offhand = null;
			dynamic ref_name = null;
			bool ok = false;
			dynamic A = null;
			dynamic A2 = null;
			bool nope = false;
			dynamic sum_w_class = null;
			Obj_Item I = null;

			
			if ( !( W is Obj_Item ) ) {
				return false;
			}

			if ( this.loc == W ) {
				return false;
			}

			if ( this.contents.len >= ( this.storage_slots ??0) ) {
				
				if ( !( stop_messages == true ) ) {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( this ).item().str( " is full, make some space.</span>" ).ToString() );
				}
				return false;
			}

			if ( Task13.User != null && W.cant_drop > 0 ) {
				
				if ( !( stop_messages == true ) ) {
					Task13.User.WriteMsg( new Txt( "<span class='notice'>You can't let go of " ).the( W ).item().str( "!</span>" ).ToString() );
				}
				return false;
			}

			if ( Lang13.Bool( W.wielded ) || W is Obj_Item_Offhand ) {
				offhand = W;
				ref_name = W;

				if ( offhand is Obj_Item_Offhand ) {
					ref_name = offhand.wielding;
				}
				GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>Unwield " ).the( ref_name ).item().str( " first.</span>" ).ToString() );
				return false;
			}

			if ( this.can_hold.len != 0 ) {
				ok = false;

				foreach (dynamic _a in Lang13.Enumerate( this.can_hold )) {
					A = _a;
					

					if ( GlobalFuncs.dd_hasprefix( A, "=" ) != 0 ) {
						
						if ( "" + W.type == String13.SubStr( A, 2, 0 ) ) {
							ok = true;
							break;
						}
					} else if ( Lang13.Bool( ((dynamic)Lang13.FindClass( A )).IsInstanceOfType( W ) ) ) {
						ok = true;
						break;
					}
				}

				if ( !ok ) {
					
					if ( !( stop_messages == true ) ) {
						
						if ( W is Obj_Item_Weapon_HandLabeler ) {
							return false;
						}
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( this ).item().str( " cannot hold " ).the( W ).item().str( ".</span>" ).ToString() );
					}
					return false;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.cant_hold )) {
				A2 = _b;
				
				nope = false;

				if ( GlobalFuncs.dd_hasprefix( A2, "=" ) != 0 ) {
					
					if ( "" + W.type == String13.SubStr( A2, 2, 0 ) ) {
						nope = true;
						break;
					}
				} else if ( Lang13.Bool( ((dynamic)Lang13.FindClass( A2 )).IsInstanceOfType( W ) ) ) {
					nope = true;
					break;
				}

				if ( nope ) {
					
					if ( !( stop_messages == true ) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( this ).item().str( " cannot hold " ).the( W ).item().str( ".</span>" ).ToString() );
					}
					return false;
				}
			}

			if ( Convert.ToDouble( W.w_class ) > Convert.ToDouble( this.max_w_class ) ) {
				
				if ( !( stop_messages == true ) ) {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( W ).item().str( " is too big for " ).the( this ).item().str( ".</span>" ).ToString() );
				}
				return false;
			}
			sum_w_class = W.w_class;

			foreach (dynamic _c in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				I = _c;
				
				sum_w_class += I.w_class;
			}

			if ( Convert.ToDouble( sum_w_class ) > this.max_combined_w_class ) {
				
				if ( !( stop_messages == true ) ) {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( this ).item().str( " is full, make some space.</span>" ).ToString() );
				}
				return false;
			}

			if ( Convert.ToDouble( W.w_class ) >= Convert.ToDouble( this.w_class ) && W is Obj_Item_Weapon_Storage ) {
				
				if ( !( this is Obj_Item_Weapon_Storage_Backpack_Holding ) ) {
					
					if ( !( stop_messages == true ) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>" ).The( this ).item().str( " cannot hold " ).the( W ).item().str( " as it's a storage item of the same size.</span>" ).ToString() );
					}
					return false;
				}
			}
			return true;
		}

		// Function from file: storage.dm
		public virtual void orient2hud( dynamic user = null ) {
			int adjusted_contents = 0;
			ByTable numbered_contents = null;
			Obj_Item I = null;
			bool found = false;
			NumberedDisplay ND = null;
			int row_num = 0;
			int col_count = 0;

			adjusted_contents = this.contents.len;

			if ( this.display_contents_with_number ) {
				numbered_contents = new ByTable();
				adjusted_contents = 0;

				foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
					I = _b;
					
					found = false;

					foreach (dynamic _a in Lang13.Enumerate( numbered_contents, typeof(NumberedDisplay) )) {
						ND = _a;
						

						if ( ND.sample_object.type == I.type ) {
							ND.number++;
							found = true;
							break;
						}
					}

					if ( !found ) {
						adjusted_contents++;
						numbered_contents.Add( new NumberedDisplay( I ) );
					}
				}
			}
			row_num = 0;
			col_count = Num13.MinInt( 7, this.storage_slots ??0 ) - 1;

			if ( adjusted_contents > 7 ) {
				row_num = Num13.Floor( ( adjusted_contents - 1 ) / 7 );
			}
			this.standard_orient_objs( row_num, col_count, numbered_contents );
			return;
		}

		// Function from file: storage.dm
		public void standard_orient_objs( int rows = 0, int cols = 0, ByTable display_contents = null ) {
			int cx = 0;
			int cy = 0;
			NumberedDisplay ND = null;
			Obj O = null;

			cx = 4;
			cy = rows + 2;
			((dynamic)this.boxes).screen_loc = "4:16,2:16 to " + ( cols + 4 ) + ":16," + ( rows + 2 ) + ":16";

			if ( this.display_contents_with_number ) {
				
				foreach (dynamic _a in Lang13.Enumerate( display_contents, typeof(NumberedDisplay) )) {
					ND = _a;
					
					ND.sample_object.screen_loc = "" + cx + ":16," + cy + ":16";
					ND.sample_object.maptext = "<font color='white'>" + ( ( ND.number ??0) > 1 ? "" + ND.number : "" ) + "</font>";
					ND.sample_object.layer = 20;
					cx++;

					if ( cx > cols + 4 ) {
						cx = 4;
						cy--;
					}
				}
			} else {
				
				foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					O = _b;
					
					O.screen_loc = "" + cx + ":16," + cy + ":16";
					O.maptext = "";
					O.layer = 20;
					cx++;

					if ( cx > cols + 4 ) {
						cx = 4;
						cy--;
					}
				}
			}
			((dynamic)this.closer).screen_loc = "" + ( cols + 5 ) + ":16,2:16";
			return;
		}

		// Function from file: storage.dm
		public void orient_objs( dynamic tx = null, dynamic ty = null, int mx = 0, dynamic my = null ) {
			int cx = 0;
			int cy = 0;
			Obj O = null;

			cx = Convert.ToInt32( tx );
			cy = Convert.ToInt32( ty );
			((dynamic)this.boxes).screen_loc = "" + tx + ":," + ty + " to " + mx + "," + my;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
				O = _a;
				
				O.screen_loc = "" + cx + "," + cy;
				O.layer = 20;
				cx++;

				if ( cx > mx ) {
					cx = Convert.ToInt32( tx );
					cy--;
				}
			}
			((dynamic)this.closer).screen_loc = "" + ( mx + 1 ) + "," + my;
			return;
		}

		// Function from file: storage.dm
		public virtual void close( dynamic user = null ) {
			this.hide_from( user );
			user.s_active = null;
			return;
		}

		// Function from file: storage.dm
		public void hide_from( dynamic user = null ) {
			
			if ( !Lang13.Bool( user.client ) ) {
				return;
			}
			user.client.screen -= this.boxes;
			user.client.screen -= this.closer;
			user.client.screen -= this.contents;

			if ( user.s_active == this ) {
				user.s_active = null;
			}
			this.is_seeing.Remove( user );
			return;
		}

		// Function from file: storage.dm
		public virtual dynamic show_to( dynamic user = null ) {
			Obj_Item I = null;

			
			if ( user is Mob_Living ) {
				
				if ( user.s_active != this ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item) )) {
						I = _a;
						

						if ( I.on_found( user ) ) {
							return null;
						}
					}
				}
			}

			if ( user.s_active != null ) {
				((Obj_Item_Weapon_Storage)user.s_active).hide_from( user );
			}
			user.client.screen -= this.boxes;
			user.client.screen -= this.closer;
			user.client.screen -= this.contents;
			user.client.screen += this.boxes;
			user.client.screen += this.closer;
			user.client.screen += this.contents;
			user.s_active = this;
			this.is_seeing.Or( user );
			return null;
		}

		// Function from file: storage.dm
		public ByTable return_inv(  ) {
			ByTable L = null;
			Obj_Item_Weapon_Storage S = null;
			Obj_Item_Weapon_Gift G = null;

			L = new ByTable();
			L.Add( this.contents );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item_Weapon_Storage) )) {
				S = _a;
				
				L.Add( S.return_inv() );
			}

			foreach (dynamic _b in Lang13.Enumerate( this, typeof(Obj_Item_Weapon_Gift) )) {
				G = _b;
				
				L.Add( G.gift );

				if ( G.gift is Obj_Item_Weapon_Storage ) {
					L.Add( G.gift.return_inv() );
				}
			}
			return L;
		}

		// Function from file: storage.dm
		public void empty_contents_to( Mob place = null ) {
			dynamic turf = null;
			Obj objects = null;

			turf = GlobalFuncs.get_turf( place );

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
				objects = _a;
				
				this.remove_from_storage( objects, turf );
				objects.pixel_x = Rand13.Int( -6, 6 );
				objects.pixel_y = Rand13.Int( -6, 6 );
			}
			return;
		}

		// Function from file: storage.dm
		[Verb]
		[VerbInfo( name: "Empty Contents", group: "Object" )]
		public virtual void quick_empty(  ) {
			dynamic T = null;

			
			if ( !( Task13.User is Mob_Living_Carbon_Human ) && this.loc != Task13.User || Task13.User.isUnconscious() || Task13.User.restrained() ) {
				return;
			}
			T = GlobalFuncs.get_turf( this );
			this.hide_from( Task13.User );
			this.mass_remove( T );
			return;
		}

		// Function from file: storage.dm
		[Verb]
		[VerbInfo( name: "Switch Gathering Method", group: "Object" )]
		public void toggle_gathering_mode(  ) {
			this.collection_mode = !this.collection_mode;

			switch ((bool)( this.collection_mode )) {
				case 1:
					GlobalFuncs.to_chat( Task13.User, new Txt().The( this ).item().str( " will now pick up all items on a tile at once." ).ToString() );
					break;
				case 0:
					GlobalFuncs.to_chat( Task13.User, new Txt().The( this ).item().str( " will now pick up one item at a time." ).ToString() );
					break;
			}
			return;
		}

	}

}