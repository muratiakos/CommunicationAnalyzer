using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caCoreLibrary;

namespace caGraphLibrary
{
	/// <summary>
	/// Ügymenet elemzés ábrázolására szolgáló vezérlő osztály
	/// </summary>

	public partial class caCommFlow : UserControl
	{

		//Node típusát leíró enumerációk
		public enum caCommFlowNodeType
		{
			ParticipantNode,
			CommItemNode
		}

		//Idő megjelenítési módok enumerációja
		public enum caCommFlowTimeMode
		{
			Minute, // 1440
			Hour, // 24,
			Day, // 1,
			Week, // 1/7
			Month,
			DateList //Csak adott dátumok listázásához
		}

		//Dátum lista módban az idő a vízszintes kooordinátáért felel
		private class caCommFlowNodeTimeListItem
		{
			public DateTime m_timestamp;
			public int m_nodeCount = 1;
			public float m_left = 0;
		}

		//Egy csomópontot prezentáló osztály
		private class caCommFlowNode
		{
			//Statikus teljes dátumintervallumot leíró időjelölők
			public static DateTime minDate = DateTime.MaxValue;
			public static DateTime maxDate = DateTime.MinValue;

			//Időlista elemei
			public static List<caCommFlowNodeTimeListItem> timeList = new List<caCommFlowNodeTimeListItem>();

			//Új dátum felvétele az időcache-be
			public static caCommFlowNodeTimeListItem AddToCache(caCommFlowNodeTimeListItem _new)
			{
				caCommFlowNodeTimeListItem _old = null;
				try
				{
					_old = timeList.Find(t => t.m_timestamp.Equals(_new.m_timestamp));
				}
				catch { }

				if (_old == null)
				{
					timeList.Add(_new);
					return _new;
				}
				else
				{
					//this.Add(_old);
					_old.m_nodeCount++;
					return _old;
				}
			}

			//Részidőegységek (fekete vonalak) a különböző időmódokban
			public static int SmallScale(caCommFlowTimeMode _z)
			{
				int smallGrid = -1;
				switch (_z)
				{
					case caCommFlowTimeMode.Minute:
						smallGrid = 20; //1 perc = 40 pixel
						break;
					case caCommFlowTimeMode.Hour:
						smallGrid = 120;
						break;
					case caCommFlowTimeMode.Day:
						smallGrid = 96;
						break;
					case caCommFlowTimeMode.Week:
						smallGrid = 70;
						break;
					case caCommFlowTimeMode.Month:
						smallGrid = 240;
						break;
					case caCommFlowTimeMode.DateList:
						smallGrid = 240;
						break;
					default:
						break;
				}
				return smallGrid;
			}

			//Nagy léptékű időegységek (piros vonal) a különböző időmódokban
			public static int BigScale(caCommFlowTimeMode _z)
			{
				int bigGrid = -1;
				switch (_z)
				{
					case caCommFlowTimeMode.Minute:
						bigGrid = 60 * SmallScale(_z);
						break;
					case caCommFlowTimeMode.Hour:
						bigGrid = 24 * SmallScale(_z);
						break;
					case caCommFlowTimeMode.Day:
						bigGrid = 7 * SmallScale(_z);
						break;
					case caCommFlowTimeMode.Week:
						bigGrid = 4 * SmallScale(_z);
						break;
					case caCommFlowTimeMode.Month:
						bigGrid = 12 * SmallScale(_z);
						break;
					case caCommFlowTimeMode.DateList:
						bigGrid = SmallScale(_z);
						break;
					default:
						break;
				}
				return bigGrid;
			}

			//Változók
			public PointF m_p = new Point(0, 0);
			public caParticipantObject m_participant = null;
			public DateTime m_timestamp = DateTime.Now;
			public caCommFlowNodeTimeListItem m_timeItem;
			public string m_rawId = "";
			public List<caCommFlowNode> m_children = new List<caCommFlowNode>();
			public caCommFlowNode m_parent = null;
			public int m_defaultSize = 20;
			public caCommFlowNodeType m_nodeType = caCommFlowNodeType.ParticipantNode;

			//Propertyk

