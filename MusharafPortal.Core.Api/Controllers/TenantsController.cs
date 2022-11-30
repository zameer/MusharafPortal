using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Musharaf.Portal.Core.Api.Models.Tenants;
using Musharaf.Portal.Core.Api.Models.Tenants.Exceptions;
using Musharaf.Portal.Core.Api.Services.Foundations.Tenants;
using RESTFulLinq;
using RESTFulLinq.Models;
using RESTFulSense.Controllers;

namespace Musharaf.Portal.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : RESTFulController
    {
        private readonly ITenantService tenantService;

        public TenantsController(ITenantService tenantService)
        {
            this.tenantService = tenantService;
        }

        [HttpGet("linQuery")]
        public async ValueTask<ActionResult<IQueryable<Tenant>>> GetAllTenantAsync(string linQuery)
        {
            try
            {
                IQueryable<Tenant> allTenants = this.tenantService.RetrieveAllTenants();

                var results = await RESTFulLinqService.RunQueryAsync(
                    linQuery,
                    new Gloabals<Tenant> { DataSource = allTenants });

                return Ok(results);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return Problem(tenantDependencyException.Message);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return Problem(tenantServiceException.Message);
            }
        }

        [HttpPost]
        public async ValueTask<ActionResult<Tenant>> PostTenantAsync(Tenant tenant)
        {
            try
            {
                Tenant createdTenant =
                    await this.tenantService.CreateTenantAsync(tenant);

                return Created(createdTenant);
            }
            catch (TenantValidationException tenantValidationException)
                when (tenantValidationException.InnerException is AlreadyExistsTenantException)
            {
                return Conflict(tenantValidationException.InnerException);
            }
            catch (TenantValidationException tenantValidationException)
            {
                return BadRequest(tenantValidationException.InnerException);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return InternalServerError(tenantDependencyException);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return InternalServerError(tenantServiceException);
            }
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Tenant>> GetAllTenants()
        {
            try
            {
                IQueryable<Tenant> storageTenants =
                    this.tenantService.RetrieveAllTenants();

                return Ok(storageTenants);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return Problem(tenantDependencyException.Message);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return Problem(tenantServiceException.Message);
            }
        }

        [HttpGet("{tenantId}")]
        public async ValueTask<ActionResult<Tenant>> GetTenantAsync(Guid tenantId)
        {
            try
            {
                Tenant storageTenant =
                    await this.tenantService.RetreiveTenantByIdAsync(tenantId);

                return Ok(storageTenant);
            }
            catch (TenantValidationException tenantValidationException)
                when (tenantValidationException.InnerException is NotFoundTenantException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return NotFound(innerMessage);
            }
            catch (TenantValidationException tenantValidationException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return BadRequest(tenantValidationException);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return Problem(tenantDependencyException.Message);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return Problem(tenantServiceException.Message);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<Tenant>> PutTenantAsync(Tenant tenant)
        {
            try
            {
                Tenant registeredTenant =
                    await this.tenantService.ModifyTenantAsync(tenant);

                return Ok(registeredTenant);
            }
            catch (TenantValidationException tenantValidationException)
                when (tenantValidationException.InnerException is NotFoundTenantException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return NotFound(innerMessage);
            }
            catch (TenantValidationException tenantValidationException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return BadRequest(innerMessage);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return Problem(tenantDependencyException.Message);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return Problem(tenantServiceException.Message);
            }
        }

        [HttpDelete("{tenantId}")]
        public async ValueTask<ActionResult<Tenant>> DeleteTenantAsync(Guid tenantId)
        {
            try
            {
                Tenant storageTenant =
                    await this.tenantService.RemoveTenantByIdAsync(tenantId);

                return Ok(storageTenant);
            }
            catch (TenantValidationException tenantValidationException)
                when (tenantValidationException.InnerException is NotFoundTenantException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return NotFound(innerMessage);
            }
            catch (TenantValidationException tenantValidationException)
            {
                string innerMessage = GetInnerMessage(tenantValidationException);

                return BadRequest(tenantValidationException);
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                return Problem(tenantDependencyException.Message);
            }
            catch (TenantServiceException tenantServiceException)
            {
                return Problem(tenantServiceException.Message);
            }
        }

        private static string GetInnerMessage(Exception exception) =>
            exception.InnerException.Message;

        public class Gloabals<T> : IGlobals<T>
        {
            public IEnumerable<T> DataSource { get; set; }
        }
    }
}
