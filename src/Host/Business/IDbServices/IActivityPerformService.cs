﻿using Host.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Business.IDbServices
{
    public interface IActivityPerformService
    {
        Task<int> ActivityPerform(ActivityPerformDto requestDto);
        Task<List<GroupActivityReports>> ActivityFilterReport();
        Task<List<GroupActivityReports>> ActivityFilterReporByBranchIdt(int branchId, int locationId);
        List<GraphActivityPerform> StationReport();
        Task<List<ReportDto>> ActivityReport(int? locationId, DateTime? createdOn, int? branchId);
    }
}
