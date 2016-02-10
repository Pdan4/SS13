// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_AreaAtmos : Obj_Machinery_Computer {

		public ByTable connectedscrubbers = new ByTable();
		public string status = "";
		public int range = 25;
		public string zone = "This computer is working on a wireless range, the range is currently limited to 25 meters.";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = "/obj/item/weapon/circuitboard/area_atmos";
			this.light_color = "#7DE1E1";
			this.light_range_on = 2;
			this.icon_state = "area_atmos";
		}

		// Function from file: area_atmos_computer.dm
		public Obj_Machinery_Computer_AreaAtmos ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				this.scanscrubbers();
				return;
			}));
			return;
		}

		// Function from file: area_atmos_computer.dm
		public virtual void scanscrubbers(  ) {
			bool found = false;
			Obj_Machinery_PortableAtmospherics_Scrubber_Huge scrubber = null;

			this.connectedscrubbers = new ByTable();
			found = false;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this.loc, this.range ), typeof(Obj_Machinery_PortableAtmospherics_Scrubber_Huge) )) {
				scrubber = _a;
				

				if ( scrubber is Obj_Machinery_PortableAtmospherics_Scrubber_Huge ) {
					found = true;
					this.connectedscrubbers.Add( scrubber );
				}
			}

			if ( !found ) {
				this.status = "ERROR: No scrubber found!";
			}
			this.updateUsrDialog();
			return;
		}

		// Function from file: area_atmos_computer.dm
		public virtual bool validscrubber( dynamic scrubber = null ) {
			
			if ( !( scrubber is Obj ) || Map13.GetDistance( scrubber.loc, this.loc ) > this.range || scrubber.loc.z != this.loc.z ) {
				return false;
			}
			return true;
		}

		// Function from file: area_atmos_computer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic scrubber = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["scan"] ) ) {
				this.scanscrubbers();
			} else if ( Lang13.Bool( href_list["toggle"] ) ) {
				scrubber = Lang13.FindObj( href_list["scrub"] );

				if ( !this.validscrubber( scrubber ) ) {
					Task13.Schedule( 20, (Task13.Closure)(() => {
						this.status = "ERROR: Couldn't connect to scrubber! (timeout)";
						this.connectedscrubbers.Remove( scrubber );
						this.updateUsrDialog();
						return;
					}));
					return null;
				}
				scrubber.on = String13.ParseNumber( href_list["toggle"] );
				scrubber.update_icon();
			}
			return null;
		}

		// Function from file: area_atmos_computer.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			Obj_Machinery_PortableAtmospherics_Scrubber_Huge scrubber = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );
			dat = new Txt( @"
		<html>
			<head>
				<style type=""text/css"">
					a.green:link
					{
						color:#00CC00;
					}
					a.green:visited
					{
						color:#00CC00;
					}
					a.green:hover
					{
						color:#00CC00;
					}
					a.green:active
					{
						color:#00CC00;
					}
					a.red:link
					{
						color:#FF0000;
					}
					a.red:visited
					{
						color:#FF0000;
					}
					a.red:hover
					{
						color:#FF0000;
					}
					a.red:active
					{
						color:#FF0000;
					}
				</style>
			</head>
			<body>
				<center><h1>Area Air Control</h1></center>
				<font color=""red"">" ).item( this.status ).str( "</font><br>\n				<a href=\"?src=" ).Ref( this ).str( ";scan=1\">Scan</a>\n				<table border=\"1\" width=\"90%\">" ).ToString();

			foreach (dynamic _a in Lang13.Enumerate( this.connectedscrubbers, typeof(Obj_Machinery_PortableAtmospherics_Scrubber_Huge) )) {
				scrubber = _a;
				
				dat += new Txt( "\n					<tr>\n						<td>" ).item( scrubber.name ).str( "</td>\n						<td width=\"150\"><a class=\"green\" href=\"?src=" ).Ref( this ).str( ";scrub=" ).Ref( scrubber ).str( ";toggle=1\">Turn On</a> <a class=\"red\" href=\"?src=" ).Ref( this ).str( ";scrub=" ).Ref( scrubber ).str( ";toggle=0\">Turn Off</a></td>\n					</tr>" ).ToString();
			}
			dat += "\n				</table><br>\n				<i>" + this.zone + "</i>\n			</body>\n		</html>";
			Interface13.Browse( a, "" + dat, "window=miningshuttle;size=400x400" );
			this.status = "";
			return null;
		}

		// Function from file: area_atmos_computer.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: area_atmos_computer.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}