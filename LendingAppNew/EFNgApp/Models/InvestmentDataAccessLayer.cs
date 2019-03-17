using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFNgApp.Models
{
    public class InvestmentDataAccessLayer
    {       

        /// <summary>
        ///Get project details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectModel> GetProjectDetails()
        {
            List<ProjectModel> lstProject = new List<ProjectModel>();
            ProjectModel objProjectModel1 = new ProjectModel();
            objProjectModel1.Id = 1;
            objProjectModel1.Name = "Project 1";
            objProjectModel1.Location = "Berlin";
            objProjectModel1.Price = 20000;
            objProjectModel1.Status = 1;
            lstProject.Add(objProjectModel1);
            ProjectModel objProjectModel2 = new ProjectModel();
            objProjectModel2.Id = 2;
            objProjectModel2.Name = "Project 2";
            objProjectModel2.Location = "Munich";
            objProjectModel2.Price = 25000;
            objProjectModel2.Status = 2;
            lstProject.Add(objProjectModel2);
            ProjectModel objProjectModel3 = new ProjectModel();
            objProjectModel3.Id = 3;
            objProjectModel3.Name = "Project 3";
            objProjectModel3.Location = "Frankfurt";
            objProjectModel3.Price = 30000;
            objProjectModel3.Status = 1;
            lstProject.Add(objProjectModel3);
            ProjectModel objProjectModel4 = new ProjectModel();
            objProjectModel4.Id = 4;
            objProjectModel4.Name = "Project 4";
            objProjectModel4.Location = "Dortmund";
            objProjectModel4.Price = 20000;
            objProjectModel4.Status = 1;
            lstProject.Add(objProjectModel4);
            ProjectModel objProjectModel5 = new ProjectModel();
            objProjectModel5.Id = 5;
            objProjectModel5.Name = "Project 5";
            objProjectModel5.Location = "Cologne";
            objProjectModel5.Price = 25000;
            objProjectModel5.Status = 1;
            lstProject.Add(objProjectModel5);
            return lstProject;
        }

        /// <summary>
        ///Get the details of a particular project 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProjectModel GetProjectData(int id)
        {            
            IEnumerable<ProjectModel> lstProject = GetProjectDetails();
            ProjectModel project = lstProject.Where(x => x.Id == id).FirstOrDefault();
            return project;
        }

        /// <summary>
        ///Get the mock data of a projects 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ProjectModel> GetProjectDataMock(string investedProject)
        {
            string[] ids = investedProject.Remove(0, 1).Split(',');
            IEnumerable<ProjectModel> lstProject = GetProjectDetails();
            foreach (string id in ids)
            {
                foreach (ProjectModel project in lstProject)
                {
                    if (project.Id.ToString() == id)
                    {
                        project.Status = 2;
                    }
                }
            }
            return lstProject;
        }

        /// <summary>
        //To Add new investment record   
        /// </summary>
        /// <param name="investment"></param>
        /// <returns></returns>
        public int AddInvestment(InvestmentModel investment)
        {
            try
            {
                return 1;
            }
            catch
            {
                throw;
            }
        }
        
    }
}
