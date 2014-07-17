using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AsanaNet;

namespace AsanaCrescent
{
    static class Parser
    {
        public static string ParseStory(AsanaStory story, string s)
        {    
            return story.Text.LastIndexOf(s) != -1 ? story.CreatedAt.ToString() : null;
        }

        public static string[] ParseStories(ArrayList stories, ArrayList columns)
        {
            string[] data = new string[columns.Count];
            // get date data (excluding columns "Task" and "Project")
            for (int i = 2; i<columns.Count; i++)
            {
                string col = (string) columns[i];
                AsanaStory LastStory = null;
                foreach (AsanaStory story in stories)
                {
                    if (story.Text.LastIndexOf("to " + col) != -1)
                        LastStory = story;
                }
                if (LastStory != null)
                    data[i] = LastStory.CreatedAt.ToString();
                else data[i] = null;
            }
            return data;
        }

        public static string[] ParseSubProjects(ArrayList tasks)
        {
            ArrayList subprojects = new ArrayList();
            foreach(var o in tasks)
            {
                AsanaTask task = o as AsanaTask;
                if(task.Name.EndsWith(":")) 
                {
                    subprojects.Add(task.Name);
                }
            }
            return (string[]) subprojects.ToArray( typeof( string ) );
        }
    }
}
