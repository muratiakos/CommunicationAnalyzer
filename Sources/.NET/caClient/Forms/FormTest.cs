using System;
using System.Windows.Forms;

using caCoreLibrary;

namespace caClient.Forms
{
	public partial class FormTest : Form
	{
		public FormTest()
		{
			InitializeComponent();


			caParticipant tmit = new caParticipant("tmit", "TMIT", caParticipantType.Group);
			caParticipant murati = new caParticipant("murati.hu", "murati.hu", caParticipantType.Group);
			caParticipant egyeb = new caParticipant("other", "Egyéb", caParticipantType.Group);

			caParticipant akos = new caParticipant("akos@murati.hu", "Ákos");
			caParticipant rita = new caParticipant("rita", "Rita");
			caParticipant csaba = new caParticipant("csaba", "Csaba");
			caParticipant zsolt = new caParticipant("zsolt", "Zsolt");
			caParticipant jozsi = new caParticipant("jozsi", "Marton");
			caParticipant edit = new caParticipant("edit", "Edit");

			edit.m_groupList.Add(murati);
			edit.m_groupList.Add(egyeb);

			jozsi.m_groupList.Add(tmit);
			zsolt.m_groupList.Add(tmit);

			akos.m_groupList.Add(murati);
			akos.m_groupList.Add(tmit);

			rita.m_groupList.Add(egyeb);

			caSubCommItemList cil = new caSubCommItemList();

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "12312341234",
				m_commId = "0",
				m_toParticipant = rita,
				m_fromParticipant = akos,
				m_subcategory = caCommSubCategory.CC,
				m_sentTime = new DateTime(2006, 11, 20),
				m_receivedTime = new DateTime(2006, 11, 20)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "ms23421g01.2",
				m_commId = "0",
				m_toParticipant = csaba,
				m_fromParticipant = akos,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 20),
				m_receivedTime = new DateTime(2006, 11, 20)
			});


			//Második levél
			cil.Add(new caSubCommItem()
			{
				m_subcommId = "121241234",
				m_commId = "1",
				m_previousCommId = "0",
				m_toParticipant = csaba,
				m_fromParticipant = rita,
				m_subcategory = caCommSubCategory.CC,
				m_sentTime = new DateTime(2006, 11, 22),
				m_receivedTime = new DateTime(2006, 11, 22)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "ms23412g01.2",
				m_commId = "11",
				m_toParticipant = rita,
				m_fromParticipant = akos,
				m_sentTime = new DateTime(2006, 11, 21),
				m_receivedTime = new DateTime(2006, 11, 21)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg213401.2",
				m_commId = "12",
				m_toParticipant = zsolt,
				m_fromParticipant = akos,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 23),
				m_receivedTime = new DateTime(2006, 11, 23)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg011234.2",
				m_commId = "12",
				m_toParticipant = jozsi,
				m_fromParticipant = akos,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 23),
				m_receivedTime = new DateTime(2006, 11, 23)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg01.1242",
				m_commId = "2",
				m_previousCommId = "12",
				m_toParticipant = akos,
				m_fromParticipant = zsolt,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 24),
				m_receivedTime = new DateTime(2006, 11, 24)
			});


			cil.Add(new caSubCommItem()
			{
				m_subcommId = "ms234g01.2",
				m_commId = "2",
				m_previousCommId = "12",
				m_toParticipant = jozsi,
				m_fromParticipant = zsolt,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 24),
				m_receivedTime = new DateTime(2006, 11, 24)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "ms1234g01.2",
				m_commId = "3",
				m_toParticipant = edit,
				m_fromParticipant = edit,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 25),
				m_receivedTime = new DateTime(2006, 11, 25)
			});


			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg011234.2",
				m_commId = "3",
				m_toParticipant = akos,
				m_fromParticipant = edit,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2006, 11, 25),
				m_receivedTime = new DateTime(2006, 11, 25)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg011234.2",
				m_commId = "3",
				m_toParticipant = jozsi,
				m_fromParticipant = edit,
				m_subcategory = caCommSubCategory.TO,

				m_sentTime = new DateTime(2006, 11, 25),
				m_receivedTime = new DateTime(2006, 11, 25)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg01.2342",
				m_commId = "4",
				m_previousCommId = "3",
				m_toParticipant = akos,
				m_fromParticipant = jozsi,
				m_subcategory = caCommSubCategory.TO,

				m_sentTime = new DateTime(2009, 11, 5, 12, 25, 15),
				m_receivedTime = new DateTime(2009, 11, 5, 12, 30, 13)
			});

			cil.Add(new caSubCommItem()
			{
				m_subcommId = "msg01.452",
				m_commId = "4",
				m_previousCommId = "3",
				m_toParticipant = zsolt,
				m_fromParticipant = jozsi,
				m_subcategory = caCommSubCategory.TO,
				m_sentTime = new DateTime(2009, 11, 5, 12, 25, 15),
				m_receivedTime = new DateTime(2009, 11, 5, 12, 30, 13)
			});

			//emaRelationGraph1.m_commItemObjectList = caCommItemObjectList.CreateCommItemObjectList(cil);
			//emaRelationGraph1.createGraph();

			//caCommFlow1.NodeMode = caCommFlow.caCommFlowNodeType.CommItemNode;
			//caCommFlow1.TimeMode = caCommFlow.caCommFlowTimeMode.DateList;
			//caCommFlow1.CommList = caSubCommItemObjectList.CreateCommItemObjectList(cil);
			//caCommFlow1.GenerateFlowNodeStruck();

		}
	}
}
