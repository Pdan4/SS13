// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_DiseaseOutbreak : Event {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 90;
		}

		public Event_DiseaseOutbreak ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: vgstation13.dme
		public override bool start(  ) {
			Type virus_type = null;
			Mob_Living_Carbon_Human H = null;
			bool foundAlready = false;
			dynamic T = null;
			Disease D = null;
			Disease_Dnaspread D2 = null;
			dynamic D3 = null;

			virus_type = Rand13.Pick(new object [] { typeof(Disease_Dnaspread), typeof(Disease_Advance_Flu), typeof(Disease_Advance_Cold), typeof(Disease_Brainrot), typeof(Disease_Magnitis) });

			foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.shuffle( GlobalVars.living_mob_list ), typeof(Mob_Living_Carbon_Human) )) {
				H = _b;
				
				foundAlready = false;
				T = GlobalFuncs.get_turf( H );

				if ( !Lang13.Bool( T ) ) {
					continue;
				}

				if ( Lang13.Bool( T.z ) != true ) {
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( H.viruses, typeof(Disease) )) {
					D = _a;
					
					foundAlready = true;
				}

				if ( H.stat == 2 || foundAlready ) {
					continue;
				}

				if ( virus_type == typeof(Disease_Dnaspread) ) {
					
					if ( !( H.dna != null ) || ( H.sdisabilities & 1 ) != 0 ) {
						continue;
					}
					D2 = new Disease_Dnaspread();
					D2.strain_data["name"] = H.real_name;
					D2.strain_data["UI"] = H.dna.UI.Copy();
					D2.strain_data["SE"] = H.dna.SE.Copy();
					D2.carrier = true;
					D2.holder = H;
					D2.affected_mob = H;
					H.viruses.Add( D2 );
					break;
				} else {
					D3 = Lang13.Call( virus_type );
					D3.carrier = true;
					D3.holder = H;
					D3.affected_mob = H;
					H.viruses.Add( D3 );
					break;
				}
			}
			return false;
		}

		// Function from file: disease_outbreak.dm
		public override void setup(  ) {
			this.announceWhen = Rand13.Int( 30, 150 );
			return;
		}

		// Function from file: disease_outbreak.dm
		public override void announce(  ) {
			GlobalFuncs.biohazard_alert();
			return;
		}

	}

}