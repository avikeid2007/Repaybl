using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RepayblApi.Models;

namespace RepayblApi.DTOs
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
