// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class AdvancePakSSL : ModuleRules
{
    public AdvancePakSSL(ReadOnlyTargetRules Target) : base(Target)
    {
		Type = ModuleType.External;

        string OpenSSLPath = Path.Combine(Target.UEThirdPartySourceDirectory, "OpenSSL", "1.1.1t");
        string PlatformSubdir = Target.Platform.ToString();
        string ConfigFolder = (Target.Configuration == UnrealTargetConfiguration.Debug && Target.bDebugBuildsActuallyUseDebugCRT) ? "Debug" : "Release";

        if (Target.Platform == UnrealTargetPlatform.Mac || Target.Platform == UnrealTargetPlatform.IOS)
        {
            PublicIncludePaths.Add(Path.Combine(OpenSSLPath, "Include", PlatformSubdir));

            string LibPath = Path.Combine(OpenSSLPath, "Lib", PlatformSubdir);

            PublicAdditionalLibraries.Add(Path.Combine(LibPath, "libssl.a"));
            PublicAdditionalLibraries.Add(Path.Combine(LibPath, "libcrypto.a"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Our OpenSSL 1.1.1 libraries are built with zlib compression support
            PrivateDependencyModuleNames.Add("zlib");

            string VSVersion = "VS" + Target.WindowsPlatform.GetVisualStudioCompilerVersionName();

            // Add includes
            PublicIncludePaths.Add(Path.Combine(OpenSSLPath, "include", PlatformSubdir, VSVersion));

            // Add Libs
            string LibPath = Path.Combine(OpenSSLPath, "lib", PlatformSubdir, VSVersion, ConfigFolder);

            PublicAdditionalLibraries.Add(Path.Combine(LibPath, "libssl.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(LibPath, "libcrypto.lib"));
            PublicSystemLibraries.Add("crypt32.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            string IncludePath = OpenSSLPath + "/include/Android";
            PublicIncludePaths.Add(IncludePath);
        }
    }
}