			//Kommunikációs elem azonosítója propertyként - null esetében ""
			public String RawId
			{
				get { return m_rawId; }
				set
				{
					if (String.IsNullOrEmpty(value)) m_rawId = "";
					else m_rawId = value;
				}
			}

			//Kommunikáció időbélyege
			public DateTime TimeStamp
			{
				get { return m_timestamp; }
				set
				{
					m_timestamp = value;
					if (m_timestamp > maxDate) maxDate = m_timestamp;
					if (m_timestamp < minDate) minDate = m_timestamp;

					caCommFlowNodeTimeListItem t = new caCommFlowNodeTimeListItem();
					t.m_timestamp = this.m_timestamp;
					m_timeItem = AddToCache(t);
				}
			}

			//Csomópont középpontját számítő függvény
			public PointF CenterPoint
			{
				get { return new PointF(m_p.X + Margin, m_p.Y + Margin); }
			}

			public int Margin { get; set; }
			public int Height { get; set; }


			//Konstruktor
			public caCommFlowNode()
			{
				Margin = 5;
			}

			//Koordinátákat számító függvény az időpont alapján és az időmódnak megfelelően
			public double GetXByTimestamp(caCommFlowTimeMode _z)
			{
				TimeSpan d = m_timestamp - caCommFlowNode.minDate;
				double dx = 0;
				switch (_z)
				{
					case caCommFlowTimeMode.Minute:
						dx = SmallScale(_z) * d.TotalMinutes;
						break;
					case caCommFlowTimeMode.Hour:
						dx = SmallScale(_z) * d.TotalHours;
						break;
					case caCommFlowTimeMode.Day:
						dx = SmallScale(_z) * d.TotalDays;
						break;
					case caCommFlowTimeMode.Week:
						dx = SmallScale(_z) * d.TotalDays / 7;
						break;
					case caCommFlowTimeMode.Month:
						dx = SmallScale(_z) * d.TotalDays / 30;
						break;
					case caCommFlowTimeMode.DateList:
						dx = m_timeItem.m_left;
						break;
					default:
						break;
				}

				return dx;
			}

			//Pozíció beállítása és függőleges eltolás függvénye - a bővülő fastruktúra kirajzolására
			public int SetPositionsAndGetNewY(double _y, caCommFlowTimeMode _z, int depth)
			{
				//Alsó szintenként kis eltolás

				//if (depth > 0) m_p.X = Convert.ToInt32(GetXByTimestamp(_z) + depth * Margin) ;
				//else

				m_p.X = ((float)GetXByTimestamp(_z)) + (depth + 1) * Margin;
				m_p.Y = (float)_y;

				int db = 1;
				int fullHeight = m_defaultSize;
				//Teljes méret növelése a germekek méretei és pozíciói alapján
				foreach (caCommFlowNode c in this.m_children)
				{
					fullHeight += db * c.SetPositionsAndGetNewY(_y + db * m_defaultSize, _z, depth + db);
					db++;
				}

				Height = fullHeight;

				return fullHeight; // + Margin *2;
			}

			//Csaomópontot kirajzoló eljárás
			public void DrawMe(Graphics _g, Pen _p, Brush _b)
			{
				//_g.DrawEllipse(_p, m_p.X, m_p.Y, m_defaultSize/3, m_defaultSize/3);
				_g.FillEllipse(Brushes.Red, m_p.X, m_p.Y, m_defaultSize, m_defaultSize);
				// Create string to draw.
				Font drawFont = new Font("Arial", 12);
				SolidBrush drawBrush = new SolidBrush(Color.Black);


				if (m_nodeType == caCommFlowNodeType.ParticipantNode) //Participant info
				{
					_g.DrawString(this.m_participant.m_name, drawFont, Brushes.Black, CenterPoint.X, CenterPoint.Y);
				}
				else //COmmItem Info
				{
					_g.DrawString(this.RawId, drawFont, Brushes.Black, CenterPoint.X, CenterPoint.Y);
				}

			}

