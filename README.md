# XBoxSocialApi

## Basic Setup
- Create Definition File (Menu > Assets > Create > Achievements Definition)
- Fill definition data asset with your achievement information, most importantfield is ExternalId (Achievement Id) from XDP Portal.
- Add SocialPro component to Gameobject (There should be only one instance of SocialPro componenet in game)
- Check API example usage from exmaple scene

## Required XBox Native Plugins
You need to add those Native Plugins to use Social Pro XBox:
- ConsoleUtilsImport
- DataPlatformImport
- StorageImport
- TextSystemsImport
- UnityEtx
- UnityPluginLogImport
- UsersImport
- XboxOneCommonImport

## Misc
Featured Stats requires access to [Windows Runtime (IL2CPP)](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)
