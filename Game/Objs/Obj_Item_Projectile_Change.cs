// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Change : Obj_Item_Projectile {

		public dynamic changetype = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.damage_type = "fire";
			this.nodamage = true;
			this.flag = "energy";
			this.icon_state = "ice_1";
		}

		public Obj_Item_Projectile_Change ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: change.dm
		public dynamic wabbajack( dynamic M = null, dynamic type = null ) {
			dynamic Robot = null;
			Obj_Item W = null;
			dynamic new_mob = null;
			dynamic randomize = null;
			dynamic Monkey = null;
			dynamic Robot2 = null;
			dynamic MoMMI = null;
			dynamic slimey = null;
			dynamic Slime = null;
			dynamic alien_caste = null;
			dynamic Alien = null;
			Preferences A = null;
			dynamic H = null;
			dynamic newspecies = null;
			Preferences A2 = null;
			dynamic H2 = null;
			Spell S = null;
			dynamic I = null;

			
			if ( M is Mob_Living && Convert.ToInt32( M.stat ) != 2 ) {
				
				if ( M.monkeyizing ) {
					return null;
				}

				if ( M is Mob_Living_Carbon_Human_Manifested ) {
					this.visible_message( "<span class='caution'>The bolt of change doesn't seem to affect " + M + " in any way.</span>" );
					return null;
				}
				M.monkeyizing = true;
				M.canmove = false;
				M.icon = null;
				M.overlays.len = 0;
				M.invisibility = 101;

				if ( M is Mob_Living_Silicon_Robot ) {
					Robot = M;

					if ( Lang13.Bool( Robot.mmi ) ) {
						GlobalFuncs.qdel( Robot.mmi );
					}
				} else {
					
					foreach (dynamic _a in Lang13.Enumerate( M, typeof(Obj_Item) )) {
						W = _a;
						

						if ( W is Obj_Item_Weapon_Implant ) {
							GlobalFuncs.qdel( W );
							continue;
						}
						W.layer = Convert.ToDouble( Lang13.Initial( W, "layer" ) );
						W.loc = M.loc;
						W.dropped( M );
					}
				}
				new_mob = null;

				if ( type != null && Rand13.PercentChance( 10 ) ) {
					type = null;
				}
				randomize = ( type == null ? Rand13.PickFromTable( GlobalVars.available_staff_transforms ) : type );

				dynamic _c = randomize; // Was a switch-case, sorry for the mess.
				if ( _c=="monkey" ) {
					new_mob = new Mob_Living_Carbon_Monkey( M.loc );
					((Game_Data)new_mob).setGender( M.gender );
					Monkey = new_mob;
					Monkey.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						Monkey.default_language = M.default_language;
					}
				} else if ( _c=="robot" ) {
					new_mob = new Mob_Living_Silicon_Robot( M.loc );
					((Game_Data)new_mob).setGender( M.gender );
					new_mob.invisibility = 0;
					new_mob.job = "Cyborg";
					Robot2 = new_mob;
					Robot2.mmi = new Obj_Item_Device_Mmi( new_mob );
					((Obj_Item_Device_Mmi)Robot2.mmi).transfer_identity( M );
					Robot2.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						Robot2.default_language = M.default_language;
					}
				} else if ( _c=="mommi" ) {
					new_mob = new Mob_Living_Silicon_Robot_Mommi( M.loc );
					((Game_Data)new_mob).setGender( M.gender );
					new_mob.invisibility = 0;
					new_mob.job = "MoMMI";
					MoMMI = new_mob;
					MoMMI.mmi = new Obj_Item_Device_Mmi( new_mob );
					((Obj_Item_Device_Mmi)MoMMI.mmi).transfer_identity( M );
					MoMMI.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						MoMMI.default_language = M.default_language;
					}
				} else if ( _c=="slime" ) {
					slimey = Rand13.Pick(new object [] { "", "/purple", "/metal", "/orange", "/blue", "/darkblue", "/darkpurple", "/yellow", "/silver", "/pink", "/red", "/gold", "/green", "/lightpink", "/oil", "/black", "/adamantine", "/bluespace", "/pyrite", "/cerulean", "/sepia" });

					if ( Rand13.PercentChance( 50 ) ) {
						slimey = "/adult" + slimey;
					}
					slimey = Lang13.FindClass( "/mob/living/carbon/slime" + slimey );
					new_mob = Lang13.Call( slimey, M.loc );
					((Game_Data)new_mob).setGender( M.gender );
					Slime = new_mob;
					Slime.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						Slime.default_language = M.default_language;
					}
				} else if ( _c=="xeno" ) {
					alien_caste = Rand13.Pick(new object [] { "Hunter", "Sentinel", "Drone", "Larva" });

					dynamic _b = alien_caste; // Was a switch-case, sorry for the mess.
					if ( _b=="Hunter" ) {
						new_mob = new Mob_Living_Carbon_Alien_Humanoid_Hunter( M.loc );
					} else if ( _b=="Sentinel" ) {
						new_mob = new Mob_Living_Carbon_Alien_Humanoid_Sentinel( M.loc );
					} else if ( _b=="Drone" ) {
						new_mob = new Mob_Living_Carbon_Alien_Humanoid_Drone( M.loc );
					} else {
						new_mob = new Mob_Living_Carbon_Alien_Larva( M.loc );
					}
					Alien = new_mob;
					Alien.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						Alien.default_language = M.default_language;
					}
				} else if ( _c=="human" ) {
					new_mob = new Mob_Living_Carbon_Human( M.loc );

					if ( M.gender == GlobalVars.MALE || M.gender == GlobalVars.FEMALE ) {
						((Game_Data)new_mob).setGender( M.gender );
					} else {
						((Game_Data)new_mob).setGender( Rand13.Pick(new object [] { GlobalVars.MALE, GlobalVars.FEMALE }) );
					}
					A = new Preferences();
					A.randomize_appearance_for( new_mob );
					H = new_mob;
					newspecies = Rand13.PickFromTable( GlobalVars.all_species - typeof(Species_Krampus) );
					((Mob_Living_Carbon_Human)H).set_species( newspecies );
					((Mob)H).generate_name();
					H.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						H.default_language = M.default_language;
					}
				} else if ( _c=="furry" ) {
					new_mob = new Mob_Living_Carbon_Human( M.loc );

					if ( M.gender == GlobalVars.MALE || M.gender == GlobalVars.FEMALE ) {
						((Game_Data)new_mob).setGender( M.gender );
					} else {
						((Game_Data)new_mob).setGender( Rand13.Pick(new object [] { GlobalVars.MALE, GlobalVars.FEMALE }) );
					}
					A2 = new Preferences();
					A2.randomize_appearance_for( new_mob );
					H2 = new_mob;
					((Mob_Living_Carbon_Human)H2).set_species( "Tajaran" );
					H2.languages |= M.languages;

					if ( Lang13.Bool( M.default_language ) ) {
						H2.default_language = M.default_language;
					}
					((Mob)H2).generate_name();
				} else {
					return null;
				}

				if ( Lang13.Bool( M.mind ) && M.mind.wizard_spells != null && M.mind.wizard_spells.len != 0 ) {
					
					foreach (dynamic _d in Lang13.Enumerate( M.mind.wizard_spells, typeof(Spell) )) {
						S = _d;
						
						new_mob.spell_list.Add( Lang13.Call( S.type ) );
					}
				}
				new_mob.a_intent = "hurt";

				if ( Lang13.Bool( M.mind ) ) {
					((Mind)M.mind).transfer_to( new_mob );
				} else {
					new_mob.key = M.key;
				}

				if ( M is Mob_Living_Carbon ) {
					I = M;
					((Mob_Living_Carbon)I).transferBorers( new_mob );
				}
				GlobalFuncs.to_chat( new_mob, "<B>Your form morphs into that of a " + randomize + ".</B>" );
				GlobalFuncs.qdel( M );
				return new_mob;
			}
			return null;
		}

		// Function from file: change.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			dynamic type = null;

			type = this.changetype;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				this.wabbajack( atarget, type );
				return;
			}));
			return false;
		}

	}

}