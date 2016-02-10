// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSettings : Game_Data {

		public ByTable settings = new ByTable();

		// Function from file: NewSettings.dm
		public ZASSettings (  ) {
			dynamic S = null;
			string id = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(ZASSetting) ) - typeof(ZASSetting) )) {
				S = _a;
				
				id = "" + S;
				this.settings[id] = Lang13.Call( S );
			}

			if ( !File13.Exists( "config/ZAS.txt" ) ) {
				this.Save();
			}
			this.Load();
			return;
		}

		// Function from file: NewSettings.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic sure = null;
			dynamic sure2 = null;

			Interface13.Stat( null, href_list.Contains( "changevar" ) );

			if ( false ) {
				this.ChangeSetting( Task13.User, href_list["changevar"] );
			}
			Interface13.Stat( null, href_list.Contains( "save" ) );

			if ( false ) {
				sure = Interface13.Input( Task13.User, "Are you sure?  This will overwrite your ZAS configuration!", "Overwrite ZAS.txt?", "No", new ByTable(new object [] { "Yes", "No" }), InputType.Any );

				if ( sure == "Yes" ) {
					this.Save();
					GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( Task13.User ) + " saved ZAS settings to disk." );
				}
			}
			Interface13.Stat( null, href_list.Contains( "load" ) );

			if ( false ) {
				sure2 = Interface13.Input( Task13.User, "Are you sure?", "Reload ZAS.txt?", "No", new ByTable(new object [] { "Yes", "No" }), InputType.Any );

				if ( sure2 == "Yes" ) {
					this.Load();
					GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( Task13.User ) + " reloaded ZAS settings from disk." );
				}
			}
			return null;
		}

		// Function from file: NewSettings.dm
		public void SetDefault( Mob user = null ) {
			ByTable setting_choices = null;
			dynamic def = null;

			setting_choices = new ByTable(new object [] { "Plasma - Standard", "Plasma - Low Hazard", "Plasma - High Hazard", "Plasma - Oh Shit!", "ZAS - Normal", "ZAS - Forgiving", "ZAS - Dangerous", "ZAS - Hellish" });
			def = Interface13.Input( user, "Which of these presets should be used?", null, null, setting_choices, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( def ) ) {
				return;
			}

			dynamic _a = def; // Was a switch-case, sorry for the mess.
			if ( _a=="Plasma - Standard" ) {
				this.Set( "/datum/ZAS_Setting/CLOTH_CONTAMINATION", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMAGUARD_ONLY", 0 );
				this.Set( "/datum/ZAS_Setting/GENETIC_CORRUPTION", 0 );
				this.Set( "/datum/ZAS_Setting/SKIN_BURNS", 0 );
				this.Set( "/datum/ZAS_Setting/EYE_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMA_HALLUCINATION", 0 );
				this.Set( "/datum/ZAS_Setting/CONTAMINATION_LOSS", 0.11 );
			} else if ( _a=="Plasma - Low Hazard" ) {
				this.Set( "/datum/ZAS_Setting/CLOTH_CONTAMINATION", 0 );
				this.Set( "/datum/ZAS_Setting/PLASMAGUARD_ONLY", 0 );
				this.Set( "/datum/ZAS_Setting/GENETIC_CORRUPTION", 0 );
				this.Set( "/datum/ZAS_Setting/SKIN_BURNS", 0 );
				this.Set( "/datum/ZAS_Setting/EYE_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMA_HALLUCINATION", 0 );
				this.Set( "/datum/ZAS_Setting/CONTAMINATION_LOSS", 0.01 );
			} else if ( _a=="Plasma - High Hazard" ) {
				this.Set( "/datum/ZAS_Setting/CLOTH_CONTAMINATION", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMAGUARD_ONLY", 0 );
				this.Set( "/datum/ZAS_Setting/GENETIC_CORRUPTION", 0 );
				this.Set( "/datum/ZAS_Setting/SKIN_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/EYE_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMA_HALLUCINATION", 1 );
				this.Set( "/datum/ZAS_Setting/CONTAMINATION_LOSS", 0.05 );
			} else if ( _a=="Plasma - Oh Shit!" ) {
				this.Set( "/datum/ZAS_Setting/CLOTH_CONTAMINATION", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMAGUARD_ONLY", 1 );
				this.Set( "/datum/ZAS_Setting/GENETIC_CORRUPTION", 5 );
				this.Set( "/datum/ZAS_Setting/SKIN_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/EYE_BURNS", 1 );
				this.Set( "/datum/ZAS_Setting/PLASMA_HALLUCINATION", 1 );
				this.Set( "/datum/ZAS_Setting/CONTAMINATION_LOSS", 0.075 );
			} else if ( _a=="ZAS - Normal" ) {
				this.Set( "/datum/ZAS_Setting/airflow_push", 0 );
				this.Set( "/datum/ZAS_Setting/airflow_lightest_pressure", 20 );
				this.Set( "/datum/ZAS_Setting/airflow_light_pressure", 35 );
				this.Set( "/datum/ZAS_Setting/airflow_medium_pressure", 50 );
				this.Set( "/datum/ZAS_Setting/airflow_heavy_pressure", 65 );
				this.Set( "/datum/ZAS_Setting/airflow_dense_pressure", 85 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_pressure", 60 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_cooldown", 60 );
				this.Set( "/datum/ZAS_Setting/airflow_stun", 1 );
				this.Set( "/datum/ZAS_Setting/airflow_damage", 2 );
				this.Set( "/datum/ZAS_Setting/airflow_speed_decay", 1.5 );
				this.Set( "/datum/ZAS_Setting/airflow_delay", 30 );
				this.Set( "/datum/ZAS_Setting/airflow_mob_slowdown", 1 );
			} else if ( _a=="ZAS - Forgiving" ) {
				this.Set( "/datum/ZAS_Setting/airflow_push", 0 );
				this.Set( "/datum/ZAS_Setting/airflow_lightest_pressure", 45 );
				this.Set( "/datum/ZAS_Setting/airflow_light_pressure", 60 );
				this.Set( "/datum/ZAS_Setting/airflow_medium_pressure", 120 );
				this.Set( "/datum/ZAS_Setting/airflow_heavy_pressure", 110 );
				this.Set( "/datum/ZAS_Setting/airflow_dense_pressure", 200 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_pressure", 150 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_cooldown", 90 );
				this.Set( "/datum/ZAS_Setting/airflow_stun", 0.15 );
				this.Set( "/datum/ZAS_Setting/airflow_damage", 0.15 );
				this.Set( "/datum/ZAS_Setting/airflow_speed_decay", 1.5 );
				this.Set( "/datum/ZAS_Setting/airflow_delay", 50 );
				this.Set( "/datum/ZAS_Setting/airflow_mob_slowdown", 0 );
			} else if ( _a=="ZAS - Dangerous" ) {
				this.Set( "/datum/ZAS_Setting/airflow_push", 1 );
				this.Set( "/datum/ZAS_Setting/airflow_lightest_pressure", 15 );
				this.Set( "/datum/ZAS_Setting/airflow_light_pressure", 30 );
				this.Set( "/datum/ZAS_Setting/airflow_medium_pressure", 45 );
				this.Set( "/datum/ZAS_Setting/airflow_heavy_pressure", 55 );
				this.Set( "/datum/ZAS_Setting/airflow_dense_pressure", 70 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_pressure", 50 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_cooldown", 50 );
				this.Set( "/datum/ZAS_Setting/airflow_stun", 2 );
				this.Set( "/datum/ZAS_Setting/airflow_damage", 3 );
				this.Set( "/datum/ZAS_Setting/airflow_speed_decay", 1.2 );
				this.Set( "/datum/ZAS_Setting/airflow_delay", 25 );
				this.Set( "/datum/ZAS_Setting/airflow_mob_slowdown", 2 );
			} else if ( _a=="ZAS - Hellish" ) {
				this.Set( "/datum/ZAS_Setting/airflow_push", 1 );
				this.Set( "/datum/ZAS_Setting/airflow_lightest_pressure", 20 );
				this.Set( "/datum/ZAS_Setting/airflow_light_pressure", 30 );
				this.Set( "/datum/ZAS_Setting/airflow_medium_pressure", 40 );
				this.Set( "/datum/ZAS_Setting/airflow_heavy_pressure", 50 );
				this.Set( "/datum/ZAS_Setting/airflow_dense_pressure", 60 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_pressure", 40 );
				this.Set( "/datum/ZAS_Setting/airflow_stun_cooldown", 40 );
				this.Set( "/datum/ZAS_Setting/airflow_stun", 3 );
				this.Set( "/datum/ZAS_Setting/airflow_damage", 4 );
				this.Set( "/datum/ZAS_Setting/airflow_speed_decay", 1 );
				this.Set( "/datum/ZAS_Setting/airflow_delay", 20 );
				this.Set( "/datum/ZAS_Setting/airflow_mob_slowdown", 3 );
			}
			GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><b>" + GlobalFuncs.key_name( Task13.User ) + " loaded ZAS preset <i>" + def + "</i></b></span>" );
			return;
		}

		// Function from file: NewSettings.dm
		public void ChangeSettingsDialog( Mob user = null ) {
			string dat = null;
			dynamic id = null;
			dynamic s = null;

			dat = new Txt( @"
<html>
	<head>
		<title>ZAS Settings 2.0</title>
		<style type=""text/css"">
body,html {
	background:#666666;
	font-family:sans-serif;
	font-size:smaller;
	color: #cccccc;
}
a { color: white; }
		</style>
	</head>
	<body>
		<h1>ZAS Configuration</h1>
		<p><a href=""?src=" ).Ref( this ).str( ";save=1\">Save Settings</a> | <a href=\"?src=" ).Ref( this ).str( ";load=1\">Load Settings</a></p>\n		<p>Please note that changing these settings can and probably will result in death, destruction and mayhem. <b>Change at your own risk.</b></p>\n	<dl>" ).ToString();

			foreach (dynamic _a in Lang13.Enumerate( this.settings )) {
				id = _a;
				
				s = this.settings[id];
				dat += new Txt( "<dt><b>" ).item( s.name ).str( "</b> = <i>" ).item( s.value ).str( "</i> <A href='?src=" ).Ref( this ).str( ";changevar=" ).item( id ).str( "'>[Change]</A></dt>\n			<dd>" ).item( s.desc ).str( "</i></dd>" ).ToString();
			}
			dat += "</dl></body></html>";
			Interface13.Browse( user, dat, "window=settings" );
			return;
		}

		// Function from file: NewSettings.dm
		public dynamic Get( dynamic id = null ) {
			dynamic setting = null;

			
			if ( id is Type ) {
				id = "" + id;
			}
			setting = this.settings[id];

			if ( !Lang13.Bool( setting ) || !( setting is ZASSetting ) ) {
				Game13.log.WriteMsg( "ZAS_SETTING DEBUG: " + id + " | " + id );
			}
			return setting.value;
		}

		// Function from file: NewSettings.dm
		public void SetFromConfig( dynamic id = null, string value = null ) {
			ZASSetting setting = null;

			setting = this.settings["" + id];

			switch ((int)( setting.valtype )) {
				case 1:
					setting.value = String13.ParseNumber( value );
					break;
				case 0:
					setting.value = value == "1";
					break;
			}
			return;
		}

		// Function from file: NewSettings.dm
		public void Set( string id = null, double value = 0 ) {
			dynamic setting = null;

			setting = this.settings["" + id];
			setting.value = value;
			return;
		}

		// Function from file: NewSettings.dm
		public void ChangeSetting( Mob user = null, dynamic id = null ) {
			ZASSetting setting = null;
			string displayedValue = null;

			setting = this.settings["" + id];
			displayedValue = "";

			switch ((int)( setting.valtype )) {
				case 1:
					setting.value = Interface13.Input( user, "Enter a number:", "Settings", setting.value, null, InputType.Num );
					displayedValue = "\"" + setting.value + "\"";
					break;
				case 0:
					setting.value = !Lang13.Bool( setting.value );
					displayedValue = ( Lang13.Bool( setting.value ) ? "ON" : "OFF" );
					break;
				default:
					GlobalFuncs.error( "" + id + " has an invalid typeval." );
					return;
					break;
			}
			GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><b>" + GlobalFuncs.key_name( user ) + " changed ZAS setting <i>" + setting.name + "</i> to <i>" + displayedValue + "</i>.</b></span>" );
			this.ChangeSettingsDialog( user );
			return;
		}

		// Function from file: NewSettings.dm
		public string idfrompath( string path = null ) {
			return String13.SubStr( path, GlobalFuncs.rfindtext( path, "/" ) + 1, 0 );
		}

		// Function from file: NewSettings.dm
		public void Load(  ) {
			dynamic t = null;
			int pos = 0;
			dynamic name = null;
			string value = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.file2list( "config/ZAS.txt" ) )) {
				t = _a;
				

				if ( !Lang13.Bool( t ) ) {
					continue;
				}
				t = GlobalFuncs.trim( t );

				if ( Lang13.Length( t ) == 0 ) {
					continue;
				} else if ( String13.SubStr( t, 1, 2 ) == "#" ) {
					continue;
				}
				pos = String13.FindIgnoreCase( t, " ", 1, 0 );
				name = null;
				value = null;

				if ( pos != 0 ) {
					name = String13.SubStr( t, 1, pos );
					value = String13.SubStr( t, pos + 1, 0 );
				} else {
					name = t;
				}

				if ( !Lang13.Bool( name ) ) {
					continue;
				}
				this.SetFromConfig( name, value );
			}
			return;
		}

		// Function from file: NewSettings.dm
		public void Save(  ) {
			dynamic F = null;
			dynamic id = null;
			dynamic setting = null;

			F = new File( "config/ZAS.txt" );
			File13.Delete( F );

			foreach (dynamic _a in Lang13.Enumerate( this.settings )) {
				id = _a;
				
				setting = this.settings[id];
				GlobalFuncs.to_chat( F, "# " + setting.name );
				GlobalFuncs.to_chat( F, "#   " + setting.desc );
				GlobalFuncs.to_chat( F, "" + id + " " + setting.value );
				GlobalFuncs.to_chat( F, "" );
			}
			return;
		}

	}

}