			//A csomópontot és gyermek nodejait kirajzoló eljárás
			public void DrawAll(Graphics _g, Pen _p, Brush _b)
			{
				foreach (caCommFlowNode child in this.m_children)
				{
					Pen p = new Pen(Brushes.Black, 3);

					_g.DrawLine(p, CenterPoint.X, CenterPoint.Y, CenterPoint.X, child.CenterPoint.Y);
					_g.DrawLine(p, CenterPoint.X, child.CenterPoint.Y, child.CenterPoint.X, child.CenterPoint.Y);

					child.DrawAll(_g, _p, _b);
				}
				this.DrawMe(_g, _p, _b);

			}

			//Egérmutató érzékelése a csomóponton
			public bool HitTest(float x, float y)
			{
				if (
					x >= CenterPoint.X - m_defaultSize &&
					x <= CenterPoint.X + m_defaultSize &&
					y >= CenterPoint.Y - m_defaultSize &&
					y <= CenterPoint.Y + m_defaultSize
				) return true;
				else return false;
			}
		}

		//CSomópontok listáját leíró osztály
		private class caCommFlowNodeList : List<caCommFlowNode>
		{
			//Csomópont gyorsítótár
			public static caCommFlowNodeList cache_fnl = new caCommFlowNodeList();

			//Csak az újdonságot tartalmazóakat ábrázoljuk
			public caCommFlowNode AddIdentical(caCommFlowNode _new)
			{
				caCommFlowNode _old = null;
				try
				{
					if (_new.m_nodeType == caCommFlowNodeType.ParticipantNode) //Emberi nézet
					{
						_old = cache_fnl.Find(
							delegate(caCommFlowNode fn)
							{
								return
									fn.m_participant.m_participantId.Equals(_new.m_participant.m_participantId)
										&& fn.m_rawId.Equals(_new.m_rawId)
										&& (
											!String.IsNullOrEmpty(fn.m_rawId)
										|| (String.IsNullOrEmpty(fn.m_rawId) && fn.m_timestamp.Equals(_new.m_timestamp))
										);
							});
					}
					else //Levél/Comm-item nézet
					{
						_old = cache_fnl.Find(
							delegate(caCommFlowNode fn)
							{
								return (!String.IsNullOrEmpty(fn.m_rawId) && fn.m_rawId.Equals(_new.m_rawId));
								//|| (String.IsNullOrEmpty(fn.m_rawId) && fn.m_timestamp.Equals(_new.m_timestamp) && fn.m_parent == null);
							});

						//if (String.IsNullOrEmpty(_old.m_rawId) && _old.m_parent!=null) _old = _old.m_parent;
					}
				}
				catch { }
				if (_old == null)
				{
					cache_fnl.Add(_new);
					return _new;
				}
				else
				{
					//this.Add(_old);

					return _old;
				}
			}
		}


		//Változók
		private caSubCommItemObjectList m_ciol = new caSubCommItemObjectList();
		caCommFlowNodeList m_flowRoots = new caCommFlowNodeList();

		private caCommFlowTimeMode m_timeMode = caCommFlowTimeMode.Day;
		private caCommFlowNodeType m_nodeMode = caCommFlowNodeType.CommItemNode;
		private int m_smallGrid = 10;
		private int m_bigGrid = 20;

		private float m_Margin = 20;

		private Bitmap m_Bitmap;
		private Graphics m_Graphics;

		private object m_selected = null;



		//Propertyk
		//Kommunikációs modell propertyje
		public caSubCommItemObjectList CommList
		{
			get { return m_ciol; }
			set { m_ciol = value; }
		}

		//Időmód beállítása
		public caCommFlowTimeMode TimeMode
		{
			get { return m_timeMode; }
			set
			{
				m_timeMode = value;
				cb_timemode.SelectedValue = m_timeMode;
				m_smallGrid = caCommFlowNode.SmallScale(m_timeMode);
				m_bigGrid = caCommFlowNode.BigScale(m_timeMode);
			}
		}

		//Csomópont mód
		public caCommFlowNodeType NodeMode
		{
			get { return m_nodeMode; }
			set
			{
				m_nodeMode = value;
				cb_nodemode.SelectedValue = m_nodeMode;
			}
		}

