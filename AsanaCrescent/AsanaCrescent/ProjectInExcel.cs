using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace AsanaCrescent
{

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
