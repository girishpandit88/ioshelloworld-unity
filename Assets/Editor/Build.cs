﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public static class AutoBuilder {

	static string GetProjectName()
	{
		string[] s = Application.dataPath.Split('/');
		return s[s.Length - 2];
	}
	
	static string[] GetScenePaths()
	{
		string[] scenes = {"Assets/BasicCube.unity"};

		//for(int i = 0; i < scenes.Length; i++)
		//{
	//		scenes[i] = EditorBuildSettings.scenes[i].path;
	//	}
		
		return scenes;
	}
	
	[MenuItem("File/AutoBuilder/iOS")]
	static void PerformiOSBuild ()
	{
		PlayerSettings.productName= "iosBasic";
		PlayerSettings.bundleIdentifier = "com.ea.SimpleTextEditor";
		PlayerSettings.bundleVersion = "1.0";
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.iPhone);
		string error = BuildPipeline.BuildPlayer(GetScenePaths(), "BuildiOS/app",BuildTarget.iPhone,BuildOptions.None);
		if (error != null && error.Length > 0) {
            throw new Exception("Build failed: " + error);
        }
	}
	
	
}


