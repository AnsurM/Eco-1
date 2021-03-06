﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Host.DataModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Host.Business.IDbServices
{
    public interface IStationLocationService
    {
        int AddStationLocation(StationLocationDto requestDto);
        Task<int> UpdateStationLocation(StationLocationDto requestDto);
        List<StationLocationDto> GetStationLocationByLocationId(int locationId);
        StationLocationDto GetStationLocationById(int id);
        string GetStationNameById(int id);
        string LastCodeStationLocation();
        Task<ActivityPerformDto> GetStationActivityByCode(string code);
        List<BranchStationLocationDto> GetStationLocationByBranchId(int branchId);
        void DeleteStationLocation(int id);
        bool CheckSnoExist(int sno, int branchId);
        Task<int> BranchStationLocation(StationLocationDto requestDto);
        Task<List<StationLocationDropDownDto>> GetLocationByBranchIdAsync(int branchId);

    }
}
