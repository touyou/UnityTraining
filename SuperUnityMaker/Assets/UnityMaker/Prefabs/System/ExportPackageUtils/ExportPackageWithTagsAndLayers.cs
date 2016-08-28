using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Linq;

namespace ExportPackageUtils{
	public class ExportPackageWithTagsAndLayers{

		[MenuItem("Assets/ExportPackageWithTagsAndLayers")]

		static void ExportPackage(){

			List<string> assets = new List<string>();
			// Get subdirectories and files in the project directory
			// and convert absolute path to relative path to the project directory.
			assets.AddRange(
				Directory.GetFileSystemEntries(Application.dataPath)
					.Select(x => "Assets/" + x.Substring(Application.dataPath.Length+1))
			);

			// Add TagManager.asset to unitypackage
			assets.Add("ProjectSettings/EditorBuildSettings.asset");
			assets.Add("ProjectSettings/ProjectSettings.asset");
			assets.Add("ProjectSettings/TagManager.asset");

			string packageName = Application.productName;
			string packagePath = packageName + ".unitypackage";

			AssetDatabase.ExportPackage(assets.ToArray(), packagePath,
				ExportPackageOptions.Recurse | ExportPackageOptions.Interactive | 
				ExportPackageOptions.IncludeDependencies
			);
		}
	}
}
