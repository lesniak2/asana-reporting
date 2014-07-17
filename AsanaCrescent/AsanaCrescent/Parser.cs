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

        public static string[] ParseSubProjects(ArrayList tasks)
        {
            ArrayList subprojects = new ArrayList();
            foreach(var o in tasks)
            {
                AsanaTask task = o as AsanaTask;
                if(task.Name.EndsWith(':')) 
                {
                    subprojects.Add(task.Name);
                }
            }
            return (string[]) subprojects.ToArray();
        }
    }
}
