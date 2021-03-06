// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Biogenerator : Obj_Machinery {

		public bool processing = false;
		public dynamic beaker = null;
		public double points = 0;
		public string menustat = "menu";
		public double efficiency = 0;
		public double productivity = 0;
		public dynamic max_items = 40;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 40;
			this.icon = "icons/obj/biogenerator.dmi";
			this.icon_state = "biogen-empty";
		}

		// Function from file: biogenerator.dm
		public Obj_Machinery_Biogenerator ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 1000 );
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Biogenerator( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ConsoleScreen( null ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.RefreshParts();
			return;
		}

		// Function from file: biogenerator.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			double? amount = null;
			double? i = null;
			dynamic C = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) || Lang13.Bool( this.panel_open ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["activate"] ) ) {
				this.activate();
				this.updateUsrDialog();
			} else if ( Lang13.Bool( href_list["detach"] ) ) {
				this.detach();
				this.updateUsrDialog();
			} else if ( Lang13.Bool( href_list["create"] ) ) {
				amount = String13.ParseNumber( href_list["amount"] );
				i = amount;
				C = href_list["create"];

				if ( ( i ??0) <= 0 ) {
					return null;
				}

				while (( i ??0) >= 1) {
					this.create_product( C );
					i--;
				}
				this.updateUsrDialog();
			} else if ( Lang13.Bool( href_list["menu"] ) ) {
				this.menustat = "menu";
				this.updateUsrDialog();
			}
			return null;
		}

		// Function from file: biogenerator.dm
		public void detach(  ) {
			
			if ( Lang13.Bool( this.beaker ) ) {
				this.beaker.loc = this.loc;
				this.beaker = null;
				this.update_icon();
			}
			return;
		}

		// Function from file: biogenerator.dm
		public bool create_product( dynamic create = null ) {
			
			dynamic _a = create; // Was a switch-case, sorry for the mess.
			if ( _a=="milk" ) {
				
				if ( this.check_container_volume( 10 ) ) {
					return false;
				} else if ( this.check_cost( 20 / this.efficiency ) ) {
					return false;
				} else {
					this.beaker.reagents.add_reagent( "milk", 10 );
				}
			} else if ( _a=="cream" ) {
				
				if ( this.check_container_volume( 10 ) ) {
					return false;
				} else if ( this.check_cost( 30 / this.efficiency ) ) {
					return false;
				} else {
					this.beaker.reagents.add_reagent( "cream", 10 );
				}
			} else if ( _a=="cmilk" ) {
				
				if ( this.check_cost( 100 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Food_Condiment_Milk( this.loc );
				}
			} else if ( _a=="ccream" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Cream( this.loc );
				}
			} else if ( _a=="meat" ) {
				
				if ( this.check_cost( 250 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Monkeycube( this.loc );
				}
			} else if ( _a=="ez" ) {
				
				if ( this.check_cost( 10 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Ez( this.loc );
				}
			} else if ( _a=="l4z" ) {
				
				if ( this.check_cost( 20 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_L4z( this.loc );
				}
			} else if ( _a=="rh" ) {
				
				if ( this.check_cost( 25 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Rh( this.loc );
				}
			} else if ( _a=="wk" ) {
				
				if ( this.check_cost( 50 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Weedkiller( this.loc );
				}
			} else if ( _a=="pk" ) {
				
				if ( this.check_cost( 50 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Pestkiller( this.loc );
				}
			} else if ( _a=="wallet" ) {
				
				if ( this.check_cost( 100 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Wallet( this.loc );
				}
			} else if ( _a=="bkbag" ) {
				
				if ( this.check_cost( 200 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Bag_Books( this.loc );
				}
			} else if ( _a=="ptbag" ) {
				
				if ( this.check_cost( 200 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Bag_Plants( this.loc );
				}
			} else if ( _a=="mnbag" ) {
				
				if ( this.check_cost( 200 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Bag_Ore( this.loc );
				}
			} else if ( _a=="chbag" ) {
				
				if ( this.check_cost( 200 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Bag_Chemistry( this.loc );
				}
			} else if ( _a=="rag" ) {
				
				if ( this.check_cost( 200 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_ReagentContainers_Glass_Rag( this.loc );
				}
			} else if ( _a=="gloves" ) {
				
				if ( this.check_cost( 250 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Clothing_Gloves_BotanicLeather( this.loc );
				}
			} else if ( _a=="tbelt" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Utility( this.loc );
				}
			} else if ( _a=="sbelt" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Security( this.loc );
				}
			} else if ( _a=="mbelt" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Medical( this.loc );
				}
			} else if ( _a=="jbelt" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Janitor( this.loc );
				}
			} else if ( _a=="bbelt" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Bandolier( this.loc );
				}
			} else if ( _a=="sholster" ) {
				
				if ( this.check_cost( 400 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Belt_Holster( this.loc );
				}
			} else if ( _a=="satchel" ) {
				
				if ( this.check_cost( 400 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Weapon_Storage_Backpack_Satchel( this.loc );
				}
			} else if ( _a=="jacket" ) {
				
				if ( this.check_cost( 500 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Clothing_Suit_Jacket_Leather( this.loc );
				}
			} else if ( _a=="overcoat" ) {
				
				if ( this.check_cost( 1000 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Clothing_Suit_Jacket_Leather_Overcoat( this.loc );
				}
			} else if ( _a=="rice_hat" ) {
				
				if ( this.check_cost( 300 / this.efficiency ) ) {
					return false;
				} else {
					new Obj_Item_Clothing_Head_RiceHat( this.loc );
				}
			}
			this.processing = false;
			this.menustat = "complete";
			this.update_icon();
			return true;
		}

		// Function from file: biogenerator.dm
		public bool check_container_volume( int reagent_amount = 0 ) {
			
			if ( ( this.beaker.reagents.total_volume ??0) + reagent_amount > Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
				this.menustat = "nobeakerspace";
				return true;
			}
			return false;
		}

		// Function from file: biogenerator.dm
		public bool check_cost( double cost = 0 ) {
			
			if ( cost > this.points ) {
				this.menustat = "nopoints";
				return true;
			} else {
				this.points -= cost;
				this.processing = true;
				this.update_icon();
				this.updateUsrDialog();
				return false;
			}
		}

		// Function from file: biogenerator.dm
		public void activate(  ) {
			int S = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown I = null;

			
			if ( Task13.User.stat != 0 ) {
				return;
			}

			if ( this.stat != 0 ) {
				return;
			}

			if ( this.processing ) {
				Task13.User.WriteMsg( "<span class='warning'>The biogenerator is in the process of working.</span>" );
				return;
			}
			S = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown) )) {
				I = _a;
				
				S += 5;

				if ( ( I.reagents.get_reagent_amount( "nutriment" ) ?1:0) < 0.1 ) {
					this.points += this.productivity;
				} else {
					this.points += ( I.reagents.get_reagent_amount( "nutriment" ) ?1:0) * this.productivity * 10;
				}
				GlobalFuncs.qdel( I );
			}

			if ( S != 0 ) {
				this.processing = true;
				this.update_icon();
				this.updateUsrDialog();
				GlobalFuncs.playsound( this.loc, "sound/machines/blender.ogg", 50, 1 );
				this.f_use_power( S * 30 );
				Task13.Sleep( ((int)( S + 15 / this.productivity )) );
				this.processing = false;
				this.update_icon();
			} else {
				this.menustat = "void";
			}
			return;
		}

		// Function from file: biogenerator.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.interact( a );
			return null;
		}

		// Function from file: biogenerator.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic dat = null;
			Browser popup = null;

			
			if ( ( this.stat & 1 ) != 0 || Lang13.Bool( this.panel_open ) ) {
				return null;
			}
			((Mob)user).set_machine( this );

			if ( this.processing ) {
				dat += "<div class='statusDisplay'>Biogenerator is processing! Please wait...</div><BR>";
			} else {
				
				switch ((string)( this.menustat )) {
					case "nopoints":
						dat += "<div class='statusDisplay'>You do not have biomass to create products.<BR>Please, put growns into reactor and activate it.</div>";
						this.menustat = "menu";
						break;
					case "complete":
						dat += "<div class='statusDisplay'>Operation complete.</div>";
						this.menustat = "menu";
						break;
					case "void":
						dat += "<div class='statusDisplay'>Error: No growns inside.<BR>Please, put growns into reactor.</div>";
						this.menustat = "menu";
						break;
					case "nobeakerspace":
						dat += "<div class='statusDisplay'>Not enough space left in container. Unable to create product.</div>";
						this.menustat = "menu";
						break;
				}

				if ( Lang13.Bool( this.beaker ) ) {
					dat += "<div class='statusDisplay'>Biomass: " + this.points + " units.</div><BR>";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";activate=1'>Activate</A><A href='?src=" ).Ref( this ).str( ";detach=1'>Detach Container</A>" ).ToString();
					dat += "<h3>Food:</h3>";
					dat += "<div class='statusDisplay'>";
					dat += new Txt( "10 milk: <A href='?src=" ).Ref( this ).str( ";create=milk;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=milk;amount=5'>x5</A> (" ).item( 20 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "10 cream: <A href='?src=" ).Ref( this ).str( ";create=cream;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=cream;amount=5'>x5</A> (" ).item( 30 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Milk Carton: <A href='?src=" ).Ref( this ).str( ";create=cmilk;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=cmilk;amount=5'>x5</A> (" ).item( 100 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Cream Carton: <A href='?src=" ).Ref( this ).str( ";create=ccream;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=ccream;amount=5'>x5</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Monkey cube: <A href='?src=" ).Ref( this ).str( ";create=meat;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=meat;amount=5'>x5</A> (" ).item( 250 / this.efficiency ).str( ")" ).ToString();
					dat += "</div>";
					dat += "<h3>Botany Chemicals:</h3>";
					dat += "<div class='statusDisplay'>";
					dat += new Txt( "E-Z-Nutrient: <A href='?src=" ).Ref( this ).str( ";create=ez;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=ez;amount=5'>x5</A> (" ).item( 10 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Left 4 Zed: <A href='?src=" ).Ref( this ).str( ";create=l4z;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=l4z;amount=5'>x5</A> (" ).item( 20 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Robust Harvest: <A href='?src=" ).Ref( this ).str( ";create=rh;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=rh;amount=5'>x5</A> (" ).item( 25 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Weed Killer: <A href='?src=" ).Ref( this ).str( ";create=wk;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=wk;amount=5'>x5</A> (" ).item( 50 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Pest Killer: <A href='?src=" ).Ref( this ).str( ";create=pk;amount=1'>Make</A><A href='?src=" ).Ref( this ).str( ";create=pk;amount=5'>x5</A> (" ).item( 50 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += "</div>";
					dat += "<h3>Leather and Cloth:</h3>";
					dat += "<div class='statusDisplay'>";
					dat += new Txt( "Wallet: <A href='?src=" ).Ref( this ).str( ";create=wallet;amount=1'>Make</A> (" ).item( 100 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Book bag: <A href='?src=" ).Ref( this ).str( ";create=bkbag;amount=1'>Make</A> (" ).item( 200 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Plant bag: <A href='?src=" ).Ref( this ).str( ";create=ptbag;amount=1'>Make</A> (" ).item( 200 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Rag: <A href='?src=" ).Ref( this ).str( ";create=rag;amount=1'>Make</A> (" ).item( 200 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Mining satchel: <A href='?src=" ).Ref( this ).str( ";create=mnbag;amount=1'>Make</A> (" ).item( 200 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Chemistry bag: <A href='?src=" ).Ref( this ).str( ";create=chbag;amount=1'>Make</A> (" ).item( 200 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Botanical gloves: <A href='?src=" ).Ref( this ).str( ";create=gloves;amount=1'>Make</A> (" ).item( 250 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Utility belt: <A href='?src=" ).Ref( this ).str( ";create=tbelt;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Security belt: <A href='?src=" ).Ref( this ).str( ";create=sbelt;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Medical belt: <A href='?src=" ).Ref( this ).str( ";create=mbelt;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Janitorial belt: <A href='?src=" ).Ref( this ).str( ";create=jbelt;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Bandolier belt: <A href='?src=" ).Ref( this ).str( ";create=bbelt;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Shoulder holster: <A href='?src=" ).Ref( this ).str( ";create=sholster;amount=1'>Make</A> (" ).item( 400 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Leather Satchel: <A href='?src=" ).Ref( this ).str( ";create=satchel;amount=1'>Make</A> (" ).item( 400 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Leather Jacket: <A href='?src=" ).Ref( this ).str( ";create=jacket;amount=1'>Make</A> (" ).item( 500 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Leather Overcoat: <A href='?src=" ).Ref( this ).str( ";create=overcoat;amount=1'>Make</A> (" ).item( 1000 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += new Txt( "Rice Hat: <A href='?src=" ).Ref( this ).str( ";create=rice_hat;amount=1'>Make</A> (" ).item( 300 / this.efficiency ).str( ")<BR>" ).ToString();
					dat += "</div>";
				} else {
					dat += "<div class='statusDisplay'>No container inside, please insert container.</div>";
				}
			}
			popup = new Browser( user, "biogen", this.name, 350, 520 );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: biogenerator.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			int i = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown G = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown G2 = null;
			int i2 = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown G3 = null;
			dynamic B = null;

			
			if ( A is Obj_Item_Weapon_ReagentContainers_Glass && !Lang13.Bool( this.panel_open ) ) {
				
				if ( Lang13.Bool( this.beaker ) ) {
					user.WriteMsg( "<span class='warning'>A container is already loaded into the machine.</span>" );
				} else {
					((Mob)user).unEquip( A );
					A.loc = this;
					this.beaker = A;
					user.WriteMsg( "<span class='notice'>You add the container to the machine.</span>" );
					this.updateUsrDialog();
				}
			} else if ( this.processing ) {
				user.WriteMsg( "<span class='warning'>The biogenerator is currently processing.</span>" );
			} else if ( A is Obj_Item_Weapon_Storage_Bag_Plants ) {
				i = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown) )) {
					G = _a;
					
					i++;
				}

				if ( i >= Convert.ToDouble( this.max_items ) ) {
					user.WriteMsg( "<span class='warning'>The biogenerator is already full! Activate it.</span>" );
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( A.contents, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown) )) {
						G2 = _b;
						

						if ( i >= Convert.ToDouble( this.max_items ) ) {
							break;
						}
						G2.loc = this;
						i++;
					}

					if ( i < Convert.ToDouble( this.max_items ) ) {
						user.WriteMsg( "<span class='info'>You empty the plant bag into the biogenerator.</span>" );
					} else if ( A.contents.len == 0 ) {
						user.WriteMsg( "<span class='info'>You empty the plant bag into the biogenerator, filling it to its capacity.</span>" );
					} else {
						user.WriteMsg( "<span class='info'>You fill the biogenerator to its capacity.</span>" );
					}
				}
			} else if ( !( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ) ) {
				user.WriteMsg( "<span class='warning'>You cannot put this in " + this.name + "!</span>" );
			} else {
				i2 = 0;

				foreach (dynamic _c in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown) )) {
					G3 = _c;
					
					i2++;
				}

				if ( i2 >= Convert.ToDouble( this.max_items ) ) {
					user.WriteMsg( "<span class='warning'>The biogenerator is full! Activate it.</span>" );
				} else {
					((Mob)user).unEquip( A );
					A.loc = this;
					user.WriteMsg( "<span class='info'>You put " + A.name + " in " + this.name + "</span>" );
				}
			}

			if ( !this.processing ) {
				
				if ( this.default_deconstruction_screwdriver( user, "biogen-empty-o", "biogen-empty", A ) ) {
					
					if ( Lang13.Bool( this.beaker ) ) {
						B = this.beaker;
						B.loc = this.loc;
						this.beaker = null;
					}
				}
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}
			this.default_deconstruction_crowbar( A );
			this.update_icon();
			return null;
		}

		// Function from file: biogenerator.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( Lang13.Bool( this.panel_open ) ) {
				this.icon_state = "biogen-empty-o";
			} else if ( !Lang13.Bool( this.beaker ) ) {
				this.icon_state = "biogen-empty";
			} else if ( !this.processing ) {
				this.icon_state = "biogen-stand";
			} else {
				this.icon_state = "biogen-work";
			}
			return false;
		}

		// Function from file: biogenerator.dm
		public override void on_reagent_change(  ) {
			this.update_icon();
			return;
		}

		// Function from file: biogenerator.dm
		public override void RefreshParts(  ) {
			double E = 0;
			double P = 0;
			dynamic max_storage = null;
			Obj_Item_Weapon_StockParts_MatterBin B = null;
			Obj_Item_Weapon_StockParts_Manipulator M = null;

			E = 0;
			P = 0;
			max_storage = 40;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				B = _a;
				
				P += Convert.ToDouble( B.rating );
				max_storage = B.rating * 40;
			}

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _b;
				
				E += Convert.ToDouble( M.rating );
			}
			this.efficiency = E;
			this.productivity = P;
			this.max_items = max_storage;
			return;
		}

	}

}