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
       /* static string[] tags = {"P2", "s2", "p1", "s1", "Interrupted Business", "corpchannel", "P3",
                                "2012 enhancements", "ADSU BI", "ccad", "S3", "[support]", "bau", "bug",
                                "call center", "medium", "platform maintenance", "retail"};*/
        public static string ParseStory(AsanaStory story, string s)
        {    
            return story.Text.LastIndexOf(s) != -1 ? story.CreatedAt.ToString() : null;
        }

        public static string[] ParseStories(ArrayList stories, string[] tags, string[] columns, string proj)
        {
            int valid = 0;
            for (int i = 0; columns[i] != null; i++)
                valid++;

            string[] data = new string[valid];
                // get data excluding task name 
                for (int i = 1; i < columns.Length; i++)
                {
                    string col = (string)columns[i];
                    if (col != null)
                    {

                        switch (col)
                        {
                            case "Added To Project":
                                data[i] = findDate(stories, proj);
                                break;
                            case "Due":
                                data[i] = findDate(stories,"changed the due date to");
                                break;
                            case "Completed":
                                data[i] = findDate(stories, "completed this task");
                                break;
                            case "Assignee":
                                data[i] = findAssignee(stories);
                                break;
                            case "Tags":
                                data[i] = findTags(stories, tags);
                                break;
                            case "Project":
                                data[i] = proj;
                                break;
                            default:
                                data[i] = findDate(stories, "to " + col);
                                break;
                        }
                    }
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

        private static string findDate(ArrayList stories, string s)
        {
            AsanaStory LastStory = null;
            foreach (AsanaStory story in stories)
            {
                if (story.Text.Contains(s))
                    LastStory = story;
            }
            if (LastStory != null)
                return LastStory.CreatedAt.ToString();
            else return null;
        }

        private static string findSection(ArrayList stories, string s)
        {
            AsanaStory LastStory = null;
            foreach (AsanaStory story in stories)
            {
                if (story.Text.LastIndexOf("to " + s) != -1)
                    LastStory = story;
            }
            if (LastStory != null)
                return LastStory.CreatedAt.ToString();
            else return null;
        }
        private static string findCreated(ArrayList stories, string s)
        {
            foreach(AsanaStory story in stories)
            {
                if (story.Text.IndexOf(s) != -1)
                    return story.CreatedAt.ToString();
            }
            return null;
        }
        private static string findTags(ArrayList stories, string[] tags)
        {
            string d = "";
            foreach (AsanaStory story in stories)
            {
                foreach(string tag in tags) 
                {
                    string t = "added to " + tag;
                    if (story.Text.Contains(t) && story.Text.Length == story.Text.IndexOf(t) + t.Length)
                    {
                        d += tag + ", ";
                        break;
                    }
                }
            }
            if (d != "")
                return d.Remove(d.Length-2);
            else return null;
        }

        private static string findAssignee(ArrayList stories)
        { 
            string assignee = "";
            foreach (AsanaStory story in stories)
            {
                int index = story.Text.LastIndexOf("assigned to ");
                if (index != -1)
                    assignee = story.Text.Substring(index+12).Replace(".","");
            }
            if (assignee != "")
                return assignee;
            else return null;
        }

    }

}
