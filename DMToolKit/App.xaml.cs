﻿using DMToolKit.Services;

namespace DMToolKit;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        if (DataController.NameData is null)
            DataController.NameData = new NameData();
		if (DataController.NPCData is null)
			DataController.NPCData = new NPCData();
		if(DataController.NameConstructionData is null)
			DataController.NameConstructionData= new NameConstructionData();

		DataController.LoadNPCData();
		DataController.LoadNameData();
		DataController.LoadNameConstructionData();
    }
}