		//Konstruktor
		public caCommFlow()
		{
			InitializeComponent();

			//Time Mode-ok beállítása a vezértlőkön
			caGlobalListItem glMin = new caGlobalListItem("Minutes", caCommFlowTimeMode.Minute);
			caGlobalListItem glHour = new caGlobalListItem("Hours", caCommFlowTimeMode.Hour);
			caGlobalListItem glDay = new caGlobalListItem("Days", caCommFlowTimeMode.Day);
			caGlobalListItem glWeek = new caGlobalListItem("Weeks", caCommFlowTimeMode.Week);
			caGlobalListItem glMonth = new caGlobalListItem("Months", caCommFlowTimeMode.Month);
			caGlobalListItem glDT = new caGlobalListItem("Date List", caCommFlowTimeMode.DateList);

			caGlobalList glZoom = new caGlobalList();
			glZoom.Add(glMin);
			glZoom.Add(glHour);
			glZoom.Add(glDay);
			glZoom.Add(glWeek);
			glZoom.Add(glMonth);
			glZoom.Add(glDT);

			cb_timemode.DataSource = glZoom;
			cb_timemode.DisplayMember = "Display";
			cb_timemode.ValueMember = "Value";

			//Alapértelmezésben a dátumlista
			TimeMode = caCommFlowTimeMode.DateList;

			//Node MOde
			caGlobalListItem glPar = new caGlobalListItem("Participant", caCommFlowNodeType.ParticipantNode);
			caGlobalListItem glComm = new caGlobalListItem("Communication Item", caCommFlowNodeType.CommItemNode);

			caGlobalList glNode = new caGlobalList();
			glNode.Add(glPar);
			glNode.Add(glComm);

			cb_nodemode.DataSource = glNode;
			cb_nodemode.DisplayMember = "Display";
			cb_nodemode.ValueMember = "Value";

			//Alapértelmezésben üzenetek
			NodeMode = caCommFlowNodeType.CommItemNode;

			GenerateGraph();


		}

		//Gráf generálása kommunikációs modellből
		public void GenerateGraph()
		{
			//Dátum szerint rendezve
			/*_cl.Sort(
				delegate(caCommItemObject c1, caCommItemObject c2)
				{
					return c1.m_sentDate.CompareTo(c2.m_sentDate);
				});

			*/

			m_flowRoots.Clear();
			caCommFlowNodeList.cache_fnl.Clear();

			if (NodeMode == caCommFlowNodeType.ParticipantNode) //Résztvevők megjelenítése mód
			{
				//MInden modellelemen végigmegyünk
				foreach (caSubCommItemObject ci in m_ciol)
				{
					caCommFlowNode fromNode = new caCommFlowNode()
					{
						RawId = ci.m_previousCommId,
						m_participant = ci.m_fromParticipant,
						TimeStamp = ci.m_sentTime,
						m_nodeType = NodeMode
					};
					//szlő hozzáadás vagy kikeresése a cache-ből
					caCommFlowNode toParentNode = m_flowRoots.AddIdentical(fromNode);
					//Ha létezik, akkor visszaadjuk azt, ha nem, akkor felvesszük gyökérbe és azt
					if (fromNode.GetHashCode() == toParentNode.GetHashCode()) //Szülő újonnan lett felvéve, mert ugyanaz jött vissza
					{
						m_flowRoots.Add(toParentNode);
					}


					//Gyerekként hozzáadni a másikat
					caCommFlowNode toNode = new caCommFlowNode()
					{
						RawId = ci.m_commId,
						m_participant = ci.m_toParticipant,
						TimeStamp = ci.m_receivedTime,
						m_parent = toParentNode,
						m_nodeType = NodeMode
					};

					//Gyerek felvételel a cache-be 
					m_flowRoots.AddIdentical(toNode);
					toParentNode.m_children.Add(toNode);
				}
			}
			else if (NodeMode == caCommFlowNodeType.CommItemNode) //Levelek megjelenítése mód
			{
				foreach (caSubCommItemObject ci in m_ciol)
				{
					//szülő node
					caCommFlowNode parentNode = new caCommFlowNode()
					{
						RawId = ci.m_previousCommId,
						m_nodeType = NodeMode,
						m_participant = null,
						TimeStamp = ci.m_sentTime
					};

					//szülő hozzáadás vagy kikeresése a cache-ből
					caCommFlowNode realParentNode = m_flowRoots.AddIdentical(parentNode);
					//Ha létezik, akkor visszaadjuk azt, ha nem, akkor felvesszük gyökérbe és azt
					if (parentNode.GetHashCode() == realParentNode.GetHashCode()) //Szülő újonnan lett felvéve, mert ugyanaz jött vissza
					{
						m_flowRoots.Add(realParentNode);
					}


					//Gyerekként hozzáadni a másikat
					caCommFlowNode actualNode = new caCommFlowNode()
					{
						RawId = ci.m_commId,
						m_nodeType = NodeMode,
						m_participant = ci.m_fromParticipant,
						TimeStamp = ci.m_sentTime
					};

					//Gyerek felvételel a cache-be, csak egyszer
					caCommFlowNode realActualNode = m_flowRoots.AddIdentical(actualNode);
					realParentNode.m_children.Add(realActualNode);
				}
			}

			//Dátumlista rendezése
			caCommFlowNode.timeList.Sort(
				delegate(caCommFlowNodeTimeListItem t1, caCommFlowNodeTimeListItem t2)
				{
					return t1.m_timestamp.CompareTo(t2.m_timestamp);
				});
		}

