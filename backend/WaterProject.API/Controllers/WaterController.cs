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
	    public IActionResult GetProjects(int pageHowMany = 5, int pageNum = 1)
	    {
		    var something = _waterContext.Projects
			    .Skip((pageNum-1) * pageHowMany)
			    .Take(pageHowMany).ToList();
		    var totalNumProjects = _waterContext.Projects.Count();

		    var someObject = new
		    {
			    Projects = something,
			    TotalNumProjects = totalNumProjects
		    };
		    return Ok(someObject);
	    }

	    [HttpGet("FunctionalProjects")]
	    public IEnumerable<Project> GetFunctionalProjects()
	    {
		    var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();
		    return something;
	    }
    }
    
}
