// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class AdvancePak : ModuleRules
{
	public AdvancePak(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
			});
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
                "Json",
                "JsonUtilities",
                "PakFile",
                "HTTP",
                "Sockets",
                "SSL",
                "AdvancePakSSL",
                "RSA"
            });
		
        bool bWithCurl = false;

        if (Target.bBuildEditor)
        {
            PrivateDependencyModuleNames.Add("DesktopPlatform");
        }

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            AddEngineThirdPartyPrivateStaticDependencies(Target, "WinHttp");
            AddEngineThirdPartyPrivateStaticDependencies(Target, "libcurl");
            AddEngineThirdPartyPrivateStaticDependencies(Target, "OpenSSL");

            bWithCurl = true;
        }
        else if (Target.IsInPlatformGroup(UnrealPlatformGroup.Unix) ||
                Target.IsInPlatformGroup(UnrealPlatformGroup.Android))
        {
            AddEngineThirdPartyPrivateStaticDependencies(Target, "libcurl");
            AddEngineThirdPartyPrivateStaticDependencies(Target, "OpenSSL");

            bWithCurl = true;
        }
        else
        {
            PublicDefinitions.Add("WITH_LIBCURL=0");
        }

        if (bWithCurl)
        {
            PublicDefinitions.Add("CURL_ENABLE_DEBUG_CALLBACK=1");
            if (Target.Configuration != UnrealTargetConfiguration.Shipping)
            {
                PublicDefinitions.Add("CURL_ENABLE_NO_TIMEOUTS_OPTION=1");
            }
        }

        if (Target.Platform == UnrealTargetPlatform.IOS || Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicFrameworks.Add("Security");
        }
    }
}
