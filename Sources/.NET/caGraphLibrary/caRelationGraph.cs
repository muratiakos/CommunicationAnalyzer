using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;
using caCoreLibrary;

namespace caGraphLibrary
{
	public partial class caRelationGraph : UserControl
	{
		Graph m_graph;

		caGraphGleeColorService m_colorService = new caGraphGleeColorService();

		//ContextMenu cm = new ContextMenu();
		ToolTip myTip = new ToolTip();
		object selectedObjectAttr;
		object selectedObject;

		public caSubCommItemObjectList m_commItemObjectList = new caSubCommItemObjectList();


		public bool ShowDirection { get; set; }
		double totalCount;


		public void DisplayAllNodeAs(caRelationGraphNodeTypeDisplayMode mode)
		{
			switch (mode)
			{
				case caRelationGraphNodeTypeDisplayMode.UsersOnly:
				case caRelationGraphNodeTypeDisplayMode.GroupsOnly:
					foreach (caSubCommItemObject ci in m_commItemObjectList)
					{
						caParticipantType cpt = caParticipantType.User;
						if (mode == caRelationGraphNodeTypeDisplayMode.GroupsOnly) cpt = caParticipantType.Group;
						//caParticipantObject.ShowAs(ci.m_fromParticipant, cpt);
						//caParticipantObject.ShowAs(ci.m_toParticipant, cpt);
						ci.m_fromParticipant.ShowAs(cpt);
						ci.m_toParticipant.ShowAs(cpt);
					}
					break;
				case caRelationGraphNodeTypeDisplayMode.Both:
				default:
					break;
			}

			createGraph();
		}

		private void FormatNodePair(caIndirectRelation r)
		{
			Node src = m_graph.FindNode(r.srcID) as Node;
			Node dst = m_graph.FindNode(r.dstID) as Node;

			src.UserData = r.srcObject;
			dst.UserData = r.dstObject;

			src.Attr.Label = r.srcLabel;
			dst.Attr.Label = r.dstLabel;

			switch (r.getRelationType)
			{
				case caIndirectRelation.caRelationType.UserToUser:
					caNodeFormat.FormatAsUser(src, m_colorService);
					caNodeFormat.FormatAsUser(dst, m_colorService);
					break;
				case caIndirectRelation.caRelationType.UserToGroup:
					caNodeFormat.FormatAsUser(src, m_colorService);
					caNodeFormat.FormatAsGroup(dst, m_colorService);
					break;
				case caIndirectRelation.caRelationType.GroupToUser:
					caNodeFormat.FormatAsGroup(src, m_colorService);
					caNodeFormat.FormatAsUser(dst, m_colorService);
					break;
				case caIndirectRelation.caRelationType.GroupToGroup:
					caNodeFormat.FormatAsGroup(src, m_colorService);
					caNodeFormat.FormatAsGroup(dst, m_colorService);
					break;
			}
		}

		private void FormatEdge(Edge v)
		{
			v.EdgeAttr.Label = v.UserData.ToString();
			double d = Convert.ToDouble(v.EdgeAttr.Label) / totalCount;
			v.EdgeAttr.LineWidth = (int)(1 + 17 * d); // *2; - ARányos vastagítás kell

			if (ShowDirection)
				v.EdgeAttr.ArrowHeadAtTarget = ArrowStyle.Normal;
			else
				v.EdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;

		}

		private MenuItem CreateUserMenuItem(Object u, String Text)
		{
			MenuItem mu = new MenuItem();

			mu.Tag = u;
			mu.Text = Text;
			mu.Click += new EventHandler(groupMenuClick);

			return mu;

		}

		public void createGraph()
		{
			totalCount = 0;
			m_graph = new Graph("kapcsolatihalo");
			m_graph.GraphAttr.NodeAttr.Padding = 2;

			//			int sum_times = m_commItemObjectList.Sum(
			m_colorService = new caGraphGleeColorService();
			//int count = 0;

			//SimaCOmmItemListből Object List

			//Végigbogarászás
			foreach (caSubCommItemObject cio in m_commItemObjectList)
			{
				//count ++;
				List<caIndirectRelation> ir = caIndirectRelation.getIndirectRelation(cio.m_fromParticipant, cio.m_toParticipant);

				foreach (caIndirectRelation r in ir)
				{
					//Felépítendő, vagy frissítendő él
					Edge v = null;

					try
					{
						//g.Directed = ShowDirection;

						if (ShowDirection)
						{
							var vk = from e in m_graph.Edges
									 where e.SourceNode.Attr.Id == r.srcID && e.TargetNode.Attr.Id == r.dstID
									 select e;

							v = vk.First<Edge>();
						}
						else
						{
							var vk = from e in m_graph.Edges
									 where
										(e.SourceNode.Attr.Id == r.srcID && e.TargetNode.Attr.Id == r.dstID) ||
										(e.SourceNode.Attr.Id == r.dstID && e.TargetNode.Attr.Id == r.srcID)
									 select e;
							v = vk.First<Edge>();
						}
					}
					catch
					{
						//Még nem létezik a keresett él, v=null, így fel kell venni
					}


					if (v == null)
					{
						v = m_graph.AddEdge(r.srcID, r.dstID);
					}

					if (v.UserData == null) v.UserData = 0;

					v.UserData = (int)v.UserData + cio.m_times;
					totalCount += cio.m_times;

					//TODO: kiíró motort frissíteni ki-ki: db és összesen db

					FormatEdge(v);
					FormatNodePair(r);
				}

			}

			//Élek utóformázása
			foreach (Edge e in m_graph.Edges) FormatEdge(e);

			gViewer.Graph = m_graph;
		}
		public caRelationGraph()
		{
			InitializeComponent();
			ShowDirection = true;

			this.myTip.Active = true;
			myTip.AutoPopDelay = 5000;
			myTip.InitialDelay = 1000;
			myTip.ReshowDelay = 500;

			//this.gViewer.ContextMenu = cm;

			gViewer.SelectionChanged += new EventHandler(gViewer_SelectionChanged);
			gViewer.MouseClick += new MouseEventHandler(gViewer_MouseClick);
		}

