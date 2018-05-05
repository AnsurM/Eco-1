﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Host.Business.IDbServices;
using Host.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Host.Controllers
{
    [Authorize]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly IStationService _stationService;
        private readonly IActivityService _activityService;


        public CompanyController(ICompanyService companyService,
                                 IStationService stationService,
                                 IActivityService activityService)
        {
            _companyService = companyService;
            _stationService = stationService;
            _activityService = activityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCompany(CompanyDto requestDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return null;
        //        await _companyService.AddCompany(requestDto);
        //        return RedirectToAction("index", "Home");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        public ActionResult CompanyWizard()
        {
            return View("CompanyWizard");
        }

        public ActionResult ViewCompany()
        {
            var companies = _companyService.GetCompanyList();
            return View("CompanyView", companies);
        }

        public ActionResult Station()
        {
            var stations = _stationService.GetAllStation();
            return View("Station", stations);
        }

        [HttpPost("Company/AddStation")]
        public async Task<IActionResult> AddStation([FromBody]StationDto requestDto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Station");
            var station = await _stationService.AddStation(requestDto);
            return RedirectToAction("Station");
        }

        public async Task<IActionResult> DeleteStation(int id)
        {
            await _stationService.DeleteStation(id);
            return RedirectToAction("Station");
        }

        [HttpGet("Company/GetStationById/id/{id}")]
        public IActionResult GetStationById([FromRoute]int id)
        {
            var station = _stationService.GetStationById(id);
            return Json(station);
        }

        [HttpPost("Company/AddActivity")]
        public async Task<IActionResult> AddActivity([FromBody] StationActivityDto requestDto)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Station");

            await _activityService.AddActivity(requestDto);
            return RedirectToAction("Station");
        }

        [HttpGet("Company/GetActivityByStationId/id/{id}")]
        public IActionResult GetActivityByStationId([FromRoute] int id)
        {
            try
            {
                var activities = _activityService.GetActivityByStationId(id);
                return Json(activities);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IActionResult AllCompanyView()
        {
            return View("AllCompanyView");
        }


        [HttpPost]
        public  IActionResult AddCompany(CompanyDto requestDto)
        {
            try
            {
                var userId = GetUserid().ToString();
                requestDto.UserId = userId;
                if (!ModelState.IsValid)
                    return RedirectToAction("CompanyCreation");
                if(requestDto.CompanyId.HasValue && requestDto.CompanyId != 0)
                {
                    _companyService.UpdateCompany(requestDto);
                    return RedirectToAction("CompanyCreation");
                }
                var company = _companyService.AddCompany(requestDto);
                return RedirectToAction("CompanyCreation");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

       [HttpGet]
       public IActionResult GetCompanyById(int id)
        {
            try
            {
                var companies = _companyService.GetCompanyById(id);
                return View("AddCompany", companies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IActionResult> CompanyCreation()
        {
            var allCompany =await _companyService.GetAllCompany();
            if(allCompany == null)
            {
                var model = new CompanyDto();
                return View("CompanyCreation", model);
            }

            return View("CompanyCreation",allCompany);
        }
        public IActionResult AddCompany()
        {
            return View("AddCompany");
        }
        public IActionResult Branch()
        {
            return View("BranchCreation");
        }
        public async Task<IActionResult> AddBranch()
        {
            var companiesList =await _companyService.GetAllCompany();
            var brancModel = new BranchDto
            {
                Companies = new SelectList(companiesList,"CompanyId", "Name")
            };

            return View("AddBranch",brancModel);
        }
        public IActionResult BranchEmployee()
        {
            return View("BranchEmployee");
        }
        public IActionResult AddBranchEmployee()
        {
            return View("AddBranchEmployee");
        }

    }
}