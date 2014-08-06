using System.Collections;

namespace AsanaCrescent
{
    /// <summary>
    /// A simple way to represent the projects in Asana as a worksheet
    /// in Microsoft Excel.
    /// </summary>
    class ProjectInExcel
    {
        public string Name { get; set; }
        private ArrayList columns;

        public ArrayList Columns
        {
            get
            {
                return columns;
            }
        }

        public ProjectInExcel()
        {
            columns = new ArrayList();
            columns.Add("Task");
            columns.Add("Project");
            columns.Add("Added To Project");
            columns.Add("Due");
            columns.Add("Completed");
            columns.Add("Assignee");
            columns.Add("Tags");
        }


    }

}
