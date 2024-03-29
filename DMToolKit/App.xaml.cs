﻿using DMToolKit.Services;
using DMToolKit.Data;

namespace DMToolKit;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		DataController DataController = DataController.Instance;

        if (DataController.NameData is null)
            DataController.NameData = new NameData(true);
		if (DataController.NPCData is null)
			DataController.NPCData = new NPCData(true);
		if(DataController.NameSeedData is null)
			DataController.NameSeedData= new NameSeedData(true);

		DataController.LoadNPCData();
		DataController.LoadNameData();
		DataController.LoadNameSeedData();
    }
}
