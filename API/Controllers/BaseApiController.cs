using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatedPagedResult<T>(IGenericRepository<T> repository, ISpecification<T> specification, int pageIndex, int pageSize) where T : BaseEntity
        {
            var items = await repository.ListAsync(specification);
            var count = await repository.CountAsync(specification);

            var pagination = new Pagination<T>(pageIndex, pageSize, count, items);

            return Ok(pagination);
        }
    }
}