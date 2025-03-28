using Microsoft.AspNetCore.Mvc;
using WaterProject.API.Models;

namespace WaterProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
			    
    public class WaterController : ControllerBase
    {
	    private WaterDbContext _waterContext;
	    
	    public WaterController(WaterDbContext temp)
	    {
		    _waterContext = temp;
	    }
	    [HttpGet("AllProjects")]
	    public IActionResult GetProjects(int pageHowMany = 5, int pageNum = 1, [FromQuery] List<string>? projectTypes = null)
	    {
		    var query = _waterContext.Projects.AsQueryable();
		    //checks if any are in there
		    if (projectTypes != null && projectTypes.Any())
		    {
			    query = query.Where(p => projectTypes.Contains(p.ProjectType));
		    }

		    var totalNumProjects = _waterContext.Projects.Count();
		    
		    var something = query
			    .Skip((pageNum-1) * pageHowMany)
			    .Take(pageHowMany).ToList();
		    

		    var someObject = new
		    {
			    Projects = something,
			    TotalNumProjects = totalNumProjects
		    };
		    return Ok(someObject);
	    }
		[HttpGet("GetProjectsTypes")]
	    public IActionResult GetProjectTypes()
	    {
		    var projectTypes = _waterContext.Projects
			    .Select(p => p.ProjectType)
			    .Distinct()
			    .ToList();
		    return Ok(projectTypes);
	    }

	    [HttpGet("FunctionalProjects")]
	    public IEnumerable<Project> GetFunctionalProjects()
	    {
		    var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();
		    return something;
	    }
    }
    
}
