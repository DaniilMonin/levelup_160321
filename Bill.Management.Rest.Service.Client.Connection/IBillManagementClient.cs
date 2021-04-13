﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;
using Refit;

namespace Bill.Management.Rest.Service.Client.Connection
{
    public interface IBillManagementClient
    {
        [Get("/v1/users/")]
        Task<OperationResult<IReadOnlyList<User>>> GetClients();
    }
}