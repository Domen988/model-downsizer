using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Model_Downsizer
{
    public class copyClass
    {
        // method for copying folders.
        public void copyFolder(string sourceFolder,
                               string destFolder, 
                               DataTable influenceTable, 
                               Dictionary<String, List<String>> directoriesDict, 
                               Dictionary<String, List<String>> filesDict)
        {
            if (!Directory.Exists(destFolder))                                        // overwrites automatically. 
                Directory.CreateDirectory(destFolder);

            DataRow[] dr;
            string[] files = Directory.GetFiles(sourceFolder);
            string fullPath = sourceFolder.TrimEnd(Path.DirectorySeparatorChar);
            string modelName = Path.GetFileName(fullPath);

            foreach (string file in files)
            {
                string name;
                string dest;
                name = Path.GetFileName(file);
                dest = Path.Combine(destFolder, name);

                dr = influenceTable.Select("folderName = '" + sourceFolder + "'");                   // choose dataRow, if it exists

                if (dr.Length != 0)
                {
                    if ((int)dr[0]["filesMode"] == 0)
                        File.Copy(file, dest, true);                                                 // true added for overwrite      
                    if ((int)dr[0]["filesMode"] == 1)
                    {
                        List<string> test = filesDict[sourceFolder];

                        if (test.Contains("last model db")                                           // special case "only last model db"
                            &&                                                                       // copies only last <model name>.db1 and <model name>.db2
                            (file.EndsWith(".db1") || file.EndsWith(".db2"))                                                   
                            &&                                                                                               
                           (name.Substring(0, (name.IndexOf("."))) == modelName))
                        {
                            File.Copy(file, dest, true);
                            continue;
                        }
                                                                                                     //
                        int index = name.IndexOf(".");                                               // preparation for the next if statement ...
                        if (index > 0)                                                            // IndexOf cant start with 0
                            if (test.Contains(name.Substring(name.IndexOf(".")).Trim()))             // copies files based on extensions, from the first dot on (eg.: .db1.bak)
                                File.Copy(file, dest, true);
                        if (test.Contains(name))                                                     // copies files based on names                
                            File.Copy(file, dest, true);
                    }
                    if ((int)dr[0]["filesMode"] == 2)                                                                               
                    {
                        List<string> test = filesDict[sourceFolder];
                        if (test.Contains(".bak") && file.EndsWith(".bak"))
                            continue;
                        if (test.Contains("old model db")                                            // special case "old model db"
                            && (file.EndsWith(".db1")                                                // copies only the last verison of <model>.db1, <model>.db2, <model>.db1.bak, <model>.db2.bak
                            || file.EndsWith(".db2")                                              
                            || file.EndsWith(".db1.bak")                                          
                            || file.EndsWith(".db2.bak"))                                         
                            &&                                                                    
                           (name.Substring(0, (name.IndexOf("."))) != modelName
                           && name.Substring(0, (name.IndexOf("."))) != "xslib"))
                        {
                            continue;
                        }
                        if (test.Contains(name))                                                    // checks names
                            continue;
                        if (name.Contains("."))                                                     // checks extensions
                            if (test.Contains(name.Remove(0, name.IndexOf("."))))
                                continue;
                        File.Copy(file, dest, true);                                                // if no if statement is true, copy
                    }
                }
                else
                {
                    File.Copy(file, dest, true);                                                    // true added to allow overwrite
                }
            }


            // folders
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)                                                       // go folder by folder
            {
                string name;
                string dest; 
                name = Path.GetFileName(folder);
                dest = Path.Combine(destFolder, name);
                dr = influenceTable.Select("folderName = '" + sourceFolder + "'");                   // checks if instance exists in influenceTable
                if (dr.Length != 0)                                                                  // if it does, dr contains sth and is not 0
                {
                    if ((int)dr[0]["directoriesMode"] == 0)                                          // checks for mode
                    {
                        if (!Directory.Exists(dest))
                            Directory.CreateDirectory(dest);
                        copyFolder(folder, dest, influenceTable, directoriesDict, filesDict);
                    }
                    if ((int)dr[0]["directoriesMode"] == 1)                                          // check for mode, if 1:
                    {
                        List<string> test = directoriesDict[sourceFolder];                           // look in directoriesDict dictionary
                        if (test.Contains(name))                                                     //
                        {
                            if (!Directory.Exists(dest))                                             // overwrite, if exists
                                Directory.CreateDirectory(dest);
                            copyFolder(folder, dest, influenceTable, directoriesDict, filesDict);
                        }
                    }
                    if ((int)dr[0]["directoriesMode"] == 2)
                    {
                        List<string> test = directoriesDict[sourceFolder];
                        if (!test.Contains(name))
                        {                                                                            // overwrite, if exists
                            if (!Directory.Exists(dest))
                                Directory.CreateDirectory(dest);
                            copyFolder(folder, dest, influenceTable, directoriesDict, filesDict);
                        }
                    }
                }
                else                                                                                // copies every other folder
                {
                    if (!Directory.Exists(dest))
                        Directory.CreateDirectory(dest);
                    copyFolder(folder, dest, influenceTable, directoriesDict, filesDict);
                }  
            }
        }
    }
}
