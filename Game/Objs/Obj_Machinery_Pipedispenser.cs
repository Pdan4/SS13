// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Pipedispenser : Obj_Machinery {

		public bool wait = false;
		public dynamic layer_to_make = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.machine_flags = 24;
			this.icon_state = "pipe_d";
		}

		// Function from file: pipe_dispenser.dm
		public Obj_Machinery_Pipedispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Pipedispenser(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: pipe_dispenser.dm
		public override int wrenchAnchor( dynamic user = null ) {
			
			if ( base.wrenchAnchor( (object)(user) ) == 1 ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.stat &= 65527;
					this.power_change();
				} else {
					this.stat |= 8;

					if ( user.machine == this ) {
						Interface13.Browse( user, null, "window=pipedispenser" );
					}
				}
			}
			return 0;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.add_fingerprint( Task13.User );

			if ( a is Obj_Item_Pipe || a is Obj_Item_PipeMeter || a is Obj_Item_PipeGsensor ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You put " + a + " back to " + this + ".</span>" );

					if ( a is Obj_Item_Pipe ) {
						GlobalFuncs.returnToPool( a );
					} else {
						GlobalFuncs.qdel( a );
					}
					return null;
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? p_type = null;
			double? p_dir = null;
			Game_Data P = null;
			dynamic num_input = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				Interface13.Browse( Task13.User, null, "window=pipedispenser" );
				return 1;
			}

			if ( !Lang13.Bool( this.anchored ) ) {
				Interface13.Browse( Task13.User, null, "window=pipedispenser" );
				return 1;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["make"] ) ) {
				
				if ( !this.wait ) {
					p_type = String13.ParseNumber( href_list["make"] );
					p_dir = String13.ParseNumber( href_list["dir"] );
					P = GlobalFuncs.getFromPool( typeof(Obj_Item_Pipe), GlobalFuncs.get_turf( this ) );
					new ByTable().Set( 1, ((dynamic)P).loc ).Set( "pipe_type", p_type ).Set( "dir", p_dir ).Apply( Lang13.BindFunc( P, "New" ) );
					((dynamic)P).setPipingLayer( this.layer_to_make );
					((dynamic)P).update();
					((dynamic)P).add_fingerprint( Task13.User );
					this.wait = true;
					Task13.Schedule( 10, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}

			if ( Lang13.Bool( href_list["makemeter"] ) ) {
				
				if ( !this.wait ) {
					new Obj_Item_PipeMeter( this.loc );
					this.wait = true;
					Task13.Schedule( 15, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}

			if ( Lang13.Bool( href_list["makegsensor"] ) ) {
				
				if ( !this.wait ) {
					new Obj_Item_PipeGsensor( this.loc );
					this.wait = true;
					Task13.Schedule( 15, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}

			if ( Lang13.Bool( href_list["editlayer"] ) ) {
				
				if ( !this.wait ) {
					num_input = Interface13.Input( Task13.User, "Alignment", "Calibrate Dispenser", "", null, InputType.Num );
					num_input = ( Num13.Round( Convert.ToDouble( num_input ), 1 ) <= 1 ? 1 : ( Num13.Round( Convert.ToDouble( num_input ), 1 ) >= 5 ? 5 : Num13.Round( Convert.ToDouble( num_input ), 1 ) ) );
					this.layer_to_make = num_input;
					this.interact( Task13.User );
				}
			}
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;

			dat = new Txt( "\n<b>Regular pipes:</b>\n<ul>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 0 ).str( ";dir=1'>Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 1 ).str( ";dir=5'>Bent Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 5 ).str( ";dir=1'>Manifold</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 8 ).str( ";dir=1'>Manual Valve</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 18 ).str( ";dir=1'>Digital Valve</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 21 ).str( ";dir=1'>Pipe Cap</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 20 ).str( ";dir=1'>4-Way Manifold</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 19 ).str( ";dir=1'>Manual T-Valve</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 19 ).str( ";dir=9'>Manual T-Valve [M]</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 26 ).str( ";dir=1'>Digital T-Valve</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 26 ).str( ";dir=9'>Digital T-Valve [M]</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 29 ).str( ";dir=1'>Layer Manifold</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 30 ).str( @";dir=1'>Layer Adapter</a></li>
</ul>
<b>Devices:</b>
<ul>
	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 4 ).str( ";dir=1'>Connector</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 7 ).str( ";dir=1'>Unary Vent</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 25 ).str( ";dir=1'>Passive Vent</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 9 ).str( ";dir=1'>Gas Pump</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 15 ).str( ";dir=1'>Passive Gate</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 16 ).str( ";dir=1'>Volume Pump</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 10 ).str( ";dir=1'>Scrubber</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";makemeter=1'>Meter</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";makegsensor=1'>Gas Sensor</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 13 ).str( ";dir=1'>Gas Filter</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 13 ).str( ";dir=9'>Gas Filter [M]</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 14 ).str( ";dir=1'>Gas Mixer</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 14 ).str( ";dir=9'>Gas Mixer [M]</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 22 ).str( ";dir=1'>Thermal Plate</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 23 ).str( ";dir=1'>Injector</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 24 ).str( @";dir=1'>Dual-Port Vent</a></li>
</ul>
<b>Heat exchange:</b>
<ul>
	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 2 ).str( ";dir=1'>Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 3 ).str( ";dir=5'>Bent Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 6 ).str( ";dir=1'>Junction</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 17 ).str( @";dir=1'>Heat Exchanger</a></li>
</ul>
<b>Insulated pipes:</b>
<ul>
	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 11 ).str( ";dir=1'>Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 12 ).str( ";dir=5'>Bent Pipe</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 27 ).str( ";dir=1'>Manifold</a></li>\n	<li><a href='?src=" ).Ref( this ).str( ";make=" ).item( 28 ).str( ";dir=1'>4-Way Manifold</a></li>\n</ul>\n<b> Currently aligned at: " ).item( this.layer_to_make ).str( " [ <a href='?src=" ).Ref( this ).str( ";editlayer=1'>EDIT</a> ]</b></li>\n" ).ToString();
			Interface13.Browse( user, "<HEAD><TITLE>" + this + "</TITLE></HEAD><TT>" + dat + "</TT>", "window=pipedispenser" );
			GlobalFuncs.onclose( user, "pipedispenser" );
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			this.interact( a );
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

	}

}