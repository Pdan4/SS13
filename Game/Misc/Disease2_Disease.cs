// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Disease : Disease2 {

		public dynamic infectionchance = 70;
		public bool speed = true;
		public dynamic spreadtype = "Contact";
		public int? stage = 1;
		public int stageprob = 10;
		public bool dead = false;
		public int clicks = 0;
		public double? uniqueID = 0;
		public ByTable effects = new ByTable();
		public double? antigen = 0;
		public int? max_stage = 4;
		public string log = "";
		public bool logged_virusfood = false;

		// Function from file: disease2.dm
		public Disease2_Disease ( string notes = null ) {
			notes = notes ?? "No notes.";

			this.uniqueID = Rand13.Int( 0, 10000 );
			this.log += "<br />" + GlobalFuncs.timestamp() + " CREATED - " + notes + "<br>";
			GlobalVars.disease2_list["" + this.uniqueID] = this;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: disease2.dm
		public bool addToDB(  ) {
			Data_Record v = null;

			Interface13.Stat( null, GlobalVars.virusDB.Contains( "" + this.uniqueID ) );

			if ( false ) {
				return false;
			}
			v = new Data_Record();
			v.fields["id"] = this.uniqueID;
			v.fields["name"] = this.name();
			v.fields["description"] = this.get_info();
			v.fields["antigen"] = GlobalFuncs.antigens2string( this.antigen );
			v.fields["spread type"] = this.spreadtype;
			GlobalVars.virusDB["" + this.uniqueID] = v;
			return true;
		}

		// Function from file: disease2.dm
		public string get_info(  ) {
			string r = null;
			Disease2_Effectholder E = null;

			r = "GNAv2 based virus lifeform - " + this.name() + ", #" + GlobalFuncs.add_zero( "" + this.uniqueID, 4 );
			r += "<BR>Infection rate : " + this.infectionchance * 10;
			r += "<BR>Spread form : " + this.spreadtype;
			r += "<BR>Progress Speed : " + this.stageprob * 10;

			foreach (dynamic _a in Lang13.Enumerate( this.effects, typeof(Disease2_Effectholder) )) {
				E = _a;
				
				r += "<BR>Effect:" + E.effect.name + ". Strength : " + E.multiplier * 8 + ". Verosity : " + E.chance * 15 + ". Type : " + ( 5 - ( E.stage ??0) ) + ".";
			}
			r += "<BR>Antigen pattern: " + GlobalFuncs.antigens2string( this.antigen );
			return r;
		}

		// Function from file: disease2.dm
		public string name(  ) {
			string _default = null;

			dynamic V = null;

			_default = "stamm #" + GlobalFuncs.add_zero( "" + this.uniqueID, 4 );
			Interface13.Stat( null, GlobalVars.virusDB.Contains( "" + this.uniqueID ) );

			if ( false ) {
				V = GlobalVars.virusDB["" + this.uniqueID];
				_default = V.fields["name"];
			}
			return _default;
		}

		// Function from file: disease2.dm
		public bool issame( Disease2_Disease disease = null ) {
			ByTable types = null;
			ByTable types2 = null;
			Disease2_Effectholder d = null;
			bool equal = false;
			Disease2_Effectholder d2 = null;
			dynamic type = null;

			types = new ByTable();
			types2 = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.effects, typeof(Disease2_Effectholder) )) {
				d = _a;
				
				types.Add( d.effect.type );
			}
			equal = true;

			foreach (dynamic _b in Lang13.Enumerate( disease.effects, typeof(Disease2_Effectholder) )) {
				d2 = _b;
				
				types2.Add( d2.effect.type );
			}

			foreach (dynamic _c in Lang13.Enumerate( types )) {
				type = _c;
				
				Interface13.Stat( null, types2.Contains( type ) );

				if ( !false ) {
					equal = false;
				}
			}

			if ( this.antigen != disease.antigen ) {
				equal = false;
			}
			return equal;
		}

		// Function from file: disease2.dm
		public Disease2_Disease getcopy(  ) {
			Disease2_Disease disease = null;
			Disease2_Effectholder holder = null;
			Disease2_Effectholder newholder = null;

			disease = new Disease2_Disease( "" );
			disease.log = this.log;
			disease.infectionchance = this.infectionchance;
			disease.spreadtype = this.spreadtype;
			disease.stageprob = this.stageprob;
			disease.antigen = this.antigen;
			disease.uniqueID = this.uniqueID;
			disease.speed = this.speed;
			disease.stage = this.stage;
			disease.clicks = this.clicks;

			foreach (dynamic _a in Lang13.Enumerate( this.effects, typeof(Disease2_Effectholder) )) {
				holder = _a;
				
				newholder = new Disease2_Effectholder( disease );
				newholder.effect = Lang13.Call( holder.effect.type );
				newholder.chance = holder.chance;
				newholder.cure = holder.cure;
				newholder.multiplier = holder.multiplier;
				newholder.happensonce = holder.happensonce;
				newholder.stage = holder.stage;
				disease.effects.Add( newholder );
			}
			return disease;
		}

		// Function from file: disease2.dm
		public void majormutate(  ) {
			dynamic holder = null;

			this.uniqueID = Rand13.Int( 0, 10000 );
			holder = Rand13.PickFromTable( this.effects );
			holder.majormutate();

			if ( Rand13.PercentChance( 5 ) ) {
				this.antigen = String13.ParseNumber( Rand13.PickFromTable( GlobalVars.ANTIGENS ) );
				this.antigen = ((int)( this.antigen )) | ( ((int)( String13.ParseNumber( Rand13.PickFromTable( GlobalVars.ANTIGENS ) ) ??0 )) );
			}
			return;
		}

		// Function from file: disease2.dm
		public void minormutate(  ) {
			dynamic holder = null;

			holder = Rand13.PickFromTable( this.effects );
			((Disease2_Effectholder)holder).minormutate();
			this.infectionchance = Num13.MinInt( 50, Convert.ToInt32( this.infectionchance + Rand13.Int( 0, 10 ) ) );
			this.log += "<br />" + GlobalFuncs.timestamp() + " Infection chance now " + this.infectionchance + "%";
			return;
		}

		// Function from file: disease2.dm
		public void cure( Mob_Living_Carbon mob = null ) {
			Disease2_Effectholder e = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.effects, typeof(Disease2_Effectholder) )) {
				e = _a;
				
				e.effect.deactivate( mob );
			}
			mob.virus2.Remove( "" + this.uniqueID );
			return;
		}

		// Function from file: disease2.dm
		public void activate( Mob_Living_Carbon mob = null ) {
			Disease2_Effectholder e = null;
			Mob_Living_Carbon M = null;

			
			if ( this.dead ) {
				this.cure( mob );
				return;
			}

			if ( mob.stat == 2 ) {
				return;
			}

			if ( ( this.stage ??0) <= 1 && this.clicks == 0 ) {
				
				if ( Rand13.PercentChance( 5 ) ) {
					mob.antibodies = ((int)( mob.antibodies )) | ( ((int)( this.antigen ??0 )) );
				}
			}

			if ( ((Reagents)mob.reagents).has_reagent( "spaceacillin" ) ) {
				return;
			}

			if ( ((Reagents)mob.reagents).has_reagent( "virusfood" ) ) {
				((Reagents)mob.reagents).remove_reagent( "virusfood", 0.1 );

				if ( !this.logged_virusfood ) {
					this.log += "<br />" + GlobalFuncs.timestamp() + " Virus Fed (" + ((Reagents)mob.reagents).get_reagent_amount( "virusfood" ) + "U)";
					this.logged_virusfood = true;
				}
				this.clicks += 10;
			} else {
				this.logged_virusfood = false;
			}

			if ( this.clicks > ( this.stage ??0) * 100 && Rand13.PercentChance( 10 ) ) {
				
				if ( this.stage == this.max_stage ) {
					this.cure( mob );
					mob.antibodies = ((int)( mob.antibodies )) | ( ((int)( this.antigen ??0 )) );
					this.log += "<br />" + GlobalFuncs.timestamp() + " STAGEMAX (" + this.stage + ")";
				} else {
					this.stage++;
					this.log += "<br />" + GlobalFuncs.timestamp() + " NEXT STAGE (" + this.stage + ")";
					this.clicks = 0;
				}
			}

			foreach (dynamic _a in Lang13.Enumerate( this.effects, typeof(Disease2_Effectholder) )) {
				e = _a;
				
				e.runeffect( mob, this.stage );
			}

			if ( this.spreadtype == "Airborne" ) {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInViewExcludeThis( mob, 1 ), typeof(Mob_Living_Carbon) )) {
					M = _b;
					

					if ( GlobalFuncs.airborne_can_reach( GlobalFuncs.get_turf( mob ), GlobalFuncs.get_turf( M ) ) ) {
						GlobalFuncs.infect_virus2( M, this, null, "(Airborne from " + GlobalFuncs.key_name( mob ) + ")" );
					}
				}
			}
			mob.bodytemperature = Num13.MaxInt( Convert.ToInt32( mob.bodytemperature ), Num13.MinInt( ( this.stage ??0) * 5 + 310, Convert.ToInt32( mob.bodytemperature + ( this.stage ??0) * 5 ) ) );
			this.clicks += this.speed ?1:0;
			return;
		}

		// Function from file: disease2.dm
		public void makerandom( bool? greater = null ) {
			greater = greater ?? false;

			int? i = null;
			Disease2_Effectholder holder = null;

			i = null;
			i = 1;

			while (( i ??0) <= ( this.max_stage ??0)) {
				holder = new Disease2_Effectholder( this );
				holder.stage = i;

				if ( greater == true ) {
					holder.getrandomeffect( 2 );
				} else {
					holder.getrandomeffect();
				}
				this.effects.Add( holder );
				i++;
			}
			this.uniqueID = Rand13.Int( 0, 10000 );
			GlobalVars.disease2_list["" + this.uniqueID] = this;
			this.infectionchance = Rand13.Int( 60, 90 );
			this.antigen = ((int)( this.antigen )) | ( ((int)( String13.ParseNumber( Rand13.PickFromTable( GlobalVars.ANTIGENS ) ) ??0 )) );
			this.antigen = ((int)( this.antigen )) | ( ((int)( String13.ParseNumber( Rand13.PickFromTable( GlobalVars.ANTIGENS ) ) ??0 )) );
			this.spreadtype = ( Rand13.PercentChance( 70 ) ? "Airborne" : ( Rand13.PercentChance( 20 ) ? "Blood" : "Contact" ) );
			return;
		}

	}

}