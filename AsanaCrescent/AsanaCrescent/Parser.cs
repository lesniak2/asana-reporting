using System;
using System.Collections;
using AsanaNet;

namespace AsanaCrescent
{
    /// <summary>
    /// All of the searching for dates within stories happens here. 
    /// </summary>
    static class Parser
    {
        /// <summary>
        /// Looks through the stories for a particular task to find the most recent information
        /// an event occurred in a task.
        /// </summary>
        /// <param name="stories">All of the stories associated with a particular task</param>
        /// <param name="tags">The tags in the workspace that each task may be given</param>
        /// <param name="columns">The data to pull from Asana. Also the columns in the report.</param>
        /// <param name="proj">The current project we are working with.</param>
        /// <returns>An array of data in </returns>
        public static string[] ParseStories(ArrayList stories, string[] tags, string[] columns, string proj)
        {
            // ExcelMaster only supports a maximum of 50 columns -- find out 
            // which of those we need.
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
                            data[i] = findDate(stories, "changed the due date to");
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
        /// <summary>
        /// Currently not used, but finds the sections in a project.
        /// </summary>
        /// <param name="tasks">All of the "tasks" in a particular projects. Sections are stored
        /// as tasks in Asana.</param>
        /// <returns>An array of strings containing the names of each section</returns>
        public static string[] ParseSubProjects(ArrayList tasks)
        {
            ArrayList subprojects = new ArrayList();
            foreach (var o in tasks)
            {
                AsanaTask task = o as AsanaTask;
                if (task.Name.EndsWith(":"))
                {
                    subprojects.Add(task.Name);
                }
            }
            return (string[])subprojects.ToArray(typeof(string));
        }
        /// <summary>
        /// Gets the most recent Date within the stories for a specific piece of data.
        /// </summary>
        /// <param name="stories">The list of stories to parse for a given task</param>
        /// <param name="s">A string related to the type of date to be retrieved</param>
        /// <returns></returns>
        private static string findDate(ArrayList stories, string s)
        {
            /// Code for finding the earliest would look like:
            /// foreach (AsanaStory story in stories)
            /// {
            ///     if(story.Text.Contains(s))
            ///         return LastStory.CreatedAt.ToString();
            /// }
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
        /// <summary>
        /// Searches a Task for everything it has been tagged with.
        /// </summary>
        /// <param name="stories">The list of stories to parse</param>
        /// <param name="tags">The tags in the current workspace</param>
        /// <returns>All of the tags associated with a task</returns>
        private static string findTags(ArrayList stories, string[] tags)
        {
            string data = "";
            foreach (AsanaStory story in stories)
            {
                foreach (string tag in tags)
                {
                    string t = "added to " + tag;
                    // handle cases such as the tag is just "BI" 
                    // but there is a story with "Added to BI: Sprint Plan"
                    // in which case it is a false alarm.
                    if (story.Text.Contains(t) && story.Text.Length == story.Text.IndexOf(t) + t.Length)
                    {
                        data += tag + ", ";
                        break;
                    }
                }
            }
            if (data != "")
                return data.Remove(data.Length - 2); // remove trailing ", "
            else return null;
        }
        /// <summary>
        /// Search a task for its most recent assignee
        /// </summary>
        /// <param name="stories">The stories in a task to parse</param>
        /// <returns>The most recent assignee on the task. Note that if the user who entered his/her
        /// API Key is the assignee, the return value will be "me".</returns>
        private static string findAssignee(ArrayList stories)
        {
            string assignee = "";
            foreach (AsanaStory story in stories)
            {
                int index = story.Text.LastIndexOf("assigned to ");
                if (index != -1)
                    assignee = story.Text.Substring(index + 12).Replace(".", "");
            }
            if (assignee != "")
                return assignee;
            else return null;
        }

    }

}
