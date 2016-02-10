// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Diseasesplicer : Obj_Machinery_Computer {

		public dynamic memorybank = null;
		public bool analysed = false;
		public dynamic dish = null;
		public int burning = 0;
		public int splicing = 0;
		public int scanning = 0;
		public bool spliced = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = "/obj/item/weapon/circuitboard/splicer";
			this.light_color = "#64C864";
			this.icon_state = "virus";
		}

		public Obj_Machinery_Computer_Diseasesplicer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: diseasesplicer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Disease2_Effectholder e = null;
			dynamic old_e = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Task13.User != null ) {
				Task13.User.set_machine( this );
			}

			if ( Lang13.Bool( href_list["grab"] ) ) {
				this.memorybank = Lang13.FindObj( href_list["grab"] );
				this.analysed = Lang13.Bool( this.dish.analysed );
				GlobalFuncs.qdel( this.dish );
				this.dish = null;
				this.scanning = 10;
			} else if ( Lang13.Bool( href_list["eject"] ) ) {
				
				if ( this.spliced ) {
					this.dish.virus2.uniqueID = Rand13.Int( 0, 10000 );
					((Disease2_Disease)this.dish.virus2).addToDB();
					this.spliced = false;
				}
				((Ent_Dynamic)this.dish).forceMove( this.loc );
				this.dish = null;
			} else if ( Lang13.Bool( href_list["splice"] ) ) {
				
				if ( Lang13.Bool( this.dish ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.dish.virus2.effects, typeof(Disease2_Effectholder) )) {
						e = _a;
						
						old_e = e.effect.name;

						if ( e.stage == Lang13.IntNullable( this.memorybank.stage ) ) {
							e.effect = this.memorybank.effect;
							this.dish.virus2.log += "<br />" + GlobalFuncs.timestamp() + " " + e.effect.name + " spliced in by " + GlobalFuncs.key_name( Task13.User ) + " (replaces " + old_e + ")";
						}
					}
					this.splicing = 10;
				}
			} else if ( Lang13.Bool( href_list["disk"] ) ) {
				this.burning = 10;
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: diseasesplicer.dm
		public override dynamic process(  ) {
			Obj_Item_Weapon_Diseasedisk d = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			this.f_use_power( 500 );

			if ( this.scanning != 0 ) {
				this.scanning -= 1;

				if ( !( this.scanning != 0 ) ) {
					this.alert_noise( "beep" );
				}
			}

			if ( this.splicing != 0 ) {
				this.splicing -= 1;

				if ( !( this.splicing != 0 ) ) {
					this.spliced = true;
					this.alert_noise( "ping" );
				}
			}

			if ( this.burning != 0 ) {
				this.burning -= 1;

				if ( !( this.burning != 0 ) ) {
					d = new Obj_Item_Weapon_Diseasedisk( this.loc );

					if ( this.analysed ) {
						d.name = "" + this.memorybank.effect.name + " GNA disk (Stage: " + ( 5 - Convert.ToDouble( this.memorybank.effect.stage ) ) + ")";
					} else {
						d.name = "Unknown GNA disk (Stage: " + ( 5 - Convert.ToDouble( this.memorybank.effect.stage ) ) + ")";
					}
					d.effect = this.memorybank;
					this.alert_noise( "ping" );
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: diseasesplicer.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic dat = null;
			Disease2_Effectholder e = null;
			Browser popup = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			((Mob)a).set_machine( this );
			dat = new ByTable();

			if ( this.splicing != 0 ) {
				dat += "Splicing in progress.";
			} else if ( this.scanning != 0 ) {
				dat += "Scanning in progress.";
			} else if ( this.burning != 0 ) {
				dat += "Data disk burning in progress.";
			} else {
				
				if ( Lang13.Bool( this.dish ) ) {
					dat += "Virus dish inserted.";
				}
				dat += "<BR>Current DNA strand : ";

				if ( Lang13.Bool( this.memorybank ) ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";splice=1'>" ).ToString();

					if ( this.analysed ) {
						dat += "" + this.memorybank.effect.name + " (" + ( 5 - Convert.ToDouble( this.memorybank.effect.stage ) ) + ")";
					} else {
						dat += "Unknown DNA strand (" + ( 5 - Convert.ToDouble( this.memorybank.effect.stage ) ) + ")";
					}
					dat += "</a>";
					dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";disk=1'>Burn DNA Sequence to data storage disk</a>" ).ToString();
				} else {
					dat += "Empty.";
				}
				dat += "<BR><BR>";

				if ( Lang13.Bool( this.dish ) ) {
					
					if ( Lang13.Bool( this.dish.virus2 ) ) {
						
						if ( Convert.ToDouble( this.dish.growth ) >= 50 ) {
							
							foreach (dynamic _a in Lang13.Enumerate( this.dish.virus2.effects, typeof(Disease2_Effectholder) )) {
								e = _a;
								
								dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";grab=" ).Ref( e ).str( "'> DNA strand" ).ToString();

								if ( Lang13.Bool( this.dish.analysed ) ) {
									dat += ": " + e.effect.name;
								}
								dat += " (5-" + e.effect.stage + ")</a>";
							}
						} else {
							dat += "<BR>Insufficent cells to attempt gene splicing.";
						}
					} else {
						dat += "<BR>No virus found in dish.";
					}
					dat += new Txt( "<BR><BR><A href='?src=" ).Ref( this ).str( ";eject=1'>Eject disk</a>" ).ToString();
				} else {
					dat += "<BR>Please insert dish.";
				}
			}
			dat = GlobalFuncs.list2text( dat );
			popup = new Browser( a, "disease_splicer", "Disease Splicer", 400, 500, this );
			popup.set_content( dat );
			popup.open();
			GlobalFuncs.onclose( a, "disease_splicer" );
			return null;
		}

		// Function from file: diseasesplicer.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: diseasesplicer.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: diseasesplicer.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic c2 = null;

			
			if ( !( a is Obj_Item_Weapon_Virusdish || a is Obj_Item_Weapon_Diseasedisk ) ) {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}

			if ( a is Obj_Item_Weapon_Virusdish ) {
				c2 = b;

				if ( !Lang13.Bool( this.dish ) ) {
					
					if ( !Lang13.Bool( c2.drop_item( a, this ) ) ) {
						return 1;
					}
					this.dish = a;
				}
			}

			if ( a is Obj_Item_Weapon_Diseasedisk ) {
				GlobalFuncs.to_chat( b, "You upload the contents of the disk into the buffer" );
				this.memorybank = a.effect;
			}
			this.attack_hand( b );
			return null;
		}

	}

}