		//Gráf kirajzolása
		public void DrawGraph()
		{
			//TODO: vászonra rajzolni és azt kitenni
			Pen penBlack = new Pen(Color.Black, 2);
			Pen penGray = new Pen(Color.Gray, 1);
			Pen penRed = new Pen(Color.Red, 2);


			//Rácsozás beállítása
			if (m_flowRoots.Count > 0)
			{
				//Alapértékek
				int textMargin = 20;
				int width = -1;
				int height = -1;

				//------- SZÉLESSÉG: Teljes időbeni eltérés számítása
				TimeSpan delta = caCommFlowNode.maxDate - caCommFlowNode.minDate;
				double deltaByZoom = 0;
				switch (TimeMode)
				{
					case caCommFlowTimeMode.Minute:
						deltaByZoom = delta.TotalMinutes;
						break;
					case caCommFlowTimeMode.Hour:
						deltaByZoom = delta.TotalHours;
						break;
					case caCommFlowTimeMode.Day:
						deltaByZoom = delta.TotalDays;
						break;
					case caCommFlowTimeMode.Week:
						deltaByZoom = delta.TotalDays / 7;
						break;
					case caCommFlowTimeMode.Month:
						deltaByZoom = delta.TotalDays / 30;
						break;
					case caCommFlowTimeMode.DateList:
						deltaByZoom = caCommFlowNode.timeList.Count;
						int x = 0;
						foreach (caCommFlowNodeTimeListItem t in caCommFlowNode.timeList)
						{
							t.m_left = x;
							x += m_smallGrid + t.m_nodeCount * 2;
						}

						break;
					//Datetimelist
					default:
						break;
				}
				width = (int)(deltaByZoom * m_smallGrid + m_Margin * 2);


				//-------- MAGASSÁG: Node-ok pontjainak számítása
				float y = (textMargin + m_Margin);
				foreach (caCommFlowNode froot in m_flowRoots)
				{
					y += froot.SetPositionsAndGetNewY(y, TimeMode, 0);
				}
				height = (int)(y + textMargin + m_Margin * 2);



				// -------- Vászon beállítása
				myCanvas.Width = width + 100;
				myCanvas.Height = height;

				//Image m_i = new Image();
				//m_Bitmap = new Bitmap(width, height);
				//m_Graphics = Graphics.FromImage(m_Bitmap);

				m_Graphics = myCanvas.CreateGraphics();
				m_Graphics.Clear(Color.White);

				//Számegyenes sarokszámai
				float rulerStartX = m_Margin / 2;
				float rulerStartY = textMargin + m_Margin / 2;

				float rulerStopX = width - m_Margin / 2;
				float rulerStopY = height - m_Margin / 2;

				if (TimeMode != caCommFlowTimeMode.DateList) //Dátum arányos nézet
				{
					//Számegyenes kirajzolása Skálázva
					m_Graphics.DrawLine(penBlack, new PointF(rulerStartX, rulerStartY), new PointF(rulerStopX, rulerStartY));
					for (int i = (int)rulerStartX; i < (int)rulerStopX; i += m_smallGrid)
					{
						if ((i - (int)rulerStartX) % m_bigGrid == 0) // Bonyolutltab heti logika is beépíthető
						{ // Nagy vonal rajzolása
							m_Graphics.DrawLine(penRed, new PointF(i, rulerStartY), new PointF(i, rulerStopY));
						}
						else
						{ // Kis vonal rajzolása
							m_Graphics.DrawLine(penGray, new PointF(i, rulerStartY), new PointF(i, rulerStopY));
						}
					}
				}
				else //Dátum Lista nézet
				{
					//Számegyenes kirajzolása lista alapján
					m_Graphics.DrawLine(penBlack, new PointF(rulerStartX, rulerStartY), new PointF(rulerStopX, rulerStartY));
					foreach (caCommFlowNodeTimeListItem t in caCommFlowNode.timeList)
					{
						Font drawFont = new Font("Arial", 12);
						SolidBrush drawBrush = new SolidBrush(Color.Black);

						m_Graphics.DrawString(t.m_timestamp.ToString(), drawFont, drawBrush, new PointF(t.m_left, 0));
						m_Graphics.DrawLine(penRed, new PointF(t.m_left, rulerStartY), new PointF(t.m_left, rulerStopY));
					}


				}


				//Node-ok kirajzolása
				foreach (caCommFlowNode froot in m_flowRoots)
				{
					froot.DrawAll(m_Graphics, penRed, Brushes.Black);
				}

			}
			//myCanvas.Image = m_Bitmap;
		}

