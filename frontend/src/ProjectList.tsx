import { useEffect, useState } from "react";
import { Project } from "./Project";


function ProjectList()
{
    const [projects, setProjects] = useState<Project[]>([]);

    // useEffect only grabs the data when it is needed instead of constantly going back and grabbing it 
    useEffect(() => {
        const fetchProjects = async () => {
            // this is where it is getting the data from
            const response =await fetch('http://localhost:4000/api/Water/AllProjects');
            //this variable holds the data
            const data = await response.json();
            //sets the project with the updated data
            setProjects(data);
        };

    fetchProjects();
}, []);
    return(
        <>
            <h1>Water Projects</h1>
            <br />
            {projects.map((p) => (
                <div id="projectCard">
                    <h3>{p.projectName}</h3>

                    <ul>
                        <li>Project Type: {p.projectType}</li>
                        <li>Regional Program: {p.projectRegionalProgram}</li>
                        <li>Impact: {p.projectImpact} Indivduals Served</li>
                        <li>Project Phase: {p.projectPhase}</li>
                        <li>Project Status: {p.projectFunctionalityStatus}</li>
                    </ul>
                    
                </div>
    ))}
        </>
    );
}

export default ProjectList;