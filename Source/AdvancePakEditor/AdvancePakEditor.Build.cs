// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class AdvancePakEditor : ModuleRules
{
	public AdvancePakEditor(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
        PublicIncludePathModuleNames.AddRange(
            new string[] {
                "LauncherServices",
            }
        );


        PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
			});
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Projects",
				"InputCore",
				"UnrealEd",
				"LevelEditor",
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
                "AdvancePak",
                "UATHelper",
                "EditorStyle",
                "TargetPlatform",
                "WorkspaceMenuStructure",
                "PropertyEditor",
                "Json",
                "JsonUtilities",
                "AssetRegistry",
                "DeveloperToolSettings"
			});
		
        PrivateIncludePathModuleNames.AddRange(
        new string[] {
                "OutputLog",
        });
    }
}
