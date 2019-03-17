using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFNgApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace EFNgApp.Controllers
{

    public class InvestmentController : Controller
    {
        InvestmentDataAccessLayer objInvestment = new InvestmentDataAccessLayer();

        /// <summary>
        /// Get project details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Investment/Index")]
        public IEnumerable<ProjectModel> Get()
        {
            string investedProject = string.Empty;
            IEnumerable<ProjectModel> lstProjectDetails = null;
            if (TempData["investedProject"] != null)
            {
                investedProject = (string)TempData["investedProject"];
                TempData["investedProject"] = investedProject;
                lstProjectDetails = objInvestment.GetProjectDataMock(investedProject);
            }
            else
            {
                lstProjectDetails = objInvestment.GetProjectDetails();
            }
            return lstProjectDetails;
        }

        /// <summary>
        /// Get Project by sending projectid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Project/Details/{id}")]
        public ProjectModel Details(int id)
        {
            return objInvestment.GetProjectData(id);
        }

        /// <summary>
        /// Update investment
        /// </summary>
        /// <param name="investment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Investment/Add")]
        public int AddInvestment([FromBody] InvestmentModel investment)
        {
            string investedProject = string.Empty;
            if (TempData["investedProject"] != null)
            {
                investedProject = (string)TempData["investedProject"];
            }
            investment.projectId = investment.id;
            investedProject = investedProject + "," + investment.projectId.ToString();
            TempData["investedProject"] = investedProject;
            IEnumerable<ProjectModel> lstProjectDetails = objInvestment.GetProjectDetails();
            lstProjectDetails.Where(x => x.Id == investment.projectId).FirstOrDefault().Status = 2;
            return objInvestment.AddInvestment(investment);
        }


    }
}