		void gViewer_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				if (selectedObject != null)
				{
					Object so = null;
					switch (selectedObject.GetType().Name)
					{
						case "Node":
							so = ((Node)selectedObject).UserData;
							break;
						case "Edge":
							so = ((Edge)selectedObject).UserData;
							break;
					}

					if (so != null)
					{
						ContextMenu cm = new ContextMenu();
						switch (((caParticipantObject)so).m_type)
						{
							case caParticipantType.User:
								caParticipantObject u = ((caParticipantObject)so);

								MenuItem mu = CreateUserMenuItem(u, u.m_name + " (" + u.m_participantId + ")");
								mu.MenuItems.Add(CreateUserMenuItem("show-info", "Show User Info"));
								mu.MenuItems.Add(CreateUserMenuItem("show-asG", "Show as Group Member"));

								cm.MenuItems.Add(mu);
								cm.Show(gViewer, e.Location);
								break;
							case caParticipantType.Group:
								caParticipantObject g = ((caParticipantObject)so);
								//MessageBox.Show(g.members.Count.ToString());

								//cm.MenuItems.Clear();
								foreach (caParticipantObject uig in g.MemberList)
								{
									MenuItem muig = CreateUserMenuItem(uig, uig.m_name + " (" + uig.m_participantId + ")");
									muig.MenuItems.Add(CreateUserMenuItem("show-info", "Show User Info"));
									muig.MenuItems.Add(CreateUserMenuItem("show-asU", "Show as Individual User"));

									cm.MenuItems.Add(muig);
								}
								cm.Show(gViewer, e.Location);
								break;
						}
					}
				}
		}

		void groupMenuClick(object sender, EventArgs e)
		{
			MenuItem actual = (MenuItem)sender;

			switch (actual.Tag.GetType().Name)
			{
				case "caParticipantObject":

					break;
				case "String":
					String code = (String)actual.Tag;
					caParticipantObject u = (caParticipantObject)actual.Parent.Tag;

					switch (code)
					{
						case "show-asG":
							u.ShowAs(caParticipantType.Group);
							//caParticipantObject.ShowAs(u,caParticipantType.Group);
							createGraph();
							break;

						case "show-asU":
							u.ShowAs(caParticipantType.User);
							//caParticipantObject.ShowAs(u, caParticipantType.User);
							createGraph();
							break;

						case "show-info":
							MessageBox.Show(u.m_showAs.ToString());
							break;
					}
					break;
			}

			//createGraph();

		}

		void gViewer_SelectionChanged(object sender, EventArgs e)
		{

			if (selectedObject != null)
			{
				if (selectedObject is Edge)
				{
					FormatEdge((Edge)selectedObject);
					(selectedObject as Edge).Attr = selectedObjectAttr as EdgeAttr;
				}
				else if (selectedObject is Node)
					(selectedObject as Node).Attr = selectedObjectAttr as NodeAttr;

				selectedObject = null;
			}

			if (gViewer.SelectedObject == null)
			{
				mutat.Text = "No object under the mouse";
				this.gViewer.SetToolTip(myTip, "");
			}
			else
			{
				selectedObject = gViewer.SelectedObject;
				mutat.Text = "";
				if (selectedObject is Edge)
				{
					selectedObjectAttr = (gViewer.SelectedObject as Edge).Attr.Clone();
					(gViewer.SelectedObject as Edge).Attr.Color = Microsoft.Glee.Drawing.Color.Red;
					(gViewer.SelectedObject as Edge).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Red;
					Edge edge = gViewer.SelectedObject as Edge;


					mutat.Text = edge.UserData.ToString(); //String.Format("{1} - {2} : {0}", (int)edge.UserData, edge.Source, edge.Target);
					this.gViewer.SetToolTip(this.myTip, mutat.Text);

				}
				else if (selectedObject is Node)
				{
					selectedObjectAttr = (gViewer.SelectedObject as Node).Attr.Clone();
					(selectedObject as Node).Attr.Color = Microsoft.Glee.Drawing.Color.Red;
					(selectedObject as Node).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Red;
					

					caParticipantObject po = (caParticipantObject)(selectedObject as Node).UserData;
					mutat.Text =(selectedObject as Node).Attr.Label;
					this.gViewer.SetToolTip(myTip, po.ToString());
				}
				//mutat.Text = selectedObject.ToString();
			}
			gViewer.Invalidate();
		}

		private void gViewer_Load(object sender, EventArgs e)
		{

		}

		private void emaRelationGraph_Load(object sender, EventArgs e)
		{

		}


	}
}
