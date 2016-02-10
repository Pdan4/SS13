// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Violin : Obj_Item_Device {

		public Song song = null;
		public bool playing = false;
		public double help = 0;
		public double edit = 1;
		public int repeat = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "violin";
			this.force = 10;
			this.icon = "icons/obj/musician.dmi";
			this.icon_state = "violin";
		}

		public Obj_Item_Device_Violin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vgstation13.dme
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic tempnum = null;
			string newline = null;
			int? num = null;
			double num2 = 0;
			string content = null;
			string t = null;
			dynamic cont = null;
			ByTable lines = null;
			double tempo = 0;
			int linenum = 0;
			dynamic l = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["newsong"] ) ) {
				this.song = new Song();
			} else if ( this.song != null ) {
				
				if ( Lang13.Bool( href_list["repeat"] ) ) {
					
					if ( this.playing ) {
						return null;
					}
					tempnum = Interface13.Input( "How many times do you want to repeat this piece? (max:10)", null, null, null, null, InputType.Num | InputType.Null );

					if ( Convert.ToDouble( tempnum ) > 10 ) {
						tempnum = 10;
					}

					if ( Convert.ToDouble( tempnum ) < 0 ) {
						tempnum = 0;
					}
					this.repeat = Num13.Floor( Convert.ToDouble( tempnum ) );
				} else if ( Lang13.Bool( href_list["tempo"] ) ) {
					this.song.tempo += Num13.Floor( String13.ParseNumber( href_list["tempo"] ) ??0 );

					if ( this.song.tempo < 1 ) {
						this.song.tempo = 1;
					}
				} else if ( Lang13.Bool( href_list["play"] ) ) {
					
					if ( this.song != null ) {
						this.playing = true;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.playsong();
							return;
						}));
					}
				} else if ( Lang13.Bool( href_list["newline"] ) ) {
					newline = String13.HtmlEncode( Interface13.Input( "Enter your line: ", "violin", null, null, null, InputType.Str | InputType.Null ) );

					if ( !Lang13.Bool( newline ) ) {
						return null;
					}

					if ( this.song.lines.len > 50 ) {
						return null;
					}

					if ( Lang13.Length( newline ) > 50 ) {
						newline = String13.SubStr( newline, 1, 50 );
					}
					this.song.lines.Add( newline );
				} else if ( Lang13.Bool( href_list["deleteline"] ) ) {
					num = Num13.Floor( String13.ParseNumber( href_list["deleteline"] ) ??0 );

					if ( ( num ??0) > this.song.lines.len || ( num ??0) < 1 ) {
						return null;
					}
					this.song.lines.Cut( num, ( num ??0) + 1 );
				} else if ( Lang13.Bool( href_list["modifyline"] ) ) {
					num2 = Num13.Round( String13.ParseNumber( href_list["modifyline"] ) ??0, 1 );
					content = String13.HtmlEncode( Interface13.Input( "Enter your line: ", "violin", this.song.lines[num2], null, null, InputType.Str | InputType.Null ) );

					if ( !Lang13.Bool( content ) ) {
						return null;
					}

					if ( Lang13.Length( content ) > 50 ) {
						content = String13.SubStr( content, 1, 50 );
					}

					if ( num2 > this.song.lines.len || num2 < 1 ) {
						return null;
					}
					this.song.lines[num2] = content;
				} else if ( Lang13.Bool( href_list["stop"] ) ) {
					this.playing = false;
				} else if ( Lang13.Bool( href_list["help"] ) ) {
					this.help = ( String13.ParseNumber( href_list["help"] ) ??0) - 1;
				} else if ( Lang13.Bool( href_list["edit"] ) ) {
					this.edit = ( String13.ParseNumber( href_list["edit"] ) ??0) - 1;
				} else if ( Lang13.Bool( href_list["import"] ) ) {
					t = "";

					do {
						t = String13.HtmlEncode( Interface13.Input( Task13.User, "Please paste the entire song, formatted:", "" + this.name, t, null, InputType.StrMultiline ) );

						if ( !GlobalFuncs.in_range( this, Task13.User ) ) {
							return null;
						}

						if ( Lang13.Length( t ) >= 3072 ) {
							cont = Interface13.Input( Task13.User, "Your message is too long! Would you like to continue editing it?", "", "yes", new ByTable(new object [] { "yes", "no" }), InputType.Any );

							if ( cont == "no" ) {
								break;
							}
						}
					} while ( Lang13.Length( t ) > 3072 );
					Task13.Schedule( 0, (Task13.Closure)(() => {
						lines = GlobalFuncs.text2list( t, "\n" );
						tempo = 5;

						if ( String13.SubStr( lines[1], 1, 6 ) == "BPM: " ) {
							tempo = 600 / ( String13.ParseNumber( String13.SubStr( lines[1], 6, 0 ) ) ??0);
							lines.Cut( 1, 2 );
						}

						if ( lines.len > 50 ) {
							GlobalFuncs.to_chat( Task13.User, "Too many lines!" );
							lines.Cut( 51 );
						}
						linenum = 1;

						foreach (dynamic _a in Lang13.Enumerate( lines )) {
							l = _a;
							

							if ( Lang13.Length( l ) > 50 ) {
								GlobalFuncs.to_chat( Task13.User, "Line " + linenum + " too long!" );
								lines.Remove( l );
							} else {
								linenum++;
							}
						}
						this.song = new Song();
						this.song.lines = lines;
						this.song.tempo = tempo;
						return;
					}));
				}
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: violin.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;
			double calctempo = 0;
			int linecount = 0;
			dynamic line = null;

			
			if ( !( user is Mob_Living ) || Lang13.Bool( user.stat ) || ((Mob)user).restrained() || user.lying == true ) {
				return null;
			}
			((Mob)user).set_machine( this );
			dat = "<HEAD><TITLE>Violin</TITLE></HEAD><BODY>";

			if ( this.song != null ) {
				
				if ( this.song.lines.len > 0 && !this.playing ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";play=1'>Play Song</A><BR><BR>\n				<A href='?src=" ).Ref( this ).str( ";repeat=1'>Repeat Song: " ).item( this.repeat ).str( " times.</A><BR><BR>" ).ToString();
				}

				if ( this.playing ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";stop=1'>Stop Playing</A><BR>\n				Repeats left: " ).item( this.repeat ).str( ".<BR><BR>" ).ToString();
				}
			}

			if ( !( this.edit != 0 ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";edit=2'>Show Editor</A><BR><BR>" ).ToString();
			} else {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";edit=1'>Hide Editor</A><BR>\n			<A href='?src=" ).Ref( this ).str( ";newsong=1'>Start a New Song</A><BR>\n			<A href='?src=" ).Ref( this ).str( ";import=1'>Import a Song</A><BR><BR>" ).ToString();

				if ( this.song != null ) {
					calctempo = 10 / this.song.tempo * 60;
					dat += new Txt( "Tempo : <A href='?src=" ).Ref( this ).str( ";tempo=10'>-</A><A href='?src=" ).Ref( this ).str( ";tempo=1'>-</A> " ).item( calctempo ).str( " BPM <A href='?src=" ).Ref( this ).str( ";tempo=-1'>+</A><A href='?src=" ).Ref( this ).str( ";tempo=-10'>+</A><BR><BR>" ).ToString();
					linecount = 0;

					foreach (dynamic _a in Lang13.Enumerate( this.song.lines )) {
						line = _a;
						
						linecount += 1;
						dat += new Txt( "Line " ).item( linecount ).str( ": " ).item( line ).str( " <A href='?src=" ).Ref( this ).str( ";deleteline=" ).item( linecount ).str( "'>Delete Line</A> <A href='?src=" ).Ref( this ).str( ";modifyline=" ).item( linecount ).str( "'>Modify Line</A><BR>" ).ToString();
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";newline=1'>Add Line</A><BR><BR>" ).ToString();
				}

				if ( this.help != 0 ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";help=1'>Hide Help</A><BR>" ).ToString();
					dat += @"
					Lines are a series of chords, separated by commas (,), each with notes seperated by hyphens (-).<br>
					Every note in a chord will play together, with chord timed by the tempo.<br>
					<br>
					Notes are played by the names of the note, and optionally, the accidental, and/or the octave number.<br>
					By default, every note is natural and in octave 3. Defining otherwise is remembered for each note.<br>
					Example: <i>C,D,E,F,G,A,B</i> will play a C major scale.<br>
					After a note has an accidental placed, it will be remembered: <i>C,C4,C,C3</i> is C3,C4,C4,C3</i><br>
					Chords can be played simply by seperating each note with a hyphon: <i>A-C#,Cn-E,E-G#,Gn-B</i><br>
					A pause may be denoted by an empty chord: <i>C,E,,C,G</i><br>
					To make a chord be a different time, end it with /x, where the chord length will be length<br>
					defined by tempo / x: <i>C,G/2,E/4</i><br>
					Combined, an example is: <i>E-E4/4,/2,G#/8,B/8,E3-E4/4</i>
					<br>
					Lines may be up to 50 characters.<br>
					A song may only contain up to 50 lines.<br>
					";
				} else {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";help=2'>Show Help</A><BR>" ).ToString();
				}
			}
			dat += "</BODY></HTML>";
			Interface13.Browse( user, dat, "window=violin;size=700x300" );
			GlobalFuncs.onclose( user, "violin" );
			return null;
		}

		// Function from file: violin.dm
		public void playsong(  ) {
			ByTable cur_oct = null;
			ByTable cur_acc = null;
			double i = 0;
			dynamic line = null;
			dynamic beat = null;
			ByTable notes = null;
			dynamic note = null;
			int cur_note = 0;
			double i2 = 0;
			string ni = null;

			
			do {
				cur_oct = null;
				cur_oct = new ByTable( 7 );
				cur_acc = null;
				cur_acc = new ByTable( 7 );

				foreach (dynamic _a in Lang13.IterateRange( 1, 7 )) {
					i = _a;
					
					cur_oct[i] = "3";
					cur_acc[i] = "n";
				}

				foreach (dynamic _e in Lang13.Enumerate( this.song.lines )) {
					line = _e;
					

					foreach (dynamic _d in Lang13.Enumerate( GlobalFuncs.text2list( String13.ToLower( line ), "," ) )) {
						beat = _d;
						
						notes = GlobalFuncs.text2list( beat, "/" );

						foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.text2list( notes[1], "-" ) )) {
							note = _c;
							

							if ( !this.playing || !( this.loc is Mob_Living ) ) {
								this.playing = false;
								return;
							}

							if ( Lang13.Length( note ) == 0 ) {
								continue;
							}
							cur_note = String13.GetCharCode( note, null ) - 96;

							if ( cur_note < 1 || cur_note > 7 ) {
								continue;
							}

							foreach (dynamic _b in Lang13.IterateRange( 2, Lang13.Length( note ) )) {
								i2 = _b;
								
								ni = String13.SubStr( note, ((int)( i2 )), ((int)( i2 + 1 )) );

								if ( !Lang13.Bool( String13.ParseNumber( ni ) ) ) {
									
									if ( ni == "#" || ni == "b" || ni == "n" ) {
										cur_acc[cur_note] = ni;
									} else if ( ni == "s" ) {
										cur_acc[cur_note] = "#";
									}
								} else {
									cur_oct[cur_note] = ni;
								}
							}
							this.playnote( String13.ToUpper( String13.SubStr( note, 1, 2 ) ) + cur_acc[cur_note] + cur_oct[cur_note] );
						}

						if ( notes.len >= 2 && Lang13.Bool( String13.ParseNumber( notes[2] ) ) ) {
							Task13.Sleep( ((int)( this.song.tempo / ( String13.ParseNumber( notes[2] ) ??0) )) );
						} else {
							Task13.Sleep( ((int)( this.song.tempo )) );
						}
					}
				}

				if ( this.repeat > 0 ) {
					this.repeat--;
				}
			} while ( this.repeat > 0 );
			this.playing = false;
			return;
		}

		// Function from file: violin.dm
		public void playnote( string note = null ) {
			string soundfile = null;

			
			switch ((string)( note )) {
				case "Cn1":
					soundfile = "sound/violin/Cn1.mid";
					break;
				case "C#1":
					soundfile = "sound/violin/Db1.mid";
					break;
				case "Db1":
					soundfile = "sound/violin/Db1.mid";
					break;
				case "Dn1":
					soundfile = "sound/violin/Dn1.mid";
					break;
				case "D#1":
					soundfile = "sound/violin/Eb1.mid";
					break;
				case "Eb1":
					soundfile = "sound/violin/Eb1.mid";
					break;
				case "En1":
					soundfile = "sound/violin/En1.mid";
					break;
				case "E#1":
					soundfile = "sound/violin/E#1.mid";
					break;
				case "Fb1":
					soundfile = "sound/violin/Fb1.mid";
					break;
				case "Fn1":
					soundfile = "sound/violin/Fn1.mid";
					break;
				case "F#1":
					soundfile = "sound/violin/Gb1.mid";
					break;
				case "Gb1":
					soundfile = "sound/violin/Gb1.mid";
					break;
				case "Gn1":
					soundfile = "sound/violin/Gn1.mid";
					break;
				case "G#1":
					soundfile = "sound/violin/G#1.mid";
					break;
				case "Ab1":
					soundfile = "sound/violin/Ab1.mid";
					break;
				case "An1":
					soundfile = "sound/violin/An1.mid";
					break;
				case "A#1":
					soundfile = "sound/violin/Bb1.mid";
					break;
				case "Bb1":
					soundfile = "sound/violin/Bb1.mid";
					break;
				case "Bn1":
					soundfile = "sound/violin/Bn1.mid";
					break;
				case "B#1":
					soundfile = "sound/violin/B#1.mid";
					break;
				case "Cb2":
					soundfile = "sound/violin/Cb2.mid";
					break;
				case "Cn2":
					soundfile = "sound/violin/Cn2.mid";
					break;
				case "C#2":
					soundfile = "sound/violin/Db2.mid";
					break;
				case "Db2":
					soundfile = "sound/violin/Db2.mid";
					break;
				case "Dn2":
					soundfile = "sound/violin/Dn2.mid";
					break;
				case "D#2":
					soundfile = "sound/violin/Eb2.mid";
					break;
				case "Eb2":
					soundfile = "sound/violin/Eb2.mid";
					break;
				case "En2":
					soundfile = "sound/violin/En2.mid";
					break;
				case "E#2":
					soundfile = "sound/violin/E#2.mid";
					break;
				case "Fb2":
					soundfile = "sound/violin/Fb2.mid";
					break;
				case "Fn2":
					soundfile = "sound/violin/Fn2.mid";
					break;
				case "F#2":
					soundfile = "sound/violin/Gb2.mid";
					break;
				case "Gb2":
					soundfile = "sound/violin/Gb2.mid";
					break;
				case "Gn2":
					soundfile = "sound/violin/Gn2.mid";
					break;
				case "G#2":
					soundfile = "sound/violin/Ab3.mid";
					break;
				case "Ab2":
					soundfile = "sound/violin/Ab2.mid";
					break;
				case "An2":
					soundfile = "sound/violin/An2.mid";
					break;
				case "A#2":
					soundfile = "sound/violin/Bb2.mid";
					break;
				case "Bb2":
					soundfile = "sound/violin/Bb2.mid";
					break;
				case "Bn2":
					soundfile = "sound/violin/Bn2.mid";
					break;
				case "B#2":
					soundfile = "sound/violin/B#2.mid";
					break;
				case "Cb3":
					soundfile = "sound/violin/Cb3.mid";
					break;
				case "Cn3":
					soundfile = "sound/violin/Cn3.mid";
					break;
				case "C#3":
					soundfile = "sound/violin/Db3.mid";
					break;
				case "Db3":
					soundfile = "sound/violin/Db3.mid";
					break;
				case "Dn3":
					soundfile = "sound/violin/Dn3.mid";
					break;
				case "D#3":
					soundfile = "sound/violin/Eb3.mid";
					break;
				case "Eb3":
					soundfile = "sound/violin/Eb3.mid";
					break;
				case "En3":
					soundfile = "sound/violin/En3.mid";
					break;
				case "E#3":
					soundfile = "sound/violin/E#3.mid";
					break;
				case "Fb3":
					soundfile = "sound/violin/Fb3.mid";
					break;
				case "Fn3":
					soundfile = "sound/violin/Fn3.mid";
					break;
				case "F#3":
					soundfile = "sound/violin/Gb3.mid";
					break;
				case "Gb3":
					soundfile = "sound/violin/Gb3.mid";
					break;
				case "Gn3":
					soundfile = "sound/violin/Gn3.mid";
					break;
				case "G#3":
					soundfile = "sound/violin/Ab4.mid";
					break;
				case "Ab3":
					soundfile = "sound/violin/Ab3.mid";
					break;
				case "An3":
					soundfile = "sound/violin/An3.mid";
					break;
				case "A#3":
					soundfile = "sound/violin/Bb3.mid";
					break;
				case "Bb3":
					soundfile = "sound/violin/Bb3.mid";
					break;
				case "Bn3":
					soundfile = "sound/violin/Bn3.mid";
					break;
				case "B#3":
					soundfile = "sound/violin/B#3.mid";
					break;
				case "Cb4":
					soundfile = "sound/violin/Cb4.mid";
					break;
				case "Cn4":
					soundfile = "sound/violin/Cn4.mid";
					break;
				case "C#4":
					soundfile = "sound/violin/Db4.mid";
					break;
				case "Db4":
					soundfile = "sound/violin/Db4.mid";
					break;
				case "Dn4":
					soundfile = "sound/violin/Dn4.mid";
					break;
				case "D#4":
					soundfile = "sound/violin/Eb4.mid";
					break;
				case "Eb4":
					soundfile = "sound/violin/Eb4.mid";
					break;
				case "En4":
					soundfile = "sound/violin/En4.mid";
					break;
				case "E#4":
					soundfile = "sound/violin/E#4.mid";
					break;
				case "Fb4":
					soundfile = "sound/violin/Fb4.mid";
					break;
				case "Fn4":
					soundfile = "sound/violin/Fn4.mid";
					break;
				case "F#4":
					soundfile = "sound/violin/Gb4.mid";
					break;
				case "Gb4":
					soundfile = "sound/violin/Gb4.mid";
					break;
				case "Gn4":
					soundfile = "sound/violin/Gn4.mid";
					break;
				case "G#4":
					soundfile = "sound/violin/Ab5.mid";
					break;
				case "Ab4":
					soundfile = "sound/violin/Ab4.mid";
					break;
				case "An4":
					soundfile = "sound/violin/An4.mid";
					break;
				case "A#4":
					soundfile = "sound/violin/Bb4.mid";
					break;
				case "Bb4":
					soundfile = "sound/violin/Bb4.mid";
					break;
				case "Bn4":
					soundfile = "sound/violin/Bn4.mid";
					break;
				case "B#4":
					soundfile = "sound/violin/B#4.mid";
					break;
				case "Cb5":
					soundfile = "sound/violin/Cb5.mid";
					break;
				case "Cn5":
					soundfile = "sound/violin/Cn5.mid";
					break;
				case "C#5":
					soundfile = "sound/violin/Db5.mid";
					break;
				case "Db5":
					soundfile = "sound/violin/Db5.mid";
					break;
				case "Dn5":
					soundfile = "sound/violin/Dn5.mid";
					break;
				case "D#5":
					soundfile = "sound/violin/Eb5.mid";
					break;
				case "Eb5":
					soundfile = "sound/violin/Eb5.mid";
					break;
				case "En5":
					soundfile = "sound/violin/En5.mid";
					break;
				case "E#5":
					soundfile = "sound/violin/E#5.mid";
					break;
				case "Fb5":
					soundfile = "sound/violin/Fb5.mid";
					break;
				case "Fn5":
					soundfile = "sound/violin/Fn5.mid";
					break;
				case "F#5":
					soundfile = "sound/violin/Gb5.mid";
					break;
				case "Gb5":
					soundfile = "sound/violin/Gb5.mid";
					break;
				case "Gn5":
					soundfile = "sound/violin/Gn5.mid";
					break;
				case "G#5":
					soundfile = "sound/violin/Ab6.mid";
					break;
				case "Ab5":
					soundfile = "sound/violin/Ab5.mid";
					break;
				case "An5":
					soundfile = "sound/violin/An5.mid";
					break;
				case "A#5":
					soundfile = "sound/violin/Bb5.mid";
					break;
				case "Bb5":
					soundfile = "sound/violin/Bb5.mid";
					break;
				case "Bn5":
					soundfile = "sound/violin/Bn5.mid";
					break;
				case "B#5":
					soundfile = "sound/violin/B#5.mid";
					break;
				case "Cb6":
					soundfile = "sound/violin/Cb6.mid";
					break;
				case "Cn6":
					soundfile = "sound/violin/Cn6.mid";
					break;
				case "C#6":
					soundfile = "sound/violin/Db6.mid";
					break;
				case "Db6":
					soundfile = "sound/violin/Db6.mid";
					break;
				case "Dn6":
					soundfile = "sound/violin/Dn6.mid";
					break;
				case "D#6":
					soundfile = "sound/violin/Eb6.mid";
					break;
				case "Eb6":
					soundfile = "sound/violin/Eb6.mid";
					break;
				case "En6":
					soundfile = "sound/violin/En6.mid";
					break;
				case "E#6":
					soundfile = "sound/violin/E#6.mid";
					break;
				case "Fb6":
					soundfile = "sound/violin/Fb6.mid";
					break;
				case "Fn6":
					soundfile = "sound/violin/Fn6.mid";
					break;
				case "F#6":
					soundfile = "sound/violin/Gb6.mid";
					break;
				case "Gb6":
					soundfile = "sound/violin/Gb6.mid";
					break;
				case "Gn6":
					soundfile = "sound/violin/Gn6.mid";
					break;
				case "G#6":
					soundfile = "sound/violin/Ab7.mid";
					break;
				case "Ab6":
					soundfile = "sound/violin/Ab6.mid";
					break;
				case "An6":
					soundfile = "sound/violin/An6.mid";
					break;
				case "A#6":
					soundfile = "sound/violin/Bb6.mid";
					break;
				case "Bb6":
					soundfile = "sound/violin/Bb6.mid";
					break;
				case "Bn6":
					soundfile = "sound/violin/Bn6.mid";
					break;
				case "B#6":
					soundfile = "sound/violin/B#6.mid";
					break;
				case "Cb7":
					soundfile = "sound/violin/Cb7.mid";
					break;
				case "Cn7":
					soundfile = "sound/violin/Cn7.mid";
					break;
				case "C#7":
					soundfile = "sound/violin/Db7.mid";
					break;
				case "Db7":
					soundfile = "sound/violin/Db7.mid";
					break;
				case "Dn7":
					soundfile = "sound/violin/Dn7.mid";
					break;
				case "D#7":
					soundfile = "sound/violin/Eb7.mid";
					break;
				case "Eb7":
					soundfile = "sound/violin/Eb7.mid";
					break;
				case "En7":
					soundfile = "sound/violin/En7.mid";
					break;
				case "E#7":
					soundfile = "sound/violin/E#7.mid";
					break;
				case "Fb7":
					soundfile = "sound/violin/Fb7.mid";
					break;
				case "Fn7":
					soundfile = "sound/violin/Fn7.mid";
					break;
				case "F#7":
					soundfile = "sound/violin/Gb7.mid";
					break;
				case "Gb7":
					soundfile = "sound/violin/Gb7.mid";
					break;
				case "Gn7":
					soundfile = "sound/violin/Gn7.mid";
					break;
				case "G#7":
					soundfile = "sound/violin/G#7.mid";
					break;
				case "Ab7":
					soundfile = "sound/violin/Ab7.mid";
					break;
				case "An7":
					soundfile = "sound/violin/An7.mid";
					break;
				case "A#7":
					soundfile = "sound/violin/Bb7.mid";
					break;
				case "Bb7":
					soundfile = "sound/violin/Bb7.mid";
					break;
				case "Bn7":
					soundfile = "sound/violin/Bn7.mid";
					break;
				case "B#7":
					soundfile = "sound/violin/B#7.mid";
					break;
				case "Cb8":
					soundfile = "sound/violin/Cb8.mid";
					break;
				case "Cn8":
					soundfile = "sound/violin/Cn8.mid";
					break;
				case "C#8":
					soundfile = "sound/violin/Db8.mid";
					break;
				case "Db8":
					soundfile = "sound/violin/Db8.mid";
					break;
				case "Dn8":
					soundfile = "sound/violin/Dn8.mid";
					break;
				case "D#8":
					soundfile = "sound/violin/Eb8.mid";
					break;
				case "Eb8":
					soundfile = "sound/violin/Eb8.mid";
					break;
				case "En8":
					soundfile = "sound/violin/En8.mid";
					break;
				case "E#8":
					soundfile = "sound/violin/E#8.mid";
					break;
				case "Fb8":
					soundfile = "sound/violin/Fb8.mid";
					break;
				case "Fn8":
					soundfile = "sound/violin/Fn8.mid";
					break;
				case "F#8":
					soundfile = "sound/violin/Gb8.mid";
					break;
				case "Gb8":
					soundfile = "sound/violin/Gb8.mid";
					break;
				case "Gn8":
					soundfile = "sound/violin/Gn8.mid";
					break;
				case "G#8":
					soundfile = "sound/violin/G#8.mid";
					break;
				case "Ab8":
					soundfile = "sound/violin/Ab8.mid";
					break;
				case "An8":
					soundfile = "sound/violin/An8.mid";
					break;
				case "A#8":
					soundfile = "sound/violin/Bb8.mid";
					break;
				case "Bb8":
					soundfile = "sound/violin/Bb8.mid";
					break;
				case "Bn8":
					soundfile = "sound/violin/Bn8.mid";
					break;
				case "B#8":
					soundfile = "sound/violin/B#8.mid";
					break;
				case "Cb9":
					soundfile = "sound/violin/Cb9.mid";
					break;
				case "Cn9":
					soundfile = "sound/violin/Cn9.mid";
					break;
				default:
					return;
					break;
			}
			GlobalFuncs.to_chat( Map13.FetchHearers( GlobalFuncs.get_turf( this ), 15 ), new Sound( soundfile ) );
			return;
		}

	}

}