		//Újrarajzolás
		public void RepaintGraph()
		{
			//TODO: csak canvas újrarajzolás kellene
			//myCanvas.Image = m_Bitmap;
			//myCanvas.Update();
			//myCanvas.Refresh();
			DrawGraph();
		}

		//Átállás az új időábrázolási módra
		private void cb_zoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			object v = cb_timemode.SelectedValue;
			if (v != null && v.GetType() == typeof(caCommFlowTimeMode)) TimeMode = (caCommFlowTimeMode)cb_timemode.SelectedValue;

			DrawGraph();
		}

		//Csúszka mozgatás - ájtrarajzolás
		private void scroll_panel_Paint(object sender, PaintEventArgs e)
		{
			RepaintGraph();
		}

		private void scroll_panel_Scroll(object sender, ScrollEventArgs e)
		{
			RepaintGraph();
		}

		private void caCommFlow_Paint(object sender, PaintEventArgs e)
		{
			RepaintGraph();
		}

		private void scroll_panel_Resize(object sender, EventArgs e)
		{
			RepaintGraph();
		}

		private void scroll_panel_SizeChanged(object sender, EventArgs e)
		{
			RepaintGraph();
		}

		private void myCanvas_Paint(object sender, PaintEventArgs e)
		{
			RepaintGraph();
		}

		//Egér események figyelése -> melyik node van a kurzor alatt
		private void myCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			m_selected = null;
			foreach (caCommFlowNode fn in caCommFlowNodeList.cache_fnl)
			{
				if (fn.HitTest(e.X, e.Y))
				{
					m_selected = fn;

					//Kiírni az idikátor szövegdobozba a nevét
					if (fn.m_nodeType == caCommFlowNodeType.ParticipantNode)
					{
						lb_info.Text = fn.m_participant.m_name + " - " + fn.m_timestamp.ToString();
					}
					else
					{
						lb_info.Text = fn.RawId + " - " + fn.m_timestamp.ToString();
					}
					break;
				}
			}
		}

		//CSomópont mgejelnítés váltása listából
		private void cb_nodemode_SelectedIndexChanged(object sender, EventArgs e)
		{
			object v = cb_nodemode.SelectedValue;
			if (v != null && v.GetType() == typeof(caCommFlowNodeType)) NodeMode = (caCommFlowNodeType)cb_nodemode.SelectedValue;
			GenerateGraph();
			DrawGraph();
		}
	}
}
