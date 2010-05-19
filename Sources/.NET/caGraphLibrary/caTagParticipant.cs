using System;
using Microsoft.Glee.Drawing;
using caCoreLibrary;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


namespace caGraphLibrary
{
	public partial class caTagParticipant : UserControl
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

		public caTagParticipant()
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

		private void FormatParticipantTagNode(caIndirectRelation r, string _tag)
		{
			Node src = m_graph.FindNode(r.srcID) as Node;
			Node dst = m_graph.FindNode(r.dstID) as Node;
			Node tag = m_graph.FindNode(_tag) as Node;

			src.UserData = r.srcObject;
			dst.UserData = r.dstObject;
			tag.UserData = _tag;

			src.Attr.Label = r.srcLabel;
			dst.Attr.Label = r.dstLabel;
			tag.Attr.Label = _tag;

			caNodeFormat.FormatAsTag(tag, m_colorService);

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
			int w = 0;
			if (totalCount > 20) w = (int)(1 + 17 * d);
			else w = (int)(1 + 10 * d);

			v.EdgeAttr.LineWidth = (int)(1 + 17 * d); // *2; - ARányos vastagítás kell

			if (ShowDirection)
				v.EdgeAttr.ArrowHeadAtTarget = ArrowStyle.Normal;
			else
				v.EdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;

		}

		private Edge AddEdge(string src, string dst, int times)
		{
			//Felépítendő, vagy frissítendő él
			Edge v = null;

			try
			{
				if (ShowDirection)
				{
					var vk = from e in m_graph.Edges
							 where e.SourceNode.Attr.Id == src && e.TargetNode.Attr.Id == dst
							 select e;

					v = vk.First<Edge>();
				}
				else
				{
					var vk = from e in m_graph.Edges
							 where
								(e.SourceNode.Attr.Id == src && e.TargetNode.Attr.Id == dst) ||
								(e.SourceNode.Attr.Id == dst && e.TargetNode.Attr.Id == src)
							 select e;
					v = vk.First<Edge>();
				}
			}
			catch { }


			if (v == null) //Még nem létezik a keresett él, v=null, így fel kell venni
			{
				v = m_graph.AddEdge(src, dst);
			}

			if (v.UserData == null) v.UserData = 0;

			v.UserData = (int)v.UserData + times;
			return v;
		}

		public void createGraph()
		{
			totalCount = 0;
			m_graph = new Graph("tag-participant-relation");
			m_graph.GraphAttr.NodeAttr.Padding = 2;

			//			int sum_times = m_commItemObjectList.Sum(
			m_colorService = new caGraphGleeColorService();

			//Végigbogarászás
			foreach (caSubCommItemObject cio in m_commItemObjectList)
			{
				//Két résztvevő közötti kapcsolat
				List<caIndirectRelation> ir = caIndirectRelation.getIndirectRelation(cio.m_fromParticipant, cio.m_toParticipant);


				foreach (caIndirectRelation r in ir)
				{
					totalCount += cio.m_times;
					Edge tto = AddEdge(r.srcID, cio.m_threadId, cio.m_times);
					FormatEdge(tto);

					Edge tfrom = AddEdge(cio.m_threadId, r.dstID, cio.m_times);
					FormatEdge(tfrom);

					FormatParticipantTagNode(r, cio.m_threadId);
				}

			}

			//Élek utóformázása
			foreach (Edge e in m_graph.Edges) FormatEdge(e);
			gViewer.Graph = m_graph;
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
						try
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
						catch { }
					}
				}
		}
		private MenuItem CreateUserMenuItem(Object u, String Text)
		{
			MenuItem mu = new MenuItem();

			mu.Tag = u;
			mu.Text = Text;
			mu.Click += new EventHandler(groupMenuClick);

			return mu;

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


					string tip = (selectedObject as Node).Attr.Label;
					mutat.Text = tip;
					try
					{
						caParticipantObject po = (caParticipantObject)(selectedObject as Node).UserData;
						tip = po.ToString();
					}
					catch { }
					this.gViewer.SetToolTip(myTip, tip);
				}
				//mutat.Text = selectedObject.ToString();
			}
			gViewer.Invalidate();
		}

	}
}
