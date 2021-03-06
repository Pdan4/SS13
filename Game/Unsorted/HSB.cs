// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class HSB : Game_Data {

		public string owner = null;
		public bool admin = false;
		public string clothinfo = null;
		public string reaginfo = null;
		public string objinfo = null;
		public dynamic canisterinfo = null;
		public string hsbinfo = null;
		public dynamic spawn_forbidden = null;

		// Function from file: h_sandbox.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Mob P = null;
			Obj_Machinery_PortableAtmospherics_Scrubber hsb = null;
			Obj_Item_Weapon_Card_Id_Gold ID = null;
			dynamic all_items = null;
			dynamic typekey = null;
			dynamic O = null;
			dynamic all_items2 = null;
			dynamic typekey2 = null;
			dynamic O2 = null;
			dynamic all_items3 = null;
			dynamic typekey3 = null;
			dynamic O3 = null;
			Type typepath = null;
			Type typepath2 = null;

			
			if ( !( Task13.User != null ) || !( this != null ) || !( this.owner == Task13.User.ckey ) ) {
				
				if ( Task13.User != null ) {
					Interface13.Browse( Task13.User, null, "window=sandbox" );
				}
				return null;
			}

			if ( Lang13.Bool( href_list["hsb"] ) ) {
				
				dynamic _g = href_list["hsb"]; // Was a switch-case, sorry for the mess.
				if ( _g=="hsbtobj" ) {
					
					if ( !this.admin ) {
						return null;
					}

					if ( GlobalVars.hsboxspawn ) {
						Game13.WriteMsg( new Txt( "<span class='boldannounce'>Sandbox:</span> <b>" ).black().item( Task13.User.key ).str( " has disabled object spawning!</b>" ).ToString() );
						GlobalVars.hsboxspawn = false;
						return null;
					} else {
						Game13.WriteMsg( new Txt( "<span class='boldnotice'>Sandbox:</span> <b>" ).black().item( Task13.User.key ).str( " has enabled object spawning!</b>" ).ToString() );
						GlobalVars.hsboxspawn = true;
						return null;
					}
				} else if ( _g=="hsbtac" ) {
					
					if ( !this.admin ) {
						return null;
					}

					if ( GlobalVars.config.sandbox_autoclose ) {
						Game13.WriteMsg( new Txt( "<span class='boldnotice'>Sandbox:</span> <b>" ).black().item( Task13.User.key ).str( " has removed the object spawn limiter.</b>" ).ToString() );
						GlobalVars.config.sandbox_autoclose = false;
					} else {
						Game13.WriteMsg( new Txt( "<span class='danger'>Sandbox:</span> <b>" ).black().item( Task13.User.key ).str( " has added a limiter to object spawning.  The window will now auto-close after use.</b>" ).ToString() );
						GlobalVars.config.sandbox_autoclose = true;
					}
					return null;
				} else if ( _g=="hsbsuit" ) {
					P = Task13.User;

					if ( !( P is Mob_Living_Carbon_Human ) ) {
						return null;
					}

					if ( Lang13.Bool( ((dynamic)P).wear_suit ) ) {
						((dynamic)P).wear_suit.loc = P.loc;
						((dynamic)P).wear_suit.layer = Lang13.Initial( ((dynamic)P).wear_suit, "layer" );
						((dynamic)P).wear_suit = null;
					}
					((dynamic)P).wear_suit = new Obj_Item_Clothing_Suit_Space( P );
					((dynamic)P).wear_suit.layer = 20;
					P.update_inv_wear_suit();

					if ( Lang13.Bool( ((dynamic)P).head ) ) {
						((dynamic)P).head.loc = P.loc;
						((dynamic)P).head.layer = Lang13.Initial( ((dynamic)P).head, "layer" );
						((dynamic)P).head = null;
					}
					((dynamic)P).head = new Obj_Item_Clothing_Head_Helmet_Space( P );
					((dynamic)P).head.layer = 20;
					P.update_inv_head();

					if ( Lang13.Bool( ((dynamic)P).wear_mask ) ) {
						((dynamic)P).wear_mask.loc = P.loc;
						((dynamic)P).wear_mask.layer = Lang13.Initial( ((dynamic)P).wear_mask, "layer" );
						((dynamic)P).wear_mask = null;
					}
					((dynamic)P).wear_mask = new Obj_Item_Clothing_Mask_Gas( P );
					((dynamic)P).wear_mask.layer = 20;
					P.update_inv_wear_mask();

					if ( Lang13.Bool( ((dynamic)P).back ) ) {
						((dynamic)P).back.loc = P.loc;
						((dynamic)P).back.layer = Lang13.Initial( ((dynamic)P).back, "layer" );
						((dynamic)P).back = null;
					}
					((dynamic)P).back = new Obj_Item_Weapon_Tank_Jetpack_Oxygen( P );
					((dynamic)P).back.layer = 20;
					P.update_inv_back();
					((dynamic)P).v_internal = ((dynamic)P).back;
					((dynamic)P).update_internals_hud_icon( 1 );
				} else if ( _g=="hsbscrubber" ) {
					hsb = new Obj_Machinery_PortableAtmospherics_Scrubber( Task13.User.loc ) {
						volume_rate = 5066.25,
						on = 1
						
					};
					hsb.update_icon();
				} else if ( _g=="hsbrglass" ) {
					new Obj_Item_Stack_Sheet_Rglass( Task13.User.loc ) {
						amount = 50
						
					};
				} else if ( _g=="hsbmetal" ) {
					new Obj_Item_Stack_Sheet_Metal( Task13.User.loc ) {
						amount = 50
						
					};
				} else if ( _g=="hsbplasteel" ) {
					new Obj_Item_Stack_Sheet_Plasteel( Task13.User.loc ) {
						amount = 50
						
					};
				} else if ( _g=="hsbglass" ) {
					new Obj_Item_Stack_Sheet_Glass( Task13.User.loc ) {
						amount = 50
						
					};
				} else if ( _g=="hsbwood" ) {
					new Obj_Item_Stack_Sheet_Mineral_Wood( Task13.User.loc ) {
						amount = 50
						
					};
				} else if ( _g=="hsbaaid" ) {
					ID = new Obj_Item_Weapon_Card_Id_Gold( Task13.User.loc );
					ID.registered_name = Task13.User.real_name;
					ID.assignment = "Sandbox";
					ID.access = GlobalFuncs.get_all_accesses();
					ID.update_label();
				} else if ( _g=="hsbrcd" ) {
					
					if ( !GlobalVars.hsboxspawn ) {
						return null;
					}
					new Obj_Item_Weapon_Rcd_Combat( Task13.User.loc );
				} else if ( _g=="hsbairlock" ) {
					new AirlockMaker( Task13.User.loc );
				} else if ( _g=="hsbcloth" ) {
					
					if ( !GlobalVars.hsboxspawn ) {
						return null;
					}

					if ( !Lang13.Bool( this.clothinfo ) ) {
						this.clothinfo = new Txt( "<b>Clothing</b> <a href='?" ).Ref( this ).str( ";hsb=hsbreag'>(Reagent Containers)</a> <a href='?" ).Ref( this ).str( ";hsb=hsbobj'>(Other Items)</a><hr><br>" ).ToString();
						all_items = Lang13.GetTypes( typeof(Obj_Item_Clothing) ) - typeof(Obj_Item_Clothing);

						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.spawn_forbidden )) {
							typekey = _a;
							
							all_items -= Lang13.GetTypes( typekey );
						}

						foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.reverseRange( all_items ) )) {
							O = _b;
							
							this.clothinfo += new Txt( "<a href='?src=" ).Ref( this ).str( ";hsb=hsb_safespawn&path=" ).item( O ).str( "'>" ).item( O ).str( "</a><br>" ).ToString();
						}
					}
					Interface13.Browse( Task13.User, this.clothinfo, "window=sandbox" );
				} else if ( _g=="hsbreag" ) {
					
					if ( !GlobalVars.hsboxspawn ) {
						return null;
					}

					if ( !Lang13.Bool( this.reaginfo ) ) {
						this.reaginfo = new Txt( "<b>Reagent Containers</b> <a href='?" ).Ref( this ).str( ";hsb=hsbcloth'>(Clothing)</a> <a href='?" ).Ref( this ).str( ";hsb=hsbobj'>(Other Items)</a><hr><br>" ).ToString();
						all_items2 = Lang13.GetTypes( typeof(Obj_Item_Weapon_ReagentContainers) ) - typeof(Obj_Item_Weapon_ReagentContainers);

						foreach (dynamic _c in Lang13.Enumerate( GlobalVars.spawn_forbidden )) {
							typekey2 = _c;
							
							all_items2 -= Lang13.GetTypes( typekey2 );
						}

						foreach (dynamic _d in Lang13.Enumerate( GlobalFuncs.reverseRange( all_items2 ) )) {
							O2 = _d;
							
							this.reaginfo += new Txt( "<a href='?src=" ).Ref( this ).str( ";hsb=hsb_safespawn&path=" ).item( O2 ).str( "'>" ).item( O2 ).str( "</a><br>" ).ToString();
						}
					}
					Interface13.Browse( Task13.User, this.reaginfo, "window=sandbox" );
				} else if ( _g=="hsbobj" ) {
					
					if ( !GlobalVars.hsboxspawn ) {
						return null;
					}

					if ( !Lang13.Bool( this.objinfo ) ) {
						this.objinfo = new Txt( "<b>Other Items</b> <a href='?" ).Ref( this ).str( ";hsb=hsbcloth'>(Clothing)</a> <a href='?" ).Ref( this ).str( ";hsb=hsbreag'>(Reagent Containers)</a><hr><br>" ).ToString();
						all_items3 = Lang13.GetTypes( typeof(Obj_Item) ) - typeof(Obj_Item) - Lang13.GetTypes( typeof(Obj_Item_Clothing) ) - Lang13.GetTypes( typeof(Obj_Item_Weapon_ReagentContainers) );

						foreach (dynamic _e in Lang13.Enumerate( GlobalVars.spawn_forbidden )) {
							typekey3 = _e;
							
							all_items3 -= Lang13.GetTypes( typekey3 );
						}

						foreach (dynamic _f in Lang13.Enumerate( GlobalFuncs.reverseRange( all_items3 ) )) {
							O3 = _f;
							
							this.objinfo += new Txt( "<a href='?src=" ).Ref( this ).str( ";hsb=hsb_safespawn&path=" ).item( O3 ).str( "'>" ).item( O3 ).str( "</a><br>" ).ToString();
						}
					}
					Interface13.Browse( Task13.User, this.objinfo, "window=sandbox" );
				} else if ( _g=="hsb_safespawn" ) {
					
					if ( !GlobalVars.hsboxspawn ) {
						Interface13.Browse( Task13.User, null, "window=sandbox" );
						return null;
					}
					typepath = Lang13.FindClass( href_list["path"] );

					if ( !( typepath != null ) ) {
						Task13.User.WriteMsg( "Bad path: \"" + href_list["path"] + "\"" );
						return null;
					}
					Lang13.Call( typepath, Task13.User.loc );

					if ( GlobalVars.config.sandbox_autoclose ) {
						Interface13.Browse( Task13.User, null, "window=sandbox" );
					}
				} else if ( _g=="hsbspawn" ) {
					typepath2 = Lang13.FindClass( href_list["path"] );

					if ( !( typepath2 != null ) ) {
						Task13.User.WriteMsg( "Bad path: \"" + href_list["path"] + "\"" );
						return null;
					}
					Lang13.Call( typepath2, Task13.User.loc );

					if ( GlobalVars.config.sandbox_autoclose ) {
						Interface13.Browse( Task13.User, null, "window=sandbox" );
					}
				}
			}
			return null;
		}

		// Function from file: h_sandbox.dm
		public void update(  ) {
			dynamic T = null;
			dynamic href = null;

			
			if ( !Lang13.Bool( this.hsbinfo ) ) {
				this.hsbinfo = "<center><b>Sandbox Panel</b></center><hr>";

				if ( this.admin ) {
					this.hsbinfo += "<b>Administration</b><br>";
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbtobj'>Toggle Object Spawning</a><br>" ).ToString();
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbtac'>Toggle Item Spawn Panel Auto-close</a><br>" ).ToString();
					this.hsbinfo += "<b>Canister Spawning</b><br>";
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbspawn&path=" ).item( typeof(Obj_Machinery_PortableAtmospherics_Canister_Toxins) ).str( "'>Spawn Plasma Canister</a><br>" ).ToString();
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbspawn&path=" ).item( typeof(Obj_Machinery_PortableAtmospherics_Canister_CarbonDioxide) ).str( "'>Spawn CO2 Canister</a><br>" ).ToString();
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbspawn&path=" ).item( typeof(Obj_Machinery_PortableAtmospherics_Canister_Nitrogen) ).str( "'>Spawn Nitrogen Canister</a><br>" ).ToString();
					this.hsbinfo += new Txt( "- <a href='?src=" ).Ref( this ).str( ";hsb=hsbspawn&path=" ).item( typeof(Obj_Machinery_PortableAtmospherics_Canister_NitrousOxide) ).str( "'>Spawn N2O Canister</a><hr>" ).ToString();
				} else {
					this.hsbinfo += "<i>Some item spawning may be disabled by the administrators.</i><br>";
					this.hsbinfo += "<i>Only administrators may spawn dangerous canisters.</i><br>";
				}

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.hrefs )) {
					T = _a;
					
					href = GlobalVars.hrefs[T];

					if ( Lang13.Bool( href ) ) {
						this.hsbinfo += new Txt( "- <a href='?" ).Ref( this ).str( ";hsb=" ).item( GlobalVars.hrefs[T] ).str( "'>" ).item( T ).str( "</a><br>" ).ToString();
					} else {
						this.hsbinfo += "<br><b>" + T + "</b><br>";
					}
				}
				this.hsbinfo += "<hr>";
				this.hsbinfo += new Txt( "- <a href='?" ).Ref( this ).str( ";hsb=hsbcloth'>Spawn Clothing...</a><br>" ).ToString();
				this.hsbinfo += new Txt( "- <a href='?" ).Ref( this ).str( ";hsb=hsbreag'>Spawn Reagent Container...</a><br>" ).ToString();
				this.hsbinfo += new Txt( "- <a href='?" ).Ref( this ).str( ";hsb=hsbobj'>Spawn Other Item...</a><br><br>" ).ToString();
			}
			Interface13.Browse( Task13.User, this.hsbinfo, "window=hsbpanel" );
			return;
		}

	}

}